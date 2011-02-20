namespace Astar
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.drawStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawGoalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.drawStartBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawGoalBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.drawWallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseWallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obstaclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawStartToolStripMenuItem,
            this.drawGoalToolStripMenuItem,
            this.toolStripMenuItem2,
            this.drawStartBToolStripMenuItem,
            this.drawGoalBToolStripMenuItem,
            this.toolStripMenuItem1,
            this.drawWallToolStripMenuItem,
            this.eraseWallToolStripMenuItem,
            this.toolStripMenuItem3,
            this.searchToolStripMenuItem,
            this.toolStripMenuItem4,
            this.randomToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 226);
            // 
            // drawStartToolStripMenuItem
            // 
            this.drawStartToolStripMenuItem.Checked = true;
            this.drawStartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawStartToolStripMenuItem.Name = "drawStartToolStripMenuItem";
            this.drawStartToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.drawStartToolStripMenuItem.Text = "Draw Start A";
            this.drawStartToolStripMenuItem.Click += new System.EventHandler(this.drawStartToolStripMenuItem_Click);
            // 
            // drawGoalToolStripMenuItem
            // 
            this.drawGoalToolStripMenuItem.Name = "drawGoalToolStripMenuItem";
            this.drawGoalToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.drawGoalToolStripMenuItem.Text = "Draw Goal A";
            this.drawGoalToolStripMenuItem.Click += new System.EventHandler(this.drawGoalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 6);
            // 
            // drawStartBToolStripMenuItem
            // 
            this.drawStartBToolStripMenuItem.Name = "drawStartBToolStripMenuItem";
            this.drawStartBToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.drawStartBToolStripMenuItem.Text = "Draw Start B";
            this.drawStartBToolStripMenuItem.Click += new System.EventHandler(this.drawStartBToolStripMenuItem_Click);
            // 
            // drawGoalBToolStripMenuItem
            // 
            this.drawGoalBToolStripMenuItem.Name = "drawGoalBToolStripMenuItem";
            this.drawGoalBToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.drawGoalBToolStripMenuItem.Text = "Draw Goal B";
            this.drawGoalBToolStripMenuItem.Click += new System.EventHandler(this.drawGoalBToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 6);
            // 
            // drawWallToolStripMenuItem
            // 
            this.drawWallToolStripMenuItem.Name = "drawWallToolStripMenuItem";
            this.drawWallToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.drawWallToolStripMenuItem.Text = "Draw Wall";
            this.drawWallToolStripMenuItem.Click += new System.EventHandler(this.drawWallToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 6);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // eraseWallToolStripMenuItem
            // 
            this.eraseWallToolStripMenuItem.Name = "eraseWallToolStripMenuItem";
            this.eraseWallToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eraseWallToolStripMenuItem.Text = "Erase Wall";
            this.eraseWallToolStripMenuItem.Click += new System.EventHandler(this.eraseWallToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obstaclesToolStripMenuItem,
            this.playersToolStripMenuItem});
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.randomToolStripMenuItem.Text = "Random";
            // 
            // obstaclesToolStripMenuItem
            // 
            this.obstaclesToolStripMenuItem.Name = "obstaclesToolStripMenuItem";
            this.obstaclesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.obstaclesToolStripMenuItem.Text = "Obstacles";
            this.obstaclesToolStripMenuItem.Click += new System.EventHandler(this.obstaclesToolStripMenuItem_Click);
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playersToolStripMenuItem.Text = "Players";
            this.playersToolStripMenuItem.Click += new System.EventHandler(this.playersToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 328);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem drawStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawGoalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawWallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem drawStartBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawGoalBToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem eraseWallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obstaclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;

    }
}

