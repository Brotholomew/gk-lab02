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

            Designer.Init(Canvas);
            ColorChanged(null, null);
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
        }

        private void MouseDownCanvas(object sender, MouseEventArgs e)
        {
            Designer.Instance.MouseDown(e.Location);
        }

        private void MouseUpCanvas(object sender, MouseEventArgs e)
        {
            Designer.Instance.MouseUp();
        }

        private void MouseMoveCanvas(object sender, MouseEventArgs e)
        {
            Designer.Instance.FollowMouse(e.Location, this);
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
    }
}
