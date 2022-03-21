using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace szakvizsga_uj
{


    public partial class Palya_vege : Form
    {
        public Palya_vege()
        {
            InitializeComponent();
        }

      




        private void Palya_vege_Load(object sender, EventArgs e)
        {

           
            label2.Left = this.Width / 2 - label2.Width / 2;
            label3.Left = this.Width / 2 - label3.Width / 2;
            label1.Text = Convert.ToString(Program.mainWindow.f2.nr_moves);
            panel1.Left = this.Width / 2 - panel1.Width / 2;
            panel1.Top = this.Top - this.Height / 2 + label2.Height + label3.Height + 50;
          
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
            Program.mainWindow.f2.sz++;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
            Program.mainWindow.f2.Close();
            Program.mainWindow.Show();

        }



    }
}