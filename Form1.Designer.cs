
namespace lab02
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.TriangulationDegreeTrackBar = new System.Windows.Forms.TrackBar();
            this.TriangulationDegreeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriangulationDegreeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(600, 600);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintCanvas);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownCanvas);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCanvas);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpCanvas);
            // 
            // TriangulationDegreeTrackBar
            // 
            this.TriangulationDegreeTrackBar.Location = new System.Drawing.Point(606, 40);
            this.TriangulationDegreeTrackBar.Maximum = 5000;
            this.TriangulationDegreeTrackBar.Minimum = 500;
            this.TriangulationDegreeTrackBar.Name = "TriangulationDegreeTrackBar";
            this.TriangulationDegreeTrackBar.Size = new System.Drawing.Size(307, 45);
            this.TriangulationDegreeTrackBar.TabIndex = 1;
            this.TriangulationDegreeTrackBar.TickFrequency = 10;
            this.TriangulationDegreeTrackBar.Value = 500;
            this.TriangulationDegreeTrackBar.ValueChanged += new System.EventHandler(this.ScrollTriangulationDegreeTrackBar);
            // 
            // TriangulationDegreeLabel
            // 
            this.TriangulationDegreeLabel.AutoSize = true;
            this.TriangulationDegreeLabel.Location = new System.Drawing.Point(621, 22);
            this.TriangulationDegreeLabel.Name = "TriangulationDegreeLabel";
            this.TriangulationDegreeLabel.Size = new System.Drawing.Size(116, 15);
            this.TriangulationDegreeLabel.TabIndex = 2;
            this.TriangulationDegreeLabel.Text = "Triangulation Degree";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 600);
            this.Controls.Add(this.TriangulationDegreeLabel);
            this.Controls.Add(this.TriangulationDegreeTrackBar);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriangulationDegreeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TrackBar TriangulationDegreeTrackBar;
        private System.Windows.Forms.Label TriangulationDegreeLabel;
    }
}

