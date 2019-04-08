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
    public partial class rezerva : Form
    {
        public rezerva()
        {
            InitializeComponent();
        }

         private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            if (textBox1.Text == "")
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
            }
            else
            {
                if (comboBox1.Text == "Titlu")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT IDProgramare,listafilme.Titlu,listafilme.Director,listafilme.Gen,listafilme.Anulaparitiei,Sala,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE listafilme.Titlu like '" + textBox1.Text + "%' and DAY(dateadd(dd, 0, GetDate())) = DAY(programari.Inceput)", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                    if (comboBox1.Text == "Director")
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT IDProgramare,listafilme.Titlu,listafilme.Director,listafilme.Gen,listafilme.Anulaparitiei,Sala,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE listafilme.Director like '" + textBox1.Text + "%' and DAY(dateadd(dd, 0, GetDate())) = DAY(programari.Inceput)", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    else
                        if (comboBox1.Text == "Anul aparitiei")
                        {
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT IDProgramare,listafilme.Titlu,listafilme.Director,listafilme.Gen,listafilme.Anulaparitiei,Sala,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE listafilme.Anulaparitiei like '" + textBox1.Text + "%' and DAY(dateadd(dd, 0, GetDate())) = DAY(programari.Inceput)", con);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        else
                            if (comboBox1.Text == "Ora")
                            {

                                SqlDataAdapter sda = new SqlDataAdapter("SELECT IDProgramare,listafilme.Titlu,listafilme.Director,listafilme.Gen,listafilme.Anulaparitiei,Sala,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE programari.Ora like '" + textBox1.Text + "%' and DAY(dateadd(dd, 0, GetDate())) = DAY(programari.Inceput)", con);
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Data")
            {
                
                textBox1.Visible = true;
                dateTimePicker1.Visible = false;
            }
            else
            {
                textBox1.Visible = false;
                dateTimePicker1.Visible = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT IDProgramare,listafilme.Titlu,listafilme.Director,listafilme.Gen,listafilme.Anulaparitiei,Sala,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE DAY(programari.Inceput) = DAY(dateadd(dd, 0, '" + dateTimePicker1.Value + "'))", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
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
                sqlcommand.CommandText = @"SELECT Sala,listafilme.Titlu,Inceput FROM programari inner join listafilme on listafilme.ID=programari.IDFilm WHERE(IDProgramare=@idProgramare AND Sters=0)  ";
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

        private void rezerva_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > '9' || e.KeyChar < '0') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button1.Tag = dataGridView1.SelectedCells[0].Value.ToString().TrimEnd();
        }
    }
}
