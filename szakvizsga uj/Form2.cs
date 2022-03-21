using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections.Generic;

namespace szakvizsga_uj
{
   public partial class Form2 : Form
    {
        public int sz = 1;
        int n = 14;
        int m = 27;
        string dir = "labirintus";
        public int nr_moves = 0;
        Panel[,] palya;
        int a = 0, b = 0;
        int[,] akadp = new int[14, 27];
        int palyaszam = 0;
        int szel;
        short i=0, j=0;
        decimal nehezseg = Program.nehezseg;
        int palya_szele_y;
        int palya_szele_x;
        int x, y;
     


      


        public Form2()
        {
            InitializeComponent();

        }
        private int palyszam()
        {
            string[] files = Directory.GetFiles(dir);

            int maxPalyaSzam = 0;
            foreach (string file in files)
            {
                string fileNev = Path.GetFileName(file);
                if (fileNev.StartsWith("labirintusok"))
                {
                    fileNev = fileNev.Remove(0, 12);

                    fileNev = fileNev.Remove(fileNev.Length - 4);
                    int palyaSzam = Int32.Parse(fileNev);
                    if (palyaSzam > maxPalyaSzam)
                    {
                        maxPalyaSzam = palyaSzam;
                    }
                }
            }
            return maxPalyaSzam;
        }


        void palya_feltoltese()
        {
            jatekos.Left = 0;
            jatekos.Top = 0;
            if (sz == 1)
            {
               palyaszam= palyszam();
            }
            if (sz<=palyaszam)
            {
                var olvas1 = new StreamReader(File.OpenRead("labirintus\\labirintusok" + sz + ".txt"));
                string sor;
                a = 0; b = 0;
                for (i = 0; i < n; i++)
                {
                    sor = olvas1.ReadLine();
                    for (j = 0; j < m; j++)
                    {
                        akadp[i, j] = Convert.ToInt32(sor[j]);
                    }

                }
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        if (akadp[i, j] == 49)
                        {
                            palya[i, j].BackColor = Color.Yellow;
                            palya[i, j].Visible = false;
                        }
                        else
                        {
                            palya[i, j].BackColor = Color.Blue;
                            palya[i, j].Visible = false;
                        }
                    }
                }
                palya[n - 1, m - 1].Enabled = true;
                palya[n - 1, m - 1].Visible = true;
            }
            else
            {
                string no_more_stage_mess = "Ninics több pálya! Készíts új pályát a szerkesztővel. ";
                MessageBox.Show(no_more_stage_mess);
                this.Close();
                Program.mainWindow.Show();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            switch (Program.mainWindow.kepszam)
            {
                case 1:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.icigo;
                    break;
                case 2:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.mumus;
                    break;
                case 3:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.ajzem;
                    break;
                case 4:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.gin;
                    break;
                case 5:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.tosen;
                    break;
                case 6:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.ulkviora;
                    break;
                case 7:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.grindzso;
                    break;
                case 8:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.vajzard;
                    break;
                case 9:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.urahara;
                    break;
                case 10:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.kenpacsi;
                    break;
                case 11:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.bak;
                    break;
                case 12:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.doki;
                    break;
                case 13:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.jamji;
                    break;
                case 14:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.soifon;
                    break;
                case 15:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.hisagi;
                    break;
                case 16:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.renji;
                    break;
                case 17:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.ikaku;
                    break;
                case 18:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.isida;
                    break;
                case 19:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.sado;
                    break;
                case 20:
                    jatekos.BackgroundImage.Dispose();
                    jatekos.BackgroundImage = Properties.Resources.kon;
                    break;

                default:
                    break;
            }

            this.BackColor = Color.Black;
            int szelesseg = (this.Width+3) / m;
            szel = szelesseg;
            palya = new Panel[n, m];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    palya[i, j] = new Panel();
                    palya[i, j].Width = szelesseg;
                    palya[i, j].Height = szelesseg;
                    palya[i, j].Parent = this;
                    palya[i, j].Left = j * szelesseg;
                    palya[i, j].Top = i * szelesseg;
                    palya[i, j].Visible = false;
                    palya[i, j].Enabled = false;
                    
                }
            }
            palya[n - 1, m - 1].Enabled = true;
            palya[n - 1, m - 1].Visible = true;
            palya[0, 0].Visible = true;
            jatekos.Width = szelesseg;
            jatekos.Height = szelesseg;

                

            PictureBox pb = new PictureBox();
            pb.Load("155.gif");
            pb.Parent = palya[n-1, m-1];
            pb.SizeMode= PictureBoxSizeMode.CenterImage;
            pb.Width = szelesseg;
            pb.Height = szelesseg;
            palya_feltoltese();
           
        }
      
        


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainWindow.Show();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            x = jatekos.Location.X;
            y = jatekos.Location.Y;
            palya_szele_y = szel * (n-1);
            palya_szele_x = szel * (m-1);

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)

                if (y != 0)
                {
                    if (palya[a - 1, b].BackColor == Color.Yellow)
                    {
                        this.jatekos.Top -= szel;
                        latotav(a - 1, b);
                        a--;
                        nr_moves++;
                    }
                }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                if (y != palya_szele_y)
                {
                    if (palya[a + 1, b].BackColor == Color.Yellow)
                    {
                        this.jatekos.Top += szel;
                        latotav(a + 1, b);
                        a++;
                        nr_moves++;
                    }
                }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)

                if (x != 0)
                {
                    if (palya[a, b - 1].BackColor == Color.Yellow)
                    {
                        this.jatekos.Left -= szel;
                        latotav(a, b - 1);
                        b--;
                        nr_moves++;
                    }
                }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)

                if (x != palya_szele_x)
                {
                    if (palya[a, b + 1].BackColor == Color.Yellow)
                    {
                        this.jatekos.Left += szel;
                        latotav(a, b + 1);
                        b++;
                        nr_moves++;
                    }
                }


            if (a == (n-1) && b == (m-1))
            {
               
                Palya_vege pv = new Palya_vege();            
                pv.ShowDialog();
                palya_feltoltese();
               
                nr_moves = 0;
            }

        }

        private void latotav(int a, int b)
        {
            Boolean up=true,down=true,left=true,right=true;
            for (i = 0; i <= nehezseg; i++)
            {
                //FEl
                if (up && y != 0 && (a - i) >= 0)
                {
                    if (palya[a - i, b].BackColor == Color.Blue)
                    {
                        up = false;
                    }
                    else
                    {
                        palya[a - i, b].Visible = true;
                    }                  
                }
                //LE
                if (down && y != palya_szele_y && ((a + i) < n))
                {
                    if (palya[a + i, b].BackColor == Color.Blue)
                    {
                        down = false;
                    }
                    else
                    {
                        palya[a + i, b].Visible = true;
                    }                    
                }
                //BALRA
                if (left && x != 0 && (b - i) >= 0)
                {
                    if (palya[a, b - i].BackColor == Color.Blue)
                    {
                        left = false;
                    }
                    else
                    {
                        palya[a, b - i].Visible = true;
                    }
                }
                //JOBBRA
                if (right && x != palya_szele_x && ((b + i) < m))
                {
                    if (palya[a, b + i].BackColor == Color.Blue)
                    {
                        right = false;
                    }
                    else
                    {
                        palya[a, b + i].Visible = true;
                    }
                }   
            }
        }
    }

}