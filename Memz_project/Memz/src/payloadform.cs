using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Memz
{
    public partial class payloadform : Form
    {
        public payloadform()
        {
            InitializeComponent();
        }

        // Messagebox Triggers every 10 seconds
        public void AskMsg(object source, EventArgs e)
        {
            MessageBox.Show("Memz", "Malware", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        // Makes the screen glitching like memz
        public void ScreenGlitching(object source, EventArgs e)
        {
            Random ran = new Random();
            int num = ran.Next(0, 150);
            int num1 = ran.Next(0, 150);
            int num2 = ran.Next(0, 150);
            int num3 = ran.Next(0, 150);
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width);
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.CopyFromScreen(num, num3, num1, num2, bmp.Size);
            graphic.CopyFromScreen(num3, num2, num, num1, bmp.Size);
            int width = ran.Next(600, 1600);
            int height = ran.Next(350, 850);

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    int alpha = p.Alpha;
                    int red = p.Red;
                    int green = p.Green;
                    int blue = p.Blue;

                    red = 255 - red;
                    green = 255 - green;
                    blue = 255 - blue;

                    bmp.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                }
                pictureBox1.Image = bmp;
            }
        }

        // Opens and triggers the memz image and messaegebox
        public void MemzImg(object source, EventArgs e)
        {
           
            MessageBox.Show("Still trying to use your computer?", "Danger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // The whole payload system in memz
        public void Memz()
        {
            StreamWriter File = new StreamWriter("get.txt");
            File.Write("You are being infected with Memz\n\nGoodbye to your computer.");
            File.Close();
            Process.Start("get.txt");
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TransparencyKey = this.BackColor;
            this.TopMost = true;
            string equisource = "https://static.vecteezy.com/system/resources/previews/004/223/162/original/dirty-grunge-hand-drawn-with-brush-strokes-cross-x-illustration-isolated-on-white-background-mark-graphic-design-check-mark-symbol-no-button-for-vote-in-check-box-web-etc-free-vector.jpg";
     

            try
            {
                string filename = "equis.png";
                equis.DownloadFile(equisource, filename);
            } catch
            {
                MessageBox.Show("It seems that the program is running.", "Infected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Process.Start("equis.png");

            Timer t1 = new Timer
            {
                Interval = 20000
            };

            Timer t2 = new Timer
            {
                Interval = 300
            };

            Timer t3 = new Timer
            {
                Interval = 60000
            };

            t1.Enabled = true;
            t1.Tick += new System.EventHandler(AskMsg);
            t2.Enabled = true;
            t2.Tick += new System.EventHandler(ScreenGlitching);
            t3.Enabled = true;
            t3.Tick += new System.EventHandler(MemzImg);
        }

        // To exit this Memz trojan
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // To warn the user about the program
        private void Form1_Load(object sender, EventArgs e)
        {
            Dialog r1;
            Dialog r2;
            r1 = MessageBox.Show("This Is a clean and a not so destructive version of Memz , still wish to continue??", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(r1 == Dialog.No)
            {
                this.Close();

            } else if(r1 == Dialog.Yes)
                {
                r2 = MessageBox.Show("Last warning before getting your the program runs....", "LAST WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r1 == Dialog.No)
                {
                    this.Close();

                }
                else if (r1 == Dialog.Yes)
                {
                    Memz();
                }
            }

        }

    }
}
