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
    public partial class fisa_deschisa : Form
    {
        public fisa_deschisa()
        {
            InitializeComponent();
        }

        private void fisa_deschisa_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcom = new SqlCommand();
            sqlcon.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            sqlcom.Connection = sqlcon;
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT fisa.ID, fisa.Email, clienti.Prenume, clienti.Nume, listamasini.Marca, listamasini.Model, fisa.Data_intrare FROM fisa
                                                     LEFT JOIN clienti ON fisa.Email=clienti.Email
                                                     LEFT JOIN listamasini ON fisa.Masina=listamasini.ID 
                                                     WHERE Data_iesire IS NULL", sqlcon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
