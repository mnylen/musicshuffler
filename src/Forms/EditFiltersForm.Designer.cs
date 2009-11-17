namespace MusicShuffler.Forms
{
    partial class EditFiltersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.genresCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.exclGenreLbl = new System.Windows.Forms.Label();
            this.exclArtistLbl = new System.Windows.Forms.Label();
            this.artistsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.uncheckArtists = new System.Windows.Forms.Button();
            this.uncheckGenres = new System.Windows.Forms.Button();
            this.minimumDurationBox = new MusicShuffler.Controls.TimeSpanBox();
            this.maximumDurationBox = new MusicShuffler.Controls.TimeSpanBox();
            this.limitMinLbl = new System.Windows.Forms.Label();
            this.limitMaxLbl = new System.Windows.Forms.Label();
            this.etchedLine1 = new MusicShuffler.Controls.EtchedLine();
            this.SuspendLayout();
            // 
            // genresCheckedListBox
            // 
            this.genresCheckedListBox.CheckOnClick = true;
            this.genresCheckedListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.genresCheckedListBox.FormattingEnabled = true;
            this.genresCheckedListBox.Location = new System.Drawing.Point(12, 160);
            this.genresCheckedListBox.Name = "genresCheckedListBox";
            this.genresCheckedListBox.Size = new System.Drawing.Size(290, 184);
            this.genresCheckedListBox.TabIndex = 15;
            this.genresCheckedListBox.ThreeDCheckBoxes = true;
            this.genresCheckedListBox.MouseHover += new System.EventHandler(this.genresCheckedListBox_MouseHover);
            // 
            // exclGenreLbl
            // 
            this.exclGenreLbl.AutoSize = true;
            this.exclGenreLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exclGenreLbl.Location = new System.Drawing.Point(9, 144);
            this.exclGenreLbl.Name = "exclGenreLbl";
            this.exclGenreLbl.Size = new System.Drawing.Size(134, 15);
            this.exclGenreLbl.TabIndex = 16;
            this.exclGenreLbl.Text = "Exclude selected genres:";
            // 
            // exclArtistLbl
            // 
            this.exclArtistLbl.AutoSize = true;
            this.exclArtistLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exclArtistLbl.Location = new System.Drawing.Point(311, 144);
            this.exclArtistLbl.Name = "exclArtistLbl";
            this.exclArtistLbl.Size = new System.Drawing.Size(130, 15);
            this.exclArtistLbl.TabIndex = 18;
            this.exclArtistLbl.Text = "Exclude selected artists:";
            // 
            // artistsCheckedListBox
            // 
            this.artistsCheckedListBox.CheckOnClick = true;
            this.artistsCheckedListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.artistsCheckedListBox.FormattingEnabled = true;
            this.artistsCheckedListBox.Location = new System.Drawing.Point(314, 160);
            this.artistsCheckedListBox.Name = "artistsCheckedListBox";
            this.artistsCheckedListBox.Size = new System.Drawing.Size(290, 184);
            this.artistsCheckedListBox.TabIndex = 17;
            this.artistsCheckedListBox.ThreeDCheckBoxes = true;
            this.artistsCheckedListBox.MouseHover += new System.EventHandler(this.artistsCheckedListBox_MouseHover);
            // 
            // applyButton
            // 
            this.applyButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.applyButton.Location = new System.Drawing.Point(448, 421);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 19;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cancelButton.Location = new System.Drawing.Point(529, 421);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // uncheckArtists
            // 
            this.uncheckArtists.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.uncheckArtists.Location = new System.Drawing.Point(522, 358);
            this.uncheckArtists.Name = "uncheckArtists";
            this.uncheckArtists.Size = new System.Drawing.Size(82, 23);
            this.uncheckArtists.TabIndex = 21;
            this.uncheckArtists.Text = "Uncheck all";
            this.uncheckArtists.UseVisualStyleBackColor = true;
            this.uncheckArtists.Click += new System.EventHandler(this.uncheckArtists_Click);
            // 
            // uncheckGenres
            // 
            this.uncheckGenres.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.uncheckGenres.Location = new System.Drawing.Point(216, 358);
            this.uncheckGenres.Name = "uncheckGenres";
            this.uncheckGenres.Size = new System.Drawing.Size(86, 23);
            this.uncheckGenres.TabIndex = 22;
            this.uncheckGenres.Text = "Uncheck all";
            this.uncheckGenres.UseVisualStyleBackColor = true;
            this.uncheckGenres.Click += new System.EventHandler(this.uncheckGenres_Click);
            // 
            // minimumDurationBox
            // 
            this.minimumDurationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimumDurationBox.Location = new System.Drawing.Point(12, 35);
            this.minimumDurationBox.Name = "minimumDurationBox";
            this.minimumDurationBox.Size = new System.Drawing.Size(290, 26);
            this.minimumDurationBox.TabIndex = 25;
            this.minimumDurationBox.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // maximumDurationBox
            // 
            this.maximumDurationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximumDurationBox.Location = new System.Drawing.Point(12, 93);
            this.maximumDurationBox.Name = "maximumDurationBox";
            this.maximumDurationBox.Size = new System.Drawing.Size(290, 29);
            this.maximumDurationBox.TabIndex = 26;
            this.maximumDurationBox.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // limitMinLbl
            // 
            this.limitMinLbl.AutoSize = true;
            this.limitMinLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.limitMinLbl.Location = new System.Drawing.Point(9, 17);
            this.limitMinLbl.Name = "limitMinLbl";
            this.limitMinLbl.Size = new System.Drawing.Size(189, 15);
            this.limitMinLbl.TabIndex = 27;
            this.limitMinLbl.Text = "Limit songs minimum duration to:";
            // 
            // limitMaxLbl
            // 
            this.limitMaxLbl.AutoSize = true;
            this.limitMaxLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.limitMaxLbl.Location = new System.Drawing.Point(11, 75);
            this.limitMaxLbl.Name = "limitMaxLbl";
            this.limitMaxLbl.Size = new System.Drawing.Size(190, 15);
            this.limitMaxLbl.TabIndex = 28;
            this.limitMaxLbl.Text = "Limit songs maximum duration to:";
            // 
            // etchedLine1
            // 
            this.etchedLine1.DarkColor = System.Drawing.SystemColors.ControlDark;
            this.etchedLine1.LightColor = System.Drawing.SystemColors.ControlLightLight;
            this.etchedLine1.Location = new System.Drawing.Point(-3, 396);
            this.etchedLine1.Name = "etchedLine1";
            this.etchedLine1.Size = new System.Drawing.Size(621, 10);
            this.etchedLine1.TabIndex = 29;
            // 
            // EditFiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 456);
            this.Controls.Add(this.etchedLine1);
            this.Controls.Add(this.limitMaxLbl);
            this.Controls.Add(this.limitMinLbl);
            this.Controls.Add(this.maximumDurationBox);
            this.Controls.Add(this.minimumDurationBox);
            this.Controls.Add(this.uncheckGenres);
            this.Controls.Add(this.uncheckArtists);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.exclArtistLbl);
            this.Controls.Add(this.artistsCheckedListBox);
            this.Controls.Add(this.exclGenreLbl);
            this.Controls.Add(this.genresCheckedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditFiltersForm";
            this.ShowInTaskbar = false;
            this.Text = "Specify filters";
            this.Load += new System.EventHandler(this.EditFiltersForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox genresCheckedListBox;
        private System.Windows.Forms.Label exclGenreLbl;
        private System.Windows.Forms.Label exclArtistLbl;
        private System.Windows.Forms.CheckedListBox artistsCheckedListBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button uncheckArtists;
        private System.Windows.Forms.Button uncheckGenres;
        private MusicShuffler.Controls.TimeSpanBox minimumDurationBox;
        private MusicShuffler.Controls.TimeSpanBox maximumDurationBox;
        private System.Windows.Forms.Label limitMinLbl;
        private System.Windows.Forms.Label limitMaxLbl;
        private MusicShuffler.Controls.EtchedLine etchedLine1;
    }
}