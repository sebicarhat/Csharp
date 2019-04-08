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
    public partial class setari : Form
    {
        public setari()
        {
            InitializeComponent();
        }

        private void setari_Load(object sender, EventArgs e)
        {
            string s;
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.CommandText = "SELECT Timp FROM Setari WHERE ID=1";
            SqlDataReader reader;
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            reader.Read();
            s = reader[0].ToString();
            sqlconnection.Close();
            numericUpDown1.Value = int.Parse(s);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.Parameters.AddWithValue("set", numericUpDown1.Value.ToString());
            sqlcommand.CommandText = "UPDATE Setari set Timp=@set WHERE ID=1";
            sqlconnection.Open();
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            MessageBox.Show("Salvare efectuata!");
        }
    }
}
