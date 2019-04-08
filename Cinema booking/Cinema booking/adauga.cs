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
    public partial class adauga : Form
    {
        string id;
        public adauga(string s)
        {
            id = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gen = "";
            foreach (var checkbox in Controls.OfType<CheckBox>())
            {
                if (checkbox.Checked == true)
                {
                    gen += checkbox.Text;
                    gen += ",";
                }
            }


            try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                {
                    SqlConnection sqlconnection = new SqlConnection();
                    sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = sqlconnection;
                    sqlcommand.Parameters.AddWithValue("titlu", textBox1.Text);
                    sqlcommand.Parameters.AddWithValue("director", textBox2.Text);
                    sqlcommand.Parameters.AddWithValue("gen", gen);
                    sqlcommand.Parameters.AddWithValue("an", textBox4.Text);
                    sqlcommand.Parameters.AddWithValue("id", id);

                    sqlconnection.Close();
                    sqlcommand.CommandText = "insert into listafilme(Titlu,Director,Gen,Anulaparitiei,Adaugatde) values (@titlu,@director,@gen,@an,@id)";
                    sqlconnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlconnection.Close();

                    MessageBox.Show("Adaugat cu succes!");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                }
                else MessageBox.Show("Campurile nu pot fi goale!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
