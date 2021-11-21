using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace lab02
{
    public partial class Designer
    {
        public Color ChosenColor { get; set; }
        public Color LightColor { get; set; }

        public ImageComboBoxLoader ICMBL { get; set; } 
        public bool ColorInterpolation { get; set; }

        public double ks { get; set; }
        public double kd { get; set; }
        public double m { get; set; }
        public double k { get; set; }

        public void FillPoly(Drawable d)
        {
            this.ScanLine(d);
        }

        public void HorizontalLine(int y, int x1, int x2, Triangle t)
        {
            for (int i = x1; i <= x2; i++)
                this.Printer.PutPixel(new Point(i, y), this.GetColor(i, y, (int)t.GetZ(i, y), t));
        }

        public Color GetColor(int x, int y, int z, Triangle t)
        {
            if (this.ColorInterpolation)
                return (this.InterpolateColor(x, y, z, t));
            else
                return this.CalculateColor(x, y, z, t);

        }

        private Color InterpolateColor(int x, int y, int z, Triangle t)
        {
            #region variables

            var (A, B, C) = t.GetPoints();
            var (cA, cB, cC) = t.GetColors();

            double denominator = (B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y);

            double alpha = (double) ((B.Y - C.Y) * (x - C.X) + (C.X - B.X) * (y - C.Y)) / (double) denominator;
            double beta = (double) ((C.Y - A.Y) * (x - C.X) + (A.X - C.X) * (y - C.Y)) / (double) denominator;
            double gamma = 1 - alpha - beta;

            #endregion

            double _R = cA.R * alpha + cB.R * beta + cC.R * gamma;
            double _G = cA.G * alpha + cB.G * beta + cC.G * gamma;
            double _B = cA.B * alpha + cB.B * beta + cC.B * gamma;

            _R = Math.Max(0, _R); _R = Math.Min(255, _R);
            _G = Math.Max(0, _G); _G = Math.Min(255, _G);
            _B = Math.Max(0, _B); _B = Math.Min(255, _B);

            return Color.FromArgb((int)Math.Ceiling(_R), (int)Math.Ceiling(_G), (int)Math.Ceiling(_B));
        }

        private Color CalculateColor(int x, int y, int z, Triangle t)
        {
            Color ChosenColor = this.ICMBL.GetColor(x, y, z);
            Color LightColor = this.ICMBL.LightColor;

            double R = ChosenColor.R, G = ChosenColor.G, B = this.ChosenColor.B;

            // The code below was object oriented. Unfortunately that implementation caused significant optimization issues,
            // thus a primitive code-convention was adopted 

            #region variables

            // vector N
            double _x = (x - this.radius * 1.5) / 2;
            double _y = (y - this.radius * 1.5) / 2;
            double N_X = _x, N_Y = _y, N_Z = (int)Math.Sqrt(this.radius * this.radius - _x * _x - _y * _y);

            // vector L
            double L_X = this.LightX - x, L_Y = this.LightY - y, L_Z = this.DistanceFromLightSource - z;

            // normalize L and N vectors
            double L_abs = Math.Sqrt(L_X * L_X + L_Y * L_Y + L_Z * L_Z); if (L_abs == 0) L_abs = 1;
            double N_abs = Math.Sqrt(N_X * N_X + N_Y * N_Y + N_Z * N_Z); if (N_abs == 0) N_abs = 1;

            L_X /= L_abs; L_Y /= L_abs; L_Z /= L_abs;
            N_X /= N_abs; N_Y /= N_abs; N_Z /= N_abs;

            L_abs = 1;
            N_abs = 1;

            (N_X, N_Y, N_Z) = this.ICMBL.GetNormalVector(x, y, N_X, N_Y, N_Z, this.k);

            // vector V
            double V_X = 0, V_Y = 0, V_Z = 1;

            // Vector R
            double N_L_dp = Math.Max(0, L_X * N_X + L_Y * N_Y + L_Z * N_Z);
            double R_X = 2 * N_L_dp * N_X - L_X, R_Y = 2 * N_L_dp * N_Y - L_Y, R_Z = 2 * N_L_dp * N_Z - L_Z;

            // normalize R
            double R_abs = Math.Sqrt(R_X * R_X + R_Y * R_Y + R_Z * R_Z);
            R_X /= R_abs; R_Y /= R_abs; R_Z /= R_abs;

            double lambertCompositional;
            double mirrorCompositional;

            double V_R_dp = Math.Max(0, V_X * R_X + V_Y * R_Y + V_Z * R_Z);
            double V_R_cos = Math.Max(Math.Pow(V_R_dp, this.m), 0);

            #endregion

            #region R

            lambertCompositional = this.kd * ChosenColor.R * LightColor.R * N_L_dp; // abs(N) * abs(L) = 1
            mirrorCompositional = this.ks * ChosenColor.R * LightColor.R * V_R_cos;

            R = Math.Min((lambertCompositional + mirrorCompositional) / 255, 255);

            #endregion

            #region G

            lambertCompositional = this.kd * ChosenColor.G * LightColor.G * N_L_dp; // abs(N) * abs(L) = 1
            mirrorCompositional = this.ks * ChosenColor.G * LightColor.G * V_R_cos;

            G = Math.Min((lambertCompositional + mirrorCompositional) / 255, 255);

            #endregion

            #region B

            lambertCompositional = this.kd * ChosenColor.B * LightColor.B * N_L_dp; // abs(N) * abs(L) = 1
            mirrorCompositional = this.ks * ChosenColor.B * LightColor.B * V_R_cos;

            B = Math.Min((lambertCompositional + mirrorCompositional) / 255, 255);

            #endregion

            return Color.FromArgb((int)R, (int)G, (int)B);
        }

        #region Light Source

        private double DistanceFromLightSource = 600;
        private double LightX;
        private double LightY;
        private double _AnimationDegree;
        private double AnimationTick;
        private double phi = 0;
        private double r = 0;
        private double radius = 200;
        private double animationCenterX = 100;
        private double animationCenterY = 500;

        private TrackBar AnimationTrackBar;

        public void UpdateLightSourcePosition(object sender, EventArgs e)
        {
            this.phi += 0.1;
            if (this.r > radius || this.r <= 0) this.AnimationTick *= -1;

            this.r += this.AnimationTick;

            this.LightX = (int)(this.r * Math.Cos(this.phi) + animationCenterX);
            this.LightY = (int)(this.r * Math.Sin(this.phi) + animationCenterY);

            this._AnimationDegree = Math.Min(this.AnimationTrackBar.Maximum, Math.Max(0, this.r / radius * this.AnimationTrackBar.Maximum));
            this.AnimationTrackBar.Value = (int)this._AnimationDegree;
        }

        public void AnimationAdvance()
        {
            this._AnimationDegree = this.AnimationTrackBar.Value;
            this.r = this._AnimationDegree * this.radius / this.AnimationTrackBar.Maximum; 
            
            this.phi += 0.1;
            if (this.r > radius || this.r <= 0) this.AnimationTick *= -1;

            this.r += this.AnimationTick;

            this.LightX = (int)(this.r * Math.Cos(this.phi) + animationCenterX);
            this.LightY = (int)(this.r * Math.Sin(this.phi) + animationCenterY);
        }

        #endregion
    }
}
