using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;
using System.Threading;



namespace szerkeszto
{
    public partial class Form2 : Form
    {
        short i, j;
        public enum MouseButtonState { }
        public static MouseButtonState LeftButton { get; }
        Panel[,] palya;
        Panel fedo = new Panel();
        static short n = 14; //14
        static short m = 27; //27
        string dir = @"..\..\..\szakvizsga uj\bin\Debug";
        Image kep = new Bitmap("karakter.jpg");
        bool[,] volt = new bool [n,m];
        int szel = 0;
        short szin = 1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(30);
            this.Hide();
            //Program.ls = new LoadingScreen();
            //Program.ls.Show();   
            int bal = Program.f2.Right;
            int top = Program.f2.Top;
            int also = Program.f2.Bottom;
            button4.Height = Program.f2.Height - panel1.Height - 380;
            button5.Height = button4.Height;
            button6.Height = button4.Height;
            button7.Height = button4.Height;
            button1.Left = bal - 120;
            button1.Top = top + 25;
            button2.Left = bal - 120;
            button2.Top = top + 115;
            button3.Left = bal - 120;
            button3.Top = top + 205;
            button4.Top = also - 130;
            button4.Left = Program.f2.Left + 140;
            button5.Top = also - 130;
            button5.Left = button4.Right + 70;
            button6.Top = also - 130;
            button6.Left = button5.Right + 70;
            button7.Top = also - 130;
            button7.Left = button6.Right + 70;
            button8.Top = also - 130;
            button8.Left = button7.Right + 70;
            button9.Top = also - 130;
            button9.Left = button8.Right + 70;
            palya_feltoltese();
            //Program.ls.Close();
            System.Threading.Thread.Sleep(18);
            this.Show();
        }

