using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public partial class Designer
    {
        public Color ChosenColor { get; set; }
        public Color LightColor { get; set; }

        public bool ColorInterpolation { get; set; }

        public double ks { get; set; }
        public double kd { get; set; }
        public double m { get; set; }

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

            double alpha = ((B.Y - C.Y) * (x - C.X) + (C.X - B.X) * (y - C.Y)) / denominator;
            double beta = ((C.Y - A.Y) * (x - C.X) + (A.X - C.X) * (y - C.Y)) / denominator;
            double gamma = 1 - alpha - beta;

            #endregion

            double _R = cA.R * alpha + cB.R * beta + cC.R * gamma;
            double _G = cA.G * alpha + cB.G * beta + cC.G * gamma;
            double _B = cA.B * alpha + cB.B * beta + cC.B * gamma;

            return Color.FromArgb((int)_R, (int)_G, (int)_B);
        }

        private Color CalculateColor(int x, int y, int z, Triangle t)
        {
            double R = ChosenColor.R, G = ChosenColor.G, B = this.ChosenColor.B;

            #region Object Oriented Calculations

            // this code was nicely object oriented as below. However this implementation caused significant optimization issues,
            // thus all the below objects have been abandoned

            // V3 N = new V3(plane.A, plane.B, plane.C);
            // V3 L = new V3(x, y, z);//new V3(new Point(x, y, z), this.TranslateAnimationDegree());
            // V3 V = new V3(0, 0, 1);

            // N.Normalize();
            // L.Normalize();

            // double ar = 2 * V3.DotProduct(N, L);
            // V3 Rv = new V3(ar * N.X - L.X, ar * N.Y - L.Y, ar * N.Z - L.Z);

            // R = CalculateCompositional(this.ChosenColor.R, this.LightColor.R, N, L, V, Rv);
            // G = CalculateCompositional(this.ChosenColor.G, this.LightColor.G, N, L, V, Rv);
            // B = CalculateCompositional(this.ChosenColor.B, this.LightColor.B, N, L, V, Rv);

            #endregion

            #region variables

            // vector N
            double N_X = t.pA, N_Y = t.pB, N_Z = t.pC;

            // vector L
            double L_X = x - this.LightX, L_Y = y - this.LightY, L_Z = z - this.DistanceFromLightSource;

            // normalize L and N vectors
            double L_abs = Math.Sqrt(L_X * L_X + L_Y * L_Y + L_Z * L_Z); if (L_abs == 0) L_abs = 1;
            double N_abs = Math.Sqrt(N_X * N_X + N_Y * N_Y + N_Z * N_Z); if (N_abs == 0) N_abs = 1;

            L_X /= L_abs; L_Y /= L_abs; L_Z /= L_abs;
            N_X /= N_abs; N_Y /= N_abs; N_Z /= N_abs;

            L_abs = 1;
            N_abs = 1;

            // vector V
            double V_X = 0, V_Y = 0, V_Z = 1;

            // Vector R
            double N_L_dp = Math.Max(0, L_X * N_X + L_Y * N_Y + L_Z * N_Z);
            double R_X = 2 * N_L_dp * N_X - L_X, R_Y = 2 * N_L_dp * N_Y - L_Y, R_Z = 2 * N_L_dp * N_Z - L_Z;

            double lambertCompositional;
            double mirrorCompositional;

            double V_R_dp = Math.Max(0, V_X * R_X + V_Y * R_Y + V_Z * R_Z);
            double V_abs = Math.Sqrt(V_X * V_X + V_Y * V_Y + V_Z * V_Z);
            double R_abs = Math.Sqrt(R_X * R_X + R_Y * R_Y + R_Z * R_Z);
            double V_R_cos = Math.Max(Math.Pow((double) V_R_dp / (double) (V_abs * R_abs), this.m), 0);

            #endregion

            #region R

            lambertCompositional = this.kd * this.ChosenColor.R * this.LightColor.R * N_L_dp; // abs(N) * abs(L) = 1
            mirrorCompositional = this.ks * this.ChosenColor.R * this.LightColor.R * V_R_cos;

            R = Math.Min((lambertCompositional + mirrorCompositional) / 255, 255);

            #endregion

            #region G

            lambertCompositional = this.kd * this.ChosenColor.G * this.LightColor.G * N_L_dp; // abs(N) * abs(L) = 1
            mirrorCompositional = this.ks * this.ChosenColor.G * this.LightColor.G * V_R_cos;

            G = Math.Min((lambertCompositional + mirrorCompositional) / 255, 255);

            #endregion

            #region B

            lambertCompositional = this.kd * this.ChosenColor.B * this.LightColor.B * N_L_dp; // abs(N) * abs(L) = 1
            mirrorCompositional = this.ks * this.ChosenColor.B * this.LightColor.B * V_R_cos;

            B = Math.Min((lambertCompositional + mirrorCompositional) / 255, 255);

            #endregion

            return Color.FromArgb((int)R, (int)G, (int)B);
        }

        private double CalculateCompositional(double objectCompositional, double lightCompositional, V3 N, V3 L, V3 V, V3 R)
        {
            double lambertCompositional = this.kd * objectCompositional * lightCompositional * V3.Cosine(N, L);
            double mirrorCompositional = this.ks * objectCompositional * lightCompositional * Math.Pow(V3.Cosine(V, R), this.m);

            return Math.Abs((lambertCompositional + mirrorCompositional) % 256);
        }

        private Point TranslateAnimationDegree()
        {
            CircleEquation c = new CircleEquation(new Point(this.Printer.Width / 2, this.Printer.Height / 2), 200);
            return new Point(this.AnimationDegree, c.GetY(this.AnimationDegree));
        }

        #region Light Source
        public double AnimationDegree
        {
            get
            {
                return this._AnimationDegree;
            }
            set
            {
                this._AnimationDegree = value;
                this.UpdateLightSourcePosition();
            }
        }

        private double DistanceFromLightSource = 1200;
        private double LightX;
        private double LightY;
        private double _AnimationDegree;

        public void UpdateLightSourcePosition()
        {
            double radius = 200;
            double center = this.Printer.Width / 2;

            double translatedDegree = 0;
            if (this.AnimationDegree < 400)
                translatedDegree = this.AnimationDegree + 100;
            else if (this.AnimationDegree < 800)
                translatedDegree = 100 + this.AnimationDegree - 2 * (this.AnimationDegree % 400);
            else if (this.AnimationDegree < 1200)
                translatedDegree = 100 + this.AnimationDegree % 400;
            else if (this.AnimationDegree <= 1600)
                translatedDegree = 100 + (this.AnimationDegree % 800) - 2 * (this.AnimationDegree % 400);

            radius *= radius * (1600 - this.AnimationDegree) / 1600;

            this.LightX = translatedDegree;
            this.LightY = radius == 0 ? 0 : Math.Sqrt(radius * radius - (this.LightX - center) * (this.LightX - center)) + center;
        }

        #endregion
    }
}
