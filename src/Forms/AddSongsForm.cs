using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using MusicShuffler;

namespace MusicShuffler.Forms
{
    public partial class AddSongsForm : BaseForm
    {
        // The songs returned from the previous search
        private IEnumerable<Song> searchCache;

        // The previous search query
        private string previousQuery = "";

        // List of songs selected
        public List<Song> SelectedSongs = new List<Song>();

        // Initial artist filter
        public string InitialArtistFilter;

        // Initial genre filter
        public string InitialGenreFilter;

        public AddSongsForm()
        {
            InitializeComponent();

            // Localization
            addButton.Text = Strings.AddButton;
            cancelButton.Text = Strings.CancelButton;
            this.Text = Strings.AddSongsFromLibrary;
        }

        private void AddSongsForm_Load(object sender, EventArgs e)
        {
            if (InitialArtistFilter == null && InitialGenreFilter == null)
            {
                // Show the full library
                songsListView.Songs = Library.Songs;
            }
            else
            {
                List<Song> songs = new List<Song>(Library.Songs);

                if (InitialArtistFilter != null)
                    songs = new List<Song>(
                        from song in songs
                        where song.ArtistName.ToLower() == InitialArtistFilter.ToLower()
                        select song);

                if (InitialGenreFilter != null)
                    songs = new List<Song>(
                        from song in songs
                        where song.GenreName.ToLower() == InitialGenreFilter.ToLower()
                        select song);

                songsListView.Songs = songs;
            }
        }


        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Trim() == "")
                songsListView.Songs = Library.Songs;

            if (previousQuery == "" || !searchBox.Text.StartsWith(previousQuery))
            {
                // Rebuild the search cache
                searchCache = Library.Songs;
            }

            // Do search
            var matches =
                from song in searchCache
                where song.Title.ToLower().Contains(searchBox.Text.ToLower()) ||
                      song.ArtistName.ToLower().Contains(searchBox.Text.ToLower())
                select song;

            // Set the matches as search cache
            searchCache = matches;
            previousQuery = searchBox.Text;

            songsListView.Songs = matches;
        }

        private void songsListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<Song> songs = new List<Song>();

            // Drag all the selected items
            foreach (ListViewItem lvItem in songsListView.SelectedItems)
            {
                // Convert the Tag as Song
                songs.Add((lvItem.Tag as Song));
            }

            // Do the drag & drop
            DoDragDrop(songs, DragDropEffects.Move);
        }

        private void selectedSongsListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<Song>)))
                e.Effect = DragDropEffects.Move;
        }

        private void selectedSongsListBox_DragDrop(object sender, DragEventArgs e)
        {
            List<Song> songs = (List<Song>)e.Data.GetData(typeof(List<Song>));
            
            // Add only items not currently in the list
            foreach (Song song in songs)
            {
                if (!SelectedSongs.Contains(song))
                {
                    long totalFileSize = SelectedSongs.GetTotalFileSize() +
                        song.FileSize;

                    if (Presets.TargetSize < totalFileSize)
                    {
                        if (MessageBox.Show(this,
                            String.Format(Strings.AF_MboxText_OverTargetSize,
                                song.Title),
                            Strings.AF_MboxCaption_Warning,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            // Break
                            break;
                        }
                    }
                    else if (Presets.TargetSize * 0.80d < totalFileSize)
                    {
                        if (MessageBox.Show(this,
                            String.Format(Strings.AF_MboxText_LessThan20,
                                song.Title),
                            Strings.AF_MboxCaption_Warning,

                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            // Break
                            break;
                        }
                    }

                    selectedSongsListBox.Items.Add(song);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Add the selected items to the selectedSongs list
            foreach (object item in selectedSongsListBox.Items)
            {
                if (item is Song)
                    SelectedSongs.Add(item as Song);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Remove the selected item
            selectedSongsListBox.Items.Remove(
                selectedSongsListBox.SelectedItem);
        }

        private void selectedSongsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int itemIndex = selectedSongsListBox.IndexFromPoint(e.X, e.Y);

                if (itemIndex != ListBox.NoMatches)
                {
                    selectedSongsListBox.SetSelected(itemIndex, true);
                    contextMenuStrip.Show(selectedSongsListBox, new Point(e.X, e.Y));
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
