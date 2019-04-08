using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adaugarecarte form = new adaugarecarte();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listacarti form = new listacarti();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cautarecarte form = new cautarecarte();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adaugarecititor form = new adaugarecititor();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listacititori form = new listacititori();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cautarecititor form = new cautarecititor();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            imprumutcarte form = new imprumutcarte();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            returnarecarte form = new returnarecarte();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cartiimprumutate form = new cartiimprumutate();
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           restante form = new restante();
            form.Show();
        }

        private void timpImprumutareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new setari().Show();
        }




    }
}
