using System;
using System.Collections.Generic;
using System.Text;

namespace lab02
{
    public class V3
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public double Abs 
        {
            get 
            {
                if (!this.AbsInitialized)
                    this.CalculateAbs();

                return this._Abs;
            }
        }

        public V3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            this.CalculateAbs();
        }

        public V3(Point p1, Point p2)
        {
            this.X = p2.X - p1.X;
            this.Y = p2.Y - p1.Y;
            this.Z = p2.Z - p1.Z;

            this.CalculateAbs();
        }

        public void Normalize()
        {
            double a = this.Abs;
            this.X /= a;
            this.Y /= a;
            this.Z /= a;

            this._Abs = 1;
        }

        public static double DotProduct(V3 v1, V3 v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

        public static double Angle(V3 v1, V3 v2)  => Math.Acos(V3.DotProduct(v1, v2) / (v1.Abs * v2.Abs));

        public static double Cosine(V3 v1, V3 v2) => V3.DotProduct(v1, v2) / (v1.Abs * v2.Abs);

        private void CalculateAbs() => this._Abs = Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2) + Math.Pow(this.Z, 2));
        private bool AbsInitialized = false;
        private double _Abs;
    }
}
