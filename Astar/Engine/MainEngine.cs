using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Astar.Engine
{
    public class MainEngine
    {
        private List<Engine.Person> players = new List<Engine.Person>();
        private HashSet<Point> obstacles = new HashSet<Point>();
        private Brush obstacleBrush = Brushes.ForestGreen;

        public UI.Context uiContext { get; private set; }

        public int PlayersCount { get { return players.Count; } }

        public MainEngine()
        {
            uiContext = new UI.Context(6, 200, 100);           

            Random random = new Random();
            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            KnownColor[] allColors = new KnownColor[colorsArray.Length];

            Array.Copy(colorsArray, allColors, colorsArray.Length);
            
            int total = 2;
            for (int i = 0; i < total; ++i)
            {
                Color randomColor1 = Color.FromKnownColor(allColors[random.Next(0, allColors.Length)]);
                Color randomColor2 = Color.FromKnownColor(allColors[random.Next(0, allColors.Length)]);
                Color randomColor3 = Color.FromKnownColor(allColors[random.Next(0, allColors.Length)]);

                Brush pathBrush = new SolidBrush(randomColor1);
                Brush playerBrush = pathBrush;
                Brush startBrush = new SolidBrush(randomColor2);
                Brush goalBrush = new SolidBrush(randomColor3);
                players.Add(new Person(uiContext, pathBrush, playerBrush, startBrush, goalBrush));
            }

            //players.Add(new Person(uiContext, Brushes.CornflowerBlue, Brushes.CornflowerBlue, Brushes.LightBlue, Brushes.Blue));
            //players.Add(new Person(uiContext, Brushes.Red, Brushes.Red, Brushes.LightCoral, Brushes.DarkRed));
            //players.Add(new Person(uiContext, Brushes.Gold, Brushes.Gold, Brushes.Orange, Brushes.DarkOrange));
        }

        public void RenderNextFrame(Graphics g)
        {           
            Pen p = Pens.Beige;
            
            renderObstacles(g, obstacleBrush, obstacles);

            foreach (Engine.Person person in players)
            {
                person.render(g);
            }
            
            renderGrid(g, p);
        }

        private void renderGrid(Graphics g, Pen p)
        {
            for (int i = 1; i < uiContext.SquaresX; ++i)
            {
                g.DrawLine(p, i * uiContext.SquareDim, 0, i * uiContext.SquareDim, uiContext.SquaresY * uiContext.SquareDim);
            }

            for (int j = 1; j < uiContext.SquaresY; ++j)
            {
                g.DrawLine(p, 0, j * uiContext.SquareDim, uiContext.SquaresX * uiContext.SquareDim, j * uiContext.SquareDim);
            }
        }

        private void renderObstacles(Graphics g, Brush brush, ISet<Point> obstacles)
        {
            foreach (Point p in obstacles)
            {
                UI.GraphicTools.drawSquare(g, brush, p, uiContext.SquareDim);
            }
        }

        public Point GetSquareFromMouseClick(MouseEventArgs e)
        {
            int x = e.X / uiContext.SquareDim;
            int y = e.Y / uiContext.SquareDim;

            return new Point(x, y);
        }

        public void ResetPlayerToPosition(int n, Point p) {
            players[n].Start = p;
            players[n].Position = p;

            if (obstacles.Contains(p))
            {
                obstacles.Remove(p);
            }
        }

        public void SetPlayerGoal(int n, Point p) {
            players[n].Goal = p;
            
            if (obstacles.Contains(p))
            {
                obstacles.Remove(p);
            }
        }
         
        
        public void AddObstacleAt(Point p) {
            foreach (Person person in players) {
                if (person.Start == p || person.Goal == p)
                {                    
                    return;
                }
            }
            obstacles.Add(p);            
        }

        public void RemoveObstacleAt(Point p)
        {
            obstacles.Remove(p);
        }

        public void Search()
        {
            PathNode[,] grid = new PathNode[uiContext.SquaresX, uiContext.SquaresY];

            for (int x = 0; x < uiContext.SquaresX; x++)
            {
                for (int y = 0; y < uiContext.SquaresY; y++)
                {
                    grid[x, y] = new PathNode()
                    {
                        X = x,
                        Y = y,
                        IsWall = false,
                    };
                }
            }

            foreach (Point p in obstacles)
            {
                grid[p.X, p.Y].IsWall = true;
            }

            foreach (Person person in players)
            {
                person.grid = grid;
                person.calculatePath();
            }
        }

        public bool NextStep()
        {
            Boolean result = false;
            foreach (Person person in players)
            {
                result |= person.makeStep();
            }

            return result;
        }
    }
}
