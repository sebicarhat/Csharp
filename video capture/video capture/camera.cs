using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace video_capture
{
    public partial class camera : Form
    {
        public camera()
        {
            InitializeComponent();
        }
        private Screen GetSecondaryScreen()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen != Screen.PrimaryScreen)
                    return screen;
            }
            return Screen.PrimaryScreen;
        }
        private void camera_Load(object sender, EventArgs e)
        {
            this.Bounds = GetSecondaryScreen().Bounds;
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
