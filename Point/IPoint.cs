using System;
using System.Collections.Generic;
using System.Text;

namespace lab02
{
    public interface IPoint
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }

        System.Drawing.Point GetPoint();
    }
}
