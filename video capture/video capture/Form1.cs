using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
namespace video_capture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
            if (form != null)
            {
                form.pictureBox1.Image = bit;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (cam.IsRunning)
            {
                button3.Enabled = false;
                cam.Stop();
                pictureBox1.Image = null;
                if(form!=null)
                form.pictureBox1.Image = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "*";
            sfd.Title = "Save as";
            sfd.Filter = "JPEG|*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }
        camera form;
        private void button4_Click(object sender, EventArgs e)
        {
            form = new camera();
            if (System.Windows.Forms.Screen.AllScreens.Length > 1)
            {
                form.Show();
                form.Opacity = float.Parse(trackBar1.Value.ToString())/10;
                button4.Enabled = false;
                button5.Enabled = true;
            }
            else MessageBox.Show("Nu este conectat nici un monitor extins!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = false;
            form.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(button3.Enabled)
            cam.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
