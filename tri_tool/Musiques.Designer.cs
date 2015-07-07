using System.Windows.Forms;
namespace TriTool
{
    partial class Musiques
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
            this.panelSaisie = new System.Windows.Forms.Panel();
            this.next = new System.Windows.Forms.Button();
            this.saisie = new System.Windows.Forms.TextBox();
            this.titreMusique = new System.Windows.Forms.Label();
            this.selection = new System.Windows.Forms.ListBox();
            this.addFiles = new System.Windows.Forms.Button();
            this.addFolder = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.validate = new System.Windows.Forms.Button();
            this.selectFiles = new System.Windows.Forms.OpenFileDialog();
            this.selectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.selectionArtists = new System.Windows.Forms.ListBox();
            this.selectionAlbums = new System.Windows.Forms.ListBox();
            this.panelSaisie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSaisie
            // 
            this.panelSaisie.Controls.Add(this.next);
            this.panelSaisie.Controls.Add(this.saisie);
            this.panelSaisie.Location = new System.Drawing.Point(646, 0);
            this.panelSaisie.Name = "panelSaisie";
            this.panelSaisie.Size = new System.Drawing.Size(238, 461);
            this.panelSaisie.TabIndex = 6;
            this.panelSaisie.Visible = false;
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(151, 182);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 1;
            this.next.Text = "Suivant";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // saisie
            // 
            this.saisie.Location = new System.Drawing.Point(13, 138);
            this.saisie.Name = "saisie";
            this.saisie.Size = new System.Drawing.Size(213, 20);
            this.saisie.TabIndex = 0;
            // 
            // titreMusique
            // 
            this.titreMusique.AutoSize = true;
            this.titreMusique.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreMusique.Location = new System.Drawing.Point(13, 13);
            this.titreMusique.Name = "titreMusique";
            this.titreMusique.Size = new System.Drawing.Size(0, 20);
            this.titreMusique.TabIndex = 0;
            // 
            // selection
            // 
            this.selection.AllowDrop = true;
            this.selection.FormattingEnabled = true;
            this.selection.Location = new System.Drawing.Point(17, 69);
            this.selection.Name = "selection";
            this.selection.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selection.Size = new System.Drawing.Size(576, 368);
            this.selection.TabIndex = 1;
            this.selection.SelectedIndexChanged += new System.EventHandler(this.selection_SelectedIndexChanged);
            this.selection.DragDrop += new System.Windows.Forms.DragEventHandler(this.selection_DragDrop);
            this.selection.DragEnter += new System.Windows.Forms.DragEventHandler(this.selection_DragEnter);
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(714, 110);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(96, 23);
            this.addFiles.TabIndex = 2;
            this.addFiles.Text = "Ajouter fichiers";
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.addFiles_Click);
            // 
            // addFolder
            // 
            this.addFolder.Location = new System.Drawing.Point(714, 169);
            this.addFolder.Name = "addFolder";
            this.addFolder.Size = new System.Drawing.Size(96, 23);
            this.addFolder.TabIndex = 3;
            this.addFolder.Text = "Ajouter dossier";
            this.addFolder.UseVisualStyleBackColor = true;
            this.addFolder.Click += new System.EventHandler(this.addFolder_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(714, 231);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(96, 23);
            this.remove.TabIndex = 4;
            this.remove.Text = "Retirer";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // validate
            // 
            this.validate.Location = new System.Drawing.Point(714, 386);
            this.validate.Name = "validate";
            this.validate.Size = new System.Drawing.Size(96, 23);
            this.validate.TabIndex = 5;
            this.validate.Text = "Valider";
            this.validate.UseVisualStyleBackColor = true;
            this.validate.Click += new System.EventHandler(this.validate_Click);
            // 
            // selectionArtists
            // 
            this.selectionArtists.FormattingEnabled = true;
            this.selectionArtists.Location = new System.Drawing.Point(442, 69);
            this.selectionArtists.Name = "selectionArtists";
            this.selectionArtists.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectionArtists.Size = new System.Drawing.Size(151, 368);
            this.selectionArtists.TabIndex = 7;
            this.selectionArtists.Visible = false;
            this.selectionArtists.SelectedIndexChanged += new System.EventHandler(this.selectionArtists_SelectedIndexChanged);
            // 
            // selectionAlbums
            // 
            this.selectionAlbums.FormattingEnabled = true;
            this.selectionAlbums.Location = new System.Drawing.Point(442, 69);
            this.selectionAlbums.Name = "selectionAlbums";
            this.selectionAlbums.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectionAlbums.Size = new System.Drawing.Size(151, 368);
            this.selectionAlbums.TabIndex = 8;
            this.selectionAlbums.Visible = false;
            this.selectionAlbums.SelectedIndexChanged += new System.EventHandler(this.selectionAlbums_SelectedIndexChanged);
            // 
            // Musique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.selectionAlbums);
            this.Controls.Add(this.selectionArtists);
            this.Controls.Add(this.panelSaisie);
            this.Controls.Add(this.validate);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.addFolder);
            this.Controls.Add(this.addFiles);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.titreMusique);
            this.Name = "Musique";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Musique";
            this.panelSaisie.ResumeLayout(false);
            this.panelSaisie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titreMusique;
        private System.Windows.Forms.ListBox selection;
        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button addFolder;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button validate;
        private OpenFileDialog selectFiles;
        private FolderBrowserDialog selectFolder;
        private Button next;
        private TextBox saisie;
        private Panel panelSaisie;
        private ListBox selectionArtists;
        private ListBox selectionAlbums;
    }
}