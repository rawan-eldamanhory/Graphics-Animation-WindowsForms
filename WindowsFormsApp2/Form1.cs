using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private Timer timer = new Timer();
        private int x = 0;
        private int y = 200;
        private int sunX = 50;
        private int sunY = 55;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form1_Paint);
            timer.Interval = 50; // Change this value to adjust the speed of the ship
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            x += 4; // Change this value to adjust the distance moved by the ship
            if (x > this.Width + 100)
                x = -100;
           
            sunX += 3; // Change this value to adjust the speed of the sun
            if (sunX > this.Width + 100)
                sunX = -100; 

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw sea
            Brush seaBrush = new SolidBrush(Color.LightSkyBlue);
            g.FillRectangle(seaBrush, new Rectangle(0, y + 40, this.Width, this.Height - y - 20));

            // Draw ship
            Brush shipBrush = new SolidBrush(Color.Blue);
            Point[] shipPoints =
                {
                new Point(x + 60, y - 50),
                new Point(x + 50, y - 20),
                new Point(x + 30, y - 20),
                new Point(x + 30, y),
                new Point(x + 10, y),
                new Point(x + 20, y + 40),
                new Point(x + 100, y + 40),
                new Point(x + 110, y),
                new Point(x + 90, y),
                new Point(x + 90, y - 20),
                new Point(x + 70, y - 20)
            };
            g.FillPolygon(shipBrush, shipPoints);

            // Draw sun
            Brush sunBrush = new SolidBrush(Color.Yellow);
            g.FillEllipse(sunBrush, new Rectangle(sunX - 50, sunY - 50, 100, 100));
        }
    }
}
