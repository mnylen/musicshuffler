namespace MusicShuffler.Forms
{
    partial class PlaylistForm
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
            this.components = new System.ComponentModel.Container();
            this.reshuffleButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.addFromLibraryButton = new System.Windows.Forms.Button();
            this.songList = new MusicShuffler.Controls.SongListView();
            this.etchedLine1 = new MusicShuffler.Controls.EtchedLine();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excludeThisGenreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeThisArtistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSongsFromArtistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSongsFromGenreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeSongFromPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reshuffleSelectedButton = new System.Windows.Forms.Button();
            this.totalFileSizeLbl = new System.Windows.Forms.Label();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.editFiltersButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reshuffleButton
            // 
            this.reshuffleButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.reshuffleButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.reshuffleButton.Location = new System.Drawing.Point(134, 533);
            this.reshuffleButton.Name = "reshuffleButton";
            this.reshuffleButton.Size = new System.Drawing.Size(75, 23);
            this.reshuffleButton.TabIndex = 1;
            this.reshuffleButton.Text = "Reshuffle";
            this.reshuffleButton.UseVisualStyleBackColor = true;
            this.reshuffleButton.Click += new System.EventHandler(this.reshuffleButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.startButton.Location = new System.Drawing.Point(813, 533);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(57, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Copy";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // addFromLibraryButton
            // 
            this.addFromLibraryButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addFromLibraryButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addFromLibraryButton.Location = new System.Drawing.Point(215, 533);
            this.addFromLibraryButton.Name = "addFromLibraryButton";
            this.addFromLibraryButton.Size = new System.Drawing.Size(113, 23);
            this.addFromLibraryButton.TabIndex = 3;
            this.addFromLibraryButton.Text = "Add From Library";
            this.addFromLibraryButton.UseVisualStyleBackColor = true;
            this.addFromLibraryButton.Click += new System.EventHandler(this.addSongsButton_Click);
            // 
            // songList
            // 
            this.songList.AllowColumnReorder = true;
            this.songList.AlwaysOnTopGroup = null;
            this.songList.AlwaysOnTopSongs = null;
            this.songList.BackColor = System.Drawing.SystemColors.Control;
            this.songList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.songList, 7);
            this.songList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.songList.FullRowSelect = true;
            this.songList.Location = new System.Drawing.Point(3, 3);
            this.songList.Name = "songList";
            this.songList.Size = new System.Drawing.Size(874, 510);
            this.songList.Songs = null;
            this.songList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.songList.TabIndex = 4;
            this.songList.UseCompatibleStateImageBehavior = false;
            this.songList.View = System.Windows.Forms.View.Details;
            this.songList.SelectedIndexChanged += new System.EventHandler(this.songList_SelectedIndexChanged);
            this.songList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.songList_MouseDown);
            // 
            // etchedLine1
            // 
            this.etchedLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.etchedLine1, 7);
            this.etchedLine1.DarkColor = System.Drawing.SystemColors.ControlDark;
            this.etchedLine1.LightColor = System.Drawing.SystemColors.ControlLightLight;
            this.etchedLine1.Location = new System.Drawing.Point(3, 519);
            this.etchedLine1.Name = "etchedLine1";
            this.etchedLine1.Size = new System.Drawing.Size(874, 2);
            this.etchedLine1.TabIndex = 5;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excludeThisGenreToolStripMenuItem,
            this.excludeThisArtistToolStripMenuItem,
            this.toolStripSeparator1,
            this.addSongsFromArtistToolStripMenuItem,
            this.addSongsFromGenreToolStripMenuItem,
            this.toolStripSeparator2,
            this.removeSongFromPlaylistToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(216, 126);
            // 
            // excludeThisGenreToolStripMenuItem
            // 
            this.excludeThisGenreToolStripMenuItem.Name = "excludeThisGenreToolStripMenuItem";
            this.excludeThisGenreToolStripMenuItem.ShowShortcutKeys = false;
            this.excludeThisGenreToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.excludeThisGenreToolStripMenuItem.Text = "Exclude this genre";
            this.excludeThisGenreToolStripMenuItem.Click += new System.EventHandler(this.excludeThisGenreToolStripMenuItem_Click);
            // 
            // excludeThisArtistToolStripMenuItem
            // 
            this.excludeThisArtistToolStripMenuItem.Name = "excludeThisArtistToolStripMenuItem";
            this.excludeThisArtistToolStripMenuItem.ShowShortcutKeys = false;
            this.excludeThisArtistToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.excludeThisArtistToolStripMenuItem.Text = "Exclude this artist";
            this.excludeThisArtistToolStripMenuItem.Click += new System.EventHandler(this.excludeThisArtistToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // addSongsFromArtistToolStripMenuItem
            // 
            this.addSongsFromArtistToolStripMenuItem.Name = "addSongsFromArtistToolStripMenuItem";
            this.addSongsFromArtistToolStripMenuItem.ShowShortcutKeys = false;
            this.addSongsFromArtistToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.addSongsFromArtistToolStripMenuItem.Text = "Add songs from artist";
            this.addSongsFromArtistToolStripMenuItem.Click += new System.EventHandler(this.addSongsFromArtistToolStripMenuItem_Click);
            // 
            // addSongsFromGenreToolStripMenuItem
            // 
            this.addSongsFromGenreToolStripMenuItem.Name = "addSongsFromGenreToolStripMenuItem";
            this.addSongsFromGenreToolStripMenuItem.ShowShortcutKeys = false;
            this.addSongsFromGenreToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.addSongsFromGenreToolStripMenuItem.Text = "Add songs from genre";
            this.addSongsFromGenreToolStripMenuItem.Click += new System.EventHandler(this.addSongsFromGenreToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // removeSongFromPlaylistToolStripMenuItem
            // 
            this.removeSongFromPlaylistToolStripMenuItem.Name = "removeSongFromPlaylistToolStripMenuItem";
            this.removeSongFromPlaylistToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.removeSongFromPlaylistToolStripMenuItem.Text = "Remove song from playlist";
            this.removeSongFromPlaylistToolStripMenuItem.Click += new System.EventHandler(this.removeSongFromPlaylistToolStripMenuItem_Click);
            // 
            // reshuffleSelectedButton
            // 
            this.reshuffleSelectedButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.reshuffleSelectedButton.Enabled = false;
            this.reshuffleSelectedButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.reshuffleSelectedButton.Location = new System.Drawing.Point(10, 533);
            this.reshuffleSelectedButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.reshuffleSelectedButton.Name = "reshuffleSelectedButton";
            this.reshuffleSelectedButton.Size = new System.Drawing.Size(118, 23);
            this.reshuffleSelectedButton.TabIndex = 6;
            this.reshuffleSelectedButton.Text = "Reshuffle Selected";
            this.reshuffleSelectedButton.UseVisualStyleBackColor = true;
            this.reshuffleSelectedButton.Click += new System.EventHandler(this.reshuffleSelectedButton_Click);
            // 
            // totalFileSizeLbl
            // 
            this.totalFileSizeLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalFileSizeLbl.AutoSize = true;
            this.totalFileSizeLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.totalFileSizeLbl.Location = new System.Drawing.Point(435, 537);
            this.totalFileSizeLbl.Name = "totalFileSizeLbl";
            this.totalFileSizeLbl.Size = new System.Drawing.Size(81, 15);
            this.totalFileSizeLbl.TabIndex = 7;
            this.totalFileSizeLbl.Text = "Total File Size:";
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileSizeLabel.Location = new System.Drawing.Point(522, 537);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(38, 15);
            this.fileSizeLabel.TabIndex = 8;
            this.fileSizeLabel.Text = "label2";
            // 
            // editFiltersButton
            // 
            this.editFiltersButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.editFiltersButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editFiltersButton.Location = new System.Drawing.Point(334, 533);
            this.editFiltersButton.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.editFiltersButton.Name = "editFiltersButton";
            this.editFiltersButton.Size = new System.Drawing.Size(78, 23);
            this.editFiltersButton.TabIndex = 9;
            this.editFiltersButton.Text = "Edit Filters";
            this.editFiltersButton.UseVisualStyleBackColor = true;
            this.editFiltersButton.Click += new System.EventHandler(this.editFiltersButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.startButton, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.editFiltersButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.fileSizeLabel, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.reshuffleSelectedButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalFileSizeLbl, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.reshuffleButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.addFromLibraryButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.songList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.etchedLine1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(880, 564);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlaylistForm";
            this.ShowInTaskbar = false;
            this.Text = "Playlist";
            this.Load += new System.EventHandler(this.PlaylistReviewForm_Load);
            this.Resize += new System.EventHandler(this.PlaylistReviewForm_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reshuffleButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button addFromLibraryButton;
        private MusicShuffler.Controls.SongListView songList;
        private MusicShuffler.Controls.EtchedLine etchedLine1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem excludeThisArtistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excludeThisGenreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addSongsFromGenreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSongsFromArtistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem removeSongFromPlaylistToolStripMenuItem;
        private System.Windows.Forms.Button reshuffleSelectedButton;
        private System.Windows.Forms.Label totalFileSizeLbl;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.Button editFiltersButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}