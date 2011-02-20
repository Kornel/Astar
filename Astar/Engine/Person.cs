using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;


namespace Astar.Engine
{
    internal class Person
    {
        private UI.Context uiContext;

        private Brush PathBrush { get; set; }
        private Brush PlayerBrush { get; set; }
        private Brush StartBrush { get; set; }
        private Brush GoalBrush { get; set; }

        private Color StartColor;
        private Color GoalColor;
        private int currentPathLength;

        internal Person(UI.Context uiContext, Brush pathBrush, Brush playerBrush, Brush startBrush, Brush goalBrush)
        {
            this.uiContext = uiContext;
            this.PathBrush = pathBrush;
            this.PlayerBrush = playerBrush;
            this.StartBrush = startBrush;
            this.GoalBrush = goalBrush;

            StartColor = new Pen(startBrush).Color;
            GoalColor = new Pen(goalBrush).Color;
        }

        internal PathNode[,] grid { set; get; }
       
        public Point? Position { get; set; }
        private Queue<Point> pathToGo;
        private Queue<UI.ColourPoint> pathTraversed = new Queue<UI.ColourPoint>();

        public Queue<Point> Path
        {
            get
            {                
                return pathToGo;                
            }
        }

        public Point? Start { get; set; }        
        public Point? Goal { get; set; }

        public void calculatePath()
        {
            SpatialAStar<PathNode, Object> aStar = new SpatialAStar<PathNode, Object>(grid);
            pathToGo = getPath(aStar.Search(Start.Value, Goal.Value, null));
            
            currentPathLength = pathToGo.Count;
            pathTraversed.Clear();           
        }

        private Queue<Point> getPath(LinkedList<PathNode> nodes)
        {            
            Queue<Point> points = new Queue<Point>();

            if (nodes != null)
            {
                foreach (PathNode node in nodes)
                {
                    points.Enqueue(new Point(node.X, node.Y));
                }
            }

            return points;
        }

        public bool makeStep()
        {
            bool result;
            if (Path.Count > 0)
            {
                lock (Path)
                {
                    Position = Path.Dequeue();
                }

                int n = currentPathLength - Path.Count;
                UI.ColourPoint colourPoint = new UI.ColourPoint(Position.Value, getColorForNth(n));

                lock (pathTraversed)
                {
                    pathTraversed.Enqueue(colourPoint);                    
                }
                
                result = true;
            }
            else
            {
                result = false;
            }

            return result;

        }

        private Color getColorForNth(int n)
        {
            double ratio = n / (double)currentPathLength;

            int r = StartColor.R - (int)((StartColor.R - GoalColor.R) * ratio);
            int g = StartColor.G - (int)((StartColor.G - GoalColor.G) * ratio);
            int b = StartColor.B - (int)((StartColor.B - GoalColor.B) * ratio);

            return Color.FromArgb(255, r, g, b);
        }

        public void render(Graphics g)
        {
            rednerPathsIfPresent(g, PathBrush, pathToGo);
            UI.GraphicTools.drawSquare(g, StartBrush, Start, uiContext.SquareDim);
            UI.GraphicTools.drawSquare(g, PlayerBrush, Position, uiContext.SquareDim);
            UI.GraphicTools.drawSquare(g, GoalBrush, Goal, uiContext.SquareDim);
        }

        private void rednerPathsIfPresent(Graphics g, Brush b, Queue<Point> path)
        {
            if (path != null)
            {
                lock (Path)
                {
                    foreach (Point p in path)
                    {
                        UI.GraphicTools.drawSmallSquare(g, b, p, uiContext.SquareDim);
                    }
                }
            }
            
            lock (pathTraversed)
            {
                foreach (UI.ColourPoint p in pathTraversed)
                {
                    UI.GraphicTools.drawSquare(g, p.Brush, p.Point, uiContext.SquareDim);
                }
            }
        }
    }

}
