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
            this.Preview = new DirectBitmap(this.Width, this.Height);
            this.Main = new DirectBitmap(this.Width, this.Height);
        }

        public void Refresh()
        {
            this.CanvasWrapper.Invalidate();
            this.CanvasWrapper.Update();
        }

        public void PutPixel(Point p, Color c) => ModifyGraphics((Graphics g) => g.FillEllipse(new SolidBrush(c), p.X - Printer.VertexRadius, p.Y - Printer.VertexRadius, 2 * Printer.VertexRadius + 1, 2 * Printer.VertexRadius + 1));
        public void PrintLine(Point p1, Point p2, Color c) => ModifyGraphics((Graphics g) => g.DrawLine(new Pen(c), p1, p2));

        private void ModifyGraphics(Action<Graphics> how)
        {
            Graphics g = Graphics.FromImage(this.CurrentBitmap.Bitmap);

            how(g);
            g.Flush();
        }

        public void PrintDebug(String debugMsg, Point p)
        {
            if (Printer.DEBUG == 1)
                this.ModifyGraphics((Graphics g) => g.DrawString(debugMsg, SystemFonts.DefaultFont, Brushes.Black, p));
        }
    }
}
