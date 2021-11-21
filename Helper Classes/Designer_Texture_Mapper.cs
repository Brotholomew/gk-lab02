using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    // source: https://www.codeproject.com/Articles/19712/Mapping-Images-on-Spherical-Surfaces-Using-C
    public partial class Designer
    {
        public void MapTexture(DirectBitmap db, Bitmap src)
        {
            double phi0 = 0.0;
            double phi1 = Math.PI;
            double theta0 = 0.0;
            double theta1 = 2.0 * Math.PI;
            double radius = this.radius;

            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    // map the angles from image coordinates
                    double theta = MapCoordinate(0.0, src.Width - 1, theta1, theta0, i);
                    double phi = MapCoordinate(0.0, src.Height - 1, phi0, phi1, j);

                    // find the cartesian coordinates
                    double x = radius * Math.Sin(phi) * Math.Cos(theta);
                    double y = radius * Math.Sin(phi) * Math.Sin(theta);
                    double z = radius * Math.Cos(phi);

                    // apply rotation around X and Y axis to reposition the sphere
                    RotX(1.5, ref y, ref z);
                    RotY(-2.5, ref x, ref z);
                    // plot only positive points
                    if (z > 0)
                    {
                        Color color = src.GetPixel(i, j);
                        int ix = (int)x;
                        int iy = (int)y;

                        db.SetPixel((int)((ix + this.radius)), (int)((iy + this.radius)), color);
                    }
                }
            }
        }

        public static void RotX(double angle, ref double y, ref double z)
        {
            double y1 = y * System.Math.Cos(angle) - z * System.Math.Sin(angle);
            double z1 = y * System.Math.Sin(angle) + z * System.Math.Cos(angle);
            y = y1;
            z = z1;
        }
        public static void RotY(double angle, ref double x, ref double z)
        {
            double x1 = x * System.Math.Cos(angle) - z * System.Math.Sin(angle);
            double z1 = x * System.Math.Sin(angle) + z * System.Math.Cos(angle);
            x = x1;
            z = z1;
        }
        public static void RotZ(double angle, ref double x, ref double y)
        {
            double x1 = x * System.Math.Cos(angle) - y * System.Math.Sin(angle);
            double y1 = x * System.Math.Sin(angle) + y * System.Math.Cos(angle);
            x = x1;
            y = y1;
        }

        public static double MapCoordinate(double i1, double i2, double w1, double w2, double p)
        {
            return ((p - i1) / (i2 - i1)) * (w2 - w1) + w1;
        }
    }
}
