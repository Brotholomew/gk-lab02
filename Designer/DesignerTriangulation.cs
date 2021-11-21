using System;
using System.Collections.Generic;
using System.Text;

namespace lab02
{
    public partial class Designer
    {
        public void TriangulateSphere(int points)
        {
            this.Blank();
            this.Triangulate(points);
            this.Printer.Refresh();
        }

        // source: https://www.codeproject.com/Articles/8238/Polygon-Triangulation-in-C
        private void Triangulate(double accuracy)
        {
            int count = (int)accuracy * 2;
            double steps = (double) Math.PI / (double) accuracy;

            Vertex[,] verticesList = new Vertex[(int)accuracy + 1, count + 1];
            Dictionary<(int, int), Vertex> repeatedVertices = new Dictionary<(int, int), Vertex>();

            for (int tita = 0; tita <= accuracy; tita++)
            {
                double vtita = (double)tita * steps;

                for (int nphi = (-1) * (int)accuracy; nphi <= accuracy; nphi++)
                {
                    double vphi = (double)nphi * steps;
                    
                    double x = Math.Sin(vtita) * Math.Cos(vphi);
                    double y = Math.Sin(vtita) * Math.Sin(vphi);
                    double z = Math.Cos(vtita);

                    this.Translate(ref x, 300, 300);
                    this.Translate(ref y, 300, 300);
                    this.Translate(ref z, 300, 0);

                    Vertex v = new Vertex(new Point(x, y, z));

                    // merge the same vertices that appear twice as first and last vertices
                    if (((y <= 301 && y >= 299) && x <= 300) &&
                        !repeatedVertices.ContainsKey(((int)x, (int)y)) &&
                        !repeatedVertices.ContainsKey(((int)x, (int)y - 1)) &&
                        !repeatedVertices.ContainsKey(((int)x, (int)y + 1)))
                        repeatedVertices.Add(((int)x, (int)y), v);
                    else if ((y <= 301 && y >= 299) && x <= 300)
                    {
                        if (repeatedVertices.ContainsKey(((int)x, (int)y)))
                            v = repeatedVertices[((int)x, (int)y)];
                        else if (repeatedVertices.ContainsKey(((int)x, (int)y - 1)))
                            v = repeatedVertices[((int)x, (int)y - 1)];
                        else if (repeatedVertices.ContainsKey(((int)x, (int)y + 1)))
                            v = repeatedVertices[((int)x, (int)y + 1)];
                    }

                    verticesList[tita, nphi + (int)accuracy] = v;
                }
            }

            for (int n_tita = 1; n_tita <= verticesList.GetLength(0) - 1; n_tita++)
            {
                for (int n_phi = 0; n_phi <= verticesList.GetLength(1) - 2; n_phi++)
                {
                    Vertex v11 = verticesList[n_tita, n_phi], v12 = verticesList[n_tita, n_phi + 1], v13 = verticesList[n_tita - 1, n_phi];
                    Vertex v21 = verticesList[n_tita, n_phi + 1], v22 = verticesList[n_tita - 1, n_phi + 1], v23 = verticesList[n_tita - 1, n_phi];

                    if (v11.Center.Z >= 0 && v12.Center.Z >= 0 && v13.Center.Z >= 0 &&
                        !v11.Center.PlanarilyParallel(v12.Center) && !v11.Center.PlanarilyParallel(v13.Center) && !v12.Center.PlanarilyParallel(v13.Center))
                    {
                        Triangle t1 = new Triangle(new HashSet<Drawable> { v11, v12, v13 });
                        v11.AddTriangle(t1); v12.AddTriangle(t1); v13.AddTriangle(t1);
                        
                        t1.AddToMain();
                        t1.Print(Designer.Instance.PrintToMain);
                    }

                    if (v21.Center.Z >= 0 && v22.Center.Z >= 0 && v23.Center.Z >= 0 &&
                        !v21.Center.PlanarilyParallel(v22.Center) && !v21.Center.PlanarilyParallel(v23.Center) && !v22.Center.PlanarilyParallel(v23.Center))
                    {
                        Triangle t2 = new Triangle(new HashSet<Drawable> { v21, v22, v23 });
                        v21.AddTriangle(t2); v22.AddTriangle(t2); v23.AddTriangle(t2);
                        
                        t2.AddToMain();
                        t2.Print(Designer.Instance.PrintToMain);
                    }
                }
            }
        }

        private void Translate(ref double a, double radius, double shift)
        {
            a *= radius;
            a += shift;
            a = (int)a;
        }
    }
}
