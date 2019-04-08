using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "")
                listBox1.Items.Clear();
            else
            {
                listBox1.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = con;
                SqlDataReader reader;
                if(comboBox1.Text=="Numar inventar")
                sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor FROM listacarti WHERE Nrinv like '" + textBox1.Text + "%'";
                else if (comboBox1.Text == "Titlu")
                    sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor FROM listacarti WHERE Titlu like '" + textBox1.Text + "%'";
                else if (comboBox1.Text == "Autor")
                    sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor FROM listacarti WHERE Autor like '" + textBox1.Text + "%'";
                else if (comboBox1.Text == "Editura")
                    sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor FROM listacarti WHERE Editura like '" + textBox1.Text + "%'";
                else if (comboBox1.Text == "An aparitie")
                    sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor FROM listacarti WHERE Anaparitie like '" + textBox1.Text + "%'";
                else if (comboBox1.Text == "Cod de bare")
                    sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor FROM listacarti WHERE Codbare '" + textBox1.Text + "%'";
                else if (comboBox1.Text == "ISBN")
                    sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor FROM listacarti WHERE ISBN like '" + textBox1.Text + "%'";
                con.Open();
                reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                    listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                con.Close();
            }
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adaugare form = new Adaugare();
            form.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Titlu: ";
            label3.Text = "Autor: ";
            label4.Text = "Editura: ";
            label5.Text = "Anul aparitiei: ";
            label6.Text = "Cod de bare: ";
            label7.Text = "ISBN: ";
            label8.Text = "Numar inventar: ";
            if (listBox1.Text != "")
            {
                byte[] imgdata;
                int nr = int.Parse(listBox1.Text.Split(' ')[0]);
                string titlu = listBox1.Text.Split(' ')[1];
                string autor = listBox1.Text.Split(' ')[2];
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = con;
                sqlcommand.CommandText = "SELECT Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Poza from listacarti WHERE Nrinv = '" + nr + "'";
                con.Open();
                using (SqlDataReader reader = sqlcommand.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        label2.Text += reader[1].ToString();
                        label3.Text += reader[2].ToString();
                        label4.Text += reader[3].ToString();
                        label5.Text += reader[4].ToString();
                        label6.Text += reader[5].ToString();
                        label7.Text += reader[6].ToString();
                        label8.Text += reader[0].ToString();
                        imgdata = reader["Poza"] as byte[] ?? null;
                        if (imgdata != null)
                            using (MemoryStream ms = new MemoryStream(imgdata))
                            {
                                Bitmap bmp = new Bitmap(ms);
                                pictureBox1.Image = bmp;
                            }
                        else pictureBox1.Image = Properties.Resources.noimage;
                    }
                }
                con.Close();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
