using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MusicShuffler;
using System.Globalization;
using System.Resources;

namespace MusicShuffler.Forms
{
    /// <summary>
    /// A base form for all forms in this project
    /// </summary>
    public class BaseForm : Form
    {
        /// <summary>
        /// Creates a new <c>BaseForm</c>
        /// </summary>
        public BaseForm()
        {
            ControlAdded += new ControlEventHandler(BaseForm_ControlAdded);
        }

        /// <summary>
        /// Executed when a control is added to this form. Sets the font of
        /// the control to <c>SystemFonts.MessageBoxFont</c> and enables
        /// highlighting the text on enter for all <c>NumericUpDown</c>
        /// controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_ControlAdded(object sender, ControlEventArgs e)
        {
            if (!(e.Control is UserControl))
                e.Control.Font = SystemFonts.MessageBoxFont;

            // For NumericUpDowns enable selecting the text on enter
            if (e.Control is NumericUpDown)
                e.Control.Enter += new EventHandler(Control_Enter);
        }

        /// <summary>
        /// Enables highlighting the text on enter for all
        /// <c>NumericUpDown</c> controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_Enter(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown control = sender as NumericUpDown;
                control.Select(0, control.Value.ToString().Length);
            }
        }

        /// <summary>
        /// Gets or sets the "main form" of the application
        /// </summary>
        public BaseForm MainForm
        {
            get { return mainForm; }
            set { mainForm = value; }
        }

        /// <summary>
        /// Gets or sets the playlist generator
        /// </summary>
        public Playlist Playlist
        {
            get { return playlist; }
            set { playlist = value; }
        }

        /// <summary>
        /// Gets or sets the library instance
        /// </summary>
        public Library Library
        {
            get { return library; }
            set { library = value; }
        }

        /// <summary>
        /// Gets or sets the presets
        /// </summary>
        public Presets Presets
        {
            get { return presets; }
            set { presets = value; }
        }

        public CultureInfo EnglishCulture = new CultureInfo("en-US");
        public ResourceManager ResourceManager = new ResourceManager(
            "MusicShuffler.Strings", System.Reflection.Assembly.GetExecutingAssembly());

        private BaseForm mainForm;
        private Presets presets;
        private Library library;
        private Playlist playlist;
    }
}
