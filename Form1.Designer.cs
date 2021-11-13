
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
            this.InterpolationCheckBox = new System.Windows.Forms.CheckBox();
            this.KTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KTrackBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TextureImageComboBox = new lab02.ImageComboBox();
            this.LightColorComboBox = new lab02.ImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriangulationDegreeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KsTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KTrackBar)).BeginInit();
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
            this.TriangulationDegreeTrackBar.Minimum = 10;
            this.TriangulationDegreeTrackBar.Name = "TriangulationDegreeTrackBar";
            this.TriangulationDegreeTrackBar.Size = new System.Drawing.Size(215, 45);
            this.TriangulationDegreeTrackBar.TabIndex = 1;
            this.TriangulationDegreeTrackBar.TickFrequency = 100;
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
            this.KdTrackBar.Value = 200;
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
            this.KsTrackBar.Value = 200;
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
            this.AnimationTrackBar.Location = new System.Drawing.Point(606, 347);
            this.AnimationTrackBar.Maximum = 1000;
            this.AnimationTrackBar.Name = "AnimationTrackBar";
            this.AnimationTrackBar.Size = new System.Drawing.Size(215, 45);
            this.AnimationTrackBar.TabIndex = 15;
            this.AnimationTrackBar.ValueChanged += new System.EventHandler(this.ValueChangedAnimationTrackBar);
            // 
            // AnimationButton
            // 
            this.AnimationButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AnimationButton.BackgroundImage")));
            this.AnimationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AnimationButton.Location = new System.Drawing.Point(849, 347);
            this.AnimationButton.Name = "AnimationButton";
            this.AnimationButton.Size = new System.Drawing.Size(30, 30);
            this.AnimationButton.TabIndex = 16;
            this.AnimationButton.UseVisualStyleBackColor = true;
            this.AnimationButton.Click += new System.EventHandler(this.ClickAnimationButton);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(621, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Light source animation";
            // 
            // InterpolationCheckBox
            // 
            this.InterpolationCheckBox.AutoSize = true;
            this.InterpolationCheckBox.Location = new System.Drawing.Point(621, 505);
            this.InterpolationCheckBox.Name = "InterpolationCheckBox";
            this.InterpolationCheckBox.Size = new System.Drawing.Size(126, 19);
            this.InterpolationCheckBox.TabIndex = 18;
            this.InterpolationCheckBox.Text = "Color Interpolation";
            this.InterpolationCheckBox.UseVisualStyleBackColor = true;
            this.InterpolationCheckBox.CheckedChanged += new System.EventHandler(this.CheckedChangedColorInterpolation);
            // 
            // KTextBox
            // 
            this.KTextBox.Location = new System.Drawing.Point(828, 281);
            this.KTextBox.Name = "KTextBox";
            this.KTextBox.ReadOnly = true;
            this.KTextBox.Size = new System.Drawing.Size(72, 23);
            this.KTextBox.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(621, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "k coefficient";
            // 
            // KTrackBar
            // 
            this.KTrackBar.Location = new System.Drawing.Point(606, 281);
            this.KTrackBar.Maximum = 1000;
            this.KTrackBar.Name = "KTrackBar";
            this.KTrackBar.Size = new System.Drawing.Size(215, 45);
            this.KTrackBar.TabIndex = 19;
            this.KTrackBar.ValueChanged += new System.EventHandler(this.ValueChangedKScrollBar);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Texture";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(621, 443);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Light Color";
            // 
            // TextureImageComboBox
            // 
            this.TextureImageComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TextureImageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextureImageComboBox.FormattingEnabled = true;
            this.TextureImageComboBox.Location = new System.Drawing.Point(616, 407);
            this.TextureImageComboBox.Name = "TextureImageComboBox";
            this.TextureImageComboBox.Size = new System.Drawing.Size(284, 24);
            this.TextureImageComboBox.TabIndex = 26;
            this.TextureImageComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorChanged);
            // 
            // LightColorComboBox
            // 
            this.LightColorComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LightColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LightColorComboBox.FormattingEnabled = true;
            this.LightColorComboBox.Location = new System.Drawing.Point(616, 461);
            this.LightColorComboBox.Name = "LightColorComboBox";
            this.LightColorComboBox.Size = new System.Drawing.Size(284, 24);
            this.LightColorComboBox.TabIndex = 27;
            this.LightColorComboBox.SelectedIndexChanged += new System.EventHandler(this.LightColorChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 600);
            this.Controls.Add(this.LightColorComboBox);
            this.Controls.Add(this.TextureImageComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.KTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KTrackBar);
            this.Controls.Add(this.InterpolationCheckBox);
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
            this.Controls.Add(this.TriangulationDegreeLabel);
            this.Controls.Add(this.TriangulationDegreeTrackBar);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TriangulationDegreeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KsTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TrackBar TriangulationDegreeTrackBar;
        private System.Windows.Forms.Label TriangulationDegreeLabel;
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
        private System.Windows.Forms.CheckBox InterpolationCheckBox;
        private System.Windows.Forms.TextBox KTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar KTrackBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ImageComboBox TextureImageComboBox;
        private ImageComboBox LightColorComboBox;
    }
}

