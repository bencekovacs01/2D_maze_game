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
using System.Diagnostics;
using WMPLib;


namespace szakvizsga_uj
{     
    public partial class mainWindow : Form
    {
        public int hang = 50;
        public decimal kepszam = 0;
        //int sorszam = 0;
        public string kepkiv=" karakter";
        //public decimal nehez = 0;
        public bool isbe = true;
        public bool kebe = false;
        public string[] zenek = new string[5];
        public WindowsMediaPlayer player = new WindowsMediaPlayer();
      
        public string z1= "Bad Boys.mp3";
        public string z2;
        

        public Form4 f4;
        public Form2 f2;

        public mainWindow()
        {
            InitializeComponent();
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }      
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            //this.Hide();
            f4.ShowDialog();
        }
       
        private void ismet()
        {
            player.settings.setMode("loop", true);
            player.URL = z1;
            player.controls.play();
        }
      

        public int rand()
        {
            Random rnd = new Random();
            int  szam = rnd.Next(0, 5);
            return szam;
        }
        
        public void keveres()
        {
                axWindowsMediaPlayer1.URL = zenek[rand()];
                axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        private void button4_Click(object sender, EventArgs e)
        {
               this.Close();
        }
        public void lejat()
        {
           
            if (isbe)
            {
               ismet();
            }
            else
             {
                if (kebe)
                {
                   player.settings.setMode("loop", false);
                    keveres();
                }
                else
                {
                    player.settings.setMode("loop", false);
                    player.URL = z1;
                    player.controls.play();
                }  
            }
        }

        private void form1_Load(object sender, EventArgs e)
        {
            player.settings.volume = hang;
            axWindowsMediaPlayer1.settings.volume = hang;
           
            zenek[0] = "Voltaj Om.mp3";
            zenek[1] = "Gianluca Vacchii  Sigamos Bailando.mp3";
            zenek[2] = "Gianluca Vacchi - Trump-It.mp3";
            zenek[3] = "Amscat-Kamasutra Do brasil.mp3";
            zenek[4] = "Bad boys.mp3";
            
           
            //lejat();
            this.FormBorderStyle = FormBorderStyle.None;
            
            label1.Left = this.Width/2-label1.Width/2;
            button1.Left = this.Width / 2 - button1.Width / 2;
          
            button3.Left = this.Width / 2 - button3.Width / 2;
            button5.Left = this.Width / 2 - button5.Width / 2;
            button1.Top = this.Height - 340;
            button3.Top = this.Height - 240;
            button5.Top = this.Height - 140;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dir = @"..\..\..\szerkeszto\bin\Debug\szerkeszto";
            Process.Start( dir);
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)

        {
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsMediaEnded && kebe == true)
            {
               
                keveres();
            }
        }
    }
}
