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
    public partial class adauga : Form
    {
        public adauga()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcom = new SqlCommand();
            sqlcon.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            sqlcom.Connection = sqlcon;
            sqlcom.Parameters.AddWithValue("marca",textBox1.Text);
            sqlcom.Parameters.AddWithValue("model",textBox2.Text);
            sqlcom.Parameters.AddWithValue("an",textBox3.Text);
            sqlcom.Parameters.AddWithValue("serie",textBox4.Text);
            sqlcom.Parameters.AddWithValue("observatii",textBox6.Text);

            sqlcom.CommandText = "INSERT into listamasini (Marca,Model,An_fabricatie,Serie_sasiu,Observatii) values(@marca,@model,@an,@serie,@observatii)";
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Adaugat cu succes!");
            }
            else MessageBox.Show("Introduceti datele despre masina!");
            
        }
    }
}
