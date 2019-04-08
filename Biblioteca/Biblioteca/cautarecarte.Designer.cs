namespace Biblioteca
{
    partial class cautarecarte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrinvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titluDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edituraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anaparitieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codbareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSBNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listacartiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bazaDataSet = new Biblioteca.bazaDataSet();
            this.listacartiTableAdapter = new Biblioteca.bazaDataSetTableAdapters.listacartiTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listacartiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nrinvDataGridViewTextBoxColumn,
            this.titluDataGridViewTextBoxColumn,
            this.autorDataGridViewTextBoxColumn,
            this.edituraDataGridViewTextBoxColumn,
            this.anaparitieDataGridViewTextBoxColumn,
            this.codbareDataGridViewTextBoxColumn,
            this.iSBNDataGridViewTextBoxColumn,
            this.nrexDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listacartiBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(744, 44);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrinvDataGridViewTextBoxColumn
            // 
            this.nrinvDataGridViewTextBoxColumn.DataPropertyName = "Nrinv";
            this.nrinvDataGridViewTextBoxColumn.HeaderText = "Nrinv";
            this.nrinvDataGridViewTextBoxColumn.Name = "nrinvDataGridViewTextBoxColumn";
            this.nrinvDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titluDataGridViewTextBoxColumn
            // 
            this.titluDataGridViewTextBoxColumn.DataPropertyName = "Titlu";
            this.titluDataGridViewTextBoxColumn.HeaderText = "Titlu";
            this.titluDataGridViewTextBoxColumn.Name = "titluDataGridViewTextBoxColumn";
            this.titluDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // autorDataGridViewTextBoxColumn
            // 
            this.autorDataGridViewTextBoxColumn.DataPropertyName = "Autor";
            this.autorDataGridViewTextBoxColumn.HeaderText = "Autor";
            this.autorDataGridViewTextBoxColumn.Name = "autorDataGridViewTextBoxColumn";
            this.autorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // edituraDataGridViewTextBoxColumn
            // 
            this.edituraDataGridViewTextBoxColumn.DataPropertyName = "Editura";
            this.edituraDataGridViewTextBoxColumn.HeaderText = "Editura";
            this.edituraDataGridViewTextBoxColumn.Name = "edituraDataGridViewTextBoxColumn";
            this.edituraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // anaparitieDataGridViewTextBoxColumn
            // 
            this.anaparitieDataGridViewTextBoxColumn.DataPropertyName = "Anaparitie";
            this.anaparitieDataGridViewTextBoxColumn.HeaderText = "Anaparitie";
            this.anaparitieDataGridViewTextBoxColumn.Name = "anaparitieDataGridViewTextBoxColumn";
            this.anaparitieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codbareDataGridViewTextBoxColumn
            // 
            this.codbareDataGridViewTextBoxColumn.DataPropertyName = "Codbare";
            this.codbareDataGridViewTextBoxColumn.HeaderText = "Codbare";
            this.codbareDataGridViewTextBoxColumn.Name = "codbareDataGridViewTextBoxColumn";
            this.codbareDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iSBNDataGridViewTextBoxColumn
            // 
            this.iSBNDataGridViewTextBoxColumn.DataPropertyName = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.HeaderText = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.Name = "iSBNDataGridViewTextBoxColumn";
            this.iSBNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrexDataGridViewTextBoxColumn
            // 
            this.nrexDataGridViewTextBoxColumn.DataPropertyName = "Nrex";
            this.nrexDataGridViewTextBoxColumn.HeaderText = "Nrex";
            this.nrexDataGridViewTextBoxColumn.Name = "nrexDataGridViewTextBoxColumn";
            this.nrexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // listacartiBindingSource
            // 
            this.listacartiBindingSource.DataMember = "listacarti";
            this.listacartiBindingSource.DataSource = this.bazaDataSet;
            // 
            // bazaDataSet
            // 
            this.bazaDataSet.DataSetName = "bazaDataSet";
            this.bazaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listacartiTableAdapter
            // 
            this.listacartiTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Numar inventar",
            "Titlu",
            "Autor",
            "Editura",
            "An aparitie",
            "Cod de bare",
            "ISBN"});
            this.comboBox1.Location = new System.Drawing.Point(351, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Titlu";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(274, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cautare dupa:";
            // 
            // cautarecarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 117);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "cautarecarte";
            this.Text = "cautarecarte";
            this.Load += new System.EventHandler(this.cautarecarte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listacartiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bazaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private bazaDataSet bazaDataSet;
        private System.Windows.Forms.BindingSource listacartiBindingSource;
        private bazaDataSetTableAdapters.listacartiTableAdapter listacartiTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrinvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titluDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn edituraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anaparitieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codbareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSBNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrexDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}