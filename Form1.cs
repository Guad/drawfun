using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawing
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black);
        private Graphics g = null;

        private static int center_x, center_y;
        private static int start_x, start_y;
        private static int end_x, end_y;

        private static int my_angle = 0;
        private static int my_length = 0;
        private static int my_increment = 0;
        private static int numLines = 0;

        public Form1()
        {
            InitializeComponent();
            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            myPen.Width = 2;
            g = canvas.CreateGraphics();
            drawLine();
        }

        private void drawLine()
        {
            Point[] points =
            {
                new Point(start_x, start_y), 
                new Point(start_x + 100, start_y + 100),
            };
            g.DrawLines(myPen, points); //Null reference vuln
        } //end drawline

        private void button1_Click(object sender, EventArgs e)
        {
            my_length = Convert.ToInt32(length.Text);
            my_increment = Convert.ToInt32(increment.Text);
            my_angle = Convert.ToInt32(angle.Text);

            start_x = canvas.Width/2;
            start_y = canvas.Height/2;

            canvas.Refresh();
        }
    }
}
