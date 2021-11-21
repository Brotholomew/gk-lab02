using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public static class Functors
    {
        public static Point DistanceVector(Point start, Point end) => new Point(end.X - start.X, end.Y - start.Y, end.Z - start.Z);
        
        public static double CalculateTriangleArea(Triangle t)
        {
            var tmp = t.GetPoints();
            return CalculateTriangleArea(tmp.A, tmp.B, tmp.C);
        }

        public static double CalculateTriangleArea(Point A, Point B, Point C) => 0.5 * (A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y));
    }

}
