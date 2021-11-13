using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    class LineSlopeEquation
    {
        public double a { get; set; }
        public double b { get; set; }

        public LineSlopeEquation(Point p1, Point p2)
        {
            (this.a, this.b) = LineSlopeEquation.CalculateLineSlopeEquation(p1, p2);
        }

        public static (double a, double b) CalculateLineSlopeEquation(Point p1, Point p2)
        {
            double a;

            if ((p2.X - p1.X) == 0)
                a = double.PositiveInfinity;
            else
                 a = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);

            double b = p1.Y - p1.X * a;

            return (a, b);
        }
    }
}
