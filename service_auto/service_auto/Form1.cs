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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = con;
            SqlDataReader reader;
            if (toolStripTextBox1.Text == "")
                toolStripLabel6.Text = "ID: ";
            else
            {
                sqlcom.CommandText = "select ID from listamasini where Serie_sasiu like '" + toolStripTextBox1.Text + "'";
                con.Open();
                reader = sqlcom.ExecuteReader();
                if (reader.Read())
                    toolStripLabel6.Text += reader[0].ToString();
                else toolStripLabel6.Text = "ID: ";
            }

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            new adauga().Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            new client_noucs().Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            new fisa_noua().Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            new istoric().Show();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            new fisa_deschisa().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcom = new SqlCommand();
            sqlcon.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            sqlcom.Connection = sqlcon;
            sqlcom.CommandText = "UPDATE fisa SET Observatii='" + textBox2.Text + "', Data_iesire='" + DateTime.Now + "' WHERE ID='"+textBox1.Text+"'";
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("Fisa finalizata!");
        }
    }
}
