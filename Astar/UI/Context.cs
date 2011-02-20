using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar.UI
{
    public class Context
    {
        public int SquareDim { get; private set; }
        public int SquaresX { get; private set; }
        public int SquaresY { get; private set; }

        public Context(int squareDim, int squaresX, int squaresY)
        {
            this.SquareDim = squareDim;
            this.SquaresX = squaresX;
            this.SquaresY = squaresY;
        }


    }
}
