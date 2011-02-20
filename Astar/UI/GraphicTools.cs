using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Astar.UI
{
    public class GraphicTools
    {
        public static void drawSquare(Graphics g, Brush brush, Point? where, int squareDim)
        {
            if (where.HasValue)
            {
                int x = where.Value.X * squareDim + 1;
                int y = where.Value.Y * squareDim + 1;
                int width = squareDim - 1;
                int height = squareDim - 1;
                g.FillRectangle(brush, x, y, width, height);
            }        
        }

        public static void drawSmallSquare(Graphics g, Brush brush, Point? where, int squareDim)
        {
            if (where.HasValue)
            {
                int x = where.Value.X * squareDim + 1 + squareDim / 4;
                int y = where.Value.Y * squareDim + 1 + squareDim / 4;
                int width = squareDim / 2 - 1;
                int height = squareDim / 2 - 1;
                g.FillRectangle(brush, x, y, width, height);
            }
        }
      
    }
}
