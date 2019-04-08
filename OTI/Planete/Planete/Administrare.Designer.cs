namespace Planete
{
    partial class Administrare
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDPlanetaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numePlanetaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rPlanetaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gPlanetaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBSistem1DataSet = new Planete.DBSistem1DataSet();
            this.planeteTableAdapter = new Planete.DBSistem1DataSetTableAdapters.PlaneteTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planeteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSistem1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Incarca";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDPlanetaDataGridViewTextBoxColumn,
            this.numePlanetaDataGridViewTextBoxColumn,
            this.rPlanetaDataGridViewTextBoxColumn,
            this.gPlanetaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.planeteBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 235);
            this.dataGridView1.TabIndex = 1;
            // 
            // iDPlanetaDataGridViewTextBoxColumn
            // 
            this.iDPlanetaDataGridViewTextBoxColumn.DataPropertyName = "ID_Planeta";
            this.iDPlanetaDataGridViewTextBoxColumn.HeaderText = "ID_Planeta";
            this.iDPlanetaDataGridViewTextBoxColumn.Name = "iDPlanetaDataGridViewTextBoxColumn";
            this.iDPlanetaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numePlanetaDataGridViewTextBoxColumn
            // 
            this.numePlanetaDataGridViewTextBoxColumn.DataPropertyName = "Nume_Planeta";
            this.numePlanetaDataGridViewTextBoxColumn.HeaderText = "Nume_Planeta";
            this.numePlanetaDataGridViewTextBoxColumn.Name = "numePlanetaDataGridViewTextBoxColumn";
            // 
            // rPlanetaDataGridViewTextBoxColumn
            // 
            this.rPlanetaDataGridViewTextBoxColumn.DataPropertyName = "R_Planeta";
            this.rPlanetaDataGridViewTextBoxColumn.HeaderText = "R_Planeta";
            this.rPlanetaDataGridViewTextBoxColumn.Name = "rPlanetaDataGridViewTextBoxColumn";
            // 
            // gPlanetaDataGridViewTextBoxColumn
            // 
            this.gPlanetaDataGridViewTextBoxColumn.DataPropertyName = "G_Planeta";
            this.gPlanetaDataGridViewTextBoxColumn.HeaderText = "G_Planeta";
            this.gPlanetaDataGridViewTextBoxColumn.Name = "gPlanetaDataGridViewTextBoxColumn";
            // 
            // planeteBindingSource
            // 
            this.planeteBindingSource.DataMember = "Planete";
            this.planeteBindingSource.DataSource = this.dBSistem1DataSet;
            // 
            // dBSistem1DataSet
            // 
            this.dBSistem1DataSet.DataSetName = "DBSistem1DataSet";
            this.dBSistem1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // planeteTableAdapter
            // 
            this.planeteTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Inchide";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Administrare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 288);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Administrare";
            this.Text = "Administrare";
            this.Load += new System.EventHandler(this.Administrare_Load);
            this.Shown += new System.EventHandler(this.Administrare_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planeteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSistem1DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DBSistem1DataSet dBSistem1DataSet;
        private System.Windows.Forms.BindingSource planeteBindingSource;
        private DBSistem1DataSetTableAdapters.PlaneteTableAdapter planeteTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPlanetaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numePlanetaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rPlanetaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gPlanetaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button2;
    }
}