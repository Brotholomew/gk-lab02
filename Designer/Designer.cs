using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02
{
    public partial class Designer
    {
        #region Singleton Fields
        
        public static Designer Instance { get; private set; }
        
        public static void Init(PictureBox canvasWrapper, double animationTick, TrackBar at)
        {
            Designer.Instance = new Designer(canvasWrapper, animationTick, at);
        }

        #endregion

        #region Private Fields and Methods

        private Designer(PictureBox canvasWrapper, double animationTick, TrackBar at)
        {
            this.Printer = new Printer(canvasWrapper.Width, canvasWrapper.Height, canvasWrapper);
            this.Blank();
            this.AnimationTick = animationTick;
            this.AnimationTrackBar = at;
        }

        private void Blank()
        {
            this.Printer.Blank();
            this.PreviewContents = new HashSet<Drawable>();
            this.MainContents = new HashSet<Drawable>();
            this.DrawablesMap = new Dictionary<System.Drawing.Point, List<Drawable>>();
        }

        private void Move(HashSet<Drawable> set1, HashSet<Drawable> set2, Drawable d)
        {
            if (set1.Contains(d))
                set1.Remove(d);

            if (!set2.Contains(d))
                set2.Add(d);
        }

        private void Remove(Drawable d)
        {
            if (this.PreviewContents.Contains(d))
                this.PreviewContents.Remove(d);

            if (this.MainContents.Contains(d))
                this.MainContents.Remove(d);
        }

        private void DrawPerimiter(Triangle t)
        {
            if (!this.EnableGrid) return;

            List<Vertex> temp = new List<Vertex>();

            foreach (var v in t.Vertices)
            {
                temp.Add(v);
                this.DrawVertex(v);
            }

            for (int i = 0; i < temp.Count; i++)
            {
                this.Printer.PrintLine(temp[i % (temp.Count)].Center, temp[(i + 1) % temp.Count].Center, Color.Black);
            }
        }

        private void DrawPerimiters(HashSet<Drawable> ld)
        {
            if (!this.EnableGrid) return;

            this.Printer.ModifyGraphics((Graphics gx) =>
            {
                foreach (var d in ld)
                {
                    List<Vertex> temp = new List<Vertex>();
                    Triangle t = (Triangle)d;

                    foreach (var v in t.Vertices)
                    {
                        temp.Add(v);
                        this.Printer._FillEllipse(v.Center, Color.Black, gx, Brushes.Black);
                    }

                    for (int i = 0; i < temp.Count; i++)
                        this.Printer._DrawLine(temp[i % (temp.Count)].Center, temp[(i + 1) % temp.Count].Center, Color.Black, gx, Pens.Black);
                }
            });
        }

        #endregion

        #region Public Fields and Methods

        public Printer Printer                                { get; private set; }
        public HashSet<Drawable> PreviewContents              { get; private set; }
        public HashSet<Drawable> MainContents                 { get; private set; }
        public Dictionary<System.Drawing.Point, List<Drawable>> DrawablesMap { get; private set; }

        public void DrawVertex(Vertex v) => this.Printer.PutVertex(v.Center, Color.Black);

        public void DrawTriangle(Triangle t)
        {
            this.FillPoly(t);
            this.DrawPerimiter(t);
        }

        public bool EnableGrid = false;

        public void MoveToPreview(Drawable d)
        {
            this.Move(this.MainContents, this.PreviewContents, d);
            d.Deregister();
        }

        public void MoveToMain(Drawable d)
        {
            this.Move(this.PreviewContents, this.MainContents, d);
            d.Register();
        }

        public void AddToMain(Drawable d) => d.AddToMain();

        public void AddToMain(HashSet<Drawable> collection)
        {
            foreach (var element in collection)
                this.AddToMain(element);
        }
        
        public void Register(Vertex v)
        {
            if (!this.DrawablesMap.ContainsKey(v.Center.GetPoint()))
                this.DrawablesMap[v.Center.GetPoint()] = new List<Drawable> { v };
            else
                if (!this.DrawablesMap[v.Center.GetPoint()].Contains(v)) this.DrawablesMap[v.Center.GetPoint()].Add(v);
        }

        public void Deregister(Vertex v)
        {
            if (this.DrawablesMap.ContainsKey(v.Center.GetPoint()))
                this.DrawablesMap[v.Center.GetPoint()].Remove(v);
        }

        public void Reprint()
        {
            this.Printer.Blank();

            Parallel.ForEach(this.MainContents, (Drawable d) => this.PrintToMain(() => this.FillPoly(d)));
            Parallel.ForEach(this.PreviewContents, (Drawable d) => this.PrintToPreview(() => this.FillPoly(d)));

            this.PrintToMain(() => this.DrawPerimiters(this.MainContents));
            this.PrintToPreview(() => this.DrawPerimiters(this.PreviewContents));
        }

        public void PrintToPreview(Action what)
        {
            this.Printer.SwitchBitmap(Printer.PrintMode.Preview);
            what.Invoke();
        }

        public void PrintToMain(Action what)
        {
            this.Printer.SwitchBitmap(Printer.PrintMode.Main);
            what.Invoke();
        }

        public void Delete(Drawable d) => d.Delete();

        public void DeleteVertex(Vertex v)
        {
            this.Remove(v);
            this.Deregister(v);
        }

        public void DeleteTriangle(Triangle t)
        {
            foreach (var v in t.Vertices)
                v.Delete();

            this.Remove(t);
        }

        #endregion
    }
}
