using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicShuffler.Controls
{
    public partial class TimeSpanBox :UserControl
    {
        public new bool Enabled
        {
            get { return hoursUpDown.Enabled; }

            set
            {
                hoursUpDown.Enabled = value;
                minutesUpDown.Enabled = value;
                secondsUpDown.Enabled = value;
            }
        }

        public TimeSpan Value
        {
            get
            {
                return new TimeSpan(
                    (int)hoursUpDown.Value,
                    (int)minutesUpDown.Value,
                    (int)secondsUpDown.Value);
            }

            set
            {
                hoursUpDown.Value =
                    (value.TotalHours > 100d) ? 99 : (int)Math.Floor(value.TotalHours);

                minutesUpDown.Value = value.Minutes;
                secondsUpDown.Value = value.Seconds;
            }
        }

        public TimeSpanBox()
        {
            InitializeComponent();

            foreach (Control control in Controls)
                control.Font = SystemFonts.MessageBoxFont;

            // Localization
            hoursLbl.Text = Strings.Hours;
            minsLbl.Text = Strings.Minutes;
            secsLbl.Text = Strings.Seconds;
        }
    }
}
