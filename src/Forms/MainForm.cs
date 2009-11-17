using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MusicShuffler;

namespace MusicShuffler.Forms
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            // Localization
            directoriesLabel.Text = Strings.MF_SearchDirectoriesLabel;
            dstDirectoryLabel.Text = Strings.MF_DestinationDirectoryLabel;
            addDirectoryButton.Text = Strings.AddButton;
            removeDirectoryButton.Text = Strings.MF_RemoveDirectoryButton;
            shuffleLabel.Text = Strings.MF_TargetSizeLabel;
            mbLabel.Text = Strings.MF_MbLabel;
            generateButton.Text = Strings.MF_GeneratePlaylistButton;

            // Load the presets
            LoadPresets();
        }

        #region Methods

        private void LoadPresets()
        {
            // Load the presets
            Presets presets = Presets.Load();

            if (presets != null)
            {
                Presets = presets;

                // Set the values for controls
                destinationDirectoryTBox.Text = presets.DestinationDirectory;
                targetSizeNumericUpDown.Value =
                    (decimal)Math.Floor((double)presets.TargetSize / Constants.MEGABYTE);

                // Set the destination directories
                foreach (string directoryName in Presets.SearchDirectories)
                    directoriesListBox.Items.Add(directoryName);
            }
            else
            {
                Presets = new Presets();
            }
        }

        private void SaveSearchDirectory(object directoryName)
        {
            if (!(Directory.Exists(directoryName.ToString())))
            {
                // Inform user that the directory won't be searched
                MessageBox.Show(this,
                    String.Format(Strings.MF_MboxText_SearchDirectoryNotFound,
                        directoryName.ToString()),
                    Strings.MF_MboxCaption_DirectoryNotFound,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Remove the directory from the ListBox
                directoriesListBox.Items.Remove(directoryName);
            }
            else
            {
                // Save the directory to the presets
                if (!(Presets.SearchDirectories.Contains(directoryName.ToString())))
                    Presets.SearchDirectories.Add(directoryName.ToString());
            }
        }

        private bool SaveDestinationDirectory()
        {
            string destinationDirectory =
                destinationDirectoryTBox.Text.Trim();

            if (destinationDirectory == "")
            {
                // Destination directory is not given
                MessageBox.Show(this,
                    Strings.MF_MboxText_DestinationDirectoryRequired,
                    Strings.MF_MboxCaption_RequiredValue,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Give focus
                destinationDirectoryTBox.Focus();
                return false;
            }

            if (!(Directory.Exists(destinationDirectory)))
            {
                // Ask the user whether he/she wants to create the directory
                if (MessageBox.Show(this,
                    Strings.MF_MboxText_DestinationDirectoryNotFound,
                    Strings.MF_MboxCaption_DirectoryNotFound,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                        == DialogResult.Yes)
                {
                    try
                    {
                        // Try to create the directory
                        Directory.CreateDirectory(destinationDirectory);
                    }
                    catch (Exception e)
                    {
                        // Inform the user that the destination directory could not be created
                        MessageBox.Show(this,
                            String.Format(Strings.MF_MboxText_DirectoryCreateFailed,
                                destinationDirectory, e.Message),
                            Strings.MboxCaption_Error,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Give focus to the destination directory
                        destinationDirectoryTBox.Focus();
                        return false;
                    }
                }
                else
                {
                    // Give focus to destinationDirectoryTBox
                    destinationDirectoryTBox.Focus();
                    return false;
                }
            }

            // Save the directory to the presets
            Presets.DestinationDirectory = destinationDirectory;

            return true;
        }

        private bool SaveShuffleAmount()
        {
            long shuffleAmount =
                (long)targetSizeNumericUpDown.Value * Constants.MEGABYTE;

            // If less than 50 megabytes, ask for confirmation
            if (shuffleAmount < 50 * Constants.MEGABYTE)
            {
                if (MessageBox.Show(this,
                    Strings.MF_MboxText_TargetSizeLessThan50,
                    Strings.MF_MboxCaption_TargetSizeLessThan50,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Give focus to shuffleAmountNumericUpDown
                    targetSizeNumericUpDown.Focus();
                    return false;
                }
            }

            // Check if there's enough space
            long availableSpace = Utils.GetAvailableFreeSpace(
                Presets.DestinationDirectory, false);

            if (availableSpace != -1L && shuffleAmount > availableSpace)
            {
                MessageBox.Show(this,
                    String.Format(Strings.MF_MboxText_TargetSizeOverSpaceLeft,
                        Utils.ToHumanReadableFileSize(shuffleAmount),
                        Utils.ToHumanReadableFileSize(availableSpace)),
                    Strings.MF_MboxCaption_TargetSizeOverSpaceLeft,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Give focus to shuffleAmountNumericUpDown
                targetSizeNumericUpDown.Focus();
                return false;
            }

            Presets.TargetSize = shuffleAmount;

            return true;
        }

        private bool LoadLibrary()
        {
            if (Library == null)
                Library = new Library();

            foreach (string searchDirectory in Presets.SearchDirectories)
                Library.AddDirectory(searchDirectory);

            if (!Library.IsLoaded)
            {
                DoLoadLibraryForm doLoadLibraryDialog = new DoLoadLibraryForm();
                doLoadLibraryDialog.Library = Library;

                if (doLoadLibraryDialog.ShowDialog(this) == DialogResult.OK)
                    return true;

                else return false;
            }

            return true;
        }

        private bool SavePresets()
        {
            Presets.SearchDirectories.Clear();

            // Save search directories
            foreach (object directoryName in directoriesListBox.Items)
                SaveSearchDirectory(directoryName);

            if (Presets.SearchDirectories.Count == 0)
            {
                // At least one search directory must be given
                MessageBox.Show(this,
                    Strings.MF_MboxText_AtLeastOneSearchDirectory,
                    Strings.MF_MboxCaption_RequiredValue,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return false;
            }

            // Save destination directory
            if (SaveDestinationDirectory())
            {
                if (SaveShuffleAmount())
                    return true;
            }

            return false;
        }

        private void SetFreeSpace(string directoryName)
        {
            long availableSpace = Utils.GetAvailableFreeSpace(directoryName, true);

            if (availableSpace != -1L)
            {
                targetSizeNumericUpDown.Value =
                    (decimal)Math.Floor((double)availableSpace / Constants.MEGABYTE);
            }
        }

        #endregion

        #region Event handlers

        private void directoriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (directoriesListBox.SelectedIndex != -1)
            {
                // Enable the remove button
                removeDirectoryButton.Enabled = true;
            }
            else
            {
                // Disable the remove button
                removeDirectoryButton.Enabled = false;
            }
        }

        private void removeDirectoryButton_Click(object sender, EventArgs e)
        {
            string directoryName =
                directoriesListBox.Items[directoriesListBox.SelectedIndex].ToString();

            // Remove the selected item from the directories
            directoriesListBox.Items.Remove(directoryName);
        }

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Add the selected path to directoriesListBox
                directoriesListBox.Items.Add(
                    folderBrowserDialog.SelectedPath);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the destination directory to the selected directory
                destinationDirectoryTBox.Text = folderBrowserDialog.SelectedPath;

                // Try to retrieve the amount of free disk space
                SetFreeSpace(folderBrowserDialog.SelectedPath);
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (SavePresets())
            {
                if (!LoadLibrary())
                    return;

                // Show the results form
                PlaylistForm playlistForm = new PlaylistForm();
                playlistForm.Library = Library;
                playlistForm.Presets = Presets;
                playlistForm.MainForm = this;
                playlistForm.Playlist = new Playlist();

                if (playlistForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Save the presets
                    Presets.Save();

                    // Close the form
                    Close();
                }
            }
        }

        private void destinationDirectoryTBox_Leave(object sender, EventArgs e)
        {
            // Try to retrieve the amount of free space
            SetFreeSpace(destinationDirectoryTBox.Text);
        }

        #endregion
    }
}
