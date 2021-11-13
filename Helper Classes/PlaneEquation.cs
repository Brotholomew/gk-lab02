using System;
using System.Collections.Generic;
using System.Text;

namespace lab02
{
    public class PlaneEquation
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double D { get; private set; }

        public double GetX(double y, double z) => (this.B * y + this.C * z + this.D) / ((-1) * this.A);
        public double GetY(double x, double z) => (this.A * x + this.C * z + this.D) / ((-1) * this.B);
        public double GetZ(double x, double y) => (this.A * x + this.B * y + this.D) / ((-1) * this.C);

        public PlaneEquation(Point a, Point b, Point c)
        {
            this.Init(a, b, c);
        }

        public void Recalibrate(Point a, Point b, Point c)
        {
            this.Init(a, b, c);
        }

        private void Init(Point a, Point b, Point c)
        {
            this.A = (b.Y - a.Y) * (c.Z - a.Z) - (c.Y - a.Y) * (b.Z - a.Z);
            this.B = (b.Z - a.Z) * (c.X - a.X) - (c.Z - a.Z) * (b.X - a.X);
            this.C = (b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y);

            this.D = (-1) * (this.A * a.X + this.B * a.Y + this.C * a.Z);
        }
    }
}
