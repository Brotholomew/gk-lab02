using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace lab02
{
    public class ImageComboBoxLoader
    {
        private ImageComboBox Textures;
        private ImageComboBox Light;
        private ImageComboBox ObjectColor;

        public DirectBitmap ChosenTexture = null;
        public DirectBitmap ChosenImage = null;
        public Color ChosenColor;
        public Color LightColor;

        private bool IsTexture = false;

        public ImageComboBoxLoader(ImageComboBox textures, ImageComboBox light, ImageComboBox objectColor)
        {
            this.Textures = textures;
            this.Light = light;
            this.ObjectColor = objectColor;

            this.Init();
        }

        public void UpdateOptions()
        {
            DropDownItem item = (DropDownItem) this.ObjectColor.SelectedItem;

            if (item.IsDummy)
            {
                
            }
            else if (item.Choose)
            {
                if (item.Value == "Choose color ...")
                    this.ChooseColor(this.ObjectColor);
                else
                    this.ChooseTexture(this.ObjectColor);

            }
            else
            {
                if (item.IsTexture)
                {
                    this.IsTexture = true;
                    this.ChosenImage = new DirectBitmap(item.RealImage);
                }
                else
                {
                    this.IsTexture = false;
                    this.ChosenColor = item.Color;
                }
            }


            item = (DropDownItem)this.Textures.SelectedItem;
            if (item.IsDummy) { this.ChosenTexture = null; }
            else if (item.Choose)
                this.ChooseTexture(this.Textures);
            else
            {
                this.ChosenTexture = new DirectBitmap(item.RealImage);
            }


            item = (DropDownItem)this.Light.SelectedItem;
            if (item.IsDummy) { }
            else if (item.Choose)
                this.ChooseColor(this.Light);
            else
                this.LightColor = item.Color;
        }

        private void ChooseColor(ImageComboBox wrapper)
        {
            Color tmp = Color.Empty;

            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.ShowHelp = false;
                colorDialog.Color = this.ChosenColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    tmp = colorDialog.Color;
                }
            }


            if (tmp == Color.Empty)
            {
                wrapper.SelectedIndex = 0;
                this.UpdateOptions();
            }
            else
            {
                wrapper.Items.Insert(0, new DropDownItem(tmp.Name, tmp));
                wrapper.SelectedIndex = 0;
                this.UpdateOptions();
            }
        }

        private void ChooseTexture(ImageComboBox wrapper)
        {
            Bitmap tmp = null;
            string fileName = ""; 

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = System.IO.Path.Combine(Application.StartupPath, "Resources");
                fileDialog.Title = "Choose texture";
                fileDialog.Filter = "Graphic files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    tmp = new Bitmap(fileDialog.FileName);
                    fileName = fileDialog.FileName;
                }
            }

            if (tmp == null)
            {
                wrapper.SelectedIndex = 0;
                this.UpdateOptions();
            } else
            {
                wrapper.Items.Insert(wrapper.Items.Count - 1, new DropDownItem(fileName, tmp));
                wrapper.SelectedIndex = wrapper.Items.Count - 2;
                this.UpdateOptions();
            }
        }

        public Color GetColor(int _x, int _y, int _z)
        {
            if (this.IsTexture)
            {
                int x = (this.ChosenImage.Width - 1) * _x / Designer.Instance.Printer.Width;
                int y = (this.ChosenImage.Height - 1) * _y / Designer.Instance.Printer.Height;

                return this.ChosenImage.GetPixel(x, y);
            }

            return this.ChosenColor;
        }

        public (double L_X, double L_Y, double L_Z) GetNormalVector(int x, int y, double L_X, double L_Y, double L_Z, double k)
        {
            if (this.ChosenTexture != null)
            {
                var (b1, b2, b3) = CrossProduct(L_X, L_Y, L_Z, 0, 0, 1);
                var (t1, t2, t3) = CrossProduct(b1, b2, b3, L_X, L_Y, L_Z);

                x = Math.Max(x, 0); x = Math.Min(x, 599);
                y = Math.Max(y, 0); y = Math.Min(y, 599);

                Color c = this.ChosenTexture.GetPixel(x, y);

                double V_X = Transform(c.R);
                double V_Y = Transform(c.G);
                double V_Z = Transform(c.B);

                double v1 = (1 - k) * V_X;
                double v2 = (1 - k) * V_Y;
                double v3 = (1 - k) * V_Z;

                L_X = k * L_X + v1 * t1 + v2 * b1 + v3 * L_X;
                L_Y = k * L_Y + v1 * t2 + v2 * b2 + v3 * L_Y;
                L_Z = k * L_Z + v1 * t3 + v2 * b3 + v3 * L_Z;
            }

            return (L_X, L_Y, L_Z);
        }

        private (double x, double y, double z) CrossProduct(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return (y1 * z2 - y2 * z1, z1 * x2 - z2 * x1, z1 * y2 - x2 * y1);
        }

        private double Transform(double v)
        {
            v -= 127;
            v /= 127;
            v = Math.Min(v, 1);
            v = Math.Max(v, -1);

            return v;
        }

        private void Init()
        {
            this.LoadLightColors();
            this.LoadObjectColors();
            this.LoadObjectTextures();
            this.LoadTextures();

            this.Textures.SelectedIndex = 0;
            this.Light.SelectedIndex = 0;
            this.ObjectColor.SelectedIndex = 0;
        }

        private void LoadObjectColors()
        {
            this.ObjectColor.Items.Add(new DropDownItem("Red"));
            this.ObjectColor.Items.Add(new DropDownItem("Green"));
            this.ObjectColor.Items.Add(new DropDownItem("Blue"));
        }

        private void LoadLightColors()
        {
            this.Light.Items.Add(new DropDownItem("White"));
            this.Light.Items.Add(DropDownItem.ChooseItem("Choose color ..."));
        }

        private void LoadObjectTextures()
        {
            this.ObjectColor.Items.Add(new DropDownItem("Bricks", Image.FromFile("Resources\\Textures\\bricks_img.jpg")));
            this.ObjectColor.Items.Add(new DropDownItem("Thatched", Image.FromFile("Resources\\Textures\\thatched_img.jpg")));
            this.ObjectColor.Items.Add(new DropDownItem("Metal", Image.FromFile("Resources\\Textures\\metal_img.jpg")));
            this.ObjectColor.Items.Add(new DropDownItem("Stones", Image.FromFile("Resources\\Textures\\stones.gif")));
            this.ObjectColor.Items.Add(DropDownItem.ChooseItem("Choose color ..."));
            this.ObjectColor.Items.Add(DropDownItem.ChooseItem("Choose texture ..."));
        }

        private void LoadTextures()
        {
            this.Textures.Items.Add(DropDownItem.Dummy("No texture"));
            this.Textures.Items.Add(new DropDownItem("Bricks", Image.FromFile("Resources\\Textures\\bricks.jpg")));
            this.Textures.Items.Add(new DropDownItem("Thatched", Image.FromFile("Resources\\Textures\\thatched.jpg")));
            this.Textures.Items.Add(new DropDownItem("Metal", Image.FromFile("Resources\\Textures\\metal.jpg")));
            this.Textures.Items.Add(new DropDownItem("Stones", Image.FromFile("Resources\\Textures\\stones.gif")));
            this.Textures.Items.Add(DropDownItem.ChooseItem("Choose texture ..."));
        }
    }
}
