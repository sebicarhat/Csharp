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
    public partial class adaugarecarte : Form
    {
        public adaugarecarte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    SqlConnection sqlconnection = new SqlConnection();
                    sqlconnection.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = sqlconnection;
                    SqlDataReader reader;
                    sqlcommand.Parameters.AddWithValue("nrinv", textBox1.Text);
                    sqlcommand.Parameters.AddWithValue("titlu", textBox2.Text);
                    sqlcommand.Parameters.AddWithValue("autor", textBox3.Text);
                    sqlcommand.Parameters.AddWithValue("editura", textBox4.Text);
                    sqlcommand.Parameters.AddWithValue("an", textBox5.Text);
                    sqlcommand.Parameters.AddWithValue("cod", textBox6.Text);
                    sqlcommand.Parameters.AddWithValue("isbn", textBox7.Text);
                    sqlcommand.Parameters.AddWithValue("nrex", textBox8.Text);
                    sqlcommand.CommandText = "SELECT * FROM listacarti WHERE ISBN=@isbn";
                        sqlconnection.Open();
                        reader = sqlcommand.ExecuteReader();
                        if (reader.Read()) MessageBox.Show("Acest numar de inventar este deja atribuit!");
                        else
                        {
                            sqlconnection.Close();
                            sqlcommand.CommandText = "SELECT * FROM listacarti WHERE Nrinv=@nrinv";
                            sqlconnection.Open();
                            reader = sqlcommand.ExecuteReader();
                            if (!reader.Read())
                            {
                                sqlconnection.Close();

                                sqlconnection.Close();
                                sqlcommand.CommandText = "insert into listacarti (Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex) values (@nrinv,@titlu,@autor,@editura,@an,@cod,@isbn,@nrex)";
                                sqlconnection.Open();
                                sqlcommand.ExecuteNonQuery();
                                sqlconnection.Close();
                                MessageBox.Show("Carte introdusa cu succes!");
                            }
                            else MessageBox.Show("Acest numar de inventar este deja atribuit altei carti!");
                        }
                }
                else MessageBox.Show("Campurile nu pot fi goale!");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0')&&e.KeyChar!=8)
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && (e.KeyChar != 8 && e.KeyChar!='-'))
                e.Handled = true;
        }
    }
}
