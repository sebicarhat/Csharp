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
    public partial class sala1 : Form
    {
        int  sala,numar;
        string titlu, data, ora, minut;
        public sala1(int nsala,string nr, string title, string date, string hour, string min)
        {
            InitializeComponent();
            sala = nsala;
            numar = int.Parse(nr);
            titlu = title;
            data = date;
            ora = hour;
            minut = min;
        }


        private void sala1_Load(object sender, EventArgs e)
        {
            label2.Text = titlu;
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.Parameters.AddWithValue("numar", numar);
            SqlDataReader reader;
            //sqlcommand.CommandText = "SELECT A1,A2,A3,A4,A5,A6,A7,A8,A9,A10 FROM sala1 WHERE (Nr = @numar)";
            sqlcommand.CommandText = @"SELECT * INTO #TABLE FROM sala1 WHERE IDProgramare=@numar 
                                     ALTER TABLE #TABLE DROP COLUMN IDProgramare
                                     SELECT * FROM #TABLE 
                                     DROP TABLE #TABLE";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            reader.Read();
            for (int i = 0; i < 40; ++i)
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

        private void rezerva_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.Parameters.AddWithValue("idProgramare", numar);
            SqlDataReader reader;
            sqlconnection.Open();
            foreach (var button in Controls.OfType<Button>())
            {
                if (button.BackColor == Color.Red && button.Enabled == true)
                {
                    string updateString = "UPDATE sala1 SET " + button.Text + " = 1 WHERE IDProgramare=@idProgramare";
                    //sqlcommand.CommandText = @"UPDATE sala1 SET  '"+button.Text+"' = 1 WHERE Nr=@numar";
                    sqlcommand.CommandText = updateString;
                   
                        sqlcommand.ExecuteNonQuery();
                       // bilet form = new bilet("Film: " + titlu + "\nData: " + data + "\nOra: " + ora + ":" + minut + "\nLoc: " + button.Text + "\nSala: " + sala);
                    //form.Show();
                        MessageBox.Show("Film: " + titlu + "\nData: " + data + "\nOra: " + ora + ":" + minut + "\nLoc: " + button.Text + "\nSala: " + sala, "Booking efectuat");
                       // print("Film: " + titlu + "\nData: " + data + "\nOra: " + ora + ":" + minut + "\nLoc: " + button.Text + "\nSala: " + sala + "\nVizionare plăcută!" + "\n© 2006-2017 Cinema. Toate drepturile rezervate! ");
                    
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


    }
}
