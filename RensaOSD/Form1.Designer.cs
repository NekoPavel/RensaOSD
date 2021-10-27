
namespace RensaOSD
{
    partial class RensaOSD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new SmoothProgressBar.SmoothProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.runButton = new System.Windows.Forms.Button();
            this.inputTextbox = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.showMoreCheckbox = new System.Windows.Forms.CheckBox();
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.deployNewCheckBox = new System.Windows.Forms.CheckBox();
            this.forcedCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBar.ForeColor = System.Drawing.Color.Fuchsia;
            this.progressBar.Location = new System.Drawing.Point(12, 49);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressBarColor = System.Drawing.Color.Blue;
            this.progressBar.Size = new System.Drawing.Size(767, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.UseWaitCursor = true;
            this.progressBar.Value = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel Sheet|*.xlsx";
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(926, 12);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(82, 31);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "Starta";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // inputTextbox
            // 
            this.inputTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.inputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.inputTextbox.Location = new System.Drawing.Point(12, 12);
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.Size = new System.Drawing.Size(728, 31);
            this.inputTextbox.TabIndex = 1;
            this.inputTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTextbox_KeyPress);
            // 
            // openFileButton
            // 
            this.openFileButton.BackgroundImage = global::RensaOSD.Properties.Resources.icon;
            this.openFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFileButton.FlatAppearance.BorderSize = 0;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileButton.Location = new System.Drawing.Point(746, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(33, 33);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // showMoreCheckbox
            // 
            this.showMoreCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showMoreCheckbox.AutoSize = true;
            this.showMoreCheckbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.showMoreCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showMoreCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showMoreCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMoreCheckbox.Location = new System.Drawing.Point(926, 49);
            this.showMoreCheckbox.Name = "showMoreCheckbox";
            this.showMoreCheckbox.Size = new System.Drawing.Size(82, 23);
            this.showMoreCheckbox.TabIndex = 4;
            this.showMoreCheckbox.Text = "▼ Visa Mer ▼";
            this.showMoreCheckbox.UseVisualStyleBackColor = false;
            this.showMoreCheckbox.CheckedChanged += new System.EventHandler(this.showMoreCheckbox_CheckedChanged);
            // 
            // outputTextbox
            // 
            this.outputTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.outputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.outputTextbox.Location = new System.Drawing.Point(13, 79);
            this.outputTextbox.Multiline = true;
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.ReadOnly = true;
            this.outputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextbox.Size = new System.Drawing.Size(993, 220);
            this.outputTextbox.TabIndex = 5;
            this.outputTextbox.Visible = false;
            // 
            // deployNewCheckBox
            // 
            this.deployNewCheckBox.AutoSize = true;
            this.deployNewCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deployNewCheckBox.Location = new System.Drawing.Point(784, 18);
            this.deployNewCheckBox.Name = "deployNewCheckBox";
            this.deployNewCheckBox.Size = new System.Drawing.Size(132, 22);
            this.deployNewCheckBox.TabIndex = 6;
            this.deployNewCheckBox.Text = "Skjut ut ny OSD";
            this.deployNewCheckBox.UseVisualStyleBackColor = true;
            this.deployNewCheckBox.CheckedChanged += new System.EventHandler(this.deployNewCheckBox_CheckedChanged);
            // 
            // forcedCheckBox
            // 
            this.forcedCheckBox.AutoSize = true;
            this.forcedCheckBox.Enabled = false;
            this.forcedCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forcedCheckBox.Location = new System.Drawing.Point(784, 49);
            this.forcedCheckBox.Name = "forcedCheckBox";
            this.forcedCheckBox.Size = new System.Drawing.Size(142, 22);
            this.forcedCheckBox.TabIndex = 7;
            this.forcedCheckBox.Text = "Skjut ut tvingande";
            this.forcedCheckBox.UseVisualStyleBackColor = true;
            // 
            // RensaOSD
            // 
            this.AcceptButton = this.runButton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1018, 91);
            this.Controls.Add(this.forcedCheckBox);
            this.Controls.Add(this.deployNewCheckBox);
            this.Controls.Add(this.outputTextbox);
            this.Controls.Add(this.showMoreCheckbox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.progressBar);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RensaOSD";
            this.ShowIcon = false;
            this.Text = "RensaOSD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox inputTextbox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.CheckBox showMoreCheckbox;
        private System.Windows.Forms.TextBox outputTextbox;
        private System.Windows.Forms.CheckBox deployNewCheckBox;
        private System.Windows.Forms.CheckBox forcedCheckBox;
        private SmoothProgressBar.SmoothProgressBar progressBar;
    }
}

