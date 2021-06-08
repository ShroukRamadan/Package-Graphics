using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Package_Graphics
{
    public partial class Drawing_Line_Using_Bresenham : Form
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

        public int XEnd
        {
            get
            {
                return int.Parse(textBox3.Text);
            }
        }

        public int YEnd
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



        void lineBres(int x0, int y0, int xEnd, int yEnd)
        {
            int dx = Math.Abs(xEnd - x0), dy = Math.Abs(yEnd - y0);
            int x, y, p = 2 * dy - dx;
            int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);

            /* Determine which endpoint to use as start position.  */
            if (x0 > xEnd)
            {
                x = xEnd; y = yEnd; xEnd = x0;
            }
            else
            {
                x = x0; y = y0;
            }
            setPixel(x, y, g, Color.Black);

            while (x < xEnd)
            {
                x++;
                if (p < 0)
                    p += twoDy;
                else
                {
                    y++;
                    p += twoDyMinusDx;
                }
                setPixel(x, y, g, Color.Black);
            }
        }


        public Drawing_Line_Using_Bresenham()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lineBres(X0, Y0, XEnd, YEnd);

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
    }
}
