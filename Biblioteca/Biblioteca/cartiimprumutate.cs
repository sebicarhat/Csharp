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
    public partial class cartiimprumutate : Form
    {
        public cartiimprumutate()
        {
            InitializeComponent();
        }

        private void cartiimprumutate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet2.cartiimprumutate' table. You can move, or remove it, as needed.
            this.cartiimprumutateTableAdapter.Fill(this.bazaDataSet2.cartiimprumutate);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Nume,Titlucarte,Autor,Editura,Data FROM cartiimprumutate WHERE Cnp like '" + textBox1.Text + "%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

    }
}
