using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public class Triangle : Drawable
    {
        public Triangle() : base(new HashSet<Drawable>()) { }
        public Triangle(HashSet<Drawable> vertices) : base(vertices) { }

        public HashSet<Vertex> Vertices { get => this.AdjacentDrawables.ConvertAll((Drawable d) => (Vertex)d); }

        private bool AreaCalculated = false;
        private double _Area;
        public double Area { get
            {
                if (!this.AreaCalculated)
                {
                    this.AreaCalculated = true;
                    this._Area = Functors.CalculateTriangleArea(this);
                }

                return this._Area;
            }
        }

        public void AddTriangle(Triangle t) => this.AdjacentDrawables.Add(t);

        public override void Delete() => Designer.Instance.DeleteTriangle(this);

        public override void Move(Action<Drawable> how)
        {
            this.ColorsCalculated = false;
            this.PointsCalculated = false;
            this.AreaCalculated = false;
            this.PlaneCalculated = false;

            how(this);
        }

        public override void Print(Action<Action> how)
        {
            how(() => Designer.Instance.DrawTriangle(this));
        }

        public override void Register() { }
        public override void Deregister() { }
        public override void AddToMain()
        {
            foreach (var v in this.Vertices)
                v.Register();

            Designer.Instance.MainContents.Add(this);
        }

        public void InvalidateGraphics() 
        {
            this.ColorsCalculated = false;
            this.PointsCalculated = false;
        }

        #region GetPoints

        private Point PointA;
        private Point PointB;
        private Point PointC;

        private bool PointsCalculated = false;

        public void CalculatePoints()
        {
            if (this.PointsCalculated)
                return;

            this.PointsCalculated = true;

            this.PointA = Point.Empty; this.PointB = Point.Empty; this.PointC = Point.Empty;

            foreach (var v in this.Vertices)
            {
                if (this.PointA._Empty)
                    this.PointA = v.Center;
                else if (this.PointB._Empty)
                    this.PointB = v.Center;
                else if (this.PointC._Empty)
                    this.PointC = v.Center;
            }
        }

        public (Point A, Point B, Point C) GetPoints()
        {
            if (!this.PointsCalculated)
                this.CalculatePoints();

            return (this.PointA, this.PointB, this.PointC);
        }

        #endregion

        #region GetColors

        private Color ColorB;
        private Color ColorC;
        private Color ColorA;

        private bool ColorsCalculated = false;

        public void CalculateColors()
        {
            if (this.ColorsCalculated)
                return;

            this.ColorsCalculated = true;

            this.ColorA = Color.Empty; this.ColorB = Color.Empty; this.ColorC = Color.Empty;

            foreach (var v in this.Vertices)
            {
                if (this.ColorA == Color.Empty)
                    this.ColorA = v.Color;
                else if (this.ColorB == Color.Empty)
                    this.ColorB = v.Color;
                else if (this.ColorC == Color.Empty)
                    this.ColorC = v.Color;
            }
        }

        public (Color cA, Color cB, Color cC) GetColors()
        {
            if (!this.ColorsCalculated)
                this.CalculateColors();

            return (this.ColorA, this.ColorB, this.ColorC);
        }

        #endregion

        #region Plane

        private bool PlaneCalculated = false;

        public double pA { get; private set; }
        public double pB { get; private set; }
        public double pC { get; private set; }
        public double pD { get; private set; }

        public void CalculatePlane()
        {
            if (this.PlaneCalculated)
                return;

            var (a, b, c) = this.GetPoints();

            this.pA = (b.Y - a.Y) * (c.Z - a.Z) - (c.Y - a.Y) * (b.Z - a.Z);
            this.pB = (b.Z - a.Z) * (c.X - a.X) - (c.Z - a.Z) * (b.X - a.X);
            this.pC = (b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y);
            this.pD = (-1) * (this.pA * a.X + this.pB * a.Y + this.pC * a.Z);
            
            this.PlaneCalculated = true;
        }

        public double GetZ(int x, int y) => (this.pA * x + this.pB * y + this.pD) / ((-1) * this.pC);

        #endregion

        // methods not implemented for Triangles
        public override void PreMove() { }
        public override void PostMove() { }
        public override void Move(Point p) 
        {
            this.ColorsCalculated = false;
            this.PointsCalculated = false;
            this.AreaCalculated = false;
            this.PlaneCalculated = false;
        }
    }
}
