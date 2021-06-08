using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package_Graphics
{
    public partial class Form1 : Form
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

        public int xtv
        {
            get
            {
                return int.Parse(textBox5.Text);
            }
        }

        public int ytv
        {
            get
            {
                return int.Parse(textBox6.Text);
            }
        }

        public int xsf
        {
            get
            {
                return int.Parse(textBox7.Text);
            }
        }

        public int ysf
        {
            get
            {
                return int.Parse(textBox8.Text);
            }
        }

        public double r_angle
        {
            get
            {
                return double.Parse(textBox9.Text);
            }
        }

        public int shearing_value
        {
            get
            {
                return int.Parse(textBox10.Text);
            }
        }


        void DrawingLine(int x0, int y0, int xEnd, int yEnd, Brush b)
        {
           
            var g = panel1.CreateGraphics();

            int dx = Math.Abs(xEnd - x0), dy = Math.Abs(yEnd - y0);
            int x, y, p = 2 * dy - dx;
            int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);

            // Determine which endpoint to use as start position.  
            if (x0 > xEnd)
            {
                x = xEnd; y = yEnd; xEnd = x0;
            }
            else
            {
                x = x0; y = y0;
            }
            g.FillRectangle(b,x,y,2,2);

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
                g.FillRectangle(b, x, y, 2, 2);
            }
        }


       
      

       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Brush brush = Brushes.Black;
            DrawingLine(X0, Y0, XEnd, YEnd, brush);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int xn1, xn2, yn1, yn2;
            if ((X0 < Y0) ^ (XEnd < YEnd))
            {
                xn1 = X0 + 50;
                xn2 = XEnd + 50;
                yn1 = Y0;
                yn2 = YEnd;
            }
            else
            {
                xn1 = X0;
                xn2 = XEnd;
                yn1 = Y0 + 50;
                yn2 = YEnd + 50;
            }
            Brush brush = Brushes.GhostWhite;
            DrawingLine(xn1, yn1, xn2, yn2, brush);

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int XTra = X0 + xtv;
            int YTra = Y0 + ytv;
            int XTraEnd = XEnd + xtv;
            int YTraEnd = YEnd + ytv;
            Brush brush = Brushes.Red;
            DrawingLine(XTra, YTra, XTraEnd, YTraEnd, brush);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Xscale = X0 * xsf;
            int Yscale = Y0 * ysf;
            int XscaleEnd = XEnd * xsf;
            int YscaleEnd = YEnd * ysf;
            Brush brush = Brushes.Cyan;
            DrawingLine(Xscale, Yscale, XscaleEnd, YscaleEnd, brush);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double r11, r12, r21, r22;
            int xn, yn;
            r11 = Math.Cos((r_angle * Math.PI) / 180);
            r12 = Math.Sin((r_angle * Math.PI) / 180);
            r21 = (-Math.Sin((r_angle * Math.PI) / 180));
            r22 = Math.Cos((r_angle * Math.PI) / 180);
            xn = (int)((XEnd * r11) - (YEnd * r12));
            yn = (int)((XEnd * r12) + (YEnd * r11));
            Brush brush = Brushes.Yellow;
            DrawingLine(X0, Y0, xn, yn, brush);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int xsh1, xsh2;
            xsh1 = X0 + shearing_value * Y0;
            xsh2 = XEnd + shearing_value * YEnd;
            Brush brush = Brushes.DeepPink;
            DrawingLine(xsh1, Y0, xsh2, YEnd, brush);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start f = new Start();
            f.ShowDialog();
        }
    }
}
