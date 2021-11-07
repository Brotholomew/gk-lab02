using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public class Vertex : Drawable
    {
        public Vertex(Point p) : base(new HashSet<Drawable>())
        {
            this.Center = p;
        }

        public Vertex(IPoint p) : base(new HashSet<Drawable>())
        {
            this.Center = (Point)p;
        }

        public Point Center { get; private set; }
        public HashSet<Triangle> Triangles { get => this.AdjacentDrawables.ConvertAll((Drawable d) => (Triangle)d); } 

        public void AddTriangle(Triangle t) => this.AdjacentDrawables.Add(t);

        public override void Move(Action<Drawable> how)
        {
            HashSet<Vertex> Vertices = new HashSet<Vertex>();

            foreach (var t in this.Triangles)
            {
                Vertices.UnionWith(t.Vertices);
                how(t);
            }

            Vertices.UnionWith(new HashSet<Vertex> { this });

            foreach (var v in Vertices)
                how(v);
        }

        public override void Print(Action<Action> how) => how(() => Designer.Instance.DrawVertex(this));

        public override void Register() => Designer.Instance.Register(this);
        public override void Deregister() => Designer.Instance.Deregister(this);
        public override void Delete() => Designer.Instance.DeleteVertex(this);
        public override void AddToMain()
        {
            this.Register();
            Designer.Instance.MainContents.Add(this);
        }

        public override void PreMove() 
        {
            this.MoveToPreview();

            HashSet<Vertex> Vertices = new HashSet<Vertex>();

            foreach (var t in this.Triangles)
            {
                Vertices.UnionWith(t.Vertices);
                t.Print(Designer.Instance.PrintToPreview);
            }

            foreach (var v in Vertices)
                v.Deregister();

            Designer.Instance.Printer.Blank();
            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        public override void PostMove() 
        {
            this.MoveToMain();

            HashSet<Vertex> Vertices = new HashSet<Vertex>();

            foreach (var t in this.Triangles)
            {
                Vertices.UnionWith(t.Vertices);
                t.Print(Designer.Instance.PrintToMain);
            }

            foreach (var v in Vertices)
                v.Register();
        
            Designer.Instance.Printer.Refresh();
        }

        public override void Move(Point p) 
        {
            this.Center = p;
            Designer.Instance.Printer.ErasePreview();

            foreach (var t in this.Triangles)
                t.Print(Designer.Instance.PrintToPreview);

            Designer.Instance.Printer.Refresh();
        }
    }
}
