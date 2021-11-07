using System;
using System.Collections.Generic;
using System.Text;
using DelaunatorSharp;

namespace lab02
{
    public partial class Designer
    {
        public void TriangulateSphere(int points)
        {
            this.Blank();

            var temp = Designer.Instance.FibonacciSphere(points).ConvertAll((Point p) => new Vertex(p));
            Designer.Instance.Triangulate(temp);
            Designer.Instance.Printer.Refresh();
        }

        public void Triangulate(HashSet<Vertex> vertices)
        {
            Delaunator d = new Delaunator(vertices.ConvertAll((Vertex v) => (IPoint)v.Center).ToArray());
            Dictionary<IPoint, Vertex> tempMap = new Dictionary<IPoint, Vertex>();

            d.ForEachTriangle((ITriangle t) =>
            {
                Triangle nt = new Triangle();
                HashSet<Vertex> temp = new HashSet<Vertex>();

                foreach (var p in t.Points)
                {
                    Vertex v = null;

                    if (tempMap.ContainsKey(p))
                        v = tempMap[p];
                    else
                    {
                        v = new Vertex(p);
                        tempMap.Add(p, v);
                    }

                    v.AdjacentDrawables.Add(nt);
                    temp.Add(v);
                }

                nt.AdjacentDrawables.UnionWith(temp);

                this.AddToMain(nt);
                nt.Print(Designer.Instance.PrintToMain);
            });
        }
    }
}
