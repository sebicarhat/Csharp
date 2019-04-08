using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Biblioteca
{
    public partial class Adaugare : Form
    {
        public Adaugare()
        {
            InitializeComponent();
        }
        byte[] imgdata;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    SqlConnection sqlconnection = new SqlConnection();
                    sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = sqlconnection;
                    SqlDataReader reader;
                    sqlcommand.Parameters.AddWithValue("nrinv", textBox1.Text);
                    sqlcommand.Parameters.AddWithValue("titlu", textBox2.Text);
                    sqlcommand.Parameters.AddWithValue("autor", textBox3.Text);
                    sqlcommand.Parameters.AddWithValue("editura", textBox4.Text);
                    sqlcommand.Parameters.AddWithValue("an", textBox5.Text);
                    sqlcommand.Parameters.AddWithValue("cod", textBox6.Text);
                    sqlcommand.Parameters.AddWithValue("isbn", textBox7.Text);
                    sqlcommand.CommandText = "SELECT * FROM listacarti WHERE ISBN=@isbn";
                    sqlconnection.Open();
                    reader = sqlcommand.ExecuteReader();
                    if (reader.Read()) MessageBox.Show("Acest ISBN este deja atribuit!");
                    else
                    {
                        sqlconnection.Close();
                        sqlcommand.CommandText = "SELECT * FROM listacarti WHERE Nrinv=@nrinv";
                        sqlconnection.Open();
                        reader = sqlcommand.ExecuteReader();
                        if (!reader.Read())
                        {
                            sqlconnection.Close();
                            sqlcommand.CommandText = "insert into listacarti (Nrinv,Titlu,Autor,Editura,Anaparitie,Codbare,ISBN) values (@nrinv,@titlu,@autor,@editura,@an,@cod,@isbn)";
                            sqlconnection.Open();
                            sqlcommand.ExecuteNonQuery();
                            sqlconnection.Close();
                            if (pictureBox1.ImageLocation != null)
                            {
                                imgdata = File.ReadAllBytes(pictureBox1.ImageLocation);
                                sqlcommand.Parameters.AddWithValue("data", imgdata);
                                sqlcommand.CommandText = "update listacarti set Poza = @data";
                                sqlconnection.Open();
                                sqlcommand.ExecuteNonQuery();
                                sqlconnection.Close();
                            }
                            MessageBox.Show("Carte introdusa cu succes!");
                        }
                        else MessageBox.Show("Acest numar de inventar este deja atribuit altei carti!");
                    }
                }
                else MessageBox.Show("Campurile nu pot fi goale!");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input="";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open";
            ofd.InitialDirectory = "*";
            ofd.Filter = "PNG|*.png|JPEG|*.jpg|All files|*.";
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                input = ofd.FileName.Substring(ofd.FileName.LastIndexOf(@"\") + 1);
                textBox8.Text = input;
            }
            else MessageBox.Show("Ba");
        }

        private void numeric(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9')&&e.KeyChar!=8)
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9')&&((e.KeyChar!=8)&&e.KeyChar!='-'))
                e.Handled = true;
        }





    }
}
