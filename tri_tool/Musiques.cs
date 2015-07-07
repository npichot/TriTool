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
using System.Globalization;
using System.Text.RegularExpressions;

namespace TriTool
{
    public partial class Musiques : Form
    {
        private Dictionary<string, string> inputFiles;//path-name
        private Dictionary<string, string> artists;//path-artists
        private Dictionary<string, string> albums;//path-albums
        private Dictionary<string, string> titles;//path-titles
        private List<string> errors;

        private bool synchronize = true;

        public Musiques()
        {
            InitializeComponent();
            titreMusique.Text = Settings.Default.TitreSelectionMusique;

            saisie.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            saisie.AutoCompleteSource = AutoCompleteSource.CustomSource;

            inputFiles = new Dictionary<string, string>();
            artists = new Dictionary<string, string>();
            albums = new Dictionary<string, string>();
            titles = new Dictionary<string, string>();
            errors = new List<string>();
        }


        public IEnumerable<string> getKey(Dictionary<string, string> d, string value)
        {
            return (from p in d where p.Value == value select p.Key);
        }

        public void scanAuto()
        {
            foreach (var pair in inputFiles)
            {
                try
                {
                    TagLib.File f = TagLib.File.Create(pair.Key);
                    if (f.Tag.Performers.Length != 0)
                        artists.Add(pair.Key, f.Tag.Performers[0]);
                    if (!String.IsNullOrEmpty(f.Tag.Album))
                        albums.Add(pair.Key, f.Tag.Album);
                    if (!String.IsNullOrEmpty(f.Tag.Title))
                        titles.Add(pair.Key, f.Tag.Title);
                }
                catch (TagLib.CorruptFileException e)
                {
                    continue;
                }

            }
        }