        void palya_feltoltese()
        {
            
            palya = new Panel[n, m];
            
            int szelesseg = (this.Width - 150) / m;
            panel1.Height = szelesseg * n;
            panel1.Width = szelesseg * m;
            szel = szelesseg;
            
            fedo.Width = m * szelesseg;
            fedo.Height = n * szelesseg;
           
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    palya[i, j] = new Panel();
                    palya[i, j].Width = szelesseg;
                    palya[i, j].Height = szelesseg;
                    palya[i, j].Parent = panel1;
                    palya[i, j].Left = j * szelesseg;
                    palya[i, j].Top = i * szelesseg;
                    palya[i, j].BorderStyle = BorderStyle.FixedSingle;
                    palya[i, j].Visible = true;
                    palya[i, j].Enabled = false;
                    palya[i, j].BackColor = Color.Blue;
                    palya[i, j].Tag = 0;                  
                    volt[i, j] = false;
                }
            }
            fedo.Parent = panel1;
            fedo.Enabled = true;
            fedo.MouseMove += new MouseEventHandler(this.gomb_MouseMove);
            fedo.MouseClick += new MouseEventHandler(this.gomb_MouseMove);
           
            palya[0, 0].BackgroundImage = kep;
            palya[0, 0].BackColor = Color.Gray;
            PictureBox pb = new PictureBox();
            pb.Load("155.gif");
            pb.Parent = palya[n-1, m-1];
            pb.Width = szelesseg;
            pb.Height = szelesseg;
            palya[n - 1, m - 1].Enabled = true;
            palya[n - 1, m - 1].Tag = 1;
            palya[0, 0].Tag = 1;
            palya[n - 1, m - 1].BackColor = Color.Gray;
        }

        public void error()
        {
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if ((int)palya[i, j].Tag == 1)
                    {
                        palya[i, j].BackColor = Color.Yellow;
                        volt[i, j] = false;
                        palya[i, j].Refresh();
                    }
                }
            }
            palya[n - 1, m - 1].Tag = 1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!palya_Ellenorzes())
            {
                MessageBox.Show("A pálya nem helyes. A piros út el kell érjen a pálya végéig!");
                error();
                return;
            }
            string palyaString = palya_To_String();
            frissites();
            palya_Mentes(palyaString);
            MessageBox.Show("A pálya mentése sikeres volt!");
        }

        private bool palya_Ellenorzes()
        {
            bejaras(0, 0);
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (volt[i,j])
                    {
                        palya[i, j].BackColor = Color.Red;
                    }
                }
            }
            return volt[n - 1, m - 1];
        }

        private string palya_To_String()
        {
            String palyaString = "";
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if ((int)palya[i,j].Tag == 1)
                    {
                        palyaString += "1";     
                    }
                    else
                    {
                        palyaString += "0";
                    }
                }
                palyaString += "\n";
            }
            return palyaString;
        }

        private void palya_Mentes(string palyaString)
        {
            {
                string[] files = Directory.GetFiles(dir+@"\labirintus");
                int maxPalyaSzam = -1;
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
                maxPalyaSzam += 1;
                File.WriteAllText(dir + @"\labirintus\labirintusok" + maxPalyaSzam + ".txt", palyaString);
            }
        }

        public void bejaras(int x, int y)
        {
            Queue<Pont> q = new Queue<Pont>();
            Pont p;
            q.Enqueue(new Pont(x, y));
            volt[x, y] = true;
            while (q.Count!=0)
            {
                p = q.Dequeue();
                // p.x aktualis pont sora
                // p.y aktualis pont oszlopa
                if (p.x>0 && volt[p.x-1, p.y]==false && (int)palya[p.x-1,p.y].Tag==1) //FOLOTTE
                {
                    volt[p.x - 1, p.y] = true;                          
                    q.Enqueue(new Pont(p.x - 1, p.y));
                }
               
                if (p.y < 26 && volt[p.x, p.y+1] == false && (int)palya[p.x, p.y+1].Tag == 1) //JOBBRA
                {
                    volt[p.x, p.y+1] = true;
                    q.Enqueue(new Pont(p.x, p.y + 1));
                }
                
                if (p.x < 13 && volt[p.x + 1, p.y] == false && (int)palya[p.x + 1, p.y].Tag == 1) //ALATTA
                {
                    volt[p.x +1, p.y] = true;                  
                    q.Enqueue(new Pont(p.x + 1, p.y));
                }
                
                if (p.y > 0 && volt[p.x, p.y-1] == false && (int)palya[p.x, p.y-1].Tag == 1) //BALRA
                {
                    volt[p.x, p.y-1] = true;
                    q.Enqueue(new Pont(p.x, p.y-1));
                }
            }
        }

       private void gomb_MouseMove(object sender, MouseEventArgs e)
       {
            int y = e.X / szel;
            int x = e.Y / szel;
            if (x < n && y < m)
            {
                if (e.Button == MouseButtons.Left)
                {
                    palya[x, y].BackColor = Color.Yellow;
                    palya[x, y].Tag = 1;
                }
                if (e.Button == MouseButtons.Right)
                {
                    switch (szin)
                    {
                        case 1:
                            palya[x, y].BackColor = Color.Blue;
                            break;
                        case 2:
                            palya[x, y].BackColor = Color.Green;
                            break;
                        case 3:
                            palya[x, y].BackColor = Color.Gray;
                            break;
                        case 4:
                            palya[x, y].BackColor = Color.Black;
                            break;
                        case 5:
                            palya[x, y].BackColor = Color.LightSkyBlue;
                            break;
                        case 6:
                            palya[x, y].BackColor = Color.DarkOrange;
                            break;
                    }
                    palya[x, y].Tag = 0;
                }
            }      
       }

        private void frissites()
        {
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if ((int)palya[i, j].Tag == 1)
                    {
                        switch (szin)
                        {
                            case 1:
                                palya[i, j].BackColor = Color.Blue;
                                break;
                            case 2:
                                palya[i, j].BackColor = Color.Green;
                                break;
                            case 3:
                                palya[i, j].BackColor = Color.Gray;
                                break;
                            case 4:
                                palya[i, j].BackColor = Color.Black;
                                break;
                            case 5:
                                palya[i, j].BackColor = Color.LightSkyBlue;
                                break;
                            case 6:
                                palya[i, j].BackColor = Color.DarkOrange;
                                break;
                        }
                    }
                    volt[i, j] = false;
                    palya[i, j].Tag = 0;
                    palya[i, j].Refresh();
                }
            }
            palya[n - 1, m - 1].Tag = 1;
        }

        private void frissites2(string szin2)
        {
            Color palyaszin = Color.FromName(szin2);
            for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        palya[i, j].BackColor = palyaszin;
                        volt[i, j] = false;
                        palya[i, j].Tag = 0;
                        palya[i, j].Refresh();
                    }
                }
                palya[n - 1, m - 1].Tag = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frissites();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Minden módosítás törlődni fog. Biztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                szin = 1;
                frissites2("Blue");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Minden módosítás törlődni fog. Biztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                szin = 2;
                frissites2("Green");
            }       
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Minden módosítás törlődni fog. Biztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                szin = 3;
                frissites2("Gray");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Minden módosítás törlődni fog. Biztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                szin = 4;
                frissites2("Black");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Minden módosítás törlődni fog. Biztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                szin = 5;
                frissites2("LightSkyBlue");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Minden módosítás törlődni fog. Biztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                szin = 6;
                frissites2("DarkOrange");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}