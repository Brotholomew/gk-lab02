using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace lab02
{
    public sealed class ImageComboBox : ComboBox
    {
        public ImageComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            e.DrawFocusRectangle();

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                DropDownItem item = (DropDownItem)Items[e.Index];

                e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);

                e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);
            }

            base.OnDrawItem(e);
        }
    }

    public sealed class DropDownItem
    {
        public string Value { get; set; }

        public Image Image { get; set; }

        public Image RealImage { get; set; }

        public bool IsTexture = false;

        public bool IsDummy = false;

        public bool Choose = false;

        public DropDownItem()
            : this("")
        { }

        public DropDownItem(string val)
        {
            Value = val;
            Image = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(Image))
            {
                using (Brush b = new SolidBrush(Color.FromName(val)))
                {
                    g.DrawRectangle(Pens.White, 0, 0, Image.Width, Image.Height);
                    g.FillRectangle(b, 1, 1, Image.Width - 1, Image.Height - 1);
                }
            }
        }

        public DropDownItem(string value, Image image)
        {
            this.Value = value;
            this.RealImage = image;
            Image = new Bitmap(16, 16);

            using (Graphics g = Graphics.FromImage(this.Image))
            {
                g.DrawImage(this.RealImage, 0, 0, 16, 16);
                g.Dispose();
            }

            this.IsTexture = true;
        }

        public override string ToString()
        {
            return Value;
        }

        public static DropDownItem Dummy(string str)
        {
            DropDownItem item = new DropDownItem();
            item.Value = str;
            item.IsDummy = true;
            
            return item;
        }

        public static DropDownItem ChooseItem(string str)
        {
            DropDownItem item = new DropDownItem();
            item.Value = str;
            item.Choose = true;

            return item;
        }
    }
}
