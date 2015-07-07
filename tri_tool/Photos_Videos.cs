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
    public partial class Photos_Videos : Form
    {
        private Dictionary<string, string> inputFiles;//path-name
        private Dictionary<string, string> titles;//path-titles
        private List<string> errors;
        private Image image;
        private string format;
        private string filter;
        private string root;

        private bool execute = true;
        private bool photos;

        public Photos_Videos(bool photos)
        {
            this.photos = photos;
            InitializeComponent();

            if (photos)
            {
                titreLabel.Text = Settings.Default.TitreSelectionPhotos;
                this.Text = "Photos";
                filter = "IMG|*.jpg;*.png|All Files|*.*";
                format = "*.jpg|*.png";
                this.selection.Size = new Size(138, 368);
                this.pictureBox1.Visible = true;
                root = Settings.Default.Photos;
            }
            else
            {
                titreLabel.Text = Settings.Default.TitreSelectionVideos;
                this.Text = "Vidéos";
                filter = "VIDEO|*.avi;*.mov;*.mp4|All Files|*.*";
                format = "*.avi|*.mov|*.mp4";
                this.selection.Size = new Size(368, 368);
                this.pictureBox1.Visible = false;
                root = Settings.Default.Videos;
            }

            inputFiles = new Dictionary<string, string>();
            titles = new Dictionary<string, string>();
            errors = new List<string>();
        }

        public IEnumerable<string> getKey(Dictionary<string, string> d, string value)
        {
            return (from p in d where p.Value == value select p.Key);
        }

        private void addFiles_Click(object sender, EventArgs e)
        {
            selectFiles.InitialDirectory = Settings.Default.LastSelectionFolder;
            selectFiles.Multiselect = true;
            selectFiles.Filter = filter;
            selectFiles.Title = "Choisir des " + this.Text;
            selectFiles.ShowDialog();

            if (selectFiles.FileNames.Length != 0)
            {
                Settings.Default.LastSelectionFolder = Path.GetDirectoryName(selectFiles.FileNames[0]);
                Settings.Default.Save();
            }

            foreach (string f in selectFiles.FileNames)
            {
                if (!inputFiles.ContainsValue(f))
                {
                    inputFiles.Add(f, Path.GetFileNameWithoutExtension(f));
                    selection.Items.Add(Path.GetFileNameWithoutExtension(f));
                }
            }
        }

        private void addFolder_Click(object sender, EventArgs e)
        {
            selectFolder.ShowNewFolderButton = false;
            selectFolder.SelectedPath = Settings.Default.LastSelectionFolder;
            MessageBox.Show("Seuls les " + this.Text + " seront sélectionnés !", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            selectFolder.ShowDialog();
            Settings.Default.LastSelectionFolder = selectFolder.SelectedPath;
            Settings.Default.Save();


            string[] fileNames = Directory.GetFiles(selectFolder.SelectedPath, format, SearchOption.TopDirectoryOnly);
            foreach (string f in fileNames)
            {
                if (!inputFiles.ContainsValue(f))
                {
                    inputFiles.Add(f, Path.GetFileNameWithoutExtension(f));
                    selection.Items.Add(Path.GetFileNameWithoutExtension(f));
                }
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            List<Object> temp = new List<object>();
            foreach (var item in selection.SelectedItems)
                temp.Add(item);

            foreach (var it in temp)
            {
                try { inputFiles.Remove(getKey(inputFiles, selection.GetItemText(it)).ElementAt(0)); }
                catch { inputFiles.Remove(getKey(inputFiles, selection.GetItemText(it)).ElementAt(1)); }
                execute = false;
                selection.Items.Remove(it);
            }
        }

        void selection_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void selection_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string f in files)
            {
                if (!inputFiles.ContainsValue(f))
                {
                    inputFiles.Add(f, Path.GetFileNameWithoutExtension(f));
                    selection.Items.Add(Path.GetFileNameWithoutExtension(f));
                }
            }
        }


        private void validate_Click(object sender, EventArgs e)
        {
            if (selection.Items.Count != 0)
            {
                try { pictureBox1.Image.Dispose(); }
                catch { }
                step2();
            }

        }

        private void selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (photos)
            {
                if (selection.SelectedIndex == -1)
                {
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();//dispose the old image.
                    return;
                }
                if (execute)
                {
                    string imgPath = getKey(inputFiles, selection.GetItemText(selection.SelectedItem)).ElementAt(0);
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();//dispose the old image.
                    image = Image.FromFile(imgPath);
                    pictureBox1.Image = image;
                }
                else
                    execute = true;
            }
        }

        private void step2()
        {
            panel.Visible = true;

            var cat = Directory.GetDirectories(root, "*", SearchOption.TopDirectoryOnly);
            foreach (string s in cat)
            {
                categorie1.Items.Add(Path.GetFileName(s));
                categorie2.Items.Add(Path.GetFileName(s));
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (execute)
            {
                execute = false;
                categorie2.SelectedIndex = -1;
                execute = false;
                radioButton2.Checked = false;
                execute = false;
                catText.Clear();
                execute = false;
                albumText.Clear();
                suffText2.Clear();
                apercu2.Text = "Nom des " + this.Text + " :";
                execute = true;
            }
            else
                execute = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (execute)
            {
                execute = false;
                categorie1.SelectedIndex = -1;
                execute = false;
                album.SelectedIndex = -1;
                execute = false;
                radioButton1.Checked = false;
                suffText1.Clear();
                apercu1.Text = "Nom des " + this.Text + " :";
                execute = true;
            }
            else
                execute = true;
        }

        private void categorie1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            album.Items.Clear();
            if (categorie1.SelectedIndex != -1)
            {
                var alb = Directory.GetDirectories(Path.Combine(root, categorie1.Text), "*", SearchOption.TopDirectoryOnly);
                foreach (string s in alb)
                    album.Items.Add(Path.GetFileName(s));

                updateApercu(1);
            }
        }

        private void updateApercu(int p)
        {
            switch (p)
            {
                case 1:
                    if (categorie1.SelectedIndex != -1 && album.SelectedIndex != -1)
                        apercu1.Text = "Nom des " + this.Text + " :  " + album.Text.Replace(" ", "_");
                    else
                        apercu1.Text = "Nom des " + this.Text + " :";

                    if (apercu1.Text != "Nom des " + this.Text + " :" && suffText1.Text != "")
                        apercu1.Text += "_" + suffText1.Text.Replace(" ", "_");
                    break;
                case 2:
                    if (categorie2.SelectedIndex != -1 && albumText.Text != "")
                        apercu2.Text = "Nom des " + this.Text + " :  " + albumText.Text.Replace(" ", "_");
                    else if (catText.Text != "" && albumText.Text != "")
                        apercu2.Text = "Nom des " + this.Text + " :  " + albumText.Text.Replace(" ", "_");
                    else
                        apercu2.Text = "Nom des " + this.Text + " :";

                    if (apercu2.Text != "Nom des " + this.Text + " :" && suffText2.Text != "")
                        apercu2.Text += "_" + suffText2.Text.Replace(" ", "_");
                    break;
            }
        }

        private void album_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            if (album.SelectedIndex != -1)
                updateApercu(1);
        }

        private void suffText1_TextChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            updateApercu(1);
        }

        private void categorie2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (execute)
            {
                radioButton2.Checked = true;
                if (album.SelectedIndex != -1)
                    updateApercu(2);
                execute = false;
                catText.Clear();
                execute = true;
            }
            else
                execute = true;
        }

        private void catText_TextChanged(object sender, EventArgs e)
        {
            if (execute)
            {
                radioButton2.Checked = true;
                updateApercu(2);
                execute = false;
                categorie2.SelectedIndex = -1;
            }
            else
                execute = true;
        }

        private void albumText_TextChanged(object sender, EventArgs e)
        {
            if (execute)
            {
                radioButton2.Checked = true;
                updateApercu(2);
            }
            else
                execute = true;
        }

        private void suffText2_TextChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            updateApercu(2);
        }

        private void valider_Click(object sender, EventArgs e)
        {
            if (!check())
                return;

            string destination;
            string name;
            if (radioButton1.Checked)
            {
                destination = Path.Combine(root, categorie1.Text, album.Text);

                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);

                if (suffText1.Text != "")
                    name = album.Text.Replace(" ", "_") + "_" + suffText1.Text;
                else
                    name = album.Text.Replace(" ", "_");

                var files = Directory.GetFiles(destination, "*" + name + "*", SearchOption.TopDirectoryOnly);

                int cpt = files.Length + 1;
                foreach (var pair in inputFiles)
                {
                    if (!File.Exists(Path.Combine(destination, name + " (" + cpt + ")" + Path.GetExtension(pair.Key))))
                        try { File.Move(pair.Key, Path.Combine(destination, name + " (" + cpt + ")" + Path.GetExtension(pair.Key))); cpt++; }
                        catch (Exception exc) { errors.Add(pair.Value + exc.Message); }
                    else
                        errors.Add(pair.Value);
                }

                fin();

            }
            else if (radioButton2.Checked)
            {
                if (categorie2.SelectedIndex != -1)
                    destination = Path.Combine(root, categorie2.Text, albumText.Text.Replace("_", " "));
                else
                    destination = Path.Combine(root, catText.Text, albumText.Text.Replace("_", " "));

                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);
                else
                {
                    MessageBox.Show("L'album existe déjà !", "Album en double", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var files = Directory.GetFiles(destination, "*", SearchOption.TopDirectoryOnly);

                int cpt = files.Length + 1;
                foreach (var pair in inputFiles)
                {
                    if (suffText2.Text != "")
                        name = albumText.Text.Replace(" ", "_") + "_" + suffText2.Text + " (" + cpt + ")" + Path.GetExtension(pair.Key);
                    else
                        name = albumText.Text.Replace(" ", "_") + " (" + cpt + ")" + Path.GetExtension(pair.Key);

                    if (!File.Exists(Path.Combine(destination, name)))
                        try { File.Move(pair.Key, Path.Combine(destination, name)); cpt++; }
                        catch (Exception exc) { errors.Add(pair.Value + exc.Message); }
                    else
                        errors.Add(pair.Value);


                }
                fin();
            }
        }

        private void fin()
        {
            if (errors.Count != 0)
            {
                string text = "";
                foreach (string s in errors)
                    text += s + "\n";
                MessageBox.Show(text, "Liste des erreurs", MessageBoxButtons.OK);
            }

            DialogResult dialogResult = MessageBox.Show("Voulez recommencez ?", "Fin du process", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Photos_Videos f = new Photos_Videos(photos);
                f.MdiParent = this.MdiParent;
                f.Show();
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                Close();
            }
        }

        private bool check()
        {
            bool result = true;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Veuillez cocher une option", "Aucune option cochée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (radioButton1.Checked)
            {
                if (categorie1.SelectedIndex == -1)
                {
                    cat1Label.ForeColor = Color.Red;
                    result = false;
                }
                else
                    cat1Label.ForeColor = Color.Black;

                if (album.SelectedIndex == -1)
                {
                    album1Label.ForeColor = Color.Red;
                    result = false;
                }
                else
                    album1Label.ForeColor = Color.Black;

            }
            else if (radioButton2.Checked)
            {
                if (categorie2.SelectedIndex == -1 && catText.Text == "")
                {
                    cat2Label.ForeColor = Color.Red;
                    addCatLabel.ForeColor = Color.Red;
                    result = false;
                }
                else
                {
                    cat2Label.ForeColor = Color.Black;
                    addCatLabel.ForeColor = Color.Black;
                }

                if (albumText.Text == "")
                {
                    album2Label.ForeColor = Color.Red;
                    result = false;
                }
                else
                    album2Label.ForeColor = Color.Black;
            }

            return result;

        }
    }
}
