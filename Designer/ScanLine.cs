using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public partial class Designer
    {
        public void ScanLine(Drawable d)
        {
            Triangle t = (Triangle)d;
            t.CalculatePlane();

            foreach (var v in t.Vertices)
                v.Color = this.CalculateColor((int)v.Center.X, (int)v.Center.Y, (int)v.Center.Z, t);

            t.InvalidateGraphics();

            (double ymin, double ymax, List<Vertex> vertices, var yvertices) = SortVertices(d);
            List<node> aet = new List<node>();

            for (double i = ymin + 1; i <= ymax; i++)
            {
                if (yvertices.ContainsKey(i - 1))
                {
                    List<(Vertex vertex, int index)> VertList = yvertices[i - 1];
                    foreach (var v in VertList)
                    {
                        this.UpdateAET(v.vertex, this.GetPrevious(v.index, vertices), ref aet);
                        this.UpdateAET(v.vertex, this.GetNext(v.index, vertices), ref aet);
                    }
                }
                
                this.HandleAET(ref aet, (int)i, t);
            }
        }

        private void HandleAET(ref List<node> aet, int y, Triangle t)
        {
            aet.Sort((node n1, node n2) => n1.X.CompareTo(n2.X));

            for (int i = 0; i < aet.Count - 1; i++)
                this.HorizontalLine(y, (int)aet[i].X, (int)aet[i + 1].X, t);

            for (int i = 0; i < aet.Count; i++)
                aet[i].X += aet[i].SlopeInverse;
        }

        private void UpdateAET(Vertex v, Vertex vx, ref List<node> aet)
        {
            node n = new node(vx.Center, v.Center, (int)v.Center.X);

            if (double.IsInfinity(n.SlopeInverse))
                return;

            if (vx.Center.Y >= v.Center.Y)
                aet.Add(n);
            else
                aet.RemoveAll((node nx) => { return nx.SlopeInverse == n.SlopeInverse && nx.YMax == n.YMax; });
        }

        private (double ymin, double ymax, List<Vertex> vertices, Dictionary<double, List<(Vertex vertex, int index)>> yvertices) SortVertices(Drawable d)
        {
            List<Vertex> vertices = d.AdjacentDrawables.ConvertAll((Drawable d) => (Vertex)d).ToList();
            Dictionary<double, List<(Vertex vertex, int index)>> yvertices = new Dictionary<double, List<(Vertex vertex, int index)>>();

            vertices.Sort((Vertex v1, Vertex v2) => v1.Center.Y.CompareTo(v2.Center.Y));
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertex v = vertices[i];
                if (yvertices.ContainsKey(v.Center.Y))
                    yvertices[v.Center.Y].Add((v, i));
                else
                    yvertices[v.Center.Y] = new List<(Vertex vertex, int index)> { (v, i) };
            }

            return (vertices[0].Center.Y, vertices[vertices.Count - 1].Center.Y, vertices, yvertices);
        }

        private Vertex GetPrevious(int idx, List<Vertex> vertices)
        {
            int previdx = idx == 0 ? vertices.Count - 1 : idx - 1;
            return vertices[previdx];
        }

        private Vertex GetNext(int idx, List<Vertex> vertices)
        {
            int nextidx = idx == vertices.Count - 1 ? 0 : idx + 1;
            return vertices[nextidx];
        }

        class node
        {
            public int YMax            { get; private set; }
            public double X            { get; set; }
            public double SlopeInverse { get; private set; }

            public node(Point p1, Point p2, int x)
            {
                this.YMax = p1.Y >= p2.Y ? (int)p1.Y : (int)p2.Y;
                this.X = x;

                (this.SlopeInverse, _) = LineSlopeEquation.CalculateLineSlopeEquation(p1, p2);
                this.SlopeInverse = 1.0 / this.SlopeInverse;
            }
        }
    }
}
