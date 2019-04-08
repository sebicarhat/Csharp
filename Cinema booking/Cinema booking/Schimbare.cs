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
    public partial class Schimbare : Form
    {
        public Schimbare(string user)
        {
            InitializeComponent();
            textBox1.Text = user;
        }
        public Schimbare(int a, int b)
        {
            InitializeComponent();
            textBox1.Text = a.ToString();
            textBox2.Text = b.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox4.Text != "")
                {
                    string parolav = textBox2.Text;
                    SqlConnection sqlconnection = new SqlConnection();
                    sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = sqlconnection;
                    sqlcommand.Parameters.AddWithValue("id", textBox1.Text);
                    sqlcommand.Parameters.AddWithValue("usern", textBox3.Text);
                    sqlcommand.Parameters.AddWithValue("parolan", textBox4.Text);
                    SqlDataReader reader;
                    sqlcommand.CommandText = "SELECT Password FROM baza WHERE(id=@id)";
                    sqlconnection.Open();
                    reader = sqlcommand.ExecuteReader();
                    string s = "";
                    reader.Read();
                    s = reader.GetString(0);
                    sqlconnection.Close();
                    if (s == parolav)
                    {
                        if (textBox3.Text != "")
                            sqlcommand.CommandText = @"UPDATE baza set nume=@usern  WHERE Id=@id";
                        if (textBox4.Text == textBox5.Text)
                        {
                            sqlcommand.CommandText = @"UPDATE baza set Password=@parolan  WHERE Id=@id";
                            MessageBox.Show("Parola o fost schimbata cu succes.");
                        }
                        else MessageBox.Show("Parola noua nu corespunde cu cea confirmata");
                        sqlconnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlconnection.Close();
                    }
                    else MessageBox.Show("Parola incorecta!");
                }
                else MessageBox.Show("Campurile marcate cu obligatoriu (*) nu pot fi goale!");
        }
            catch (Exception ex) {MessageBox.Show(ex.Message);}

        }

        private void Schimbare_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
