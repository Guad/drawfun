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

        private static int start_x, start_y;
        private static int end_x, end_y;

        private static int my_angle = 0;
        private static int my_length = 0;
        private static int my_increment = 0;

        public Form1()
        {
            InitializeComponent();
            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            myPen.Width = 2;
            start_x = canvas.Width / 2;
            start_y = canvas.Height / 2;
            my_length = Convert.ToInt32(length.Text);
            g = canvas.CreateGraphics();
            for (int i = 0; i < Convert.ToInt32(numerOfLines.Text); i++)
            drawLine();
        }

        private void drawLine()
        {
            Random randomGen = new Random();
            myPen.Color = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));
            my_angle = my_angle + Convert.ToInt32(angle.Text);
            my_length = my_length + Convert.ToInt32(length.Text);

            end_x = (int)(start_x + Math.Cos(my_angle * 0.017453292519) * my_length); 
            end_y = (int)(start_y + Math.Sin(my_angle * 0.017453292519) * my_length);
            //0.017453292519 is a constant to convert to radians

            Point[] points =
            {
                new Point(start_x, start_y), 
                new Point(end_x, end_y),
            };
            start_x = end_x;
            start_y = end_y;

            g.DrawLines(myPen, points); //Null reference vuln
        } //end drawline

        private void button1_Click(object sender, EventArgs e)
        {
            my_length = Convert.ToInt32(length.Text);
            my_increment = Convert.ToInt32(increment.Text);
            my_angle = Convert.ToInt32(angle.Text);

            canvas.Refresh();
        }
    }
}
