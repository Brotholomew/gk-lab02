using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public class ImageComboBoxLoader
    {
        private ImageComboBox Textures;
        private ImageComboBox Light;

        public Bitmap ChosenTexture = null;
        public Color ChosenColor;
        public Color LightColor;

        private bool IsTexture = false;

        public ImageComboBoxLoader(ImageComboBox textures, ImageComboBox light)
        {
            this.Textures = textures;
            this.Light = light;

            this.Init();
        }

        public void AddNewTexture()
        {
            // todo
        }

        public void UpdateOptions()
        {
            DropDownItem item = (DropDownItem) this.Textures.SelectedItem;

            if (item.IsTexture)
            {
                this.IsTexture = true;
                this.ChosenTexture = new Bitmap(item.RealImage);
            } 
            else
            {
                this.IsTexture = false;
                this.ChosenColor = Color.FromName(item.Value);
            }

            item = (DropDownItem)this.Light.SelectedItem;
            this.LightColor = Color.FromName(item.Value);
        }

        public Color GetColor(int _x, int _y, int _z)
        {
            if (this.IsTexture)
            {
                int x = (this.ChosenTexture.Width - 1) * _x / Designer.Instance.Printer.Width;
                int y = (this.ChosenTexture.Height - 1) * _y / Designer.Instance.Printer.Height;

                return this.ChosenTexture.GetPixel(x, y);
            }

            return this.ChosenColor;
        }

        public Point GetVector(int x, int y, int z)
        {
            //todo
            Color c = this.GetColor(x, y, z);
            return new Point(c.R, c.G, c.B);
        }

        private void Init()
        {
            this.LoadLightColors();
            this.LoadObjectColors();
            this.LoadObjectTextures();

            this.Textures.SelectedIndex = 0;
            this.Light.SelectedIndex = 0;
        }

        private void LoadObjectColors()
        {
            this.Textures.Items.Add(new DropDownItem("Red"));
            this.Textures.Items.Add(new DropDownItem("Green"));
            this.Textures.Items.Add(new DropDownItem("Blue"));
        }

        private void LoadLightColors()
        {
            this.Light.Items.Add(new DropDownItem("White"));
        }

        private void LoadObjectTextures()
        {
            this.Textures.Items.Add(new DropDownItem("Bricks", Image.FromFile("Resources\\Textures\\bricks.jpg")));
        }
    }
}
