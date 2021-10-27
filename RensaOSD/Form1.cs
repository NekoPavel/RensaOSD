using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using ExcelDataReader;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace RensaOSD
{
    public partial class RensaOSD : Form
    {
        public RensaOSD(string[] arg)
        {
            InitializeComponent();
            InitializeTheme();
            if (arg.Count() > 0 && arg[0] == "ValmenyBoot")
            {
                using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
                {
                    if (rk.OpenSubKey("NekoPavel", true) != null)
                    {
                        openFileDialog.InitialDirectory = rk.OpenSubKey("NekoPavel", true).GetValue("SavePath").ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Programmet startades inte via valmenyn!" + Environment.NewLine + @"Använd valmenyn som finns under \\dfs\gem$\Lit\IT-Service\Fabriken Solna\Pavels Program", "Fel!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
                {
                    if (rk.OpenSubKey("NekoPavel", true) != null)
                    {
                        openFileDialog.InitialDirectory = rk.OpenSubKey("NekoPavel", true).GetValue("SavePath").ToString();
                    }
                    else
                    {
                        if (!WindowsIdentity.GetCurrent().Name.StartsWith("GAIA\\gaisys"))
                        {
                            MessageBox.Show("Programmet kördes inte som gaisys!" + Environment.NewLine + "Startar om", "Fel!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.WorkingDirectory = Environment.CurrentDirectory;
                            proc.FileName = "runas.exe";
                            proc.Arguments = $"/user:gaia\\gaisys{WindowsIdentity.GetCurrent().Name.Substring(5)} \"{Assembly.GetEntryAssembly().Location}\"";
                            Process.Start(proc);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        private void InitializeTheme()
        {
            if (ThemeExists())
            {
                SetColours(OpenTheme(GetSelectedTheme()));
            }
        }

        private string GetSelectedTheme()
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                return rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName").ToString();
            }
        }

        private Color[] OpenTheme(string themeName)
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                Color[] colours = {
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("BackColour")),
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("ForeColour")),
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("TextColour"))
                };
                return colours;
            }
        }

        private bool ThemeExists()
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                return (rk.OpenSubKey("NekoPavel", true) != null && rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName") != null && rk.OpenSubKey("NekoPavel", true).OpenSubKey(rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName").ToString()) != null);
            }
        }

        private void SetColours(Color[] colours)
        {
            foreach (var control in Controls)
            {
                ((Control)control).BackColor = colours[1];
                ((Control)control).ForeColor = colours[2];
            }
            foreach (var control in Controls.OfType<CheckBox>())
            {
                ((Control)control).BackColor = colours[0];
                ((Control)control).ForeColor = colours[2];
            }
            BackColor = colours[0];
            ForeColor = colours[2];
            openFileButton.BackColor = BackColor;
        }
        static Regex pcRx = new Regex(@"\A[A-z]{5}\d{8}");
        public bool fileSelected = true;
        private string osdUri = "http://sysman.sll.se/SysMan/api/v2/tool/ea45dcb0-f63a-4cbc-b824-cd7e39618f8b/run";
        private string pxeUri = "http://sysman.sll.se/SysMan/api/v2/tool/8bf7dd4d-bc5d-4509-9cfe-5f6f84523388/run";
        private string deployUri = "http://sysman.sll.se/SysMan/api/Client/deployment";
        public ConcurrentQueue<ToolResponse> outQueue = new ConcurrentQueue<ToolResponse>();
        public Color green = Color.FromArgb(255, 87, 154, 64);
        public Color red = Color.FromArgb(255, 172, 36, 32);
        public Color blue = Color.FromArgb(255, 43, 112, 170);
        public Color yellow = Color.FromArgb(255, 178, 108, 9);
        private void openFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                inputTextbox.Text = openFileDialog.FileName;
                fileSelected = true;
            }
        }
        private void showMoreCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (showMoreCheckbox.Checked)
            {
                this.Height = 350;
                outputTextbox.Visible = true;
                showMoreCheckbox.Text = "▲ Visa Mer ▲";
            }
            else
            {
                this.Height = 130;
                outputTextbox.Visible = false;
                showMoreCheckbox.Text = "▼ Visa Mer ▼";
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            UseWaitCursor = true;
            deployNewCheckBox.Enabled = false;
            forcedCheckBox.Enabled = false;
            progressBar.Value = 0;
            progressBar.ProgressBarColor = blue;
            showMoreCheckbox.UseWaitCursor = false;
            try
            {
                if (fileSelected)
                {
                    DataSet result;
                    using (FileStream stream = File.Open(inputTextbox.Text, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            result = reader.AsDataSet();
                        }
                    }
                    if (deployNewCheckBox.Checked)
                    {
                        progressBar.Maximum = result.Tables[0].Rows.Count * 3;
                    }
                    else
                    {
                        progressBar.Maximum = result.Tables[0].Rows.Count * 2;
                    }
                    WriteToTextbox($"Tar bort OSD och PXE på {result.Tables[0].Rows.Count} datorer.");

                    Task osdTask = new Task(() => ClearOSDTask(result.Tables[0]));
                    osdTask.Start();
                    Task pxeTask = new Task(() => ClearPXETask(result.Tables[0]));
                    pxeTask.Start();
                    Task queueTask = new Task(() =>
                    {
                        try
                        {
                            while (!osdTask.IsCompleted || !pxeTask.IsCompleted || outQueue.Count > 0)
                            {
                                if (outQueue.Count > 0)
                                {
                                    ToolResponse tempResponse = new ToolResponse();
                                    if (outQueue.TryDequeue(out tempResponse))
                                    {
                                        foreach (string output in tempResponse.result)
                                        {
                                            WriteToTextbox(output);
                                        }
                                        this.Invoke(new Action(() =>
                                        {
                                            progressBar.Value += 1;
                                        }));
                                    }
                                }
                            }
                            this.Invoke(new Action(() =>
                            {
                                if (!deployNewCheckBox.Checked)
                                {
                                    UseWaitCursor = false;
                                    runButton.Enabled = true;
                                    deployNewCheckBox.Enabled = true;
                                    forcedCheckBox.Enabled = true;
                                    progressBar.ProgressBarColor = green;
                                }
                                WriteToTextbox($"Tagit bort OSD och PXE på {result.Tables[0].Rows.Count} datorer.");
                            }));

                        }
                        catch (Exception ex)
                        {
                            WriteToTextbox(ex.ToString());
                            progressBar.ProgressBarColor = red;
                        }

                    });
                    queueTask.Start();
                    if (deployNewCheckBox.Checked)
                    {
                        Task deployTask = new Task(() => SendNewOSDTask(result.Tables[0], forcedCheckBox.Checked));
                        Task deployQueueTask = new Task(() =>
                        {
                            queueTask.Wait();
                            deployTask.Start();
                            try
                            {
                                while (outQueue.Count > 0 || !deployTask.IsCompleted)
                                {
                                    if (outQueue.Count > 0)
                                    {

                                        if (outQueue.TryDequeue(out ToolResponse tempResponse))
                                        {
                                            foreach (string output in tempResponse.result)
                                            {
                                                WriteToTextbox(output);
                                            }
                                            this.Invoke(new Action(() =>
                                            {
                                                progressBar.Value += 1;
                                            }));
                                        }
                                    }
                                }
                                this.Invoke(new Action(() =>
                                {
                                    UseWaitCursor = false;
                                    runButton.Enabled = true;
                                    deployNewCheckBox.Enabled = true;
                                    forcedCheckBox.Enabled = true;
                                    WriteToTextbox($"Skjutit ut nya OSD kollektioner på {result.Tables[0].Rows.Count} datorer.");
                                    progressBar.ProgressBarColor = green;
                                }));

                            }
                            catch (Exception ex)
                            {
                                WriteToTextbox(ex.ToString());
                                progressBar.ProgressBarColor = red;
                            }
                        });
                        deployQueueTask.Start();
                    }
                }
                else if (pcRx.IsMatch(inputTextbox.Text))
                {
                    inputTextbox.Text = pcRx.Match(inputTextbox.Text).ToString();
                    if (deployNewCheckBox.Checked)
                    {
                        progressBar.Maximum = 3;
                    }
                    else
                    {
                        progressBar.Maximum = 2;
                    }
                    WriteToTextbox($"Tar bort OSD och PXE på en dator.");

                    Task osdTask = new Task(() =>
                    {
                        RequestBody request = new RequestBody(inputTextbox.Text);
                        outQueue.Enqueue(JsonSerializer.Deserialize<ToolResponse>(NetRequestToString(osdUri, request)));
                    });
                    osdTask.Start();
                    Task pxeTask = new Task(() =>
                    {
                        RequestBody request = new RequestBody(inputTextbox.Text);
                        outQueue.Enqueue(JsonSerializer.Deserialize<ToolResponse>(NetRequestToString(pxeUri, request)));
                    });
                    pxeTask.Start();
                    Task queueTask = new Task(() =>
                    {
                        try
                        {
                            while (!osdTask.IsCompleted || !pxeTask.IsCompleted || outQueue.Count > 0)
                            {
                                if (outQueue.Count > 0)
                                {
                                    ToolResponse tempResponse = new ToolResponse();
                                    if (outQueue.TryDequeue(out tempResponse))
                                    {
                                        foreach (string output in tempResponse.result)
                                        {
                                            WriteToTextbox(output);
                                        }
                                        this.Invoke(new Action(() =>
                                        {
                                            progressBar.Value += 1;
                                        }));
                                    }
                                }
                            }
                            this.Invoke(new Action(() =>
                            {
                                if (!deployNewCheckBox.Checked)
                                {
                                    UseWaitCursor = false;
                                    runButton.Enabled = true;
                                    deployNewCheckBox.Enabled = true;
                                    forcedCheckBox.Enabled = true;
                                    if (progressBar.ProgressBarColor == blue)
                                    {
                                        progressBar.ProgressBarColor = green;
                                    }
                                }
                                WriteToTextbox($"Tagit bort OSD och PXE på 1 dator.");
                            }));

                        }
                        catch (Exception ex)
                        {
                            WriteToTextbox(ex.ToString());
                            progressBar.ProgressBarColor = red;
                        }

                    });
                    queueTask.Start();
                    if (deployNewCheckBox.Checked)
                    {
                        Task deployTask = new Task(() =>
                        {
                            IdLookup idLookup = JsonSerializer.Deserialize<IdLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Client?name=" + inputTextbox.Text + "&take=1&skip=0&type=0&targetActive=1"));
                            PcLookup pcLookup = JsonSerializer.Deserialize<PcLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/client?id=" + idLookup.result[0].id + "&name=" + idLookup.result[0].name + "&assetTag=" + idLookup.result[0].name));
                            InfoLookup infoLookup = JsonSerializer.Deserialize<InfoLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Reporting/Client?clientId=" + idLookup.result[0].id));
                            DeployementBody requestBody = new DeployementBody(idLookup, pcLookup, forcedCheckBox.Checked, infoLookup);
                            if (requestBody.deploymentTemplateToUse == -1)
                            {
                                outQueue.Enqueue(new ToolResponse($"Ohanterad roll på dator {idLookup.result[0].name}"));
                                this.Invoke(new Action(() =>
                                {
                                    progressBar.ProgressBarColor = yellow;
                                }));
                            }
                            else
                            {
                                NetRequestToString(deployUri, requestBody, "PUT");
                                outQueue.Enqueue(requestBody.GetReadableDeployement());
                            }
                        });
                        Task deployQueueTask = new Task(() =>
                        {
                            queueTask.Wait();
                            deployTask.Start();
                            try
                            {
                                while (outQueue.Count > 0 || !deployTask.IsCompleted)
                                {
                                    if (outQueue.TryDequeue(out ToolResponse tempResponse))
                                    {
                                        foreach (string output in tempResponse.result)
                                        {
                                            WriteToTextbox(output);
                                        }
                                        this.Invoke(new Action(() =>
                                        {
                                            progressBar.Value += 1;
                                        }));
                                    }
                                }
                                this.Invoke(new Action(() =>
                                {
                                    UseWaitCursor = false;
                                    runButton.Enabled = true;
                                    deployNewCheckBox.Enabled = true;
                                    forcedCheckBox.Enabled = true;
                                    if (progressBar.ProgressBarColor == blue)
                                    {
                                        progressBar.ProgressBarColor = green;
                                    }
                                    WriteToTextbox($"Skjutit ut nya OSD kollektioner på 1 dator.");
                                }));

                            }
                            catch (Exception ex)
                            {
                                WriteToTextbox(ex.ToString());
                                progressBar.ProgressBarColor = red;
                            }
                        });
                        deployQueueTask.Start();
                    }


                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Filen du försöker köra är öppen i ett annat program. Vänligen stäng filen i alla andra program!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UseWaitCursor = false;
                runButton.Enabled = true;
                deployNewCheckBox.Enabled = true;
                forcedCheckBox.Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Välj en fil eller skriv ett datornamn!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UseWaitCursor = false;
                runButton.Enabled = true;
                deployNewCheckBox.Enabled = true;
                forcedCheckBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UseWaitCursor = false;
                runButton.Enabled = true;
                deployNewCheckBox.Enabled = true;
                forcedCheckBox.Enabled = true;
            }
        }
        public void WriteToTextbox(string input)
        {
            if (input != "")
            {
                this.Invoke(new Action(() =>
                {
                    outputTextbox.AppendText(input + Environment.NewLine);
                }));
            }
        }
        public void ClearOSDTask(DataTable dataTable)
        {
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 10
            };
            Parallel.For(0, dataTable.Rows.Count, options, i =>
            {
                RequestBody request = new RequestBody(dataTable.Rows[i][0].ToString());
                outQueue.Enqueue(JsonSerializer.Deserialize<ToolResponse>(NetRequestToString(osdUri, request)));
            });
        }
        public void ClearPXETask(DataTable dataTable)
        {
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 10
            };
            Parallel.For(0, dataTable.Rows.Count, options, i =>
            {
                RequestBody request = new RequestBody(dataTable.Rows[i][0].ToString());
                outQueue.Enqueue(JsonSerializer.Deserialize<ToolResponse>(NetRequestToString(pxeUri, request)));
            });
        }
        public void SendNewOSDTask(DataTable dataTable, bool installationType)
        {
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 20
            };
            Parallel.For(0, dataTable.Rows.Count, options, i =>
            {
                IdLookup idLookup = JsonSerializer.Deserialize<IdLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Client?name=" + dataTable.Rows[i][0].ToString() + "&take=1&skip=0&type=0&targetActive=1"));
                if (idLookup.result.Count > 0)
                {
                    PcLookup pcLookup = JsonSerializer.Deserialize<PcLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/client?id=" + idLookup.result[0].id + "&name=" + idLookup.result[0].name + "&assetTag=" + idLookup.result[0].name));
                    InfoLookup infoLookup = JsonSerializer.Deserialize<InfoLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Reporting/Client?clientId=" + idLookup.result[0].id));
                    DeployementBody requestBody = new DeployementBody(idLookup, pcLookup, installationType, infoLookup);
                    if (requestBody.deploymentTemplateToUse == -1)
                    {
                        outQueue.Enqueue(new ToolResponse($"Ohanterad roll på dator {dataTable.Rows[i][0]}"));
                    }
                    else
                    {
                        NetRequestToString(deployUri, requestBody, "PUT");
                        outQueue.Enqueue(requestBody.GetReadableDeployement());
                    }
                }
                else
                {
                    outQueue.Enqueue(new ToolResponse($"Dator hittas inte i SysMan {dataTable.Rows[i][0]}"));
                }

            });
        }
        static string NetResponseToString(string uriString)
        {
            Uri uri = new Uri(uriString);
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse webResponse = webRequest.GetResponse();
            Stream receiveStream = webResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode);
            Char[] read = new Char[256];

            int count = readStream.Read(read, 0, 256);
            string output = "";
            while (count > 0)
            {
                String Str = new String(read, 0, count);
                output += Str;
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            webResponse.Close();
            return output;
        }
        static string NetRequestToString<T>(string uriString, T requestBody, string requestMethod = "POST")
        {
            var request = WebRequest.Create(uriString);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = requestMethod;
            string json = JsonSerializer.Serialize(requestBody);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            Stream reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            WebResponse response = request.GetResponse();

            Stream respStream = response.GetResponseStream();

            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(respStream, encode);
            Char[] read = new Char[256];

            int count = readStream.Read(read, 0, 256);
            string output = "";
            while (count > 0)
            {
                String Str = new String(read, 0, count);
                output += Str;
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            respStream.Close();
            reqStream.Close();
            return output;
        }
        private void deployNewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            forcedCheckBox.Enabled = deployNewCheckBox.Checked;
        }
        private void inputTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (fileSelected)
            {
                fileSelected = false;
                inputTextbox.Clear();
            }
        }
    }
}