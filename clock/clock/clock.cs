using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clock
{
    public partial class clock : Form
    {
        Font font; int n;
        Color cback;
        bool ex,back;
        int x, y;
        public clock(Font fontt,int nr, bool monitor,int px, int py, bool transp, Color background, Color fore, bool fundal, Color cfundal, bool afisaredata)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            font = fontt;
            n = nr;
            ex = monitor;
            back = fundal;
            cback = cfundal;
            x = px;
            y = py;
            label1.ForeColor = fore;
            label1.BackColor = background;
            afisaredata = afisaredata;

            if (transp)
                this.TransparencyKey = background;            
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
        Screen myscreen;
        private void PlaceLowerRight()
        {
            this.Left = myscreen.WorkingArea.Right - this.Width + x;
            this.Top = myscreen.WorkingArea.Bottom - this.Height + y;
        }
        private void PlaceLowerLeft()
        {
            this.Left = myscreen.WorkingArea.Left + x;
            this.Top = myscreen.WorkingArea.Bottom - this.Height + y;
        }
        private void PlaceLowerMiddle()
        {
            this.Left = (myscreen.WorkingArea.Left + myscreen.WorkingArea.Right) / 2 - this.Width / 2 + x;
            this.Top = myscreen.WorkingArea.Bottom - this.Height + y;
        }
        private void Placecenter()
        {
            this.Left = (myscreen.WorkingArea.Right+myscreen.WorkingArea.Left) / 2 - this.Width / 2;
            this.Top = (myscreen.WorkingArea.Bottom+myscreen.WorkingArea.Top) / 2 - this.Height / 2;
        }
        private void PlacecenterRight()
        {
            this.Left = myscreen.WorkingArea.Right - this.Width;
            this.Top = (myscreen.WorkingArea.Bottom + myscreen.WorkingArea.Top) / 2 - this.Height / 2;
        }
        private void PlacecenterLeft()
        {
            this.Left = myscreen.WorkingArea.Left;
            this.Top = (myscreen.WorkingArea.Bottom + myscreen.WorkingArea.Top) / 2 - this.Height / 2;
        }
        private void PlaceTopLeft()
        {
            this.Left = myscreen.WorkingArea.Left + x;
            this.Top = myscreen.WorkingArea.Top + y;
        }
        private void PlaceTopCenter()
        {
            this.Left = (myscreen.WorkingArea.Left + myscreen.WorkingArea.Right) / 2 - this.Width / 2 + x;
            this.Top = myscreen.WorkingArea.Top + y;
        }
        private void PlaceTopRight()
        {
            this.Left = myscreen.WorkingArea.Right - this.Width + x;
            this.Top = myscreen.WorkingArea.Top + y;
        }


        private void FPlaceLowerRight()
        {
            label1.Left = this.Width - label1.Width + x;
            label1.Top = this.Height - label1.Height + y;
        }
        private void FPlaceLowerLeft()
        {
            label1.Left = 0 + x;
            label1.Top = this.Height - label1.Height + y;
        }
        private void FPlaceLowerMiddle()
        {
            label1.Left = (this.Width) / 2 - label1.Width / 2 + x;
            label1.Top = this.Height - label1.Height + y;
        }
        private void FPlacecenter()
        {
            label1.Left = (this.Width) / 2 - label1.Width / 2;
            label1.Top = (this.Height) / 2 - label1.Height / 2;
        }
        private void FPlacecenterRight()
        {
            label1.Left = this.Width - label1.Width;
            label1.Top = (this.Height) / 2 - label1.Height / 2;
        }
        private void FPlacecenterLeft()
        {
            label1.Left = 0;
            label1.Top = (this.Height) / 2 - label1.Height / 2;
        }
        private void FPlaceTopLeft()
        {
            label1.Left = x;
            label1.Top =  y;
        }
        private void FPlaceTopCenter()
        {
            label1.Left = (this.Width) / 2 - label1.Width / 2 + x;
            label1.Top = y;
        }
        private void FPlaceTopRight()
        {
            label1.Left = this.Width - label1.Width + x;
            label1.Top = y;
        }
        private void clock_Load(object sender, EventArgs e)
        {
           // this.Location = Screen.AllScreens[0].WorkingArea.Location;
            //this.Bounds = GetSecondaryScreen().Bounds;
            try
            {
                this.BackColor = cback;
                label1.Text = DateTime.Now.ToString("HH:mm");
                if (Properties.Settings.Default.afisaredata == true)
                    label1.Text += "\n" + DateTime.Now.ToString("dd.MM.yyyy");
                label1.Font = font;
                if (ex == true)
                    myscreen = GetSecondaryScreen();
                else
                    myscreen = Screen.AllScreens[0];
                if (!back)
                    this.Size = label1.Size;
                else
                {
                    this.Top = myscreen.WorkingArea.Top;
                    this.Left = myscreen.WorkingArea.Left;
                    this.Size = myscreen.WorkingArea.Size;
                }
                if (back)
                {
                    if (n == 1)
                        FPlaceTopLeft();
                    else if (n == 2)
                        FPlaceTopCenter();
                    else if (n == 3)
                        FPlaceTopRight();
                    else if (n == 4)
                        FPlacecenterLeft();
                    else if (n == 5)
                        FPlacecenter();
                    else if (n == 6)
                        FPlacecenterRight();
                    else if (n == 7)
                        FPlaceLowerLeft();
                    else if (n == 8)
                        FPlaceLowerMiddle();
                    else if (n == 9)
                        FPlaceLowerRight();
                }
                else
                {
                    if (n == 1)
                        PlaceTopLeft();
                    else if (n == 2)
                        PlaceTopCenter();
                    else if (n == 3)
                        PlaceTopRight();
                    else if (n == 4)
                        PlacecenterLeft();
                    else if (n == 5)
                        Placecenter();
                    else if (n == 6)
                        PlacecenterRight();
                    else if (n == 7)
                        PlaceLowerLeft();
                    else if (n == 8)
                        PlaceLowerMiddle();
                    else if (n == 9)
                        PlaceLowerRight();
                }
                timer1.Start();
                
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
            this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.afisaredata == true)
                label1.Text = DateTime.Now.ToString("HH:mm") + "\n" + DateTime.Now.ToString("dd.MM.yyyy");
            else
                label1.Text = DateTime.Now.ToString("HH:mm");
        }
    }

}
