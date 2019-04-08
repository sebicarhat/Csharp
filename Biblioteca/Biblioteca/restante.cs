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
    public partial class restante : Form
    {
        public restante()
        {
            InitializeComponent();
        }

        private void restante_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet2.cartiimprumutate' table. You can move, or remove it, as needed.
            this.cartiimprumutateTableAdapter.Fill(this.bazaDataSet2.cartiimprumutate);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = con;
            sqlcommand.CommandText = "SELECT Timp FROM Setari WHERE ID=1";
            SqlDataReader reader;
            con.Open();
            reader = sqlcommand.ExecuteReader();
            reader.Read();
            string s = reader[0].ToString();
            con.Close();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID,Nume,CNP,Titlucarte,Autor,Editura,Data FROM cartiimprumutate WHERE '"+ DateTime.Now.DayOfYear +"'- Dataan >= '"+s+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }
    }
}
