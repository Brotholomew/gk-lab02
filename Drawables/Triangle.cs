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

        public (Point A, Point B, Point C) GetPoints()
        {
            Point A = Point.Empty, B = Point.Empty, C = Point.Empty;

            foreach (var v in this.Vertices)
            {
                if (A._Empty)
                    A = v.Center;
                else if (B._Empty)
                    B = v.Center;
                else if (C._Empty)
                    C = v.Center;
            }
            
            return (A, B, C);
        }

        public (Color cA, Color cB, Color cC) GetColors()
        {
            Color cA = Color.Empty, cB = Color.Empty, cC = Color.Empty;
            foreach (var v in this.Vertices)
            {
                if (cA == Color.Empty)
                    cA = v.Color;
                else if (cB == Color.Empty)
                    cB = v.Color;
                else if (cC == Color.Empty)
                    cC = v.Color;
            }

            return (cA, cB, cC);
        }

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
            this.AreaCalculated = false;
            this.PlaneCalculated = false;
        }
    }
}
