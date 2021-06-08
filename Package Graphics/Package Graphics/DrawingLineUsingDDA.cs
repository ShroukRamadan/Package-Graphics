using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Package_Graphics
{
    public partial class DrawingLineUsingDDA : Form
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



        void DDA(int x0, int y0, int xEnd, int yEnd)
        {
            int dx = xEnd - x0, dy = yEnd - y0, steps, k;
            float xIncrement, yIncrement, x, y;

            x = (float)x0;
            y = (float)y0;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;



            setPixel((int)Math.Round(x), (int)Math.Round(y), g, Color.Black);
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;
                setPixel((int)Math.Round(x), (int)Math.Round(y), g, Color.Black);
            }
        }

        public DrawingLineUsingDDA()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start f = new Start();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DDA(X0, Y0, XEnd, YEnd);

        }
    }
}
