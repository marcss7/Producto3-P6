namespace BancoDeTiempo
{
    partial class TransferirTiempo
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreusuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombre_usuario = new BancoDeTiempo.nombre_usuario();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.usuariosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosTableAdapter = new BancoDeTiempo.nombre_usuarioTableAdapters.usuariosTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.concepto_servicios = new BancoDeTiempo.concepto_servicios();
            this.serviciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serviciosTableAdapter = new BancoDeTiempo.concepto_serviciosTableAdapters.serviciosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreusuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombre_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.concepto_servicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.label1.Location = new System.Drawing.Point(428, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transferir tiempo a";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "Transferir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(667, 532);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 60);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario dador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario destinatario";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.usuariosBindingSource;
            this.comboBox1.DisplayMember = "nombre_usuario";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(437, 203);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "usuarios";
            this.usuariosBindingSource.DataSource = this.nombreusuarioBindingSource;
            // 
            // nombreusuarioBindingSource
            // 
            this.nombreusuarioBindingSource.DataSource = this.nombre_usuario;
            this.nombreusuarioBindingSource.Position = 0;
            // 
            // nombre_usuario
            // 
            this.nombre_usuario.DataSetName = "nombre_usuario";
            this.nombre_usuario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.usuariosBindingSource1;
            this.comboBox2.DisplayMember = "nombre_usuario";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(437, 258);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // usuariosBindingSource1
            // 
            this.usuariosBindingSource1.DataMember = "usuarios";
            this.usuariosBindingSource1.DataSource = this.nombreusuarioBindingSource;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Comentarios";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(437, 420);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 34);
            this.textBox1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Concepto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Horas";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(437, 359);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(434, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ID";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(437, 129);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 14;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.serviciosBindingSource;
            this.comboBox3.DisplayMember = "titulo";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(437, 308);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 15;
            // 
            // concepto_servicios
            // 
            this.concepto_servicios.DataSetName = "concepto_servicios";
            this.concepto_servicios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // serviciosBindingSource
            // 
            this.serviciosBindingSource.DataMember = "servicios";
            this.serviciosBindingSource.DataSource = this.concepto_servicios;
            // 
            // serviciosTableAdapter
            // 
            this.serviciosTableAdapter.ClearBeforeFill = true;
            // 
            // TransferirTiempo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "TransferirTiempo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia de tiempo";
            this.Load += new System.EventHandler(this.TransferirTiempo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombreusuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nombre_usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.concepto_servicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource nombreusuarioBindingSource;
        private nombre_usuario nombre_usuario;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private nombre_usuarioTableAdapters.usuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.BindingSource usuariosBindingSource1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private concepto_servicios concepto_servicios;
        private System.Windows.Forms.BindingSource serviciosBindingSource;
        private concepto_serviciosTableAdapters.serviciosTableAdapter serviciosTableAdapter;
    }
}