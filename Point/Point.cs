using System;
using System.Collections.Generic;
using System.Text;

namespace lab02
{
    public struct Point : IPoint
    {
        public bool _Empty { get; private set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point(double x, double y, double z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this._Empty = false;
        }

        public Point(bool empty)
        {
            this.X = this.Y = this.Z = double.NegativeInfinity;
            this._Empty = true;
        }

        public System.Drawing.Point GetPoint() => new System.Drawing.Point((int)this.X, (int)this.Y);
 
        public static Point Empty { get { return new Point(true); } }
    }

}
