using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace szakvizsga_uj
{
    static class Program
    {
        public static mainWindow mainWindow;
        public static decimal nehezseg = 6;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new mainWindow();
            Application.Run(mainWindow);
        }
    }
}
