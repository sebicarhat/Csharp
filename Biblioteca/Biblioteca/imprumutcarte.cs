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
    public partial class imprumutcarte : Form
    {
        public imprumutcarte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string nume, cnp, titlu, autor, editura,nrexemplare;
                int numarexemplare;
                SqlConnection sqlconnection = new SqlConnection();
                sqlconnection.ConnectionString = Properties.Settings.Default.bazaConnectionString1;
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.Parameters.AddWithValue("codcititor", textBox1.Text);
                sqlcommand.Parameters.AddWithValue("nrinv", textBox2.Text);
                SqlDataReader reader;
                sqlcommand.CommandText = @"SELECT Nume,CNP FROM listacititori WHERE(cod=@codcititor) ";
                sqlconnection.Open();
                reader = sqlcommand.ExecuteReader();
                if (!reader.Read())
                    MessageBox.Show("Utilizatorul nu se afla in baza de date!");
                else
                {
                    nume = reader[0].ToString();
                    cnp = reader[1].ToString();
                    sqlconnection.Close();

                    sqlconnection.Open();
                    sqlcommand.CommandText = @"Select Titlu,Autor,Editura,Nrex FROM listacarti WHERE (Nrinv=@nrinv)";
                    reader = sqlcommand.ExecuteReader();
                    if (!reader.Read())
                        MessageBox.Show("Cartea nu se afla in baza de date!");
                    else
                    {
                        titlu = reader[0].ToString();
                        autor = reader[1].ToString();
                        editura = reader[2].ToString();
                        nrexemplare = reader[3].ToString();
                        numarexemplare = int.Parse(nrexemplare);
                        sqlconnection.Close();
                        if (numarexemplare == 0)
                            MessageBox.Show("Nu mai exista exemplare disponibile pentru aceasta carte!");
                        else
                        {
                            sqlcommand.Parameters.AddWithValue("numec", nume);
                            sqlcommand.Parameters.AddWithValue("cnp", cnp);
                            sqlcommand.Parameters.AddWithValue("titluc", titlu);
                            sqlcommand.Parameters.AddWithValue("autorc", autor);
                            sqlcommand.Parameters.AddWithValue("editurac", editura);
                            sqlcommand.Parameters.AddWithValue("dataan", DateTime.Now.DayOfYear);
                            sqlcommand.CommandText = @"INSERT into cartiimprumutate (Nrinv,Codcititor,Nume,CNP,Titlucarte,Autor,Editura,Dataan) values (@nrinv,@codcititor,@numec,@cnp,@titluc,@autorc,@editurac,@dataan)";
                            sqlconnection.Open();
                            sqlcommand.ExecuteReader();
                            sqlconnection.Close();
                            sqlcommand.CommandText = @"UPDATE listacarti set Nrex = Nrex - 1  WHERE Nrinv=@nrinv";
                            sqlconnection.Open();
                            sqlcommand.ExecuteReader();
                            sqlconnection.Close();
                            MessageBox.Show("Carte imprumutata!");
                        }
                    }

                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
                
            
                    
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
    }
}
