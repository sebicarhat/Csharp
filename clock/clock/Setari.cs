using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace clock
{
    public partial class Setari : Form
    {
        public Setari()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        bool fundal;
        bool pornire;
        bool monitor;
        bool transparent;
        bool afisare;
        Font font;
        Color background;
        Color cfundal;
        Color fore;
        int x, y;
        int n;
        private void label5_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = background;
            cd.ShowDialog();
            background = cd.Color;
            label5.BackColor = background;
            Properties.Settings.Default.backgroundcolor = background;
            Properties.Settings.Default.Save();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = fore;
            cd.ShowDialog();
            fore = cd.Color;
            label6.BackColor = fore;
            Properties.Settings.Default.forecolor = fore;
            Properties.Settings.Default.Save();
        }

        private void Setari_Load(object sender, EventArgs e)
        {
            fundal = Properties.Settings.Default.fundal;
            background = Properties.Settings.Default.backgroundcolor;
            cfundal = Properties.Settings.Default.cfundal;
            fore = Properties.Settings.Default.forecolor;
            font = Properties.Settings.Default.Fontsetting;
            monitor = Properties.Settings.Default.monitor;
            x = Properties.Settings.Default.xsetting;
            y = Properties.Settings.Default.ysetting;
            n = Properties.Settings.Default.locatie;
            transparent = Properties.Settings.Default.transparentsetting;
            pornire = Properties.Settings.Default.start;
            afisare = Properties.Settings.Default.afisaredata;
            label5.BackColor = background;
            label6.BackColor = fore;
            numericUpDown1.Value = x;
            numericUpDown2.Value = y;
            if (fundal)
                checkBox3.Checked = true;
            else
                checkBox3.Checked = false;
            if (transparent)
                checkBox1.Checked = true;
            else checkBox1.Checked = false;
            if (monitor)
                comboBox1.SelectedIndex = 1;
            else comboBox1.SelectedIndex = 0;
            if (pornire)
                checkBox2.Checked = true;
            else checkBox2.Checked = false;
            if (afisare)
                checkBox4.Checked = true;
            else
                checkBox4.Checked = false;
            foreach (RadioButton item in groupBox1.Controls)
                if (item.Tag.ToString() == n.ToString())
                    item.Checked = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                Properties.Settings.Default.monitor = false;
            else
                Properties.Settings.Default.monitor = true;
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                Properties.Settings.Default.transparentsetting = true;
            else
                Properties.Settings.Default.transparentsetting = false;
            Properties.Settings.Default.Save();
       }

        private void rbcheck(object sender, EventArgs e)
        {
            foreach (RadioButton item in groupBox1.Controls)
                if (item.Checked == true)
                    Properties.Settings.Default.locatie = int.Parse(item.Tag.ToString());
            Properties.Settings.Default.Save();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.xsetting = int.Parse(numericUpDown1.Value.ToString());
            Properties.Settings.Default.Save();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ysetting = int.Parse(numericUpDown2.Value.ToString());
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fontd = new FontDialog();
            fontd.Font = font;
            fontd.ShowDialog();
            font = fontd.Font;
            Properties.Settings.Default.Fontsetting = font;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (checkBox2.Checked)
            {
                Properties.Settings.Default.start = true;
                key.SetValue("clock", Application.ExecutablePath.ToString());
            }
            else
            {
                Properties.Settings.Default.start = false;
                key.DeleteValue("clock");
            }
            Properties.Settings.Default.Save();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                Properties.Settings.Default.fundal = true;
            else
                Properties.Settings.Default.fundal = false;
            Properties.Settings.Default.Save();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = cfundal;
            cd.ShowDialog();
            cfundal = cd.Color;
            label9.BackColor = cfundal;
            Properties.Settings.Default.cfundal = cfundal;
            Properties.Settings.Default.Save();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                Properties.Settings.Default.afisaredata = true;
            else
                Properties.Settings.Default.afisaredata = false;
            Properties.Settings.Default.Save();
        }

    }
}
