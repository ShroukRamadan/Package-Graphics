using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Package_Graphics
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DrawingLineUsingDDA f = new DrawingLineUsingDDA();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Drawing_Line_Using_Bresenham f = new Drawing_Line_Using_Bresenham();
            f.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Drawing_Circle_Using_Bresenham f = new Drawing_Circle_Using_Bresenham();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DrawingElipseUsingBresenham f = new DrawingElipseUsingBresenham();
            f.ShowDialog();
        }
    }
}
