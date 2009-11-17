using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MusicShuffler;
using System.IO;

namespace MusicShuffler.Forms
{
    public partial class DoCopyForm : BaseForm
    {
        public DoCopyForm()
        {
            InitializeComponent();

            // Localization
            this.Text = Strings.CopyingSongs;
            doneLabel.Text = String.Format(Strings.DonePercentage, 0);
            cancelButton.Text = Strings.CancelButton;
            groupBox1.Text = Strings.Progress;
            infoLabel.Text = Strings.SongsBeingCopied;
        }

        private void DoCopyForm_Load(object sender, EventArgs e)
        {
            currentSongIndex = -1;
            cancel = false;
            finished = false;
            totalSongs = Playlist.Songs.Count;

            CopyNextSong();
        }

        private int currentSongIndex = -1;
        private int totalSongs = 0;
        private bool cancel = false;
        private bool finished = false;
        private string currentFileName = "";

        private void CopyNextSong()
        {
            if (cancel)
                return;

            currentSongIndex++;

            if (currentSongIndex == Playlist.Songs.Count)
            {
                // Set the cancel button as exit button
                finished = true;
                cancelButton.Text = Strings.Exit;
                infoLabel.Text = Strings.Finished;
                fileLabel.Text = "";

                return;
            }

            Song song = Playlist.Songs[currentSongIndex];
            currentFileName = song.FileName;
            backgroundWorker.RunWorkerAsync(song.FileName);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!(e.Argument is string))
                throw new ArgumentException();

            string srcFileName = e.Argument as string;

            try
            {
                File.Copy(srcFileName,
                    Path.Combine(Presets.DestinationDirectory,
                        new FileInfo(srcFileName).Name));
            }
            catch
            {

            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                // Ask the user whether he/she wants to try again/skip/cancel
                DialogResult dialogResult = MessageBox.Show(this,
                    String.Format(Strings.CopyFailed, currentFileName,
                        ((Exception)e.Result).Message),
                    Strings.Error,
                    MessageBoxButtons.AbortRetryIgnore,
                    MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Retry)
                {
                    // Try again
                    currentSongIndex--;
                    CopyNextSong();
                }
                else if (dialogResult == DialogResult.Abort)
                {
                    // Cancel
                    cancel = true;

                    // Hide the form
                    DialogResult = DialogResult.Cancel;
                    Hide();
                }

                // If the user chose to ignore, just continue like nothing happened
            }

            int progressDonePercentage = (int)Math.Floor(100 *
                (double)(currentSongIndex + 1) / (double)(totalSongs));

            // Update labels
            doneLabel.Text = String.Format(Strings.DonePercentage, progressDonePercentage);
            fileLabel.Text = String.Format(Strings.CurrentFileIndicator,
                (currentSongIndex + 1), totalSongs);

            // Update progress bar value
            progressBar1.Value = progressDonePercentage;

            // Start copying yet another song
            CopyNextSong();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                // Cancel the progress
                cancel = true;

                // Hide the form
                DialogResult = DialogResult.Cancel;
                Hide();
            }
            else
            {
                // Close the form
                DialogResult = DialogResult.OK;
                Hide();
            }
        }
    }
}
