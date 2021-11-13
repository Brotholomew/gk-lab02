using System;
using System.Collections.Generic;
using System.Text;

namespace lab02
{
    public class CircleEquation
    {
        public Point Center { get; private set; }
        public double Radius { get; private set; }

        public CircleEquation(Point center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public double GetX(double y) => this.GetCoordinate(y, this.Center.X, this.Center.Y);
        public double GetY(double x) => this.GetCoordinate(x, this.Center.Y, this.Center.X);

        private double GetCoordinate(double given, double cSearched, double cGiven) => Math.Sqrt(Math.Pow(this.Radius, 2) - Math.Pow(given - cGiven, 2)) + cSearched; 
    }
}
