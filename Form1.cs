using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            Designer.Init(Canvas);
            ColorChanged(null, null);
            LightColorChanged(null, null);
            ScrollTriangulationDegreeTrackBar(null, null);
            ValueChangedAnimationTrackBar(null, null);
            ValueChangedKdScrollBar(null, null);
            ValueChangedKsScrollBar(null, null);
            ValueChangedMScrollBar(null, null);
            ValueChangedAnimationTrackBar(null, null);
            CheckedChangedColorInterpolation(null, null);
            Designer.Instance.TriangulateSphere(TriangulationDegreeTrackBar.Value);
        }

        private void PaintCanvas(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Designer.Instance.Printer.Main.Bitmap, 0, 0);
            e.Graphics.DrawImage(Designer.Instance.Printer.Preview.Bitmap, 0, 0);
        }

        private void ScrollTriangulationDegreeTrackBar(object sender, EventArgs e)
        {
            Designer.Instance.TriangulateSphere(TriangulationDegreeTrackBar.Value);
            TriangulationDegreeTextBox.Text = TriangulationDegreeTrackBar.Value.ToString();
        }

        private void MouseDownCanvas(object sender, MouseEventArgs e)
        {
            Designer.Instance.MouseDown(new Point(e.Location.X, e.Location.Y));
        }

        private void MouseUpCanvas(object sender, MouseEventArgs e)
        {
            Designer.Instance.MouseUp();
        }

        private void MouseMoveCanvas(object sender, MouseEventArgs e)
        {
            Designer.Instance.FollowMouse(new Point(e.Location.X, e.Location.Y), this);
        }

        private void ColorChanged(object sender, EventArgs e)
        {
            if (RadioButtonColorGreen.Checked)
                Designer.Instance.ChosenColor = Color.Green;
            else if (RadioButtonColorRed.Checked)
                Designer.Instance.ChosenColor = Color.Red;

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void ValueChangedKdScrollBar(object sender, EventArgs e)
        {
            double val = KdTrackBar.Value / 1000.0;

            Designer.Instance.kd = val;
            KdTextBox.Text = val.ToString();

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void ValueChangedKsScrollBar(object sender, EventArgs e)
        {
            double val = KsTrackBar.Value / 1000.0;
            
            Designer.Instance.ks = val;
            KsTextBox.Text = val.ToString();

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void ValueChangedMScrollBar(object sender, EventArgs e)
        {
            Designer.Instance.m = MTrackBar.Value;
            MTextBox.Text = MTrackBar.Value.ToString();

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void ValueChangedAnimationTrackBar(object sender, EventArgs e)
        {
            Designer.Instance.AnimationDegree = AnimationTrackBar.Value;

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void LightColorChanged(object sender, EventArgs e)
        {
            if (WhiteLightCheckBox.Checked)
                Designer.Instance.LightColor = Color.White;
            else if (RedLighgtCheckBox.Checked)
                Designer.Instance.LightColor = Color.Red;

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void ClickAnimationButton(object sender, EventArgs e)
        {

        }

        private void CheckedChangedColorInterpolation(object sender, EventArgs e)
        {
            Designer.Instance.ColorInterpolation = this.InterpolationCheckBox.Checked;
        }
    }
}
