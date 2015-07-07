namespace TriTool
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.musiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dossiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redéfinirLesCheminsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musiqueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.photosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vidéosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musiqueToolStripMenuItem,
            this.photosToolStripMenuItem,
            this.vidéosToolStripMenuItem,
            this.dossiersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // musiqueToolStripMenuItem
            // 
            this.musiqueToolStripMenuItem.Name = "musiqueToolStripMenuItem";
            this.musiqueToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.musiqueToolStripMenuItem.Text = "Musiques";
            this.musiqueToolStripMenuItem.Click += new System.EventHandler(this.musiqueToolStripMenuItem_Click);
            // 
            // photosToolStripMenuItem
            // 
            this.photosToolStripMenuItem.Name = "photosToolStripMenuItem";
            this.photosToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.photosToolStripMenuItem.Text = "Photos";
            this.photosToolStripMenuItem.Click += new System.EventHandler(this.photosToolStripMenuItem_Click);
            // 
            // dossiersToolStripMenuItem
            // 
            this.dossiersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redéfinirLesCheminsToolStripMenuItem,
            this.afficherToolStripMenuItem});
            this.dossiersToolStripMenuItem.Name = "dossiersToolStripMenuItem";
            this.dossiersToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.dossiersToolStripMenuItem.Text = "Dossiers";
            // 
            // redéfinirLesCheminsToolStripMenuItem
            // 
            this.redéfinirLesCheminsToolStripMenuItem.Name = "redéfinirLesCheminsToolStripMenuItem";
            this.redéfinirLesCheminsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.redéfinirLesCheminsToolStripMenuItem.Text = "Redéfinir les chemins";
            this.redéfinirLesCheminsToolStripMenuItem.Click += new System.EventHandler(this.redéfinirLesCheminsToolStripMenuItem_Click);
            // 
            // afficherToolStripMenuItem
            // 
            this.afficherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musiqueToolStripMenuItem1,
            this.photosToolStripMenuItem1,
            this.videosToolStripMenuItem});
            this.afficherToolStripMenuItem.Name = "afficherToolStripMenuItem";
            this.afficherToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.afficherToolStripMenuItem.Text = "Afficher";
            // 
            // musiqueToolStripMenuItem1
            // 
            this.musiqueToolStripMenuItem1.Name = "musiqueToolStripMenuItem1";
            this.musiqueToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.musiqueToolStripMenuItem1.Text = "Musique";
            this.musiqueToolStripMenuItem1.Click += new System.EventHandler(this.musiqueToolStripMenuItem1_Click);
            // 
            // photosToolStripMenuItem1
            // 
            this.photosToolStripMenuItem1.Name = "photosToolStripMenuItem1";
            this.photosToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.photosToolStripMenuItem1.Text = "Photos";
            this.photosToolStripMenuItem1.Click += new System.EventHandler(this.photosToolStripMenuItem1_Click);
            // 
            // vidéosToolStripMenuItem
            // 
            this.vidéosToolStripMenuItem.Name = "vidéosToolStripMenuItem";
            this.vidéosToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.vidéosToolStripMenuItem.Text = "Vidéos";
            this.vidéosToolStripMenuItem.Click += new System.EventHandler(this.vidéosToolStripMenuItem_Click);
            // 
            // videosToolStripMenuItem
            // 
            this.videosToolStripMenuItem.Name = "videosToolStripMenuItem";
            this.videosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.videosToolStripMenuItem.Text = "Videos";
            this.videosToolStripMenuItem.Click += new System.EventHandler(this.videosToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TriTool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem musiqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dossiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redéfinirLesCheminsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musiqueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem photosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vidéosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videosToolStripMenuItem;
    }
}

