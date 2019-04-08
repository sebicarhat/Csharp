using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace service_auto
{
    public partial class client_noucs : Form
    {
        public client_noucs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcom = new SqlCommand();
            sqlcon.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            sqlcom.Connection = sqlcon;
            sqlcom.Parameters.AddWithValue("email", textBox1.Text);
            sqlcom.Parameters.AddWithValue("cnp", textBox2.Text);
            sqlcom.Parameters.AddWithValue("nume", textBox3.Text);
            sqlcom.Parameters.AddWithValue("prenume", textBox4.Text);
            sqlcom.Parameters.AddWithValue("adresa", textBox5.Text);
            sqlcom.Parameters.AddWithValue("telefon", textBox6.Text);
            sqlcom.CommandText = "INSERT into clienti (Email,CNP,Nume,Prenume,Adresa,Telefon) values(@email,@cnp,@nume,@prenume,@adresa,@telefon)";
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Adaugat cu succes!");
            }
            else MessageBox.Show("Introduceti datele despre client!");
        }
    }
}
