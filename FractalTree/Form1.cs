using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalTree
{
    public partial class Form1 : Form
    {
        int x = 300;
        int y = 300;
        //double angle = 90d;
        int length = 50;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g;

            g = e.Graphics;

            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;
            //g.DrawLine(myPen, 30, 30, 45, 65);

            //g.DrawLine(myPen, 1, 1, 45, 65);

            //DrawLinePoint(new PaintEventArgs(g, new Rectangle(x, y, length, 1)));
            //DrawLinePoint(new PaintEventArgs(g, new Rectangle(x, y, length, 1)));

            int x1 = x;
            int y1 = y;
            double angle1 = Math.PI * 45 / 180.0; ;

            int x2 = x;
            int y2 = y;
            double angle2 = Math.PI * 135 / 180.0;

            length = 50;

            for (var i = 0; i < 1; i++)
            {
                // Create points that define line.
                Point xPoint1 = new Point(x1, y1);
                Point yPoint1 = new Point((int)(x1 - Math.Cos(angle1) * length), (int)(y1 - Math.Sin(angle1) * length));

                // Draw line to screen.
                e.Graphics.DrawLine(myPen, xPoint1, yPoint1);

                // Create points that define line.
                Point xPoint2 = new Point(x2, y2);
                Point yPoint2 = new Point((int)(x2 - Math.Cos(angle2) * length), (int)(y2 - Math.Sin(angle2) * length));

                // Draw line to screen.
                e.Graphics.DrawLine(myPen, xPoint2, yPoint2);

                //Point yPoint3 = new Point(x, y + (int)(length * 1.5));

                //e.Graphics.DrawLine(myPen, xPoint2, yPoint3);

                x1 = yPoint1.X;
                y1 = yPoint1.Y;

                x2 = yPoint2.X;
                y2 = yPoint2.Y;

                length /= 2;
            }
        }
    }
}
