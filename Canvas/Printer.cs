using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab02
{
    public class Printer
    {
        #region Private Fields

        private static readonly int VertexRadius = 3;
        private static readonly int DEBUG = 1;
        
        private DirectBitmap CurrentBitmap;
        private PictureBox CanvasWrapper;

        #endregion

        #region Implementation Specific Methods and Fields

        public DirectBitmap Preview { get; private set; }
        public DirectBitmap Main { get; private set; }

        public enum PrintMode { Preview, Main }
        public void SwitchBitmap(PrintMode how)
        {
            switch (how)
            {
                case PrintMode.Main:
                    this.CurrentBitmap = this.Main;
                    break;
                case PrintMode.Preview:
                    this.CurrentBitmap = this.Preview;
                    break;
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Blank()
        {
            if (this.Preview != null) this.Preview.Dispose();
            if (this.Main != null) this.Main.Dispose();

            this.Preview = new DirectBitmap(this.Width, this.Height);
            this.Main = new DirectBitmap(this.Width, this.Height);
        }

        public void ErasePreview()
        {
            if (this.Preview != null) this.Preview.Dispose();

            this.Preview = new DirectBitmap(this.Width, this.Height);
        }

        public void Refresh()
        {
            this.CanvasWrapper.Invalidate();
            this.CanvasWrapper.Update();
        }

        #endregion

        public Printer(int width, int height, PictureBox canvasWrapper)
        {
            this.Width = width;
            this.Height = height;

            this.Blank();
            this.CanvasWrapper = canvasWrapper;
        }

        #region Printing and Drawing

        public void PutPixel(Point p, Color c) => this.CurrentBitmap.SetPixel((int)p.X, (int)p.Y, c);
        public void PutVertex(Point p, Color c) => ModifyGraphics((Graphics g) => 
        {
            SolidBrush b = new SolidBrush(c);

            this._FillEllipse(p, c, g, b);
            b.Dispose();
        });
        public void PrintLine(Point p1, Point p2, Color c) => ModifyGraphics((Graphics g) =>
        {
            Pen p = new Pen(c);

            this._DrawLine(p1, p2, c, g, p);
            p.Dispose();
        });

        public void ModifyGraphics(Action<Graphics> how)
        {
            if (this.CurrentBitmap == null)
                return;

            Graphics g = Graphics.FromImage(this.CurrentBitmap.Bitmap);

            how(g);
            g.Flush();
        }

        public void _DrawLine(Point p1, Point p2, Color c, Graphics g, Pen p) => g.DrawLine(p, (int)p1.X, (int)p1.Y, (int)p2.X, (int)p2.Y);
            
        public void _FillEllipse(Point p, Color c, Graphics g, Brush b) => g.FillEllipse(b, (int)p.X - Printer.VertexRadius, (int)p.Y - Printer.VertexRadius, 2 * Printer.VertexRadius + 1, 2 * Printer.VertexRadius + 1);

        public void PrintDebug(String debugMsg, Point p)
        {
            if (Printer.DEBUG == 1)
                this.ModifyGraphics((Graphics g) => g.DrawString(debugMsg, SystemFonts.DefaultFont, Brushes.Black, p.GetPoint()));
        }

        #endregion
    }
}
