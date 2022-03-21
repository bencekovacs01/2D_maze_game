using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szerkeszto
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            /*this.Width = Program.f2.Width;
            this.Height = Program.f2.Height;*/
            /*label1.Left = this.Width / 2;
            label1.Top = this.Height / 2;
            label1 = new Label();
            label1.Show();*/
            this.WindowState = FormWindowState.Maximized;
            //this.Focus();
            //this.Show();
        }
    }
}
