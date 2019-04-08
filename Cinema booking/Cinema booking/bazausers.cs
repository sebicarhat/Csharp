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
    public partial class bazausers : Form
    {
        public bazausers()
        {
            InitializeComponent();
        }

        private void bazausers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.baza' table. You can move, or remove it, as needed.
            this.bazaTableAdapter.Fill(this.database1DataSet3.baza);
            // TODO: This line of code loads data into the 'database1DataSet3.baza' table. You can move, or remove it, as needed.
            this.bazaTableAdapter.Fill(this.database1DataSet3.baza);

        }
    }
}
