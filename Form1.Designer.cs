
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
            this.RadioButtonColorRed = new System.Windows.Forms.RadioButton();
            this.ColorGroupBox = new System.Windows.Forms.GroupBox();
            this.RadioButtonColorGreen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriangulationDegreeTrackBar)).BeginInit();
            this.ColorGroupBox.SuspendLayout();
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
            // RadioButtonColorRed
            // 
            this.RadioButtonColorRed.AutoSize = true;
            this.RadioButtonColorRed.Checked = true;
            this.RadioButtonColorRed.Location = new System.Drawing.Point(6, 22);
            this.RadioButtonColorRed.Name = "RadioButtonColorRed";
            this.RadioButtonColorRed.Size = new System.Drawing.Size(45, 19);
            this.RadioButtonColorRed.TabIndex = 3;
            this.RadioButtonColorRed.TabStop = true;
            this.RadioButtonColorRed.Text = "Red";
            this.RadioButtonColorRed.UseVisualStyleBackColor = true;
            this.RadioButtonColorRed.CheckedChanged += new System.EventHandler(this.ColorChanged);
            // 
            // ColorGroupBox
            // 
            this.ColorGroupBox.Controls.Add(this.RadioButtonColorGreen);
            this.ColorGroupBox.Controls.Add(this.RadioButtonColorRed);
            this.ColorGroupBox.Location = new System.Drawing.Point(621, 148);
            this.ColorGroupBox.Name = "ColorGroupBox";
            this.ColorGroupBox.Size = new System.Drawing.Size(279, 80);
            this.ColorGroupBox.TabIndex = 4;
            this.ColorGroupBox.TabStop = false;
            this.ColorGroupBox.Text = "Select color";
            // 
            // RadioButtonColorGreen
            // 
            this.RadioButtonColorGreen.AutoSize = true;
            this.RadioButtonColorGreen.Location = new System.Drawing.Point(6, 48);
            this.RadioButtonColorGreen.Name = "RadioButtonColorGreen";
            this.RadioButtonColorGreen.Size = new System.Drawing.Size(56, 19);
            this.RadioButtonColorGreen.TabIndex = 4;
            this.RadioButtonColorGreen.Text = "Green";
            this.RadioButtonColorGreen.UseVisualStyleBackColor = true;
            this.RadioButtonColorGreen.CheckedChanged += new System.EventHandler(this.ColorChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 600);
            this.Controls.Add(this.ColorGroupBox);
            this.Controls.Add(this.TriangulationDegreeLabel);
            this.Controls.Add(this.TriangulationDegreeTrackBar);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriangulationDegreeTrackBar)).EndInit();
            this.ColorGroupBox.ResumeLayout(false);
            this.ColorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TrackBar TriangulationDegreeTrackBar;
        private System.Windows.Forms.Label TriangulationDegreeLabel;
        private System.Windows.Forms.RadioButton RadioButtonColorRed;
        private System.Windows.Forms.GroupBox ColorGroupBox;
        private System.Windows.Forms.RadioButton RadioButtonColorGreen;
    }
}

