﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lab02
{
    public partial class Designer
    {
        // source: https://stackoverflow.com/questions/9600801/evenly-distributing-n-points-on-a-sphere
        public HashSet<Point> FibonacciSphere(int samples = 1000)
        {
            samples *= 2;

            HashSet<Point> points = new HashSet<Point>();
            double phi = Math.PI * (3.0 - Math.Sqrt(5.0)), x, y, z, radius, theta;  // golden angle in radians

            for (int i = 0; i < samples; i++)
            {
                y = 1 - (i / (double)(samples - 1)) * 2;                            // y goes from 1 to 0
                radius = Math.Sqrt(1 - y * y);                                      // radius at y
                                                                                    
                theta = phi * i;                                                    // golden angle increment

                x = Math.Cos(theta) * radius;
                z = Math.Sin(theta) * radius;
                if (z < 0) continue;

                x += 1;
                x /= 2;

                y += 1;
                y /= 2;

                x *= (this.Printer.Width - 1);
                y *= (this.Printer.Height - 1);

                points.Add(new Point((int)x, (int)y));
            }

            return points;
        }
    }
}
