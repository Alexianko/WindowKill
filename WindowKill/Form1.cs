using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Drawing;
using System.Runtime.InteropServices;
//using System.Windows.Forms;

namespace WindowKill
{
    public partial class Form1 : Form
    {
        private Point circleCenter;
        private int _circleRadius = 40;
        private Point shootDirection;

        int circleSpeed = 15;
        bool wPress = false;
        bool aPress = false;
        bool sPress = false;
        bool dPress = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            circleCenter = new Point(Size.Width / 2, Size.Height / 2);

            timer.Interval = (int)(1000 / 60.0);
            timer.Start();

            TopMost = true;

            //canvas.BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e) { /* Ignore */ }

        private void TimerTick(object sender, EventArgs e)
        {
            //var position = GetCursorPosition();

            //label1.Text = MousePosition.  .ToString();

            shootDirection = new Point(MousePosition.X - Left - circleCenter.X, MousePosition.Y - Top - circleCenter.Y);
            canvas.Invalidate();

            if (aPress)
            {
                circleCenter.X -= circleSpeed;
            }
            if (dPress)
            {
                circleCenter.X += circleSpeed;
            }
            if (wPress)
            {
                circleCenter.Y -= circleSpeed;
            }
            if (sPress)
            {
                circleCenter.Y += circleSpeed;
            }

            //if (movingUp && y > 0)
            //    y -= circleSpeed;
            //if (movingDown && y < Height - pictureBox1.Height)
            //    y += circleSpeed;
            //if (movingLeft && x > 0)
            //    x -= circleSpeed;
            //if (movingRight && x < Width - pictureBox1.Width)
            //    x += circleSpeed;

            //// Update circle position
            //pictureBox1.Location = new Point(x, y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = "click";
            // Shoot if left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Add your shooting logic here

                // Get the angle between mouse position and circle position
                double angle = Math.Atan2(e.Y - (canvas.Location.Y + canvas.Height / 2), e.X - (canvas.Location.X + canvas.Width / 2));

                // Convert angle to degrees
                double angleInDegrees = angle * (180 / Math.PI);

                // Add your code to shoot using angleInDegrees
            }
        }

        private void UpdateCanvas(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Draw the circle
            //g.Clear(Color.White);
            g.Clear(Color.Red);

            g.FillEllipse(Brushes.Blue, circleCenter.X - _circleRadius, circleCenter.Y - _circleRadius, 2 * _circleRadius, 2 * _circleRadius);

            // Shoot in the mouse direction
            Pen pen = new Pen(Color.Lime, 3);
            g.DrawLine(pen, circleCenter, new Point(circleCenter.X + shootDirection.X, circleCenter.Y + shootDirection.Y));

            //var b = new SolidBrush(Color.FromArgb(5, 10, 10, 10));
            //g.FillRectangle(b, g.ClipBounds);
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // Update the shoot direction based on mouse position
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            label1.Text = "move";
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "nice";
            //circleCenter = new Point(MousePosition.X - Left, MousePosition.Y - Top);
        }





        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.Modifiers == Keys.A)
            {
                aPress = true;
            }
            if (e.KeyCode == Keys.D || e.Modifiers == Keys.D)
            {
                dPress = true;
            }
            if (e.KeyCode == Keys.W || e.Modifiers == Keys.W)
            {
                wPress = true;
            }
            if (e.KeyCode == Keys.S || e.Modifiers == Keys.S)
            {
                sPress = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.Modifiers == Keys.A)
            {
                aPress = false;
            }
            if (e.KeyCode == Keys.D || e.Modifiers == Keys.D)
            {
                dPress = false;
            }
            if (e.KeyCode == Keys.W || e.Modifiers == Keys.W)
            {
                wPress = false;
            }
            if (e.KeyCode == Keys.S || e.Modifiers == Keys.S)
            {
                sPress = false;
            }
        }
    }
}
