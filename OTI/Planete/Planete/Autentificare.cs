using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Planete
{
    public partial class Autentificare : Form
    {
        public Autentificare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString=Properties.Settings.Default.DBSistem1ConnectionString;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection=sqlconnection;
            SqlDataReader reader;
            sqlcommand.Parameters.AddWithValue("id", textBox1.Text);
            sqlcommand.Parameters.AddWithValue("parola", textBox2.Text);
            sqlcommand.Parameters.AddWithValue("email", textBox3.Text);
            sqlcommand.CommandText = "SELECT Nume_Utilizator,Parola,Email from Utilizatori WHERE Nume_Utilizator = @id";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            if (!reader.Read())
            {
                sqlconnection.Close();
                MessageBox.Show("Utilizatorul nu se afla in baza de date!");
            }
            else
            {
                string nume="", parola="", email="";
                nume = reader[0].ToString().TrimEnd();
                parola = reader[1].ToString().TrimEnd();
                email = reader[2].ToString().TrimEnd();
                if (nume != textBox1.Text || parola != textBox2.Text || email != textBox3.Text)
                    MessageBox.Show("Datele introduse sunt incorecte ");

                else
                {
                    Operatii form = new Operatii(nume);
                    form.Show();
                    this.Close();
                }
            }
        }
    }
}
