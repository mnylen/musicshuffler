using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MusicShuffler.Forms
{
    public partial class DoLoadLibraryForm : BaseForm
    {
        private BackgroundWorker worker;

        public DoLoadLibraryForm()
        {
            InitializeComponent();

            // Localization
            this.Text = Strings.LoadingLibrary;
            doneLabel.Text = String.Format(Strings.DonePercentage, 0);
            cancelButton.Text = Strings.CancelButton;
            groupBox1.Text = Strings.Progress;
            infoLabel.Text = Strings.ExtractingMetadata;
        }

        private void DoLoadLibraryForm_Load(object sender, EventArgs e)
        {
            // Start loading the library
            worker = Library.GetBackgroundLoader();
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Library.Save();
            DialogResult = DialogResult.OK;
            Hide();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update progress bar value
            progressBar1.Value = e.ProgressPercentage;

            // Update the label text
            doneLabel.Text = String.Format(Strings.DonePercentage,
                e.ProgressPercentage);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Cancel
            worker.CancelAsync();

            // Close the form
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void DoLoadLibraryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel
            worker.CancelAsync();

            // Close the form
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;

            Hide();
        }
    }
}
