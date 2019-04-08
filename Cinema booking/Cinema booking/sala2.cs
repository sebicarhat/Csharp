using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Cinema_booking
{
    public partial class sala2 : Form
    {
        int sala,numar;
        string titlu, data, ora, minut;
        public sala2(int nsala,string nr, string title, string date, string hour, string min)
        {
            InitializeComponent();
            sala = nsala;
            numar = int.Parse(nr);
            titlu = title;
            data = date;
            ora = hour;
            minut = min;
        }

        private void sala2_Load(object sender, EventArgs e)
        {
            label2.Text = titlu;
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.Parameters.AddWithValue("idProgramare", numar);
            SqlDataReader reader;
            //sqlcommand.CommandText = "SELECT A1,A2,A3,A4,A5,A6,A7,A8,A9,A10,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,F1,F2,F3,F4,F5,F6,F7,F8,F9,F10 FROM sala2 WHERE (Nr = @numar)";
            sqlcommand.CommandText = @"SELECT * INTO #TABLE FROM sala2 WHERE IDProgramare=@idProgramare 
                                     ALTER TABLE #TABLE DROP COLUMN IDProgramare
                                     SELECT * FROM #TABLE 
                                     DROP TABLE #TABLE";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            reader.Read();
            for (int i = 0; i < 60; ++i)
                if (reader[i].ToString() == "True")
                {
                    foreach (var button in Controls.OfType<Button>())
                    {
                        if (button.Text == reader.GetName(i))
                        {
                            button.BackColor = Color.Red;
                            button.Enabled = false;
                        }
                    }
                }
            sqlconnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var button in Controls.OfType<Button>())
            {
                if (sender == button)
                {
                    if (button.BackColor != Color.Red)
                        button.BackColor = Color.Red;
                    else
                        button.BackColor = Color.Green;
                }
            }   
            
        }

        private void rezerva_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.Parameters.AddWithValue("numar", numar);
            SqlDataReader reader;
            sqlconnection.Open();
            foreach (var button in Controls.OfType<Button>())
            {
                if (button.BackColor == Color.Red && button.Enabled == true)
                {
                    string updateString = "UPDATE sala2 SET " + button.Text + " = 1 WHERE Nr=@numar";
                    sqlcommand.CommandText = updateString;
                  
                    sqlcommand.ExecuteNonQuery();
                    MessageBox.Show("Film: " + titlu + "\nData: " + data + "\nOra: " + ora + ":" + minut + "\nLoc: " + button.Text + "\nSala: " + sala, "Booking efectuat");
                    //print("Film: " + titlu + "\nData: " + data + "\nOra: " + ora + ":" + minut + "\nLoc: " + button.Text + "\nSala: " + sala + "\nVizionare plăcută!" + "\n© 2006-2017 Cinema. Toate drepturile rezervate! ");
                }
            }
            sqlconnection.Close();
            
        }
        Bitmap bit;
        void print(string s)
        {
            bit = new Bitmap(Properties.Resources.ticket);
            Graphics g = Graphics.FromImage(bit);
            System.Drawing.Font printFont = new System.Drawing.Font
("Arial", 15, System.Drawing.FontStyle.Regular);
            g.DrawString(s, printFont,
    System.Drawing.Brushes.Black, 50, 50);
            printDocument1.PrintPage += PrintPage;
            printDocument1.Print();
        }
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = bit;
            Point loc = new Point(10, 10);
            e.Graphics.DrawImage(img, 30, 10, 750, 200);
        }
      
    }
}
