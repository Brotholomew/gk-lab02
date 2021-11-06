
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.TriangulationDegreeTrackBar = new System.Windows.Forms.TrackBar();
            this.TriangulationDegreeLabel = new System.Windows.Forms.Label();
            this.RadioButtonColorRed = new System.Windows.Forms.RadioButton();
            this.ColorGroupBox = new System.Windows.Forms.GroupBox();
            this.RadioButtonColorGreen = new System.Windows.Forms.RadioButton();
            this.TriangulationDegreeTextBox = new System.Windows.Forms.TextBox();
            this.KdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KdTrackBar = new System.Windows.Forms.TrackBar();
            this.KsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KsTrackBar = new System.Windows.Forms.TrackBar();
            this.MTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MTrackBar = new System.Windows.Forms.TrackBar();
            this.AnimationTrackBar = new System.Windows.Forms.TrackBar();
            this.AnimationButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LightColorGroupBox = new System.Windows.Forms.GroupBox();
            this.RedLighgtCheckBox = new System.Windows.Forms.RadioButton();
            this.WhiteLightCheckBox = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriangulationDegreeTrackBar)).BeginInit();
            this.ColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KsTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationTrackBar)).BeginInit();
            this.LightColorGroupBox.SuspendLayout();
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
            this.TriangulationDegreeTrackBar.Maximum = 2500;
            this.TriangulationDegreeTrackBar.Minimum = 500;
            this.TriangulationDegreeTrackBar.Name = "TriangulationDegreeTrackBar";
            this.TriangulationDegreeTrackBar.Size = new System.Drawing.Size(215, 45);
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
            this.ColorGroupBox.Location = new System.Drawing.Point(621, 321);
            this.ColorGroupBox.Name = "ColorGroupBox";
            this.ColorGroupBox.Size = new System.Drawing.Size(279, 80);
            this.ColorGroupBox.TabIndex = 4;
            this.ColorGroupBox.TabStop = false;
            this.ColorGroupBox.Text = "Select object color";
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
            // TriangulationDegreeTextBox
            // 
            this.TriangulationDegreeTextBox.Location = new System.Drawing.Point(828, 40);
            this.TriangulationDegreeTextBox.Name = "TriangulationDegreeTextBox";
            this.TriangulationDegreeTextBox.ReadOnly = true;
            this.TriangulationDegreeTextBox.Size = new System.Drawing.Size(72, 23);
            this.TriangulationDegreeTextBox.TabIndex = 5;
            // 
            // KdTextBox
            // 
            this.KdTextBox.Location = new System.Drawing.Point(828, 97);
            this.KdTextBox.Name = "KdTextBox";
            this.KdTextBox.ReadOnly = true;
            this.KdTextBox.Size = new System.Drawing.Size(72, 23);
            this.KdTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "k_d coefficient";
            // 
            // KdTrackBar
            // 
            this.KdTrackBar.Location = new System.Drawing.Point(606, 97);
            this.KdTrackBar.Maximum = 1000;
            this.KdTrackBar.Name = "KdTrackBar";
            this.KdTrackBar.Size = new System.Drawing.Size(215, 45);
            this.KdTrackBar.TabIndex = 6;
            this.KdTrackBar.ValueChanged += new System.EventHandler(this.ValueChangedKdScrollBar);
            // 
            // KsTextBox
            // 
            this.KsTextBox.Location = new System.Drawing.Point(828, 158);
            this.KsTextBox.Name = "KsTextBox";
            this.KsTextBox.ReadOnly = true;
            this.KsTextBox.Size = new System.Drawing.Size(72, 23);
            this.KsTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "k_s coefficient";
            // 
            // KsTrackBar
            // 
            this.KsTrackBar.Location = new System.Drawing.Point(606, 158);
            this.KsTrackBar.Maximum = 1000;
            this.KsTrackBar.Name = "KsTrackBar";
            this.KsTrackBar.Size = new System.Drawing.Size(215, 45);
            this.KsTrackBar.TabIndex = 9;
            this.KsTrackBar.ValueChanged += new System.EventHandler(this.ValueChangedKsScrollBar);
            // 
            // MTextBox
            // 
            this.MTextBox.Location = new System.Drawing.Point(828, 219);
            this.MTextBox.Name = "MTextBox";
            this.MTextBox.ReadOnly = true;
            this.MTextBox.Size = new System.Drawing.Size(72, 23);
            this.MTextBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "m coefficient";
            // 
            // MTrackBar
            // 
            this.MTrackBar.Location = new System.Drawing.Point(606, 219);
            this.MTrackBar.Maximum = 100;
            this.MTrackBar.Name = "MTrackBar";
            this.MTrackBar.Size = new System.Drawing.Size(215, 45);
            this.MTrackBar.TabIndex = 12;
            this.MTrackBar.ValueChanged += new System.EventHandler(this.ValueChangedMScrollBar);
            // 
            // AnimationTrackBar
            // 
            this.AnimationTrackBar.Location = new System.Drawing.Point(606, 270);
            this.AnimationTrackBar.Maximum = 100;
            this.AnimationTrackBar.Name = "AnimationTrackBar";
            this.AnimationTrackBar.Size = new System.Drawing.Size(215, 45);
            this.AnimationTrackBar.TabIndex = 15;
            this.AnimationTrackBar.ValueChanged += new System.EventHandler(this.ValueChangedAnimationTrackBar);
            // 
            // AnimationButton
            // 
            this.AnimationButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AnimationButton.BackgroundImage")));
            this.AnimationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AnimationButton.Location = new System.Drawing.Point(849, 270);
            this.AnimationButton.Name = "AnimationButton";
            this.AnimationButton.Size = new System.Drawing.Size(30, 30);
            this.AnimationButton.TabIndex = 16;
            this.AnimationButton.UseVisualStyleBackColor = true;
            this.AnimationButton.Click += new System.EventHandler(this.ClickAnimationButton);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(621, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Light source animation";
            // 
            // LightColorGroupBox
            // 
            this.LightColorGroupBox.Controls.Add(this.RedLighgtCheckBox);
            this.LightColorGroupBox.Controls.Add(this.WhiteLightCheckBox);
            this.LightColorGroupBox.Location = new System.Drawing.Point(621, 407);
            this.LightColorGroupBox.Name = "LightColorGroupBox";
            this.LightColorGroupBox.Size = new System.Drawing.Size(279, 80);
            this.LightColorGroupBox.TabIndex = 5;
            this.LightColorGroupBox.TabStop = false;
            this.LightColorGroupBox.Text = "Select light color";
            // 
            // RedLighgtCheckBox
            // 
            this.RedLighgtCheckBox.AutoSize = true;
            this.RedLighgtCheckBox.Location = new System.Drawing.Point(6, 48);
            this.RedLighgtCheckBox.Name = "RedLighgtCheckBox";
            this.RedLighgtCheckBox.Size = new System.Drawing.Size(45, 19);
            this.RedLighgtCheckBox.TabIndex = 4;
            this.RedLighgtCheckBox.Text = "Red";
            this.RedLighgtCheckBox.UseVisualStyleBackColor = true;
            this.RedLighgtCheckBox.CheckedChanged += new System.EventHandler(this.LightColorChanged);
            // 
            // WhiteLightCheckBox
            // 
            this.WhiteLightCheckBox.AutoSize = true;
            this.WhiteLightCheckBox.Checked = true;
            this.WhiteLightCheckBox.Location = new System.Drawing.Point(6, 22);
            this.WhiteLightCheckBox.Name = "WhiteLightCheckBox";
            this.WhiteLightCheckBox.Size = new System.Drawing.Size(56, 19);
            this.WhiteLightCheckBox.TabIndex = 3;
            this.WhiteLightCheckBox.TabStop = true;
            this.WhiteLightCheckBox.Text = "White";
            this.WhiteLightCheckBox.UseVisualStyleBackColor = true;
            this.WhiteLightCheckBox.CheckedChanged += new System.EventHandler(this.LightColorChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 600);
            this.Controls.Add(this.LightColorGroupBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AnimationButton);
            this.Controls.Add(this.AnimationTrackBar);
            this.Controls.Add(this.MTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MTrackBar);
            this.Controls.Add(this.KsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KsTrackBar);
            this.Controls.Add(this.KdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KdTrackBar);
            this.Controls.Add(this.TriangulationDegreeTextBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.KdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KsTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationTrackBar)).EndInit();
            this.LightColorGroupBox.ResumeLayout(false);
            this.LightColorGroupBox.PerformLayout();
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
        private System.Windows.Forms.TextBox TriangulationDegreeTextBox;
        private System.Windows.Forms.TextBox KdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar KdTrackBar;
        private System.Windows.Forms.TextBox KsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar KsTrackBar;
        private System.Windows.Forms.TextBox MTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar MTrackBar;
        private System.Windows.Forms.TrackBar AnimationTrackBar;
        private System.Windows.Forms.Button AnimationButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox LightColorGroupBox;
        private System.Windows.Forms.RadioButton RedLighgtCheckBox;
        private System.Windows.Forms.RadioButton WhiteLightCheckBox;
    }
}

