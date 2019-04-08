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
    public partial class programeaza : Form
    {

        public programeaza()
        {

            InitializeComponent();
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
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
                SqlDataAdapter sda = new SqlDataAdapter();
                if (comboBox1.Text == "Titlu")
                {
                    sda = new SqlDataAdapter("SELECT * FROM listafilme WHERE Titlu like '" + textBox1.Text + "%'", con);   
                }
                else
                    if (comboBox1.Text == "Director")
                    {
                        sda = new SqlDataAdapter("SELECT * FROM listafilme WHERE Director like '" + textBox1.Text + "%'", con);
                    }
                    else
                        if (comboBox1.Text == "Anul aparitiei")
                        {
                            sda = new SqlDataAdapter("SELECT * FROM listafilme WHERE Anulaparitiei like '" + textBox1.Text + "%'", con);
                        }
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

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



        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Tag == null)
                MessageBox.Show("Alege un film!");
            else
            {
                if (int.Parse(dateTimePicker1.Value.DayOfYear.ToString()) < DateTime.Now.DayOfYear)
                    MessageBox.Show("Nu se poate programa un film intr-o zi precedenta.");
                else
                {
                    DateTime dt = dateTimePicker1.Value;
                    TimeSpan ts = new TimeSpan(int.Parse(numericUpDown1.Value.ToString()),int.Parse(numericUpDown2.Value.ToString()),0);
                    dt = dt.Date + ts;

                    DateTime dt2 = dateTimePicker1.Value;
                    TimeSpan ts2 = new TimeSpan(int.Parse(numericUpDown3.Value.ToString()), int.Parse(numericUpDown4.Value.ToString()), 0);
                    dt = dt.Date + ts2;

                    int sala = int.Parse(numericUpDown3.Value.ToString());
                    SqlConnection sqlconnection = new SqlConnection();
                    sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = sqlconnection;

                    sqlcommand.Parameters.AddWithValue("sala", sala);
                    sqlcommand.Parameters.AddWithValue("inceput", dt);
                    sqlcommand.Parameters.AddWithValue("sfarsit",dt2);
                    sqlcommand.Parameters.AddWithValue("id", int.Parse(button1.Tag.ToString().TrimEnd()));
                    sqlcommand.CommandText = "select IDProgramare from Programari where Inceput>='" + dt + "' or  Sfarsit <= '" + dt2 + "'";
                    sqlconnection.Open();
                    SqlDataReader reader;
                    reader = sqlcommand.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Exista programare in acest interval de timp!");
                        sqlconnection.Close();
                    }
                    else
                    {
                        sqlconnection.Close();
                        sqlcommand.CommandText = "insert into programari (IDFilm, Sala, Inceput, Sfarsit, Sters) values (@id, @sala, @inceput, @sfarsit, 0)";
                        sqlconnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlconnection.Close();
                        sqlcommand.CommandText = "select IDProgramare from programari where IDFilm = @id";
                        sqlconnection.Open();
                        reader = sqlcommand.ExecuteReader();
                        reader.Read();
                        int id = int.Parse(reader[0].ToString());
                        sqlconnection.Close();

                        if (sala == 1)
                            sqlcommand.CommandText = "insert into sala1(IDProgramare,A1,A2,A3,A4,A5,A6,A7,A8,A9,A10,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10) values ('" + id + "',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                        else
                            if (sala == 2)
                                sqlcommand.CommandText = "insert into sala2(IDProgramare,A1,A2,A3,A4,A5,A6,A7,A8,A9,A10,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,F1,F2,F3,F4,F5,F6,F7,F8,F9,F10) values('" + id + "',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                        sqlconnection.Open();
                        sqlcommand.ExecuteNonQuery();
                        sqlconnection.Close();
                        MessageBox.Show("Programat cu succes!");
                    }

                }
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button1.Tag = dataGridView1.SelectedCells[0].Value.ToString().TrimEnd();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
