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
          

        public void AddTriangle(Triangle t) => this.AdjacentDrawables.Add(t);

        public override void Delete() => Designer.Instance.DeleteTriangle(this);

        public override void Move(Action<Drawable> how)
        {
            // triangles will not be moved in this project
            throw new NotImplementedException();
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

        // methods not implemented for Triangles
        public override void PreMove() { }
        public override void PostMove() { }
        public override void Move(Point p) { }
    }
}
