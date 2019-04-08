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
    public partial class cautarecarte : Form
    {
        public cautarecarte()
        {
            InitializeComponent();
        }

        private void cautarecarte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet.listacarti' table. You can move, or remove it, as needed.
            //this.listacartiTableAdapter.Fill(this.bazaDataSet.listacarti);
            textBox1.Select();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
            if (textBox1.Text == "")
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
            }
            else
            {
                if (comboBox1.Text == "Numar inventar")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex FROM listacarti WHERE Nrinv like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Titlu")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex FROM listacarti WHERE Titlu like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Autor")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex FROM listacarti WHERE Autor like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Editura")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex FROM listacarti WHERE Editura like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "An aparitie")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex FROM listacarti WHERE Anaparitie like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Cod de bare")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex FROM listacarti WHERE Codbare like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "ISBN")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN,Nrex FROM listacarti WHERE ISBN like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
