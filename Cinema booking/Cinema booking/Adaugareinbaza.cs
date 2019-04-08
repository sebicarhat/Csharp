using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cinema_booking
{
    public partial class Adaugareinbaza : Form
    {
        string id;
        public Adaugareinbaza(string s,string g)
        {
            InitializeComponent();
            id = s;
            label4.Text = g;
            if (id == "admin")
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
            }
        }

        private void afisareBazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void schimbaParolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schimbare form = new Schimbare(id);
            form.Show();

        }

        private void userNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bazaUtilizatoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Adaugareinbaza_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new adauga(id).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Usernou().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new bazausers().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new programeaza().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Baza().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new BazaProgramari().Show();
        }




    }
}
