using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace lab02
{
    public partial class Designer
    {
        private static readonly int TrackerRadius = 3;
        
        public enum TrackerModes { FollowMouse, Off };
        public TrackerModes Mode = TrackerModes.Off;

        public Drawable Tracked { get; set; }

        public void FollowMouse(Point location, Form1 f)
        {
            if (this.Mode == Designer.TrackerModes.Off)
            {
                this.Tracked = this.Track(location);

                if (this.Tracked != null)
                    f.Cursor = Cursors.Hand;
                else
                    f.Cursor = Cursors.Default;
            } 
            else
            {
                f.Cursor = Cursors.SizeAll;
                this.Tracked.Move(location);
            }
        }

        public void MouseDown(Point location)
        {
            if (this.Tracked != null)
            {
                this.Mode = Designer.TrackerModes.FollowMouse;
                this.Tracked.PreMove();
            }
        }

        public void MouseUp()
        {
            if (this.Tracked != null)
            {
                this.Tracked.PostMove();
                this.Tracked = null;
            }

            this.Mode = Designer.TrackerModes.Off;
        }

        public Drawable Track(Point p)
        {
            // recognize objects that are in a square of size trackerRadius x trackerRadius
            // (mouse pointer is at the square's center), begin tracking from the nearest
            // pixels to the mouse pointer

            for (int k = 0; k <= Designer.TrackerRadius; k++)
            {
                for (int i = -k; i <= k; i++)
                    for (int j = -k; j <= k; j++)
                    {
                        if (i == -k || i == k || j == -k || j == k)
                        {
                            Point np = new Point(p.X + i, p.Y + j);
                            if (this.DrawablesMap.ContainsKey(np) && this.DrawablesMap[np].Count > 0)
                                return this.DrawablesMap[np][0];
                        }
                        else
                            continue;
                    }
            }

            return null;
        }
    }
}
