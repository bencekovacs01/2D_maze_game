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
        string dir = "labirintus";
        public int lsz = 0;
        SajatPanel[,] palya;
        int a = 0, b = 0;
        int[,] akadp = new int[14, 27];
        int palyaszam = 0;
        int szel;
        short i=0, j=0;
        decimal nehezseg=Program.f1.nehez;
        int palya_szele_y;
        int palya_szele_x;
        int x, y;
     


      public  int sz = 1;
        int n = 14;
        int m = 27;


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
                for (i = 0; i < 14; i++)
                {
                    sor = olvas1.ReadLine();
                    for (j = 0; j < 27; j++)
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
                string nop = "Ninics több pálya! Készíts új pályát a szerkesztővel. ";
                MessageBox.Show(nop);
                this.Close();
                Program.f1.Show();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            switch (Program.f1.kepszam)
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
            palya = new SajatPanel[n, m];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    palya[i, j] = new SajatPanel();
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
            pb.Parent = palya[13, 26];
            pb.SizeMode= PictureBoxSizeMode.CenterImage;
            pb.Width = szelesseg;
            pb.Height = szelesseg;
            palya_feltoltese();
           
        }
      
        


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.f1.Show();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            x = jatekos.Location.X;
            y = jatekos.Location.Y;
            palya_szele_y = szel * 13;
            palya_szele_x = szel * 26;

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)

                if (y != 0)
                {
                    if (palya[a - 1, b].BackColor == Color.Yellow)
                    {
                        this.jatekos.Top -= szel;
                        latotav(a - 1, b);
                        a--;
                        lsz++;
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
                        lsz++;
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
                        lsz++;
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
                        lsz++;
                    }
                }


            if (a == 13 && b == 26)
            {
               
                Palya_vege pv = new Palya_vege();            
                pv.ShowDialog();
                palya_feltoltese();
               
                lsz = 0;
            }

        }

        private void latotav(int a, int b)
        {
            for (i = 0; i <= nehezseg; i++)
            {
                //FEl
                if (y != 0 && (a - i) >= 0)
                {
                    palya[a - i, b].Visible = true;
                   
                }
                //LE
                if (y != palya_szele_y && ((a + i) < 14))
                {
                    palya[a + i, b].Visible = true;
                    
                }
                //BALRA
                if (x != 0 && (b - i) >= 0)
                {
                    palya[a, b - i].Visible = true;
                    
                }
                //JOBBRA
                if (x != palya_szele_x && ((b + i) < 27))
                {
                     palya[a, b + i].Visible = true;
                    
                }   
            }
        }
    }

}