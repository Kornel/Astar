using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Astar.UI
{
    public class ColourPoint
    {
        public Brush Brush { get; private set; }
        public Point Point { get; private set; }

        public ColourPoint(Point point, Color color) {
            Point = point;
            Brush = new SolidBrush(color);
        }
    }
}
