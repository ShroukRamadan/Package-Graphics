using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Package_Graphics
{
    public partial class DrawingElipseUsingBresenham : Form
    {

        public int Xcenter
        {
            get
            {
                return int.Parse(textBox1.Text);
            }
        }

        public int Ycenter
        {
            get
            {
                return int.Parse(textBox2.Text);
            }
        }

        public int Rx
        {
            get
            {
                return int.Parse(textBox3.Text);
            }
        }

        public int Ry
        {
            get
            {
                return int.Parse(textBox4.Text);
            }
        }

        public Graphics g;
        void setPixel(int x, int y, Graphics g, Color colorline)
        {
            g = panel1.CreateGraphics();
            var aBrush = Brushes.Black;
            g.FillRectangle(aBrush, x, y, 2, 2);

        }



        void drawEllipse(int xc, int yc, int x, int y)
        {
            setPixel(xc + x, yc + y, g, Color.Black);
            setPixel(xc - x, yc + y, g, Color.Black);
            setPixel(xc + x, yc - y, g, Color.Black);
            setPixel(xc - x, yc - y, g, Color.Black);
        }

        void midptellipse(int xc, int yc, int rx, int ry)
        {

            int dx, dy, x, y;
            double d1, d2;
            x = 0;
            y = ry;

            // Initial decision parameter of region 1
            d1 = (ry * ry) - (rx * rx * ry) +
                            (0.25f * rx * rx);
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            // For region 1

            drawEllipse(xc, yc, x, y);
            while (dx < dy)
            {

                if (d1 < 0)
                {
                    x++;
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }
                drawEllipse(xc, yc, x, y);
            }


            d2 = ((ry * ry) * ((x + 0.5f) * (x + 0.5f)))
                + ((rx * rx) * ((y - 1) * (y - 1)))
                - (rx * rx * ry * ry);


            while (y >= 0)
            {

                if (d2 > 0)
                {
                    y--;
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }
                drawEllipse(xc, yc, x, y);
            }
        }

        public DrawingElipseUsingBresenham()
        {
            InitializeComponent();
        }

        private void DrawingElipseUsingBresenham_Load(object sender, EventArgs e)
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
            midptellipse(Xcenter, Ycenter, Rx, Ry);

        }
    }
}
