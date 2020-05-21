namespace BancoDeTiempo
{
    partial class ListadoServicios
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
            this.servicios = new BancoDeTiempo.servicios();
            this.serviciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serviciosTableAdapter = new BancoDeTiempo.serviciosTableAdapters.serviciosTableAdapter();
            this.idservicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiposervicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idservicioDataGridViewTextBoxColumn,
            this.tituloDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.idusuarioDataGridViewTextBoxColumn,
            this.idcategoriaDataGridViewTextBoxColumn,
            this.fechacreacionDataGridViewTextBoxColumn,
            this.tiposervicioDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.serviciosBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1284, 661);
            this.dataGridView1.TabIndex = 0;
            // 
            // servicios
            // 
            this.servicios.DataSetName = "servicios";
            this.servicios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // serviciosBindingSource
            // 
            this.serviciosBindingSource.DataMember = "servicios";
            this.serviciosBindingSource.DataSource = this.servicios;
            // 
            // serviciosTableAdapter
            // 
            this.serviciosTableAdapter.ClearBeforeFill = true;
            // 
            // idservicioDataGridViewTextBoxColumn
            // 
            this.idservicioDataGridViewTextBoxColumn.DataPropertyName = "id_servicio";
            this.idservicioDataGridViewTextBoxColumn.HeaderText = "id_servicio";
            this.idservicioDataGridViewTextBoxColumn.Name = "idservicioDataGridViewTextBoxColumn";
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            this.tituloDataGridViewTextBoxColumn.DataPropertyName = "titulo";
            this.tituloDataGridViewTextBoxColumn.HeaderText = "titulo";
            this.tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // idusuarioDataGridViewTextBoxColumn
            // 
            this.idusuarioDataGridViewTextBoxColumn.DataPropertyName = "id_usuario";
            this.idusuarioDataGridViewTextBoxColumn.HeaderText = "id_usuario";
            this.idusuarioDataGridViewTextBoxColumn.Name = "idusuarioDataGridViewTextBoxColumn";
            // 
            // idcategoriaDataGridViewTextBoxColumn
            // 
            this.idcategoriaDataGridViewTextBoxColumn.DataPropertyName = "id_categoria";
            this.idcategoriaDataGridViewTextBoxColumn.HeaderText = "id_categoria";
            this.idcategoriaDataGridViewTextBoxColumn.Name = "idcategoriaDataGridViewTextBoxColumn";
            // 
            // fechacreacionDataGridViewTextBoxColumn
            // 
            this.fechacreacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_creacion";
            this.fechacreacionDataGridViewTextBoxColumn.HeaderText = "fecha_creacion";
            this.fechacreacionDataGridViewTextBoxColumn.Name = "fechacreacionDataGridViewTextBoxColumn";
            // 
            // tiposervicioDataGridViewTextBoxColumn
            // 
            this.tiposervicioDataGridViewTextBoxColumn.DataPropertyName = "tipo_servicio";
            this.tiposervicioDataGridViewTextBoxColumn.HeaderText = "tipo_servicio";
            this.tiposervicioDataGridViewTextBoxColumn.Name = "tiposervicioDataGridViewTextBoxColumn";
            // 
            // ListadoServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ListadoServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de ofertas";
            this.Load += new System.EventHandler(this.ListadoServicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private servicios servicios;
        private System.Windows.Forms.BindingSource serviciosBindingSource;
        private serviciosTableAdapters.serviciosTableAdapter serviciosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idservicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiposervicioDataGridViewTextBoxColumn;
    }
}