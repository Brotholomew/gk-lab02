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
        #region Constructors

        public Form1()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            Designer.Init(Canvas, this.AnimationTrackBar.TickFrequency, this.AnimationTrackBar);
            Designer.Instance.ICMBL = new ImageComboBoxLoader(this.TextureImageComboBox, this.LightColorComboBox, this.ObjectColorImageComboBox);

            ColorChanged(null, null);
            ScrollTriangulationDegreeTrackBar(null, null);
            ValueChangedAnimationTrackBar(null, null);
            ValueChangedKdScrollBar(null, null);
            ValueChangedKsScrollBar(null, null);
            ValueChangedMScrollBar(null, null);
            ValueChangedAnimationTrackBar(null, null);
            ValueChangedKScrollBar(null, null);
            CheckedChangedColorInterpolation(null, null);
            Designer.Instance.TriangulateSphere(TriangulationDegreeTrackBar.Value);

            this.AnimationClock = new Timer();
            AnimationClock.Interval = 10;
            AnimationClock.Tick += Designer.Instance.UpdateLightSourcePosition;
            AnimationClock.Start();
        }

        #endregion

        #region Paint Event

        private void PaintCanvas(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Designer.Instance.Printer.Main.Bitmap, 0, 0);
            e.Graphics.DrawImage(Designer.Instance.Printer.Preview.Bitmap, 0, 0);
        }

        #endregion

        #region Mouse Events

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

        #endregion

        #region Color Event

        private void ColorChanged(object sender, EventArgs e)
        {
            if (Designer.Instance.ICMBL != null)
                Designer.Instance.ICMBL.UpdateOptions();

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        #endregion

        #region Scroll Bars

        private void ScrollTriangulationDegreeTrackBar(object sender, EventArgs e)
        {
            Designer.Instance.TriangulateSphere(TriangulationDegreeTrackBar.Value);
            TriangulationDegreeTextBox.Text = TriangulationDegreeTrackBar.Value.ToString();
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
            Designer.Instance.AnimationAdvance();

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void ValueChangedKScrollBar(object sender, EventArgs e)
        {
            Designer.Instance.k = KTrackBar.Value / 1000.0;
            KTextBox.Text = (KTrackBar.Value / 1000.0).ToString();

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        #endregion

        #region Animation

        private Timer AnimationClock;
        private void ClickAnimationButton(object sender, EventArgs e)
        {
            if (this.AnimationClock.Enabled)
                this.AnimationClock.Stop();
            else
                this.AnimationClock.Start();
        }

        #endregion

        #region Check Boxes

        private void CheckedChangedColorInterpolation(object sender, EventArgs e)
        {
            Designer.Instance.ColorInterpolation = this.InterpolationCheckBox.Checked;

            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        private void SwitchGrid(object sender, EventArgs e)
        {
            Designer.Instance.EnableGrid = CheckBoxGrid.Checked;
            Designer.Instance.Reprint();
            Designer.Instance.Printer.Refresh();
        }

        #endregion
    }
}
