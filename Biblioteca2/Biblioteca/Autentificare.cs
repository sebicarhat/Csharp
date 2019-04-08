using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Biblioteca
{
    public partial class Autentificare : Form
    {
        public Autentificare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString=Properties.Settings.Default.Database1ConnectionString;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            SqlDataReader reader;
            sqlcommand.CommandText="SELECT ID,Parola FROM bazautilizatori WHERE ID='"+textBox1.Text+"'";
            sqlconnection.Open();
            reader=sqlcommand.ExecuteReader();
            if (!reader.Read())
                MessageBox.Show("Utilizatorul nu se afla in baza de date");
            else 
            {
                s = reader[0].ToString();
                sqlconnection.Close();
                if (s == textBox2.Text)
                {
                    Form1 form = new Form1();
                    form.Show();
                    this.Close();
                }
                else MessageBox.Show("Parola incorecta");
            }

        }
    }
}
