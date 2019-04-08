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
    public partial class returnarecarte : Form
    {
        
        public returnarecarte()
        {
            InitializeComponent();  
        }

        private void returnarecarte_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.Parameters.AddWithValue("codcititor", textBox1.Text);
            sqlcommand.Parameters.AddWithValue("nrinv", textBox2.Text);
            SqlDataReader reader;
                sqlcommand.CommandText="SELECT Nrinv,Codcititor FROM cartiimprumutate WHERE Nrinv=@nrinv";
                sqlconnection.Open();
                reader = sqlcommand.ExecuteReader();
                if (!reader.Read())
                    MessageBox.Show("Cod cititor si/sau Numar inventar incorecte!");
                else
                {
                    sqlconnection.Close();
                    sqlcommand.CommandText = "DELETE from cartiimprumutate WHERE Codcititor like '" + textBox1.Text + "' and Nrinv like '" + textBox2.Text + "' ";
                    sqlconnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    sqlcommand.CommandText = "UPDATE listacarti set Nrex = Nrex + 1 WHERE Nrinv=@nrinv";
                    sqlconnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    MessageBox.Show("Carte returnata!");
                }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
    }
}
