using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AllInOne.BootStrapper.BackEnd;

namespace PHCForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.Application_Start();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.Run(new Login());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Global.Application_End();
        }
    }
}
