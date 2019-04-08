using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Planete
{
    public partial class Invitat : Form
    {
        public Invitat()
        {
            InitializeComponent();
            //draw = drawingarea.CreateGraphics();
        }
        Graphics draw;
        Bitmap bmp;
        Bitmap bmp2;
        Pen pen = new Pen(Color.White);
        int[] height = { 150, 200, 250, 300, 350, 400, 450, 500 };
        int[] width = { 300, 400, 500, 600, 700, 800, 900, 1000 };
        int xcenter, ycenter;
        double stop = 2 * Math.PI;
        double start = 3 * Math.PI / 2;
        double mercurangle, venusangle, pamantangle, marteangle, jupiterangle, saturnangle, uranusangle, neptunangle;

        
        
        private void reset()
        {
            mercurangle = start;
            venusangle = start;
            pamantangle = start;
            marteangle = start;
            jupiterangle = start;
            saturnangle = start;
            uranusangle = start;
            neptunangle = start;
        }
        private void aranjareplanete()
        {
            soare.Top = (drawingarea.Size.Height - soare.Height) / 2;
            soare.Left = (drawingarea.Size.Width - soare.Width) / 2;
            mercur.Top = (drawingarea.Size.Height - mercur.Height - height[0]) / 2;
            mercur.Left = (drawingarea.Size.Width - mercur.Width) / 2;
            venus.Top = (drawingarea.Size.Height - mercur.Height - height[1]) / 2;
            venus.Left = (drawingarea.Size.Width - mercur.Width) / 2;
            pamant.Top = (drawingarea.Size.Height - mercur.Height - height[2]) / 2;
            pamant.Left = (drawingarea.Size.Width - mercur.Width) / 2;
            marte.Top = (drawingarea.Size.Height - mercur.Height - height[3]) / 2;
            marte.Left = (drawingarea.Size.Width - mercur.Width) / 2;
            jupiter.Top = (drawingarea.Size.Height - mercur.Height - height[4]) / 2;
            jupiter.Left = (drawingarea.Size.Width - mercur.Width) / 2;
            saturn.Top = (drawingarea.Size.Height - mercur.Height - height[5]) / 2;
            saturn.Left = (drawingarea.Size.Width - mercur.Width) / 2;
            uranus.Top = (drawingarea.Size.Height - mercur.Height - height[6]) / 2;
            uranus.Left = (drawingarea.Size.Width - mercur.Width) / 2;
            neptun.Top = (drawingarea.Size.Height - mercur.Height - height[7]) / 2;
            neptun.Left = (drawingarea.Size.Width - mercur.Width) / 2;
        }
        private void generareorbite()
        {
            bmp = new Bitmap(drawingarea.Image, drawingarea.Size.Width, drawingarea.Size.Height);
            bmp2 = new Bitmap(bmp);
            draw = Graphics.FromImage(bmp2);
            int x,y;
        for(int i=0;i<8;++i)
        {
            x=(drawingarea.Size.Width-width[i])/2;
            y=(drawingarea.Size.Height-height[i])/2;
            draw.DrawEllipse(pen, x, y, width[i], height[i]);
        }
        drawingarea.Image = bmp2;
        }
        private void Invitat_Load(object sender, EventArgs e)
        {
            aranjareplanete();
            centrare();
            reset();
        }

        private void Invitat_SizeChanged(object sender, EventArgs e)
        {
            aranjareplanete();
            centrare();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mercurtimer.Start();
            venustimer.Start();
            pamanttimer.Start();
            martetimer.Start();
            jupitertimer.Start();
            saturntimer.Start();
            uranustimer.Start();
            neptuntimer.Start();
        }

        private void centrare()
        {
            xcenter = drawingarea.Size.Width / 2;
            ycenter = drawingarea.Size.Height / 2;
        }
        private void mercurtimer_Tick(object sender, EventArgs e)
        {
            if (mercurangle == stop)
                mercurangle = 0;
            mercur.Left = Convert.ToInt32(xcenter + Math.Cos(mercurangle) * (width[0] / 2) - mercur.Width / 2);
            mercur.Top = Convert.ToInt32(ycenter + Math.Sin(mercurangle) * (height[0] / 2) - mercur.Height / 2);
            mercurangle += 0.01;
        }

        private void venustimer_Tick(object sender, EventArgs e)
        {
            if (venusangle == stop)
                venusangle = 0;
            venus.Left = Convert.ToInt32(xcenter + Math.Cos(venusangle) * (width[1] / 2) - venus.Width / 2);
            venus.Top = Convert.ToInt32(ycenter + Math.Sin(venusangle) * (height[1] / 2) - venus.Height / 2);
            venusangle += 0.01;
        }

        private void saturntimer_Tick(object sender, EventArgs e)
        {
            if (saturnangle == stop)
                saturnangle = 0;
            saturn.Left = Convert.ToInt32(xcenter + Math.Cos(saturnangle) * (width[5] / 2) - saturn.Width / 2);
            saturn.Top = Convert.ToInt32(ycenter + Math.Sin(saturnangle) * (height[5] / 2) - saturn.Height / 2);
            saturnangle += 0.01;
        }

        private void pamanttimer_Tick(object sender, EventArgs e)
        {
            if (pamantangle == stop)
                pamantangle = 0;
            pamant.Left = Convert.ToInt32(xcenter + Math.Cos(pamantangle) * (width[2] / 2) - pamant.Width / 2);
            pamant.Top = Convert.ToInt32(ycenter + Math.Sin(pamantangle) * (height[2] / 2) - pamant.Height / 2);
            pamantangle += 0.017;
        }

        private void neptuntimer_Tick(object sender, EventArgs e)
        {
            if (neptunangle == stop)
                neptunangle = 0;
            neptun.Left = Convert.ToInt32(xcenter + Math.Cos(neptunangle) * (width[7] / 2) - neptun.Width / 2);
            neptun.Top = Convert.ToInt32(ycenter + Math.Sin(neptunangle) * (height[7] / 2) - neptun.Height / 2);
            neptunangle += 0.01;
        }

        private void uranustimer_Tick(object sender, EventArgs e)
        {
            if (uranusangle == stop)
                uranusangle = 0;
            uranus.Left = Convert.ToInt32(xcenter + Math.Cos(uranusangle) * (width[6] / 2) - uranus.Width / 2);
            uranus.Top = Convert.ToInt32(ycenter + Math.Sin(uranusangle) * (height[6] / 2) - uranus.Height / 2);
            uranusangle += 0.01;
        }

        private void martetimer_Tick(object sender, EventArgs e)
        {
            if (marteangle == stop)
                marteangle = 0;
            marte.Left = Convert.ToInt32(xcenter + Math.Cos(marteangle) * (width[3] / 2) - marte.Width / 2);
            marte.Top = Convert.ToInt32(ycenter + Math.Sin(marteangle) * (height[3] / 2) - marte.Height / 2);
            marteangle += 0.01;
        }

        private void jupitertimer_Tick(object sender, EventArgs e)
        {
            if (jupiterangle == stop)
                jupiterangle = 0;
            jupiter.Left = Convert.ToInt32(xcenter + Math.Cos(jupiterangle) * (width[4] / 2) - jupiter.Width / 2);
            jupiter.Top = Convert.ToInt32(ycenter + Math.Sin(jupiterangle) * (height[4] / 2) - jupiter.Height / 2);
            jupiterangle += 0.01;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mercurtimer.Stop();
            venustimer.Stop();
            pamanttimer.Stop();
            martetimer.Stop();
            jupitertimer.Stop();
            saturntimer.Stop();
            uranustimer.Stop();
            neptuntimer.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
            aranjareplanete();
        }

        private void Invitat_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                generareorbite();
            else
                drawingarea.Image = bmp;
        }



    }
}
