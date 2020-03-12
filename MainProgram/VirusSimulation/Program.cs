using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusSimulation
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
            Properties.Settings.Default.Page = "home";
            while (Properties.Settings.Default.Page != "exit")
            {
                switch (Properties.Settings.Default.Page)
                {
                    case "home":
                        Application.Run(new MainFormHome());
                        break;
                    case "simul":
                        Application.Run(new MainForm());
                        break;
                    case "credits":
                        Application.Run(new Credits());
                        break;
                }
            }
        }
    }
}
