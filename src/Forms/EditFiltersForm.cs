using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicShuffler.Forms
{
    public partial class EditFiltersForm : BaseForm
    {
        public EditFiltersForm()
        {
            InitializeComponent();

            // Localization
            this.Text = Strings.EditFilters;
            limitMinLbl.Text = Strings.LimitMinimumDuration;
            limitMaxLbl.Text = Strings.LimitMaximumDuration;
            exclArtistLbl.Text = Strings.ExcludeSelectedArtists;
            exclGenreLbl.Text = Strings.ExcludeSelectedGenres;
            applyButton.Text = Strings.ApplyButton;
            cancelButton.Text = Strings.CancelButton;
            uncheckArtists.Text = Strings.UncheckAll;
            uncheckGenres.Text = Strings.UncheckAll;
        }

        private void uncheckArtists_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < artistsCheckedListBox.Items.Count; i++)
                artistsCheckedListBox.SetItemChecked(i, false);
        }

        private void uncheckGenres_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < genresCheckedListBox.Items.Count; i++)
                genresCheckedListBox.SetItemChecked(i, false);
        }

        private void genresCheckedListBox_MouseHover(object sender, EventArgs e)
        {
            genresCheckedListBox.Focus();
        }

        private void artistsCheckedListBox_MouseHover(object sender, EventArgs e)
        {
            artistsCheckedListBox.Focus();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Dont save anything, just close
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            // Save the presets
            Presets.MinimumDuration = minimumDurationBox.Value;
            Presets.MaximumDuration = maximumDurationBox.Value;

            Presets.ExcludeArtists.Clear();
            Presets.ExcludeGenres.Clear();

            foreach (object artist in artistsCheckedListBox.CheckedItems)
                Presets.ExcludeArtists.Add(artist.ToString());

            foreach (object genre in genresCheckedListBox.CheckedItems)
                Presets.ExcludeGenres.Add(genre.ToString());

            // Hide the form
            Close();
        }

        private void EditFiltersForm_Load(object sender, EventArgs e)
        {
            foreach (string artist in Library.Artists)
                artistsCheckedListBox.Items.Add(artist,
                    Presets.ExcludeArtists.Contains(artist));

            foreach (string genreName in Library.Genres)
                genresCheckedListBox.Items.Add(genreName,
                    Presets.ExcludeGenres.Contains(genreName));

            minimumDurationBox.Value =
                (Presets.MinimumDuration == TimeSpan.MinValue) ? new TimeSpan(0, 0, 0) :
                                                                 Presets.MinimumDuration;

            maximumDurationBox.Value =
                (Presets.MaximumDuration == TimeSpan.MaxValue) ? new TimeSpan(0, 0, 0) :
                                                                 Presets.MaximumDuration;
        }
    }
}