        /*
         * 
         * ******************  STEP 1  *******************
         * 
         */
        private void addFiles_Click(object sender, EventArgs e)
        {
            selectFiles.InitialDirectory = Settings.Default.LastSelectionFolder;
            selectFiles.Multiselect = true;
            selectFiles.Filter = "MP3|*.mp3|All Files|*.*";
            selectFiles.Title = "Choisir des fichiers audios";
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
            MessageBox.Show("Seuls les mp3 seront sélectionnés !", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            selectFolder.ShowDialog();
            Settings.Default.LastSelectionFolder = selectFolder.SelectedPath;
            Settings.Default.Save();


            string[] fileNames = Directory.GetFiles(selectFolder.SelectedPath, "*.mp3", SearchOption.TopDirectoryOnly);
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
            //foreach (var item in selection.Items)
            //{
            //    TagLib.File f = TagLib.File.Create(getKey(inputFiles, selection.GetItemText(item)).ElementAt(0));
            //    f.Tag.Title = "";
            //    f.Save();
            //}
            scanAuto();
            selection.Items.Clear();
            foreach (var pair in inputFiles)
            {
                if (!artists.ContainsKey(pair.Key))
                    selection.Items.Add(pair.Value);
            }

            if (selection.Items.Count == 0)
                setAlbumInterface();
            else
            {
                panelSaisie.Visible = true;
                titreMusique.Text = Settings.Default.TitreArtisteMusique;
                selection.SelectedIndex = 0;
                saisie.Focus();
                setArtistAutoCompletion();
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (titreMusique.Text == Settings.Default.TitreArtisteMusique)
                nextStep2();
            else if (titreMusique.Text == Settings.Default.TitreAlbumMusique)
                nextStep3();
            else if (titreMusique.Text == Settings.Default.TitreChansonMusique)
                nextStep4();
        }


        /*
         * 
         * ******************  STEP 2 : Artiste *******************
         * 
         */
        private void nextStep2()
        {
            if (!saisie.AutoCompleteCustomSource.Contains(saisie.Text)
                && (CultureInfo.CurrentCulture.TextInfo.ToTitleCase(saisie.Text) != saisie.Text))
                saisie.Text = doYouMean();

            //Affect the artist
            List<Object> temp = new List<object>();
            foreach (var item in selection.SelectedItems)
            {
                try { artists.Add(getKey(inputFiles, selection.GetItemText(item)).ElementAt(0), saisie.Text); }
                catch { artists.Add(getKey(inputFiles, selection.GetItemText(item)).ElementAt(1), saisie.Text); }
                temp.Add(item);
            }

            if (!saisie.AutoCompleteCustomSource.Contains(saisie.Text))
                saisie.AutoCompleteCustomSource.Add(saisie.Text);

            //Remove from the list
            foreach (var it in temp)
                selection.Items.Remove(it);

            //go to next 
            if (selection.Items.Count > 0)
            {
                selection.SelectedIndex = 0;
                saisie.Clear();
                saisie.Focus();
            }
            else
                setAlbumInterface();
        }

        private void setArtistAutoCompletion()
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();

            string[] list = Directory.GetDirectories(Settings.Default.Musique, "*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < list.Length; i++)
                source.Add(Path.GetFileName(list[i]));

            saisie.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            saisie.AutoCompleteSource = AutoCompleteSource.CustomSource;
            saisie.AutoCompleteCustomSource = source;
        }

        /*
         * 
         * ******************  STEP 3 : Album *******************
         * 
         */
        private void nextStep3()
        {
            if (!saisie.AutoCompleteCustomSource.Contains(saisie.Text)
                && (CultureInfo.CurrentCulture.TextInfo.ToTitleCase(saisie.Text) != saisie.Text))
                saisie.Text = doYouMean();

            //Affect the album
            List<Object> tempS = new List<object>();
            List<Object> tempAr = new List<object>();
            foreach (var item in selection.SelectedItems)
            {
                try { albums.Add(getKey(inputFiles, selection.GetItemText(item)).ElementAt(0), saisie.Text); }
                catch { albums.Add(getKey(inputFiles, selection.GetItemText(item)).ElementAt(1), saisie.Text); }
                tempS.Add(item);
                tempAr.Add(selectionArtists.Items[selection.Items.IndexOf(item)]);
            }

            //Remove from the list
            foreach (var it in tempS)
                selection.Items.Remove(it);
            foreach (var it in tempAr)
                selectionArtists.Items.Remove(it);

            //go to next 
            if (selection.Items.Count > 0)
            {
                selection.SelectedIndex = 0;
                setAlbumAutoCompletion(selectionArtists.GetItemText(selectionArtists.SelectedItem));
                saisie.Clear();
                saisie.Focus();
            }
            else
                setChansonInterface();
        }

        private void setAlbumInterface()
        {
            //Update interface
            panelSaisie.Visible = true;
            titreMusique.Text = Settings.Default.TitreAlbumMusique;
            selection.Size = new Size(390, selection.Size.Height);
            selectionArtists.Visible = true;

            //Sort by artists name and fill in the lists
            sortByArtists();
            foreach (var pair in inputFiles)
                if (!albums.ContainsKey(pair.Key))
                    selectionArtists.Items.Add(artists[pair.Key]);

            //Divers
            if (selection.Items.Count == 0)
                setChansonInterface();
            else
            {
                selection.SelectedIndex = 0;
                setAlbumAutoCompletion(selectionArtists.GetItemText(selectionArtists.SelectedItem));
                saisie.Clear();
                saisie.Focus();
            }

        }

        private void sortByArtists()
        {
            List<KeyValuePair<string, string>> artistsList = new List<KeyValuePair<string, string>>(artists);
            artistsList.Sort(
                delegate(KeyValuePair<string, string> a,
                KeyValuePair<string, string> b)
                {
                    return a.Value.CompareTo(b.Value);
                }
            );

            artists.Clear();
            foreach (KeyValuePair<string, string> pair in artistsList)
            {
                artists.Add(pair.Key, pair.Value);
            }

            foreach (var pair in artists)
                if (!albums.ContainsKey(pair.Key))
                    selection.Items.Add(inputFiles[pair.Key]);

            List<KeyValuePair<string, string>> inputList = new List<KeyValuePair<string, string>>(inputFiles);
            inputFiles.Clear();

            foreach (var k in artists.Keys)
                inputFiles.Add(k, (from val in inputList where val.Key == k select val.Value).FirstOrDefault());
        }

        private void setAlbumAutoCompletion(string artist)
        {
            saisie.AutoCompleteCustomSource = null;

            if (Directory.Exists(Path.Combine(Settings.Default.Musique, artist)))
            {
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();

                string[] list = Directory.GetDirectories(Path.Combine(Settings.Default.Musique, artist), "*", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < list.Length; i++)
                    source.Add(Path.GetFileName(list[i]));

                saisie.AutoCompleteCustomSource = source;
            }
        }

        /*
         * 
         * ******************  STEP 4 : Chanson *******************
         * 
         */
        private void nextStep4()
        {
            //Affect the song
            List<Object> tempS = new List<object>();
            List<Object> tempAr = new List<object>();
            List<Object> tempAl = new List<object>();
            foreach (var item in selection.SelectedItems)
            {
                try { storeFile(getKey(inputFiles, selection.GetItemText(item)).ElementAt(0), saisie.Text); }
                catch
                {
                    try { storeFile(getKey(inputFiles, selection.GetItemText(item)).ElementAt(1), saisie.Text); }
                    catch
                    {
                        errors.Add(selection.GetItemText(item));
                    }
                }
                tempS.Add(item);
                tempAr.Add(selectionArtists.Items[selection.Items.IndexOf(item)]);
                tempAl.Add(selectionAlbums.Items[selection.Items.IndexOf(item)]);
            }

            //Remove from the list
            foreach (var it in tempS)
                selection.Items.Remove(it);
            foreach (var it in tempAr)
                selectionArtists.Items.Remove(it);
            foreach (var it in tempAl)
                selectionAlbums.Items.Remove(it);

            //go to next 
            if (selection.Items.Count > 0)
            {
                selection.SelectedIndex = 0;
                saisie.Clear();
                saisie.Text = Path.GetFileNameWithoutExtension(getKey(inputFiles, selection.GetItemText(selection.SelectedItem)).ElementAt(0));
                saisie.Focus();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Voulez recommencez ?", "Fin du process", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Musiques f = new Musiques();
                    f.MdiParent = this.MdiParent;
                    f.Show();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }
        }

        private void storeFile(string path, string name)
        {
            string[] artiste = artists[path].Replace("; ", ";").Split(';');
            string album = albums[path];
            string destFolder;

            if (album == "")
                destFolder = Path.Combine(Settings.Default.Musique, String.Join("", artiste[0].Split('\\', '|', '?', '\"', '<', '>', '*', '/', ':')));
            else
                destFolder = Path.Combine(Settings.Default.Musique, String.Join("", artiste[0].Split('\\', '|', '?', '\"', '<', '>', '*', '/', ':')), String.Join("", album.Split('\\', '|', '?', '\"', '<', '>', '*', '/', ':')));

            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            TagLib.File f = TagLib.File.Create(path);
            f.Tag.Album = album;
            f.Tag.Performers = new string[] { artiste[0] };
            f.Tag.Title = name;
            f.Save();

            string destination = Path.Combine(destFolder, String.Join("", name.Split('\\', '|', '?', '\"', '<', '>', '*', '/', ':')) + Path.GetExtension(path));

            if (File.Exists(destination) && destination != path)
                File.Delete(path);
            else
                File.Move(path, destination);
        }

        private void setChansonInterface()
        {
            //Update interface
            panelSaisie.Visible = true;
            titreMusique.Text = Settings.Default.TitreChansonMusique;
            selection.Size = new Size(204, selection.Size.Height);
            selectionArtists.Location = new Point(255, selectionArtists.Location.Y);
            selectionAlbums.Visible = true;
            selection.SelectionMode = SelectionMode.One;
            saisie.AutoCompleteCustomSource.Clear();

            //fill in the lists
            foreach (var pair in inputFiles)
                if (!titles.ContainsKey(pair.Key))
                {
                    selection.Items.Add(pair.Value);
                    selectionArtists.Items.Add(artists[pair.Key]);
                    selectionAlbums.Items.Add(albums[pair.Key]);
                }

            //Affect those wo have already a name
            foreach (var pair in titles)
                try { storeFile(pair.Key, pair.Value); }
                catch { errors.Add(Path.GetFileName(pair.Key)); }

            //Divers
            if (selection.Items.Count == 0)
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
                    Musiques f = new Musiques();
                    f.MdiParent = this.MdiParent;
                    f.Show();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }
            else
            {
                selection.SelectedIndex = 0;
                saisie.Clear();
                saisie.Focus();
            }

        }

        private void selectionArtists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (synchronize)
            {
                if (titreMusique.Text == Settings.Default.TitreAlbumMusique)
                {
                    synchronize = false;
                    selection.SelectedIndices.Clear();
                    foreach (int i in selectionArtists.SelectedIndices)
                    {
                        synchronize = false;
                        selection.SelectedIndices.Add(i);
                    }
                }
                else if (titreMusique.Text == Settings.Default.TitreChansonMusique)
                {
                    synchronize = false;
                    selectionAlbums.SelectedIndices.Clear();
                    synchronize = false;
                    selection.SelectedIndices.Clear();
                    foreach (int i in selectionArtists.SelectedIndices)
                    {
                        synchronize = false;
                        selectionAlbums.SelectedIndices.Add(i);
                        synchronize = false;
                        selection.SelectedIndices.Add(i);
                    }
                }
            }
            else
                synchronize = true;

        }

