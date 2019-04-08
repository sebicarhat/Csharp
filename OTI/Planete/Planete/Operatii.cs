using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Planete
{
    public partial class Operatii : Form
    {
        string id;
        public Operatii(string nume)
        {
            InitializeComponent();
            id = nume;
        }

        private void Operatii_Load(object sender, EventArgs e)
        {
            if (id == "Administrator")
                administrareToolStripMenuItem.Visible = true;
            else
                administrareToolStripMenuItem.Visible = false;
        }

        private void administrareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administrare form = new Administrare();
            form.MdiParent = this;
            form.Show();
        }

        private void invitatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invitat form = new Invitat();
            form.MdiParent = this;
            form.Show();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Operatii_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
