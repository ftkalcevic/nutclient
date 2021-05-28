using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace nutclient
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool service = false;
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg.ToUpper() == "/SERVICE")
                    service = true;
            }

            if ( service )
            {
                ServiceBase.Run(new NutClientService());
            }
            else
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
