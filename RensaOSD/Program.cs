﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RensaOSD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            global::System.Windows.Forms.Application.EnableVisualStyles();
            global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            global::System.Windows.Forms.Application.Run(new RensaOSD(arg));
        }
    }
}
