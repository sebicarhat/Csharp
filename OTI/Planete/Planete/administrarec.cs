using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Planete
{
    public partial class administrarec : Form
    {
        public administrarec()
        {
            InitializeComponent();
        }
        SqlConnection sqlconnection;
        SqlCommand sqlcommand;
        SqlDataReader reader;
        private void administrarec_Load(object sender, EventArgs e)
        {
            sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.DBSistem1ConnectionString;
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.CommandText = 
            @"SELECT Nume_Planeta
              FROM   Planete";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString()); 
            }
            sqlconnection.Close();
            comboBox1.SelectedIndex = 0;
        }

        private void administrarec_Shown(object sender, EventArgs e)
        {
            //this.MdiParent = new Operatii("Administrator");
        }
        Label umlabel;
        Label data;
        TextBox tbval;
        DateTimePicker dtpval;
        Button sterge;
        NumericUpDown numval;
        int j;
        int idplaneta;
        private void btn_Click(object sender, EventArgs e)
        {
            foreach (var button in panel1.Controls.OfType<Button>())
                if (sender == button)
         {
        string s = button.Tag.ToString();
        sqlconnection = new SqlConnection();
        sqlconnection.ConnectionString = Properties.Settings.Default.DBSistem1ConnectionString;
        sqlcommand = new SqlCommand();
        sqlcommand.Connection = sqlconnection;
        sqlcommand.CommandText = "DELETE FROM Valori WHERE ID_Caracteristica = '" + s + "' AND ID_Planeta = '"+idplaneta+"'";
        sqlconnection.Open();
        sqlcommand.ExecuteNonQuery();
        sqlconnection.Close();
        panel1.Controls.Clear();
        //foreach (Control item in panel1.Controls.OfType<Control>())
        //item.Dispose();
        comboBox1_SelectedIndexChanged(comboBox1, new EventArgs());
        }
        }

        private void generare(string s, string val,string den, string tip, string um, int j)
        {       
                data = new Label();
                data.Name = "data" + j;
                data.Text = den;
                data.Top = 50 * j;
                data.Left = 60;
                data.AutoSize = true;
                panel1.Controls.Add(data);
                if (tip == "1")
                {
                    DateTime parsed;
                    DateTime.TryParse(val, null, System.Globalization.DateTimeStyles.None, out parsed);
                    dtpval = new DateTimePicker();
                    dtpval.Name = "dtpval" + j;
                    dtpval.Value = parsed.Date;
                    dtpval.Tag=s;
                    dtpval.Top = 20 + 50 * j;
                    dtpval.Left = 60;
                    dtpval.Width = 240;
                    panel1.Controls.Add(dtpval);
                }
                else if (tip == "2")
                {
                    numval = new NumericUpDown();
                    numval.Name = "numval" + j;
                    numval.Value = int.Parse(val);
                    numval.Tag=s;
                    numval.Top = 20 + 50 * j;
                    numval.Left = 60;
                    numval.Width = 240;
                    panel1.Controls.Add(numval);
                }
                else if (tip == "3")
                {
                    tbval = new TextBox();
                    tbval.Name = "tbval" + j;
                    tbval.Text = val;
                    tbval.Tag=s;
                    tbval.Top = 20 + 50 * j;
                    tbval.Left = 60;
                    tbval.Width = 240;
                    panel1.Controls.Add(tbval);
                }
                umlabel = new Label();
                umlabel.Name = "umlabel" + j;
                umlabel.Text = um;
                umlabel.Top = 20 + 50 * j;
                umlabel.Left = 310;
                umlabel.AutoSize = true;
                panel1.Controls.Add(umlabel);
                sterge = new Button();
                sterge.Name = "sterge" + j;
                sterge.Tag = s;
                sterge.Text = "Sterge";
                sterge.Width = 50;
                sterge.Height = 25;
                sterge.Top = 20 + 50 * j;
                sterge.Left = 370;
                sterge.Click += new EventHandler(this.btn_Click);
                panel1.Controls.Add(sterge);
            }
        private void popularedatenoi()
        {
            comboBox2.Items.Clear();
            sqlcommand.CommandText = "SELECT * FROM Caracteristici WHERE ID_Caracteristica NOT IN (Select ID_Caracteristica from Valori WHERE ID_PLaneta= '" + idplaneta + "') ";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[1].ToString());
            }
            sqlconnection.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            string[] s = new string[10];
            string[] val = new string[10];
            string den = "";
            string tip = "";
            string um = "";
            int i = 0;
            sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.DBSistem1ConnectionString;
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.CommandText = "SELECT ID_Planeta from Planete WHERE Nume_Planeta = '" + comboBox1.Text.TrimEnd() + "'";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            if (reader.Read())
                idplaneta = int.Parse(reader[0].ToString());
            sqlconnection.Close();
            sqlcommand.CommandText = "SELECT ID_Caracteristica,Valoare from Valori WHERE ID_Planeta='" + idplaneta + "'";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                i++;
                s[i] = reader[0].ToString().TrimEnd();
                val[i] = reader[1].ToString().TrimEnd();
            }
            sqlconnection.Close();
            for (j = 1; j <= i; ++j)
            {
                sqlcommand.CommandText = "Select Denumire,Tip_Caracteristica,UM from Caracteristici WHERE ID_Caracteristica = '" + s[j] + "'";
                sqlconnection.Open();
                reader = sqlcommand.ExecuteReader();
                if (reader.Read())
                {
                    den = reader[0].ToString();
                    tip = reader[1].ToString();
                    um = reader[2].ToString();
                }
                sqlconnection.Close();
            generare(s[j],val[j],den,tip,um,j);
            }
            popularedatenoi();
            }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s;
            sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.DBSistem1ConnectionString;
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand.CommandText = "SELECT ID_Caracteristica,Tip_Caracteristica,UM FROM Caracteristici WHERE Denumire = '" + comboBox2.Text + "'";
            sqlconnection.Open();
            reader = sqlcommand.ExecuteReader();
            if (reader.Read())
            {
                s = reader[0].ToString();
                if (reader[1].ToString() == "1")
                {
                    sqlconnection.Close();
                    string data = "01.01.2000";
                    //generare(reader[0].ToString(), "01.01.2000", comboBox2.Text, reader[1].ToString(), reader[2].ToString(), j++);
                    sqlcommand.CommandText = @"INSERT INTO Valori (ID_Planeta,ID_Caracteristica,Valoare) values('" + idplaneta + "','" + s + "','" + data + "')";
                    sqlconnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlconnection.Close();
                }
                else
                {
                    sqlconnection.Close();
                    string data = "0";
                    //generare(reader[0].ToString(), "0", comboBox2.Text, reader[1].ToString(), reader[2].ToString(), j++);
                    sqlcommand.CommandText = @"INSERT INTO Valori (ID_Planeta,ID_Caracteristica,Valoare) values('" + idplaneta + "','" + s + "','" + data + "')";
                    sqlconnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            comboBox1_SelectedIndexChanged(comboBox1, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString = Properties.Settings.Default.DBSistem1ConnectionString;
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            foreach (var item in panel1.Controls.OfType<DateTimePicker>())
            {
                s = item.Tag.ToString();
                sqlcommand.CommandText = "UPDATE Valori SET Valoare = '" + item.Value + "' WHERE ID_Planeta = '" + idplaneta + "' AND ID_Caracteristica = '" + s + "'";
                sqlconnection.Open();
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
            }
            foreach(var item in panel1.Controls.OfType<NumericUpDown>())
            {
                s = item.Tag.ToString();
                sqlcommand.CommandText = "UPDATE Valori SET Valoare = '" + item.Value.ToString() + "' WHERE ID_Planeta = '" + idplaneta + "' AND ID_Caracteristica = '" + s + "'";
                sqlconnection.Open();
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
            }    
            foreach(var item in panel1.Controls.OfType<TextBox>())
            {
                s = item.Tag.ToString();
                sqlcommand.CommandText = "UPDATE Valori SET Valoare = '" + item.Text + "' WHERE ID_Planeta = '" + idplaneta + "' AND ID_Caracteristica = '" + s + "'";
                sqlconnection.Open();
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
            }
        } 
    }
}
