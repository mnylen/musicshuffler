using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MusicShuffler;
using MusicShuffler.Filtering;

namespace MusicShuffler.Forms
{
    public partial class PlaylistForm : BaseForm
    {
        public PlaylistForm()
        {
            InitializeComponent();
            songList.AlwaysOnTopGroup = new ListViewGroup(Strings.SongsYouAdded);

            // Localization
            this.Text = Strings.Playlist;
            totalFileSizeLbl.Text = Strings.TotalFileSize;
            reshuffleButton.Text = Strings.ReshuffleButton;
            reshuffleSelectedButton.Text = Strings.ReshuffleSelectedButton;
            addFromLibraryButton.Text = Strings.AddFromLibraryButton;
            editFiltersButton.Text = Strings.EditFiltersButton;
            startButton.Text = Strings.CopyButton;

        }

        // Generates a completely new playlist and shows the playlist to the user
        private void GeneratePlaylist()
        {
            // Generate a new playlist
            Playlist.Shuffle(Presets.TargetSize);

            // Refresh the playlist
            RefreshPlaylist();
        }

        // Refreshes the playlist
        private void RefreshPlaylist()
        {
            // Update the song list
            songList.AlwaysOnTopSongs = Playlist.AddedSongs;
            songList.Songs = Playlist.Songs;

            // Update the total file size
            fileSizeLabel.Text =
                Utils.ToHumanReadableFileSize(Playlist.TotalFileSize);
        }

        // Shows the Add Songs From Library window
        private void ShowAddSongsDialog(AddSongsForm dialog)
        {
            dialog.Library = Library;
            dialog.Presets = Presets;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                // Add the songs
                Playlist.AddRange(dialog.SelectedSongs);

                // Make the playlist fit to the target size
                Playlist.FitToSize(Presets.TargetSize);

                // Refresh the playlist
                RefreshPlaylist();
            }
        }

        #region Event handlers

        // Initializes the form for the first time use
        private void PlaylistReviewForm_Load(object sender, EventArgs e)
        {
            // Apply filtering
            DoFilter();

            // Generate playlist
            GeneratePlaylist();
        }

        // Reshuffle the playlist
        private void reshuffleButton_Click(object sender, EventArgs e)
        {
            GeneratePlaylist();
        }

        // Resizes few elements when the form is resized
        private void PlaylistReviewForm_Resize(object sender, EventArgs e)
        {
            // Resize the playlistListView
            songList.Size = new Size(Width - 40, Height - 100);
            etchedLine1.Width = Width;
        }

        // Starts transferring the songs to the destination
        private void startButton_Click(object sender, EventArgs e)
        {
            DoCopyForm doCopyDialog = new DoCopyForm();
            doCopyDialog.Presets = Presets;
            doCopyDialog.Playlist = Playlist;

            if (doCopyDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Close this form
                DialogResult = DialogResult.OK;
                Hide();
            }
        }

        // Opens the Add Songs From Library window
        private void addSongsButton_Click(object sender, EventArgs e)
        {
            ShowAddSongsDialog(new AddSongsForm());
        }

        // Shows a context menu when clicked on a item on songList
        private void songList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = songList.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    // Clear the selection on other items
                    songList.SelectedItems.Clear();

                    // Calculate the context menu items
                    string artistName = item.SubItems[1].Text.Replace("&", "&&");
                    string genreName = item.SubItems[3].Text.Replace("&", "&&").ToLower();
                    excludeThisArtistToolStripMenuItem.Text =
                        String.Format(Strings.ExcludeArtist, artistName);

                    addSongsFromGenreToolStripMenuItem.Text =
                        String.Format(Strings.AddSongsFromGenre, genreName);

                    excludeThisGenreToolStripMenuItem.Text =
                        String.Format(Strings.ExcludeGenre, genreName);

                    addSongsFromArtistToolStripMenuItem.Text =
                        String.Format(Strings.AddSongsFromArtist, artistName);

                    excludeThisArtistToolStripMenuItem.Tag = item.SubItems[1].Text;
                    excludeThisGenreToolStripMenuItem.Tag = item.SubItems[3].Text;
                    addSongsFromArtistToolStripMenuItem.Tag = item.SubItems[1].Text;
                    addSongsFromGenreToolStripMenuItem.Tag = item.SubItems[3].Text;
                    removeSongFromPlaylistToolStripMenuItem.Tag = item;

