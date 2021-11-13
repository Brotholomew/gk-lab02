using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab02
{
    public class Printer
    {
        private static readonly int VertexRadius = 3;
        private static readonly int DEBUG = 1;
        public DirectBitmap Preview { get; private set; }
        public DirectBitmap Main    { get; private set; }
        
        private DirectBitmap CurrentBitmap;
        private PictureBox CanvasWrapper;

        public enum PrintMode { Preview, Main }
        public void SwitchBitmap(PrintMode how)
        {
            switch(how)
            {
                case PrintMode.Main:
                    this.CurrentBitmap = this.Main;
                    break;
                case PrintMode.Preview:
                    this.CurrentBitmap = this.Preview;
                    break;
            }
        }

        public int Width  { get; private set; }
        public int Height { get; private set; }

        public Printer(int width, int height, PictureBox canvasWrapper)
        {
            this.Width = width;
            this.Height = height;

            this.Blank();
            this.CanvasWrapper = canvasWrapper;
        }

        public void Blank()
        {
            if (this.Preview != null) this.Preview.Dispose();
            if (this.Main != null) this.Main.Dispose();   
            
            this.Preview = new DirectBitmap(this.Width, this.Height);
            this.Main = new DirectBitmap(this.Width, this.Height);
        }

        public void ErasePreview() => this.Preview = new DirectBitmap(this.Width, this.Height);

        public void Refresh()
        {
            this.CanvasWrapper.Invalidate();
            this.CanvasWrapper.Update();
        }

        public void PutPixel(Point p, Color c) => this.CurrentBitmap.SetPixel((int)p.X, (int)p.Y, c);
        public void PutVertex(Point p, Color c) => ModifyGraphics((Graphics g) => 
        {
            SolidBrush b = new SolidBrush(c);
            g.FillEllipse(b, (int)p.X - Printer.VertexRadius, (int)p.Y - Printer.VertexRadius, 2 * Printer.VertexRadius + 1, 2 * Printer.VertexRadius + 1);
            b.Dispose();
        });
        public void PrintLine(Point p1, Point p2, Color c) => ModifyGraphics((Graphics g) =>
        {
            Pen p = new Pen(c);
            g.DrawLine(p, (int)p1.X, (int)p1.Y, (int)p2.X, (int)p2.Y);
            p.Dispose();
        });

        //public void PrintLine(Point p1, Point p2, Color c)
        //{
        //    Graphics g = Graphics.FromImage(this.CurrentBitmap.Bitmap);
        //    g.DrawLine(new Pen(c), (int)p1.X, (int)p1.Y, (int)p2.X, (int)p2.Y);
        //    g.Flush();
        //}

        //public void PrintLine(int p1x, int p1y, int p2x, int p2y, Color c)
        //{
        //    Graphics g = Graphics.FromImage(this.CurrentBitmap.Bitmap);
        //    g.DrawLine(new Pen(c), p1x, p1y, p2x, p2y);
        //    g.Flush();
        //}

        private void ModifyGraphics(Action<Graphics> how)
        {
            Graphics g = Graphics.FromImage(this.CurrentBitmap.Bitmap);

            how(g);
            g.Flush();
        }

        public void PrintDebug(String debugMsg, Point p)
        {
            if (Printer.DEBUG == 1)
                this.ModifyGraphics((Graphics g) => g.DrawString(debugMsg, SystemFonts.DefaultFont, Brushes.Black, p.GetPoint()));
        }
    }
}
