using System;
using tri_tool;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using tri_tool.Properties;


namespace TriTool
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            if (!Settings.Default.initFolder || !Directory.Exists(Settings.Default.Musique)
                || !Directory.Exists(Settings.Default.Photos)
                || !Directory.Exists(Settings.Default.Videos))
            {
                startForm(0);
                Settings.Default.initFolder = false;
                Settings.Default.Save();
            }
        }

        private void musiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startForm(1);
        }

        private void startForm(int p)
        {
            Form instance = null;

            // Looking for MyForm among all opened forms 
            foreach (Form form in Application.OpenForms)
                switch (p)
                {
                    case 0:
                        if (form is Dossiers)
                        {
                            instance = form;
                            break;
                        }
                        break;
                    case 1:
                        if (form is Musiques)
                        {
                            instance = form;
                            break;
                        }
                        break;
                    case 2:
                    case 3:
                        if (form is Photos_Videos)
                        {
                            instance = form;
                            break;
                        }
                        break;
                }

            if (Object.ReferenceEquals(null, instance))
            {
                switch (p)
                {
                    case 0:
                        instance = new Dossiers();
                        instance.MdiParent = this;
                        instance.Show();
                        break;
                    case 1:
                        instance = new Musiques();
                        instance.MdiParent = this;
                        instance.Show();
                        instance.WindowState = FormWindowState.Maximized;
                        break;
                    case 2:
                        instance = new Photos_Videos(true);
                        instance.MdiParent = this;
                        instance.Show();
                        instance.WindowState = FormWindowState.Maximized;
                        break;
                    case 3:
                        instance = new Photos_Videos(false);
                        instance.MdiParent = this;
                        instance.Show();
                        instance.WindowState = FormWindowState.Maximized;
                        break;
                }
            }
            else
            {
                instance.BringToFront();
            }
        }

        private void redéfinirLesCheminsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startForm(0);
        }

        private void musiqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.Musique);
        }

        private void photosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startForm(2);
        }

        private void photosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.Photos);
        }

        private void videosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.Videos);
        }

        private void vidéosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startForm(3);
        }
    }
}
