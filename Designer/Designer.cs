using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab02
{
    public partial class Designer
    {
        #region Singleton Fields
        
        public static Designer Instance { get; private set; }
        
        public static void Init(PictureBox canvasWrapper)
        {
            Designer.Instance = new Designer(canvasWrapper);
        }

        #endregion

        #region Private Fields and Methods

        private Designer(PictureBox canvasWrapper)
        {
            this.Printer = new Printer(canvasWrapper.Width, canvasWrapper.Height, canvasWrapper);
            this.Blank();
        }

        private void Blank()
        {
            this.Printer.Blank();
            this.PreviewContents = new HashSet<Drawable>();
            this.MainContents = new HashSet<Drawable>();
            this.DrawablesMap = new Dictionary<Point, List<Drawable>>();
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

        #endregion

        #region Public Fields and Methods

        public Printer Printer                                { get; private set; }
        public HashSet<Drawable> PreviewContents              { get; private set; }
        public HashSet<Drawable> MainContents                 { get; private set; }
        public Dictionary<Point, List<Drawable>> DrawablesMap { get; private set; }

        public void DrawVertex(Vertex v) => this.Printer.PutPixel(v.Center, Color.Black);

        public void DrawTriangle(Triangle t)
        {
            List<Vertex> temp = new List<Vertex>();
            
            foreach (var v in t.Vertices)
            {
                temp.Add(v);
                this.DrawVertex(v);
            }

            for (int i = 0; i < temp.Count - 1; i++)
                this.Printer.PrintLine(temp[i].Center, temp[i + 1].Center, Color.Black);
        }

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
            if (!this.DrawablesMap.ContainsKey(v.Center))
                this.DrawablesMap[v.Center] = new List<Drawable> { v };
            else
                if (!this.DrawablesMap[v.Center].Contains(v)) this.DrawablesMap[v.Center].Add(v);
        }

        public void Deregister(Vertex v)
        {
            if (this.DrawablesMap.ContainsKey(v.Center))
                this.DrawablesMap[v.Center].Remove(v);
        }


        public void Reprint()
        {
            Printer.Blank();

            foreach (var d in this.PreviewContents)
                d.Print(this.PrintToPreview);

            foreach (var d in this.MainContents)
                d.Print(this.PrintToMain);

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
