namespace MusicShuffler.Forms
{
    partial class AddSongsForm
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
            this.etchedLine1 = new MusicShuffler.Controls.EtchedLine();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.songsListView = new MusicShuffler.Controls.SongListView();
            this.selectedSongsListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // etchedLine1
            // 
            this.etchedLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.etchedLine1, 4);
            this.etchedLine1.DarkColor = System.Drawing.SystemColors.ControlDark;
            this.etchedLine1.LightColor = System.Drawing.SystemColors.ControlLightLight;
            this.etchedLine1.Location = new System.Drawing.Point(0, 515);
            this.etchedLine1.Margin = new System.Windows.Forms.Padding(0);
            this.etchedLine1.Name = "etchedLine1";
            this.etchedLine1.Size = new System.Drawing.Size(918, 8);
            this.etchedLine1.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addButton.Location = new System.Drawing.Point(750, 532);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cancelButton.Location = new System.Drawing.Point(835, 532);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromListToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(165, 26);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeFromListToolStripMenuItem.Text = "Remove from list";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 224F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.searchBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.songsListView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.selectedSongsListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.etchedLine1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.102805F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.89719F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(918, 564);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.SetColumnSpan(this.searchBox, 3);
            this.searchBox.Location = new System.Drawing.Point(234, 6);
            this.searchBox.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(674, 23);
            this.searchBox.TabIndex = 2;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // songsListView
            // 
            this.songsListView.AllowColumnReorder = true;
            this.songsListView.AlwaysOnTopGroup = null;
            this.songsListView.AlwaysOnTopSongs = null;
            this.songsListView.BackColor = System.Drawing.SystemColors.Control;
            this.songsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.songsListView, 3);
            this.songsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songsListView.FullRowSelect = true;
            this.songsListView.Location = new System.Drawing.Point(235, 36);
            this.songsListView.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.songsListView.Name = "songsListView";
            this.songsListView.Size = new System.Drawing.Size(672, 479);
            this.songsListView.Songs = null;
            this.songsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.songsListView.TabIndex = 3;
            this.songsListView.UseCompatibleStateImageBehavior = false;
            this.songsListView.View = System.Windows.Forms.View.Details;
            this.songsListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.songsListView_ItemDrag);
            // 
            // selectedSongsListBox
            // 
            this.selectedSongsListBox.AllowDrop = true;
            this.selectedSongsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedSongsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedSongsListBox.FormattingEnabled = true;
            this.selectedSongsListBox.IntegralHeight = false;
            this.selectedSongsListBox.ItemHeight = 15;
            this.selectedSongsListBox.Location = new System.Drawing.Point(0, 0);
            this.selectedSongsListBox.Margin = new System.Windows.Forms.Padding(0);
            this.selectedSongsListBox.Name = "selectedSongsListBox";
            this.tableLayoutPanel1.SetRowSpan(this.selectedSongsListBox, 2);
            this.selectedSongsListBox.Size = new System.Drawing.Size(224, 515);
            this.selectedSongsListBox.TabIndex = 0;
            this.selectedSongsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectedSongsListBox_DragDrop);
            this.selectedSongsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectedSongsListBox_MouseDown);
            this.selectedSongsListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.selectedSongsListBox_DragEnter);
            // 
            // AddSongsForm
            // 
            this.ClientSize = new System.Drawing.Size(918, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddSongsForm";
            this.ShowInTaskbar = false;
            this.Text = "Add Songs From Library";
            this.Load += new System.EventHandler(this.AddSongsForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MusicShuffler.Controls.EtchedLine etchedLine1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox searchBox;
        private MusicShuffler.Controls.SongListView songsListView;
        private System.Windows.Forms.ListBox selectedSongsListBox;

    }
}
