using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;

namespace lab02
{
    public partial class Designer
    {
        // source: https://stackoverflow.com/questions/9600801/evenly-distributing-n-points-on-a-sphere
        public HashSet<IPoint> FibonacciSphere(int samples = 1000)
        {
            samples *= 2;

            ConcurrentBag<IPoint> pts = new ConcurrentBag<IPoint>();
            double phi = Math.PI * (3.0 - Math.Sqrt(5.0)), x, y, z, radius, theta;  // golden angle in radians

            for (int i = 0; i < samples; i++)
            {
                y = 1 - (i / (double)(samples - 1)) * 2;                            // y goes from 1 to 0
                radius = Math.Sqrt(1 - y * y);                                      // radius at y

                theta = phi * i;                                                    // golden angle increment

                x = Math.Cos(theta) * radius;
                z = Math.Sin(theta) * radius;

                if (z < 0) continue;                                                // only the upper hemisphere

                this.Translate(ref x, this.Printer.Width);
                this.Translate(ref y, this.Printer.Height);
                this.Translate(ref z, this.Printer.Width);

                pts.Add(new Point((int)x, (int)y, (int)z));
            }

            return pts.ToHashSet();
        }

        private void Translate (ref double a, int scale)
        {
            a += 1;
            a /= 2;
            a *= scale;
        }
    }
}
