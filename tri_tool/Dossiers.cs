using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tri_tool.Properties;
using System.IO;

namespace TriTool
{
    public partial class Dossiers : Form
    {
        public Dossiers()
        {
            InitializeComponent();

            pathMusique.Text = Settings.Default.Musique;
            pathPhotos.Text = Settings.Default.Photos;
            pathVideos.Text = Settings.Default.Videos;
        }

        private void browseMusique_Click(object sender, EventArgs e)
        {
            openFolder.SelectedPath = pathMusique.Text;
            openFolder.ShowDialog();
            pathMusique.Text = openFolder.SelectedPath;
        }

        private void valider_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(pathMusique.Text) || !Directory.Exists(pathPhotos.Text) || !Directory.Exists(pathVideos.Text))
                MessageBox.Show("Veuillez revoir les chemins définis.", "Chemin introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Settings.Default.Musique = pathMusique.Text;
                Settings.Default.Photos = pathPhotos.Text;
                Settings.Default.Videos = pathVideos.Text;
                Settings.Default.initFolder = true;
                Settings.Default.Save();
                Close();
            }
        }

        private void Dossiers_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Dossiers_FormClosing);
        }

        private void Dossiers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Settings.Default.initFolder)
                e.Cancel = true;
        }

        private void browsePhotos_Click(object sender, EventArgs e)
        {
            openFolder.SelectedPath = pathPhotos.Text;
            openFolder.ShowDialog();
            pathPhotos.Text = openFolder.SelectedPath;
        }

        private void browseVideos_Click(object sender, EventArgs e)
        {
            openFolder.SelectedPath = pathVideos.Text;
            openFolder.ShowDialog();
            pathVideos.Text = openFolder.SelectedPath;
        }
    }
}
