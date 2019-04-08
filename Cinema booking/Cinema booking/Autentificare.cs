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
    public partial class Autentificare : Form
    {
        string nume = "";
        public Autentificare()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            try
            {
                SqlConnection sqlconnection = new SqlConnection();
                sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.Parameters.AddWithValue("user", textBox1.Text);
                SqlDataReader reader;
                sqlcommand.CommandText = @"SELECT password FROM baza WHERE(id=@user) ";
                sqlconnection.Open();
                reader = sqlcommand.ExecuteReader();
                if (!reader.Read())
                    MessageBox.Show("Utilizatorul nu se afla in baza de date!");
                else
                {
                    s = reader[0].ToString();
                   sqlconnection.Close();
                    if (textBox2.Text == s)
                    {
                        sqlcommand.CommandText = @"SELECT nume FROM baza WHERE(id=@user)";
                       sqlconnection.Open();
                       reader = sqlcommand.ExecuteReader();
                        reader.Read();
                        nume = reader[0].ToString();
                        sqlconnection.Close();
                        Adaugareinbaza form = new Adaugareinbaza(textBox1.Text, nume);
                        this.Close();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Parola incorecta", "Accesul interzis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sqlconnection.Close();
                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
