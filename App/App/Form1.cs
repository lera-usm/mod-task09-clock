using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace App
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 1000;
            g = this.CreateGraphics();
        }

        private void Paint()
        {
            this.Width = 800;
            this.Height = 800;
            g.Clear(Color.White);

            Pen cir_pen = new Pen(Color.Black, 2);
            Pen chas = new Pen(Color.Black, 5);
            Pen min = new Pen(Color.Black, 3);
            Pen sec = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Indigo);

            g.DrawEllipse(cir_pen, 20, 20, 520, 520);
            int rad = 250;
            int center = 280;
            for (int i = 0; i < 12; i++)
            {
                double x = center + rad * Math.Sin(30 * i * Math.PI / 180);
                double y = center + rad * Math.Cos(30 * i * Math.PI / 180);
                g.DrawLine(cir_pen, (int)x, (int)y, (int)(x - 40 * Math.Sin(30 * i * Math.PI / 180)), (int)(y - 40 * Math.Cos(30 * i * Math.PI / 180)));
            }
            for (int i = 0; i < 60; i++)
            {
                double x = center + rad * Math.Sin(6 * i * Math.PI / 180);
                double y = center + rad * Math.Cos(6 * i * Math.PI / 180);
                g.DrawLine(cir_pen, (int)x, (int)y, (int)(x - 20 * Math.Sin(6 * i * Math.PI / 180)), (int)(y - 20 * Math.Cos(6 * i * Math.PI / 180)));
            }

            DateTime dt = DateTime.Now;
            g.DrawLine(chas, center, center, (int)(center + (rad - 150) * Math.Sin((30 * (dt.Hour % 12)) * Math.PI / 180)), (int)(center - (rad - 150) * Math.Cos((30 * (dt.Hour % 12)) * Math.PI / 180)));
            g.DrawLine(min, center, center, (int)(center + (rad - 100) * Math.Sin((6 * dt.Minute) * Math.PI / 180)), (int)(center - (rad - 100) * Math.Cos((6 * dt.Minute) * Math.PI / 180)));
            g.DrawLine(sec, center, center, (int)(center + (rad - 40) * Math.Sin((6 * dt.Second) * Math.PI / 180)), (int)(center - (rad - 40) * Math.Cos((6 * dt.Second) * Math.PI / 180)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Paint();
        }
    }
}
