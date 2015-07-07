namespace TriTool
{
    partial class Dossiers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pathMusique = new System.Windows.Forms.TextBox();
            this.browseMusique = new System.Windows.Forms.Button();
            this.valider = new System.Windows.Forms.Button();
            this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.browsePhotos = new System.Windows.Forms.Button();
            this.pathPhotos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.browseVideos = new System.Windows.Forms.Button();
            this.pathVideos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veuillez définir un emplacement pour stocker votre musique";
            // 
            // pathMusique
            // 
            this.pathMusique.Location = new System.Drawing.Point(13, 30);
            this.pathMusique.Name = "pathMusique";
            this.pathMusique.Size = new System.Drawing.Size(400, 20);
            this.pathMusique.TabIndex = 1;
            // 
            // browseMusique
            // 
            this.browseMusique.Location = new System.Drawing.Point(442, 28);
            this.browseMusique.Name = "browseMusique";
            this.browseMusique.Size = new System.Drawing.Size(75, 23);
            this.browseMusique.TabIndex = 2;
            this.browseMusique.Text = "Browse";
            this.browseMusique.UseVisualStyleBackColor = true;
            this.browseMusique.Click += new System.EventHandler(this.browseMusique_Click);
            // 
            // valider
            // 
            this.valider.Location = new System.Drawing.Point(442, 183);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(75, 23);
            this.valider.TabIndex = 3;
            this.valider.Text = "Valider";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // browsePhotos
            // 
            this.browsePhotos.Location = new System.Drawing.Point(442, 81);
            this.browsePhotos.Name = "browsePhotos";
            this.browsePhotos.Size = new System.Drawing.Size(75, 23);
            this.browsePhotos.TabIndex = 6;
            this.browsePhotos.Text = "Browse";
            this.browsePhotos.UseVisualStyleBackColor = true;
            this.browsePhotos.Click += new System.EventHandler(this.browsePhotos_Click);
            // 
            // pathPhotos
            // 
            this.pathPhotos.Location = new System.Drawing.Point(12, 81);
            this.pathPhotos.Name = "pathPhotos";
            this.pathPhotos.Size = new System.Drawing.Size(400, 20);
            this.pathPhotos.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Veuillez définir un emplacement pour stocker vos photos";
            // 
            // browseVideos
            // 
            this.browseVideos.Location = new System.Drawing.Point(443, 133);
            this.browseVideos.Name = "browseVideos";
            this.browseVideos.Size = new System.Drawing.Size(75, 23);
            this.browseVideos.TabIndex = 9;
            this.browseVideos.Text = "Browse";
            this.browseVideos.UseVisualStyleBackColor = true;
            this.browseVideos.Click += new System.EventHandler(this.browseVideos_Click);
            // 
            // pathVideos
            // 
            this.pathVideos.Location = new System.Drawing.Point(13, 133);
            this.pathVideos.Name = "pathVideos";
            this.pathVideos.Size = new System.Drawing.Size(400, 20);
            this.pathVideos.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Veuillez définir un emplacement pour stocker vos vidéos";
            // 
            // Dossiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 223);
            this.Controls.Add(this.browseVideos);
            this.Controls.Add(this.pathVideos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browsePhotos);
            this.Controls.Add(this.pathPhotos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.browseMusique);
            this.Controls.Add(this.pathMusique);
            this.Controls.Add(this.label1);
            this.Name = "Dossiers";
            this.Text = "Dossiers";
            this.Load += new System.EventHandler(this.Dossiers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathMusique;
        private System.Windows.Forms.Button browseMusique;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.FolderBrowserDialog openFolder;
        private System.Windows.Forms.Button browsePhotos;
        private System.Windows.Forms.TextBox pathPhotos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseVideos;
        private System.Windows.Forms.TextBox pathVideos;
        private System.Windows.Forms.Label label3;
    }
}