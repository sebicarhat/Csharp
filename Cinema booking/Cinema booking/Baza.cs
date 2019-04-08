using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cinema_booking
{
    public partial class Baza : Form
    {
        public Baza()
        {
            InitializeComponent();
            
        }

        private void Baza_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.listafilme' table. You can move, or remove it, as needed.
            this.listafilmeTableAdapter1.Fill(this.database1DataSet1.listafilme);

                // TODO: This line of code loads data into the 'database1DataSet1.listafilme' table. You can move, or remove it, as needed.
                this.listafilmeTableAdapter1.Fill(this.database1DataSet1.listafilme);  
        }

        private void Baza_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void listafilmeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.listafilmeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void listafilmeBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.listafilmeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void listafilmeBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.listafilmeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

    }
}
