using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cinema_booking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autentificare form = new Autentificare();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DateTime dt = DateTime.Now;
            TimeSpan ts = new TimeSpan(0,0,0);
            dt = dt.Date + ts;

            DateTime dt2 = DateTime.Now;
            TimeSpan ts2 = new TimeSpan(23,59,59);
            dt2 = dt.Date + ts2;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT IDProgramare,listafilme.Titlu,listafilme.Director,listafilme.Gen,listafilme.Anulaparitiei,Sala,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE DAY(dateadd(dd, 0, GetDate())) = DAY(programari.Inceput)", con);
            DataTable dtable = new DataTable();
            sda.Fill(dtable);
            dataGridView1.DataSource = dtable;
        }
        


        private void rezervaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rezerva form = new rezerva();
            form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aceasta aplicatie a fost creata cu scopul de a simplifica modul de vanzare al biletelor la cinema(cinema booking)." + "\n" + "Utilizatorul are dreptul de a folosi aplicatia in conditile impuse de licenta fara drept de transfer.", "Despre");
        }

        private void autentificareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Autentificare().Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button1.Tag = dataGridView1.SelectedCells[0].Value.ToString().TrimEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Tag == null)
                MessageBox.Show("Nu ati selectat nici o programare!");
            else
            {

                string sala, titlu, data, ora, min;
                int nsala;
                SqlConnection sqlconnection = new SqlConnection();
                sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.Parameters.AddWithValue("idProgramare", int.Parse(button1.Tag.ToString()));
                SqlDataReader reader;
                sqlcommand.CommandText = @"SELECT Sala,listafilme.Titlu,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE IDProgramare=@idProgramare ";
                sqlconnection.Open();
                reader = sqlcommand.ExecuteReader();
                if (!reader.Read())
                    MessageBox.Show("Nu s-a gasit programarea!");
                else
                {
                    sala = reader[0].ToString();
                    titlu = reader[1].ToString();
                    data = Convert.ToDateTime(reader[2]).ToString("dd/MM/yyyy");
                    ora = Convert.ToDateTime(reader[2]).ToString("HH");
                    min = Convert.ToDateTime(reader[2]).ToString("mm");
                    nsala = int.Parse(sala);
                    sqlconnection.Close();
                    if (nsala == 1)
                    {
                        sala1 form = new sala1(nsala, button1.Tag.ToString(), titlu, data, ora, min);
                        form.Show();
                    }
                    if (nsala == 2)
                    {
                        sala2 form = new sala2(nsala, button1.Tag.ToString(), titlu, data, ora, min);
                        form.Show();
                    }
                }
            }
        }

        
    }
}
