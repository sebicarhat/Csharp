using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Biblioteca
{
    public partial class adaugarecititor : Form
    {
        public adaugarecititor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" )
                {
                    SqlConnection sqlconnection = new SqlConnection();
                    sqlconnection.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = sqlconnection;
                    sqlcommand.Parameters.AddWithValue("nume", textBox1.Text);
                    sqlcommand.Parameters.AddWithValue("cnp", textBox2.Text);
                    sqlcommand.Parameters.AddWithValue("serie", textBox3.Text);
                    sqlcommand.Parameters.AddWithValue("numar", textBox4.Text);
                    sqlcommand.Parameters.AddWithValue("adresa", textBox5.Text);
                    sqlcommand.Parameters.AddWithValue("telefon", textBox6.Text);
                    sqlcommand.CommandText = "SELECT * FROM listacititori WHERE cnp=@cnp";
                    SqlDataReader reader;
                    sqlconnection.Open();
                    reader = sqlcommand.ExecuteReader();
                    if (reader.Read())
                        MessageBox.Show("Acest CNP apartine altui cititor.");
                    else
                    {
                        sqlconnection.Close();
                        sqlcommand.CommandText = "insert into listacititori (Nume,CNP,Serie,Numar,Adresa,Telefon) values (@nume,@cnp,@serie,@numar,@adresa,@telefon)";
                        sqlconnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlconnection.Close();
                        MessageBox.Show("Cititor adaugat cu succes!");
                    }
                }
                else MessageBox.Show("Campurile nu pot fi goale!");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'a' || e.KeyChar > 'z') && e.KeyChar != 8)
                e.Handled = true;
        }




    }
}
