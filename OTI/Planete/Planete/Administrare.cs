using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Planete
{
    public partial class Administrare : Form
    {
        public Administrare()
        {
            InitializeComponent();
        }
        StreamReader sr;
        SqlConnection sqlconnection;
        SqlCommand sqlcommand;
        private void button1_Click(object sender, EventArgs e)
        {

            /*sqlcommand.CommandText = "CREATE VIEW vwPlanete AS SELECT Nume_Planeta,R_Planeta,G_Planeta FROM Planete";
            sqlconnection.Open();
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            sqlcommand.CommandText = "BULK INSERT vwPlanete FROM 'C:/Users/Sebi/Desktop/info/C#_resurse/planete.txt' WITH (FIELDTERMINATOR = ', ',ROWTERMINATOR = '\n')";
            sqlconnection.Open();
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();*/

            this.planeteTableAdapter.Fill(this.dBSistem1DataSet.Planete);
        }

        private void Administrare_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Administrare_Load(object sender, EventArgs e)
        {
            sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.DBSistem1ConnectionString;
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            string linie;
            int rp;
            decimal gp;
            List<string> nume = new List<string>();
            List<string> r = new List<string>();
            List<string> g = new List<string>();
            sr = new StreamReader(Application.StartupPath+"/C#_resurse/planete.txt");
            while (!sr.EndOfStream)
            {
                linie = sr.ReadLine();
                linie = linie.Replace(", ", "*");
                string[] parts = linie.Split('*');
                parts[2] = parts[2].Replace(",", ".");
                rp = int.Parse(parts[1]);
                gp = decimal.Parse(parts[2]);
                sqlcommand.CommandText = @"IF NOT EXISTS (SELECT * FROM Planete WHERE ID_Planeta=8)insert into Planete(Nume_Planeta,R_Planeta,G_Planeta) values('" + parts[0] + "','" + rp + "','" + gp + "')";
                sqlconnection.Open();
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            administrarec form = new administrarec();
            form.MdiParent = this.ParentForm;
            this.Close();
            form.Show();
        }
    }
}
