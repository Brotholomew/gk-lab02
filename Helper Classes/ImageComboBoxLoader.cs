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
                this.ChooseTexture(this.ObjectColor);
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
                    this.ChosenColor = Color.FromName(item.Value);
                }
            }


            item = (DropDownItem)this.Textures.SelectedItem;
            if (item.IsDummy) { this.ChosenTexture = null; }
            else if (item.Choose)
                this.ChooseTexture(this.Textures);
            else
                this.ChosenTexture = new DirectBitmap(item.RealImage);


            item = (DropDownItem)this.Light.SelectedItem;
            if (!item.IsDummy)
                this.LightColor = Color.FromName(item.Value);
        }

        private void ChooseTexture(ImageComboBox wrapper)
        {
            Bitmap tmp = null;
            string fileName = ""; 

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = Application.StartupPath + "/Resources/Textures";
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
                x = Math.Max(x, 0); x = Math.Min(x, 599);
                y = Math.Max(y, 0); y = Math.Min(y, 599);

                Color c = this.ChosenTexture.GetPixel(x, y);

                double V_X = Transform(c.R);
                double V_Y = Transform(c.G);
                double V_Z = Transform(c.B);

                L_X = k * L_X + (1 - k) * V_X;
                L_Y = k * L_Y + (1 - k) * V_Y;
                L_Z = k * L_Z + (1 - k) * V_Z;
            }

            return (L_X, L_Y, L_Z);
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
        }

        private void LoadObjectTextures()
        {
            this.ObjectColor.Items.Add(new DropDownItem("Bricks", Image.FromFile("Resources\\Textures\\bricks.jpg")));
            this.ObjectColor.Items.Add(new DropDownItem("Circle", Image.FromFile("Resources\\Textures\\circle.png")));
            this.ObjectColor.Items.Add(new DropDownItem("Hexagons", Image.FromFile("Resources\\Textures\\hexagons.jpg")));
            this.ObjectColor.Items.Add(new DropDownItem("Pattern", Image.FromFile("Resources\\Textures\\pattern.png")));
            this.ObjectColor.Items.Add(new DropDownItem("Stones", Image.FromFile("Resources\\Textures\\stones.gif")));
            this.ObjectColor.Items.Add(DropDownItem.ChooseItem("Choose texture ..."));
        }

        private void LoadTextures()
        {
            this.Textures.Items.Add(DropDownItem.Dummy("No texture"));
            this.Textures.Items.Add(new DropDownItem("Bricks", Image.FromFile("Resources\\Textures\\bricks.jpg")));
            this.Textures.Items.Add(new DropDownItem("Circle", Image.FromFile("Resources\\Textures\\circle.png")));
            this.Textures.Items.Add(new DropDownItem("Hexagons", Image.FromFile("Resources\\Textures\\hexagons.jpg")));
            this.Textures.Items.Add(new DropDownItem("Pattern", Image.FromFile("Resources\\Textures\\pattern.png")));
            this.Textures.Items.Add(new DropDownItem("Stones", Image.FromFile("Resources\\Textures\\stones.gif")));
            this.Textures.Items.Add(DropDownItem.ChooseItem("Choose texture ..."));
        }
    }
}
