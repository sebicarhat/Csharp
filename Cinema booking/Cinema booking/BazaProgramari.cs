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
    public partial class BazaProgramari : Form
    {
        public BazaProgramari()
        {
            InitializeComponent();
        }

        private void programariBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.programariBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.programariDataSet);

        }

        private void BazaProgramari_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'programariDataSet.programari' table. You can move, or remove it, as needed.
            this.programariTableAdapter.Fill(this.programariDataSet.programari);

        }
    }
}
