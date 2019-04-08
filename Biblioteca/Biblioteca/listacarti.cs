using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Biblioteca
{
    public partial class listacarti : Form
    {
        public listacarti()
        {
            InitializeComponent();
        }

        private void listacarti_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet.listacarti' table. You can move, or remove it, as needed.
            this.listacartiTableAdapter.Fill(this.bazaDataSet.listacarti);
            this.listacartiDataGridView.Sort(this.listacartiDataGridView.Columns[2], ListSortDirection.Ascending);
        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {

                if (MessageBox.Show("Salvati modificarile facute?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        this.Validate();
                        this.listacartiBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.bazaDataSet);
                    }
                    catch (SqlException ex)
                    { MessageBox.Show(ex.Message); }
                }
        }





    }
}
