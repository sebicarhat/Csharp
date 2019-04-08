using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clock f;
        bool ok = false;
        bool monitor = true;
        bool transparent = false;
        bool fundal;
        int n = 0;
        int x, y;
        bool afisaredata = false;
        Color background;
        Color forecolor;
        Color cfundal;
        private void button1_Click(object sender, EventArgs e)
        {
            cfundal = Properties.Settings.Default.cfundal;
            fundal = Properties.Settings.Default.fundal;
            font = Properties.Settings.Default.Fontsetting;
            n = Properties.Settings.Default.locatie;
            monitor = Properties.Settings.Default.monitor;
            x = Properties.Settings.Default.xsetting;
            y = Properties.Settings.Default.ysetting;
            transparent = Properties.Settings.Default.transparentsetting;
            background = Properties.Settings.Default.backgroundcolor;
            forecolor = Properties.Settings.Default.forecolor;
            afisaredata = Properties.Settings.Default.afisaredata;

            if (monitor == false || System.Windows.Forms.Screen.AllScreens.Length > 1)
            {
                if (ok == false)
                {
                    button1.Enabled = false;
                    f = new clock(font, n, monitor,x,y,transparent,background,forecolor,fundal,cfundal,afisaredata);
                    f.Show();
                    ok = true;
                }
            }
            else MessageBox.Show("Nu este conectat nici un monitor extins.");
        }
        Font font;
        private void button2_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                button1.Enabled = true;
                f.Close();
                ok = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.show==true)
                button1.PerformClick();
        }


        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                button2.PerformClick();
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizat de: Carhat Eusebiu\n"+"E-mail:sebicarhat@gmail.com","Despre");
        }

        private void setariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setari form = new Setari();
            form.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button1.Enabled == false)
                Properties.Settings.Default.show = true;
            else
                Properties.Settings.Default.show = false;
            Properties.Settings.Default.Save();
        }







    }
}
