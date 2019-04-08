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
    public partial class cautarecititor : Form
    {
        public cautarecititor()
        {
            InitializeComponent();
        }

        private void cautarecititor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet1.listacititori' table. You can move, or remove it, as needed.
            this.listacititoriTableAdapter.Fill(this.bazaDataSet1.listacititori);
            // TODO: This line of code loads data into the 'bazaDataSet1.listacititori' table. You can move, or remove it, as needed.
            this.listacititoriTableAdapter.Fill(this.bazaDataSet1.listacititori);
            // TODO: This line of code loads data into the 'bazaDataSet1.listacititori' table. You can move, or remove it, as needed.
            //this.listacititoriTableAdapter.Fill(this.bazaDataSet1.listacititori);
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
                if (comboBox1.Text == "Cod")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Cod,Nume,CNP,Serie,Numar,Adresa,Telefon FROM listacititori WHERE Cod like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "Nume")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Cod,Nume,CNP,Serie,Numar,Adresa,Telefon FROM listacititori WHERE Nume like '" + textBox1.Text + "%'" , con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "CNP")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Cod,Nume,CNP,Serie,Numar,Adresa,Telefon FROM listacititori WHERE CNP like '" + textBox1.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
