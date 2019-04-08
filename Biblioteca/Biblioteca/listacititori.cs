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
    public partial class listacititori : Form
    {
        public listacititori()
        {
            InitializeComponent();
        }

        private void listacititoriBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.listacititoriBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bazaDataSet1);

        }

        private void listacititori_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet1.listacititori' table. You can move, or remove it, as needed.
            this.listacititoriTableAdapter.Fill(this.bazaDataSet1.listacititori);

        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salvati modificarile facute?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    this.Validate();
                    this.listacititoriBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.bazaDataSet1);
                }
                catch (SqlException ex)
                { MessageBox.Show(ex.Message); }

            }
        }
    }
}
