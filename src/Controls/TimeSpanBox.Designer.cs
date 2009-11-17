namespace MusicShuffler.Controls
{
    partial class TimeSpanBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hoursUpDown = new System.Windows.Forms.NumericUpDown();
            this.hoursLbl = new System.Windows.Forms.Label();
            this.minsLbl = new System.Windows.Forms.Label();
            this.minutesUpDown = new System.Windows.Forms.NumericUpDown();
            this.secsLbl = new System.Windows.Forms.Label();
            this.secondsUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hoursUpDown
            // 
            this.hoursUpDown.Location = new System.Drawing.Point(3, 3);
            this.hoursUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.hoursUpDown.Name = "hoursUpDown";
            this.hoursUpDown.Size = new System.Drawing.Size(35, 20);
            this.hoursUpDown.TabIndex = 0;
            this.hoursUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hoursLbl
            // 
            this.hoursLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hoursLbl.AutoSize = true;
            this.hoursLbl.Location = new System.Drawing.Point(44, 6);
            this.hoursLbl.Name = "hoursLbl";
            this.hoursLbl.Size = new System.Drawing.Size(33, 13);
            this.hoursLbl.TabIndex = 1;
            this.hoursLbl.Text = "hours";
            // 
            // minsLbl
            // 
            this.minsLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minsLbl.AutoSize = true;
            this.minsLbl.Location = new System.Drawing.Point(123, 6);
            this.minsLbl.Name = "minsLbl";
            this.minsLbl.Size = new System.Drawing.Size(43, 13);
            this.minsLbl.TabIndex = 3;
            this.minsLbl.Text = "minutes";
            // 
            // minutesUpDown
            // 
            this.minutesUpDown.Location = new System.Drawing.Point(83, 3);
            this.minutesUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minutesUpDown.Name = "minutesUpDown";
            this.minutesUpDown.Size = new System.Drawing.Size(34, 20);
            this.minutesUpDown.TabIndex = 2;
            this.minutesUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // secsLbl
            // 
            this.secsLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.secsLbl.AutoSize = true;
            this.secsLbl.Location = new System.Drawing.Point(212, 6);
            this.secsLbl.Name = "secsLbl";
            this.secsLbl.Size = new System.Drawing.Size(47, 13);
            this.secsLbl.TabIndex = 5;
            this.secsLbl.Text = "seconds";
            // 
            // secondsUpDown
            // 
            this.secondsUpDown.Location = new System.Drawing.Point(172, 3);
            this.secondsUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.secondsUpDown.Name = "secondsUpDown";
            this.secondsUpDown.Size = new System.Drawing.Size(34, 20);
            this.secondsUpDown.TabIndex = 4;
            this.secondsUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.hoursUpDown, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.hoursLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondsUpDown, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.minutesUpDown, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.minsLbl, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.secsLbl, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 26);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // TimeSpanBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimeSpanBox";
            this.Size = new System.Drawing.Size(264, 32);
            ((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown hoursUpDown;
        private System.Windows.Forms.Label hoursLbl;
        private System.Windows.Forms.Label minsLbl;
        private System.Windows.Forms.NumericUpDown minutesUpDown;
        private System.Windows.Forms.Label secsLbl;
        private System.Windows.Forms.NumericUpDown secondsUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;


    }
}
