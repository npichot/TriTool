using System.Windows.Forms;
namespace TriTool
{
    partial class Photos_Videos
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
            this.titreLabel = new System.Windows.Forms.Label();
            this.selection = new System.Windows.Forms.ListBox();
            this.addFiles = new System.Windows.Forms.Button();
            this.addFolder = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.validate = new System.Windows.Forms.Button();
            this.selectFiles = new System.Windows.Forms.OpenFileDialog();
            this.selectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            this.valider = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.suffText2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.albumText = new System.Windows.Forms.TextBox();
            this.album2Label = new System.Windows.Forms.Label();
            this.apercu2 = new System.Windows.Forms.Label();
            this.categorie2 = new System.Windows.Forms.ComboBox();
            this.catText = new System.Windows.Forms.TextBox();
            this.cat2Label = new System.Windows.Forms.Label();
            this.addCatLabel = new System.Windows.Forms.Label();
            this.gBAdd = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.apercu1 = new System.Windows.Forms.Label();
            this.suffText1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.album1Label = new System.Windows.Forms.Label();
            this.album = new System.Windows.Forms.ComboBox();
            this.cat1Label = new System.Windows.Forms.Label();
            this.categorie1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gBAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // titrePhotos
            // 
            this.titreLabel.AutoSize = true;
            this.titreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreLabel.Location = new System.Drawing.Point(13, 13);
            this.titreLabel.Name = "titrePhotos";
            this.titreLabel.Size = new System.Drawing.Size(0, 20);
            this.titreLabel.TabIndex = 0;
            // 
            // selection
            // 
            this.selection.AllowDrop = true;
            this.selection.FormattingEnabled = true;
            this.selection.Location = new System.Drawing.Point(17, 69);
            this.selection.Name = "selection";
            this.selection.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selection.Size = new System.Drawing.Size(138, 368);
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
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(178, 69);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(500, 368);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 368);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panelPhotos
            // 
            this.panel.Controls.Add(this.valider);
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Controls.Add(this.gBAdd);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panelPhotos";
            this.panel.Size = new System.Drawing.Size(884, 461);
            this.panel.TabIndex = 7;
            this.panel.Visible = false;
            // 
            // valider
            // 
            this.valider.Location = new System.Drawing.Point(384, 400);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(75, 23);
            this.valider.TabIndex = 2;
            this.valider.Text = "Valider";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.suffText2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.albumText);
            this.groupBox1.Controls.Add(this.album2Label);
            this.groupBox1.Controls.Add(this.apercu2);
            this.groupBox1.Controls.Add(this.categorie2);
            this.groupBox1.Controls.Add(this.catText);
            this.groupBox1.Controls.Add(this.cat2Label);
            this.groupBox1.Controls.Add(this.addCatLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 197);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créer un nouvel album";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(38, 82);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // suffText2
            // 
            this.suffText2.Location = new System.Drawing.Point(569, 98);
            this.suffText2.Name = "suffText2";
            this.suffText2.Size = new System.Drawing.Size(131, 20);
            this.suffText2.TabIndex = 17;
            this.suffText2.TextChanged += new System.EventHandler(this.suffText2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(469, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Ajouter un suffixe :";
            // 
            // albumText
            // 
            this.albumText.Location = new System.Drawing.Point(569, 56);
            this.albumText.Name = "albumText";
            this.albumText.Size = new System.Drawing.Size(183, 20);
            this.albumText.TabIndex = 15;
            this.albumText.TextChanged += new System.EventHandler(this.albumText_TextChanged);
            // 
            // album2Label
            // 
            this.album2Label.AutoSize = true;
            this.album2Label.Location = new System.Drawing.Point(478, 59);
            this.album2Label.Name = "album2Label";
            this.album2Label.Size = new System.Drawing.Size(85, 13);
            this.album2Label.TabIndex = 14;
            this.album2Label.Text = "Nom de l\'album :";
            // 
            // apercu2
            // 
            this.apercu2.AutoSize = true;
            this.apercu2.Location = new System.Drawing.Point(473, 139);
            this.apercu2.Name = "apercu2";
            this.apercu2.Size = new System.Drawing.Size(90, 13);
            this.apercu2.TabIndex = 13;
            this.apercu2.Text = "Nom des photos :";
            // 
            // categorie2
            // 
            this.categorie2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categorie2.FormattingEnabled = true;
            this.categorie2.Location = new System.Drawing.Point(203, 61);
            this.categorie2.Name = "categorie2";
            this.categorie2.Size = new System.Drawing.Size(121, 21);
            this.categorie2.TabIndex = 7;
            this.categorie2.SelectedIndexChanged += new System.EventHandler(this.categorie2_SelectedIndexChanged);
            // 
            // catText
            // 
            this.catText.Location = new System.Drawing.Point(203, 99);
            this.catText.Name = "catText";
            this.catText.Size = new System.Drawing.Size(121, 20);
            this.catText.TabIndex = 12;
            this.catText.TextChanged += new System.EventHandler(this.catText_TextChanged);
            // 
            // cat2Label
            // 
            this.cat2Label.AutoSize = true;
            this.cat2Label.Location = new System.Drawing.Point(139, 64);
            this.cat2Label.Name = "cat2Label";
            this.cat2Label.Size = new System.Drawing.Size(58, 13);
            this.cat2Label.TabIndex = 8;
            this.cat2Label.Text = "Catégorie :";
            // 
            // addCatLabel
            // 
            this.addCatLabel.AutoSize = true;
            this.addCatLabel.Location = new System.Drawing.Point(83, 102);
            this.addCatLabel.Name = "addCatLabel";
            this.addCatLabel.Size = new System.Drawing.Size(114, 13);
            this.addCatLabel.TabIndex = 11;
            this.addCatLabel.Text = "Ajouter une catégorie :";
            // 
            // gBAdd
            // 
            this.gBAdd.Controls.Add(this.radioButton1);
            this.gBAdd.Controls.Add(this.apercu1);
            this.gBAdd.Controls.Add(this.suffText1);
            this.gBAdd.Controls.Add(this.label3);
            this.gBAdd.Controls.Add(this.album1Label);
            this.gBAdd.Controls.Add(this.album);
            this.gBAdd.Controls.Add(this.cat1Label);
            this.gBAdd.Controls.Add(this.categorie1);
            this.gBAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBAdd.Location = new System.Drawing.Point(0, 0);
            this.gBAdd.Name = "gBAdd";
            this.gBAdd.Size = new System.Drawing.Size(884, 172);
            this.gBAdd.TabIndex = 0;
            this.gBAdd.TabStop = false;
            this.gBAdd.Text = "Ajouter à un album existant";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(38, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // apercu1
            // 
            this.apercu1.AutoSize = true;
            this.apercu1.Location = new System.Drawing.Point(482, 91);
            this.apercu1.Name = "apercu1";
            this.apercu1.Size = new System.Drawing.Size(90, 13);
            this.apercu1.TabIndex = 6;
            this.apercu1.Text = "Nom des photos :";
            // 
            // suffText1
            // 
            this.suffText1.Location = new System.Drawing.Point(578, 50);
            this.suffText1.Name = "suffText1";
            this.suffText1.Size = new System.Drawing.Size(131, 20);
            this.suffText1.TabIndex = 5;
            this.suffText1.TextChanged += new System.EventHandler(this.suffText1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ajouter un suffixe :";
            // 
            // album1Label
            // 
            this.album1Label.AutoSize = true;
            this.album1Label.Location = new System.Drawing.Point(155, 91);
            this.album1Label.Name = "album1Label";
            this.album1Label.Size = new System.Drawing.Size(42, 13);
            this.album1Label.TabIndex = 3;
            this.album1Label.Text = "Album :";
            // 
            // album
            // 
            this.album.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.album.FormattingEnabled = true;
            this.album.Location = new System.Drawing.Point(203, 88);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(179, 21);
            this.album.TabIndex = 2;
            this.album.SelectedIndexChanged += new System.EventHandler(this.album_SelectedIndexChanged);
            // 
            // cat1Label
            // 
            this.cat1Label.AutoSize = true;
            this.cat1Label.Location = new System.Drawing.Point(139, 53);
            this.cat1Label.Name = "cat1Label";
            this.cat1Label.Size = new System.Drawing.Size(58, 13);
            this.cat1Label.TabIndex = 1;
            this.cat1Label.Text = "Catégorie :";
            // 
            // categorie1
            // 
            this.categorie1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categorie1.FormattingEnabled = true;
            this.categorie1.Location = new System.Drawing.Point(203, 50);
            this.categorie1.Name = "categorie1";
            this.categorie1.Size = new System.Drawing.Size(121, 21);
            this.categorie1.TabIndex = 0;
            this.categorie1.SelectedIndexChanged += new System.EventHandler(this.categorie1_SelectedIndexChanged);
            // 
            // Photos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.validate);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.addFolder);
            this.Controls.Add(this.addFiles);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.titreLabel);
            this.Name = "Photos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBAdd.ResumeLayout(false);
            this.gBAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titreLabel;
        private System.Windows.Forms.ListBox selection;
        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button addFolder;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button validate;
        private OpenFileDialog selectFiles;
        private FolderBrowserDialog selectFolder;
        private PictureBox pictureBox1;
        private Panel panel;
        private Button valider;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private TextBox suffText2;
        private Label label8;
        private TextBox albumText;
        private Label album2Label;
        private Label apercu2;
        private ComboBox categorie2;
        private TextBox catText;
        private Label cat2Label;
        private Label addCatLabel;
        private GroupBox gBAdd;
        private RadioButton radioButton1;
        private Label apercu1;
        private TextBox suffText1;
        private Label label3;
        private Label album1Label;
        private ComboBox album;
        private Label cat1Label;
        private ComboBox categorie1;
    }
}