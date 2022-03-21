using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Media;

namespace szerkeszto
{

    static class Program
    {
        public enum MouseButtonState { }
        public static MouseButtonState LeftButton { get; }
        public static Form2 f2;
        public static LoadingScreen ls;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f2 = new Form2();
            Application.Run(f2);
        }
    }
}
