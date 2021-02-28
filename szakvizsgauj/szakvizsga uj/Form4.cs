using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace szakvizsga_uj
{
    
    public partial class Form4 : Form
    {
        

        public Form4()
        {
            InitializeComponent();
           
          
        }
    
       
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
                Program.f1.player.settings.volume = trackBar1.Value;
                Program.f1.axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        
       
        

        private void Form4_Load(object sender, EventArgs e)
        {
            trackBar1.Value=Program.f1.hang;
            numericUpDown2.Value = 10-Program.f1.nehez;
            numericUpDown1.Value = Program.f1.kepszam;

            if (Program.f1.isbe) { checkBox1.CheckState = CheckState.Checked; }
            if (Program.f1.kebe) { checkBox2.CheckState = CheckState.Checked; }
            Program.f1.Hide();
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.f1.hang = trackBar1.Value;
            if (listBox1.SelectedIndex!=-1)
            {
                Program.f1.z1 = listBox1.SelectedItem.ToString() + ".mp3";
            }
           
            Program.f1.nehez =10- numericUpDown2.Value;
           
            if (Program.f1.kebe)
            {
                Program.f1.player.controls.stop();
            }
            Program.f1.lejat();

            Program.f1.kepszam = numericUpDown1.Value;
            

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { Program.f1.kebe = true; } else { Program.f1.kebe = false; }
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { Program.f1.isbe = true; } else { Program.f1.isbe = false; }
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
            }
        }

       
    }
}