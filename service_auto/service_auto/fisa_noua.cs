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
    public partial class fisa_noua : Form
    {
        public fisa_noua()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcom = new SqlCommand();
            sqlcon.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            sqlcom.Connection = sqlcon;
            SqlDataReader reader;
            sqlcom.Parameters.AddWithValue("email", textBox1.Text);
            sqlcom.Parameters.AddWithValue("id", textBox2.Text);
            sqlcom.Parameters.AddWithValue("servicii", textBox3.Text);
            sqlcom.Parameters.AddWithValue("observatii", textBox4.Text);
            sqlcom.CommandText = "SELECT CNP FROM clienti WHERE Email=@email";
            sqlcon.Open();
            reader = sqlcom.ExecuteReader();
            if (!reader.Read())
                MessageBox.Show("Adresa de e-mail nu este inregistrata!");
            else
            {
                sqlcon.Close();
                sqlcom.CommandText = "SELECT ID FROM listamasini WHERE ID=@id";
                sqlcon.Open();
                reader = sqlcom.ExecuteReader();
                if (!reader.Read())
                    MessageBox.Show("Masina nu este inregistrata!");
                else
                {
                    sqlcon.Close();
                    sqlcom.CommandText = "INSERT into fisa (Email,Masina,Servicii,Observatii,Data_intrare) values (@email,@id,@servicii,@observatii,'" + DateTime.Now + "')";
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                    {
                        sqlcon.Open();
                        sqlcom.ExecuteNonQuery();
                        sqlcon.Close();
                        MessageBox.Show("Adaugat cu succes!");
                    }

                    else MessageBox.Show("Introduceti datele!");
                }
            }
        }
    }
}
