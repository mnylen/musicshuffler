namespace MusicShuffler.Forms
{
    partial class MainForm
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
            this.directoriesLabel = new System.Windows.Forms.Label();
            this.directoriesListBox = new System.Windows.Forms.ListBox();
            this.addDirectoryButton = new System.Windows.Forms.Button();
            this.removeDirectoryButton = new System.Windows.Forms.Button();
            this.shuffleLabel = new System.Windows.Forms.Label();
            this.targetSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mbLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.dstDirectoryLabel = new System.Windows.Forms.Label();
            this.destinationDirectoryTBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.targetSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // directoriesLabel
            // 
            this.directoriesLabel.AutoSize = true;
            this.directoriesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.directoriesLabel.Location = new System.Drawing.Point(11, 13);
            this.directoriesLabel.Name = "directoriesLabel";
            this.directoriesLabel.Size = new System.Drawing.Size(117, 15);
            this.directoriesLabel.TabIndex = 0;
            this.directoriesLabel.Text = "Directories to search:";
            // 
            // directoriesListBox
            // 
            this.directoriesListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.directoriesListBox.FormattingEnabled = true;
            this.directoriesListBox.ItemHeight = 15;
            this.directoriesListBox.Location = new System.Drawing.Point(14, 29);
            this.directoriesListBox.Name = "directoriesListBox";
            this.directoriesListBox.Size = new System.Drawing.Size(264, 64);
            this.directoriesListBox.TabIndex = 1;
            this.directoriesListBox.SelectedIndexChanged += new System.EventHandler(this.directoriesListBox_SelectedIndexChanged);
            // 
            // addDirectoryButton
            // 
            this.addDirectoryButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addDirectoryButton.Location = new System.Drawing.Point(285, 29);
            this.addDirectoryButton.Name = "addDirectoryButton";
            this.addDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.addDirectoryButton.TabIndex = 2;
            this.addDirectoryButton.Text = "Add";
            this.addDirectoryButton.UseVisualStyleBackColor = true;
            this.addDirectoryButton.Click += new System.EventHandler(this.addDirectoryButton_Click);
            // 
            // removeDirectoryButton
            // 
            this.removeDirectoryButton.Enabled = false;
            this.removeDirectoryButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.removeDirectoryButton.Location = new System.Drawing.Point(285, 58);
            this.removeDirectoryButton.Name = "removeDirectoryButton";
            this.removeDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.removeDirectoryButton.TabIndex = 3;
            this.removeDirectoryButton.Text = "Remove";
            this.removeDirectoryButton.UseVisualStyleBackColor = true;
            this.removeDirectoryButton.Click += new System.EventHandler(this.removeDirectoryButton_Click);
            // 
            // shuffleLabel
            // 
            this.shuffleLabel.AutoSize = true;
            this.shuffleLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.shuffleLabel.Location = new System.Drawing.Point(13, 173);
            this.shuffleLabel.Name = "shuffleLabel";
            this.shuffleLabel.Size = new System.Drawing.Size(66, 15);
            this.shuffleLabel.TabIndex = 7;
            this.shuffleLabel.Text = "Target size:";
            // 
            // targetSizeNumericUpDown
            // 
            this.targetSizeNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.targetSizeNumericUpDown.Location = new System.Drawing.Point(85, 171);
            this.targetSizeNumericUpDown.Maximum = new decimal(new int[] {
            10240,
            0,
            0,
            0});
            this.targetSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.targetSizeNumericUpDown.Name = "targetSizeNumericUpDown";
            this.targetSizeNumericUpDown.Size = new System.Drawing.Size(69, 23);
            this.targetSizeNumericUpDown.TabIndex = 6;
            this.targetSizeNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // mbLabel
            // 
            this.mbLabel.AutoSize = true;
            this.mbLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mbLabel.Location = new System.Drawing.Point(160, 173);
            this.mbLabel.Name = "mbLabel";
            this.mbLabel.Size = new System.Drawing.Size(25, 15);
            this.mbLabel.TabIndex = 9;
            this.mbLabel.Text = "MB";
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.generateButton.Location = new System.Drawing.Point(16, 210);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(345, 32);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "Generate playlist";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // dstDirectoryLabel
            // 
            this.dstDirectoryLabel.AutoSize = true;
            this.dstDirectoryLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dstDirectoryLabel.Location = new System.Drawing.Point(12, 117);
            this.dstDirectoryLabel.Name = "dstDirectoryLabel";
            this.dstDirectoryLabel.Size = new System.Drawing.Size(120, 15);
            this.dstDirectoryLabel.TabIndex = 15;
            this.dstDirectoryLabel.Text = "Destination directory:";
            // 
            // destinationDirectoryTBox
            // 
            this.destinationDirectoryTBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.destinationDirectoryTBox.Location = new System.Drawing.Point(14, 133);
            this.destinationDirectoryTBox.Name = "destinationDirectoryTBox";
            this.destinationDirectoryTBox.Size = new System.Drawing.Size(264, 23);
            this.destinationDirectoryTBox.TabIndex = 4;
            this.destinationDirectoryTBox.Leave += new System.EventHandler(this.destinationDirectoryTBox_Leave);
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.browseButton.Location = new System.Drawing.Point(285, 133);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 258);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.destinationDirectoryTBox);
            this.Controls.Add(this.dstDirectoryLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.mbLabel);
            this.Controls.Add(this.targetSizeNumericUpDown);
            this.Controls.Add(this.shuffleLabel);
            this.Controls.Add(this.removeDirectoryButton);
            this.Controls.Add(this.addDirectoryButton);
            this.Controls.Add(this.directoriesListBox);
            this.Controls.Add(this.directoriesLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicShuffler";
            ((System.ComponentModel.ISupportInitialize)(this.targetSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label directoriesLabel;
        private System.Windows.Forms.ListBox directoriesListBox;
        private System.Windows.Forms.Button addDirectoryButton;
        private System.Windows.Forms.Button removeDirectoryButton;
        private System.Windows.Forms.Label shuffleLabel;
        private System.Windows.Forms.NumericUpDown targetSizeNumericUpDown;
        private System.Windows.Forms.Label mbLabel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label dstDirectoryLabel;
        private System.Windows.Forms.TextBox destinationDirectoryTBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

    }
}