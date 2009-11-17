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
    public partial class EtchedLine : UserControl
    {
        private Color darkColor = SystemColors.ControlDark;
        private Color lightColor = SystemColors.ControlLightLight;

        public Color DarkColor
        {
            get { return darkColor; }
            set { darkColor = value; }
        }

        public Color LightColor
        {
            get { return lightColor; }
            set { lightColor = value; }
        }

        public EtchedLine()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Brush darkBrush = new SolidBrush(DarkColor);
            Brush lightBrush = new SolidBrush(LightColor);

            Pen darkPen = new Pen(darkBrush, 1);
            Pen lightPen = new Pen(lightBrush, 1);

            // Draw two lines
            e.Graphics.DrawLine(darkPen, 0, this.Height - 2,
                this.Width, this.Height - 2);

            e.Graphics.DrawLine(lightPen, 0, this.Height - 1,
                this.Width, this.Height - 1);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
    }
}
