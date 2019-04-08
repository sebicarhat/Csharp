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
    public partial class Usernou : Form
    {
        public Usernou()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text!="")
                {
                    SqlConnection sqlconnection = new SqlConnection();
                    sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = sqlconnection;
                    sqlcommand.Parameters.AddWithValue("id", textBox1.Text);
                    sqlcommand.Parameters.AddWithValue("pass", textBox2.Text);
                    sqlcommand.Parameters.AddWithValue("nume", textBox3.Text);
                    SqlDataReader reader;
                    sqlcommand.CommandText = "SELECT ID FROM baza where (ID=@id)";
                    sqlconnection.Open();
                    reader = sqlcommand.ExecuteReader();
                    if (!reader.Read())
                        sqlcommand.CommandText = "insert into baza (ID,Password,Nume) values (@id,@pass,@nume)";
                    else MessageBox.Show("Utilizatorul exista deja in baza de date.");
                    sqlconnection.Close();
                    sqlconnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlconnection.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else MessageBox.Show("Campurile nu pot fi goale!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
