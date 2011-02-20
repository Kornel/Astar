using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Astar
{
    public partial class MainForm : Form
    {
        Random random = new Random();
        DrawMode drawMode = DrawMode.StartA;

        Engine.MainEngine engine = new Engine.MainEngine();

        public MainForm()
        {
            InitializeComponent();
            Text = "A*";
            ClientSize = new Size(engine.uiContext.SquaresX * engine.uiContext.SquareDim, engine.uiContext.SquaresY * engine.uiContext.SquareDim);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.White;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);            
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            engine.RenderNextFrame(e.Graphics);            
        }
 
        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point p = engine.GetSquareFromMouseClick(e);

                switch (drawMode)
                {
                    case DrawMode.StartA:
                        engine.ResetPlayerToPosition(0, p);
                        drawMode = DrawMode.EndA;
                        break;
                    case DrawMode.EndA:
                        engine.SetPlayerGoal(0, p);
                        drawMode = DrawMode.StartB;
                        break;
                    case DrawMode.StartB:
                        engine.ResetPlayerToPosition(1, p);
                        drawMode = DrawMode.EndB;
                        break;
                    case DrawMode.EndB:
                        engine.SetPlayerGoal(1, p);
                        drawMode = DrawMode.Wall;
                        break;
                    case DrawMode.Wall:                        
                        engine.AddObstacleAt(p);
                        break;
                    case DrawMode.WallErase:
                        engine.RemoveObstacleAt(p);
                        break;
                }

                updateMenu();

                Invalidate();
            }

        }

        private void drawStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.StartA;
            updateMenu();
        }

        private void drawGoalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.EndA;
            updateMenu();
        }

        private void drawWallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.Wall;
            updateMenu();
        }

        private void drawStartBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.StartB;
            updateMenu();
        }

        private void drawGoalBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.EndB;
            updateMenu();
        }

        private void eraseWallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.WallErase;
            updateMenu();
        }

        private void updateMenu()
        {
            drawStartToolStripMenuItem.Checked = false;
            drawGoalToolStripMenuItem.Checked = false;
            drawStartBToolStripMenuItem.Checked = false;
            drawGoalBToolStripMenuItem.Checked = false;
            drawWallToolStripMenuItem.Checked = false;
            eraseWallToolStripMenuItem.Checked = false;

            ToolStripMenuItem menuItem;

            switch (drawMode)
            {
                case DrawMode.StartA:
                    menuItem = drawStartToolStripMenuItem;
                    break;
                case DrawMode.EndA:
                    menuItem = drawGoalToolStripMenuItem;
                    break;
                case DrawMode.StartB:
                    menuItem = drawStartBToolStripMenuItem;
                    break;
                case DrawMode.EndB:
                    menuItem = drawGoalBToolStripMenuItem;
                    break;
                case DrawMode.Wall:
                    menuItem = drawWallToolStripMenuItem;
                    break;
                case DrawMode.WallErase:
                    menuItem = eraseWallToolStripMenuItem;
                    break;
                default:
                    throw new ArgumentException();
            }

            menuItem.Checked = true;
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engine.Search();
            BackgroundWorker worker1 = new BackgroundWorker();
            worker1.DoWork += new DoWorkEventHandler(worker1_DoWork);
            worker1.RunWorkerAsync();
        }

        void worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (engine.NextStep())
            {
                DateTime dt = DateTime.Now;
                Thread.Sleep(100);
                Invalidate();
            }            
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (drawMode == DrawMode.Wall || drawMode == DrawMode.WallErase)
                {
                    MainForm_MouseClick(sender, e);
                }
            }
        }

        private void obstaclesToolStripMenuItem_Click(object sender, EventArgs e)
        {                       
            int n = engine.uiContext.SquaresX * engine.uiContext.SquaresY;
            n = n / 10;
            //n = (int)(Math.Sqrt(n) / 2.0);
            
            for (int i = 0; i < n; ++i)
            {
                Point position = randomPoint(0, engine.uiContext.SquaresX, 0, engine.uiContext.SquaresY);
                engine.AddObstacleAt(position);
            }

            Invalidate();
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < engine.PlayersCount; ++i)
            {
                Point from = randomPoint(0, engine.uiContext.SquaresX, 0, engine.uiContext.SquaresY);
                Point to;
                int giveUp = 0;
                do
                {
                    to = randomPoint(0, engine.uiContext.SquaresX, 0, engine.uiContext.SquaresY);
                } while (to == from || giveUp++ == 100);

                engine.ResetPlayerToPosition(i, from);
                engine.SetPlayerGoal(i, to);
            }
            Invalidate();
        }

        private Point randomPoint(int minx, int maxx, int miny, int maxy)
        {
            int x = random.Next(minx, maxx);
            int y = random.Next(miny, maxy);

            return new Point(x, y);
        }

    }

    public class PathNode : IPathNode<Object>
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Boolean IsWall { get; set; }

        public bool IsWalkable(Object unused)
        {
            return !IsWall;
        }
    }

    public enum DrawMode { StartA, EndA, StartB, EndB, Wall, WallErase };
}
