using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Package_Graphics
{
    public partial class Drawing_Circle_Using_Bresenham : Form
    {


        public int X0
        {
            get
            {
                return int.Parse(textBox1.Text);
            }
        }

        public int Y0
        {
            get
            {
                return int.Parse(textBox2.Text);
            }
        }

        public int Radius
        {
            get
            {
                return int.Parse(textBox3.Text);
            }
        }

        public Graphics g;
        void setpixel(int x, int y, Graphics g, Color colorline)
        {
            g = panel1.CreateGraphics();
            var aBrush = Brushes.Black;
            g.FillRectangle(aBrush, x, y, 2, 2);

        }



        void drawCircle(int xc, int yc, int x, int y)
        {
            setpixel(xc + x, yc + y, g, Color.Black);
            setpixel(xc - x, yc + y, g, Color.Black);
            setpixel(xc + x, yc - y, g, Color.Black);
            setpixel(xc - x, yc - y, g, Color.Black);
            setpixel(xc + y, yc + x, g, Color.Black);
            setpixel(xc - y, yc + x, g, Color.Black);
            setpixel(xc + y, yc - x, g, Color.Black);
            setpixel(xc - y, yc - x, g, Color.Black);
        }




        void circleBres(int xc, int yc, int r)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;
            drawCircle(xc, yc, x, y);
            while (y >= x)
            {


                x++;


                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                    d = d + 4 * x + 6;
                drawCircle(xc, yc, x, y);

            }

        }


        public Drawing_Circle_Using_Bresenham()
        {
            InitializeComponent();
        }

        private void Drawing_Circle_Using_Bresenham_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start f = new Start();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            circleBres(X0, Y0, Radius);

        }
    }
}