                    // Show the context menu
                    contextMenuStrip.Show(songList, new Point(e.X, e.Y));
                }
            }
        }

        private void DoFilter()
        {
            FilterChain chain = new FilterChain();
            chain.Filters.Add(new GenreFilter(Presets.ExcludeGenres));
            chain.Filters.Add(new ArtistFilter(Presets.ExcludeArtists));
            chain.Filters.Add(new DurationFilter(Presets.MinimumDuration,
                Presets.MaximumDuration));

            Playlist.Library = chain.Filter(Library.Songs);
        }

        // Excludes the given genre
        private void excludeThisGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The genre name should be in the Tag property
            if (excludeThisArtistToolStripMenuItem.Tag != null)
            {
                string genreName = excludeThisGenreToolStripMenuItem.Tag as string;
                Presets.ExcludeGenres.Add(genreName);

                // Reshuffle all songs from the given genre
                Playlist.Shuffle(
                    new List<Song>(from song in Playlist.Songs
                                   where song.GenreName == genreName
                                   select song));

                // Apply the filtering
                DoFilter();

                // Show the playlist
                RefreshPlaylist();
            }
        }

        // Excludes the given artist
        private void excludeThisArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The artist name should be in the Tag property
            if (excludeThisArtistToolStripMenuItem.Tag != null)
            {
                string artistName = excludeThisArtistToolStripMenuItem.Tag as string;
                Presets.ExcludeArtists.Add(artistName);

                // Reshuffle all songs from the given artist
                Playlist.Shuffle(
                    new List<Song>(from song in Playlist.Songs
                                   where song.ArtistName == artistName
                                   select song));

                // Apply the filtering
                DoFilter();

                // Show the playlist
                RefreshPlaylist();
            }
        }

        // Reshuffles the selected items in the playlist
        private void reshuffleSelectedButton_Click(object sender, EventArgs e)
        {
            List<Song> reshuffleSongs = new List<Song>();

            foreach (ListViewItem item in songList.SelectedItems)
            {
                if (item.Tag is Song)
                    reshuffleSongs.Add(item.Tag as Song);
            }

            // Reshuffle
            Playlist.Shuffle(reshuffleSongs);

            // Show the playlist
            RefreshPlaylist();
        }

        // Removes the song from the playlist
        private void removeSongFromPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The ListViewItem should be in the Tag
            if (removeSongFromPlaylistToolStripMenuItem.Tag != null)
            {
                ListViewItem item = removeSongFromPlaylistToolStripMenuItem.Tag as ListViewItem;
                item.Remove();

                // Remove from the playlist
                Playlist.Remove((Song)item.Tag);

                // Update the total file size
                fileSizeLabel.Text =
                    Utils.ToHumanReadableFileSize(Playlist.TotalFileSize);
            }
        }

        // Adds songs from the given artist
        private void addSongsFromArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The artist name should be in the Tag
            if (addSongsFromArtistToolStripMenuItem.Tag != null)
            {
                AddSongsForm dialog = new AddSongsForm();
                dialog.InitialArtistFilter = addSongsFromArtistToolStripMenuItem.Tag.ToString();

                ShowAddSongsDialog(dialog);
            }
        }

        // Shows the Add Songs From Library window with songs from the specified genre
        private void addSongsFromGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The genre name should be in the Tag
            if (addSongsFromGenreToolStripMenuItem.Tag != null)
            {
                AddSongsForm dialog = new AddSongsForm();
                dialog.InitialGenreFilter = addSongsFromGenreToolStripMenuItem.Tag.ToString();

                ShowAddSongsDialog(dialog);
            }
        }

        // Shows the Edit Filters window
        private void editFiltersButton_Click(object sender, EventArgs e)
        {
            EditFiltersForm editFiltersDialog = new EditFiltersForm();
            editFiltersDialog.Library = Library;
            editFiltersDialog.Presets = Presets;

            if (editFiltersDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Apply filtering
                DoFilter();

                // Reshuffle the playlist
                GeneratePlaylist();
            }
        }

        #endregion

        private void songList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (songList.SelectedItems.Count == 0)
            {
                // Disable the reshuffle selected button
                reshuffleSelectedButton.Enabled = false;
            }
            else
            {
                // Enable the reshuffle selected button
                reshuffleSelectedButton.Enabled = true;
            }
        }
    }
}
