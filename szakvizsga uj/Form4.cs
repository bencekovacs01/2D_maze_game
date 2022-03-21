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
       /* private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Program.mainWindow.player.settings.volume = trackBar1.Value;
            Program.mainWindow.axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }*/

        private void Form4_Load(object sender, EventArgs e)
        {
            //trackBar1.Value=Program.mainWindow.hang;
            //Program.mainWindow.Hide();
            //numericUpDown2.Value = 10-Program.mainWindow.nehez;
            numericUpDown1.Value = Program.mainWindow.kepszam;

            if (Program.mainWindow.isbe) { checkBox1.CheckState = CheckState.Checked; }
            if (Program.mainWindow.kebe) { checkBox2.CheckState = CheckState.Checked; }
            
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.nehezseg = 10 - numericUpDown2.Value;
            Program.mainWindow.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*Program.mainWindow.hang = trackBar1.Value;
            if (listBox1.SelectedIndex != -1)
            {
                Program.mainWindow.z1 = listBox1.SelectedItem.ToString() + ".mp3";
            }

            Program.mainWindow.nehez =10- numericUpDown2.Value;
           
            if (Program.mainWindow.kebe)
            {
                Program.mainWindow.player.controls.stop();
            }
            Program.mainWindow.lejat();*/

            Program.mainWindow.kepszam = numericUpDown1.Value;
            this.Close();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { Program.mainWindow.kebe = true; } else { Program.mainWindow.kebe = false; }
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { Program.mainWindow.isbe = true; } else { Program.mainWindow.isbe = false; }
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
            }
        }
    }
}