        private void selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (synchronize)
            {
                if (titreMusique.Text == Settings.Default.TitreAlbumMusique)
                {
                    synchronize = false;
                    selectionArtists.SelectedIndices.Clear();
                    foreach (int i in selection.SelectedIndices)
                    {
                        synchronize = false;
                        selectionArtists.SelectedIndices.Add(i);
                    }
                }
                else if (titreMusique.Text == Settings.Default.TitreChansonMusique)
                {
                    synchronize = false;
                    selectionAlbums.SelectedIndices.Clear();
                    synchronize = false;
                    selectionArtists.SelectedIndices.Clear();
                    foreach (int i in selection.SelectedIndices)
                    {
                        synchronize = false;
                        selectionAlbums.SelectedIndices.Add(i);
                        synchronize = false;
                        selectionArtists.SelectedIndices.Add(i);
                    }
                    if (selection.SelectedIndex != -1)
                        saisie.Text = Path.GetFileNameWithoutExtension(getKey(inputFiles, selection.GetItemText(selection.SelectedItem)).ElementAt(0));
                }
            }
            else
                synchronize = true;
        }

        private void selectionAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (synchronize)
            {
                if (titreMusique.Text == Settings.Default.TitreChansonMusique)
                {
                    synchronize = false;
                    selection.SelectedIndices.Clear();
                    synchronize = false;
                    selectionArtists.SelectedIndices.Clear();
                    foreach (int i in selectionAlbums.SelectedIndices)
                    {
                        synchronize = false;
                        selection.SelectedIndices.Add(i);
                        synchronize = false;
                        selectionArtists.SelectedIndices.Add(i);
                    }
                }
            }
            else
                synchronize = true;
        }

        private string doYouMean()
        {
            string result = saisie.Text;
            DialogResult dialogResult = new DialogResult();

            result = result.ToLower();

            for (int i = 0; i < saisie.AutoCompleteCustomSource.Count; i++)
                if (result == saisie.AutoCompleteCustomSource[i].ToLower())
                {
                    dialogResult = MessageBox.Show("Voulez-vous dire : " + saisie.AutoCompleteCustomSource[i], "Sure ?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        return saisie.AutoCompleteCustomSource[i];
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return saisie.Text;
                    }
                }

            result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result);

            dialogResult = MessageBox.Show("Voulez-vous dire : " + result, "Sure ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return result;
            }
            else if (dialogResult == DialogResult.No)
            {
                return saisie.Text;
            }

            return saisie.Text;
        }

    }
}
