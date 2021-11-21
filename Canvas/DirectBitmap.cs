using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace lab02
{
    // source: https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height) => this.Init(width, height);

        public DirectBitmap(Image image)
        {
            Bitmap tmp = new Bitmap(image, Designer.Instance.Printer.Width, Designer.Instance.Printer.Height);
            this.Init(tmp.Width, tmp.Height);
            this.CopyPixels(tmp);
        }

        private void CopyPixels(Bitmap image)
        {
            for (int i = 0; i < this.Width; i++)
                for (int j = 0; j < this.Height; j++)
                    this.SetPixel(i, j, image.GetPixel(i, j));
        }

        private void Init(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            if (index < 0 || index >= this.Width * this.Height)
                return;

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
