namespace RentCar.Formularios
{
    partial class FrmInspeccion
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbVehiculo = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inspeccionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rentCarDBDataSet5 = new RentCar.RentCarDBDataSet5();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.inspeccionTableAdapter = new RentCar.RentCarDBDataSet5TableAdapters.InspeccionTableAdapter();
            this.cbRalladuraSi = new System.Windows.Forms.CheckBox();
            this.cbGomaResSi = new System.Windows.Forms.CheckBox();
            this.cbGatoSi = new System.Windows.Forms.CheckBox();
            this.cbRoturaCristalSi = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbCantidadCombus = new System.Windows.Forms.ComboBox();
            this.cbSupIzq = new System.Windows.Forms.CheckBox();
            this.cbInfIzq = new System.Windows.Forms.CheckBox();
            this.cbSupDer = new System.Windows.Forms.CheckBox();
            this.cbInfDer = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rentCarDBDataSet5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inspeccionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rentCarDBDataSet5BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rentCarDBDataSet6 = new RentCar.RentCarDBDataSet6();
            this.inspeccionBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.inspeccionTableAdapter1 = new RentCar.RentCarDBDataSet6TableAdapters.InspeccionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet5)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet5BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inspección";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vehiculo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(200, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(398, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Empleado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ralladuras:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(200, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cantidad Combustible:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Goma Respuesta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(200, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Rotura Cristal:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Gato:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(405, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Estado Gomas:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(294, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Fecha:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(134, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "Estado:";
            // 
            // cmbVehiculo
            // 
            this.cmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehiculo.FormattingEnabled = true;
            this.cmbVehiculo.Location = new System.Drawing.Point(79, 49);
            this.cmbVehiculo.Name = "cmbVehiculo";
            this.cmbVehiculo.Size = new System.Drawing.Size(87, 21);
            this.cmbVehiculo.TabIndex = 12;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(266, 49);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(87, 21);
            this.cmbCliente.TabIndex = 13;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(465, 49);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(87, 21);
            this.cmbEmpleado.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 3);
            this.panel1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 216);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(573, 233);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // inspeccionBindingSource
            // 
            this.inspeccionBindingSource.DataMember = "Inspeccion";
            this.inspeccionBindingSource.DataSource = this.rentCarDBDataSet5;
            // 
            // rentCarDBDataSet5
            // 
            this.rentCarDBDataSet5.DataSetName = "RentCarDBDataSet5";
            this.rentCarDBDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(16, 187);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(112, 187);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(211, 187);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(307, 187);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(147, 455);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 21;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(16, 455);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(125, 20);
            this.txtFiltrar.TabIndex = 22;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(343, 146);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 23;
            // 
            // inspeccionTableAdapter
            // 
            this.inspeccionTableAdapter.ClearBeforeFill = true;
            // 
            // cbRalladuraSi
            // 
            this.cbRalladuraSi.AutoSize = true;
            this.cbRalladuraSi.Location = new System.Drawing.Point(86, 80);
            this.cbRalladuraSi.Name = "cbRalladuraSi";
            this.cbRalladuraSi.Size = new System.Drawing.Size(15, 14);
            this.cbRalladuraSi.TabIndex = 24;
            this.cbRalladuraSi.UseVisualStyleBackColor = true;
            // 
            // cbGomaResSi
            // 
            this.cbGomaResSi.AutoSize = true;
            this.cbGomaResSi.Location = new System.Drawing.Point(120, 114);
            this.cbGomaResSi.Name = "cbGomaResSi";
            this.cbGomaResSi.Size = new System.Drawing.Size(15, 14);
            this.cbGomaResSi.TabIndex = 26;
            this.cbGomaResSi.UseVisualStyleBackColor = true;
            // 
            // cbGatoSi
            // 
            this.cbGatoSi.AutoSize = true;
            this.cbGatoSi.Location = new System.Drawing.Point(52, 148);
            this.cbGatoSi.Name = "cbGatoSi";
            this.cbGatoSi.Size = new System.Drawing.Size(15, 14);
            this.cbGatoSi.TabIndex = 28;
            this.cbGatoSi.UseVisualStyleBackColor = true;
            // 
            // cbRoturaCristalSi
            // 
            this.cbRoturaCristalSi.AutoSize = true;
            this.cbRoturaCristalSi.Location = new System.Drawing.Point(297, 79);
            this.cbRoturaCristalSi.Name = "cbRoturaCristalSi";
            this.cbRoturaCristalSi.Size = new System.Drawing.Size(15, 14);
            this.cbRoturaCristalSi.TabIndex = 30;
            this.cbRoturaCristalSi.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "A",
            "I"});
            this.cmbEstado.Location = new System.Drawing.Point(186, 145);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(91, 21);
            this.cmbEstado.TabIndex = 32;
            // 
            // cmbCantidadCombus
            // 
            this.cmbCantidadCombus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCantidadCombus.FormattingEnabled = true;
            this.cmbCantidadCombus.Items.AddRange(new object[] {
            "1/4",
            "1/2",
            "3/4",
            "Full",
            ""});
            this.cmbCantidadCombus.Location = new System.Drawing.Point(337, 113);
            this.cmbCantidadCombus.Name = "cmbCantidadCombus";
            this.cmbCantidadCombus.Size = new System.Drawing.Size(83, 21);
            this.cmbCantidadCombus.TabIndex = 33;
            // 
            // cbSupIzq
            // 
            this.cbSupIzq.AutoSize = true;
            this.cbSupIzq.Location = new System.Drawing.Point(0, 13);
            this.cbSupIzq.Name = "cbSupIzq";
            this.cbSupIzq.Size = new System.Drawing.Size(59, 17);
            this.cbSupIzq.TabIndex = 34;
            this.cbSupIzq.Text = "SupIzq";
            this.cbSupIzq.UseVisualStyleBackColor = true;
            // 
            // cbInfIzq
            // 
            this.cbInfIzq.AutoSize = true;
            this.cbInfIzq.Location = new System.Drawing.Point(0, 36);
            this.cbInfIzq.Name = "cbInfIzq";
            this.cbInfIzq.Size = new System.Drawing.Size(52, 17);
            this.cbInfIzq.TabIndex = 35;
            this.cbInfIzq.Text = "InfIzq";
            this.cbInfIzq.UseVisualStyleBackColor = true;
            // 
            // cbSupDer
            // 
            this.cbSupDer.AutoSize = true;
            this.cbSupDer.Location = new System.Drawing.Point(59, 13);
            this.cbSupDer.Name = "cbSupDer";
            this.cbSupDer.Size = new System.Drawing.Size(62, 17);
            this.cbSupDer.TabIndex = 36;
            this.cbSupDer.Text = "SupDer";
            this.cbSupDer.UseVisualStyleBackColor = true;
            // 
            // cbInfDer
            // 
            this.cbInfDer.AutoSize = true;
            this.cbInfDer.Location = new System.Drawing.Point(55, 36);
            this.cbInfDer.Name = "cbInfDer";
            this.cbInfDer.Size = new System.Drawing.Size(55, 17);
            this.cbInfDer.TabIndex = 37;
            this.cbInfDer.Text = "InfDer";
            this.cbInfDer.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.cbSupIzq);
            this.panel2.Controls.Add(this.cbInfDer);
            this.panel2.Controls.Add(this.cbInfIzq);
            this.panel2.Controls.Add(this.cbSupDer);
            this.panel2.Location = new System.Drawing.Point(497, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(122, 61);
            this.panel2.TabIndex = 38;
            // 
            // rentCarDBDataSet5BindingSource
            // 
            this.rentCarDBDataSet5BindingSource.DataSource = this.rentCarDBDataSet5;
            this.rentCarDBDataSet5BindingSource.Position = 0;
            // 
            // inspeccionBindingSource1
            // 
            this.inspeccionBindingSource1.DataMember = "Inspeccion";
            this.inspeccionBindingSource1.DataSource = this.rentCarDBDataSet5BindingSource;
            // 
            // rentCarDBDataSet5BindingSource1
            // 
            this.rentCarDBDataSet5BindingSource1.DataSource = this.rentCarDBDataSet5;
            this.rentCarDBDataSet5BindingSource1.Position = 0;
            // 
            // rentCarDBDataSet6
            // 
            this.rentCarDBDataSet6.DataSetName = "RentCarDBDataSet6";
            this.rentCarDBDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inspeccionBindingSource2
            // 
            this.inspeccionBindingSource2.DataMember = "Inspeccion";
            this.inspeccionBindingSource2.DataSource = this.rentCarDBDataSet6;
            // 
            // inspeccionTableAdapter1
            // 
            this.inspeccionTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 487);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmbCantidadCombus);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cbRoturaCristalSi);
            this.Controls.Add(this.cbGatoSi);
            this.Controls.Add(this.cbGomaResSi);
            this.Controls.Add(this.cbRalladuraSi);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.cmbVehiculo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInspeccion";
            this.Text = "FrmInspeccion";
            this.Load += new System.EventHandler(this.FrmInspeccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet5BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentCarDBDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbVehiculo;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private RentCarDBDataSet5 rentCarDBDataSet5;
        private System.Windows.Forms.BindingSource inspeccionBindingSource;
        private RentCarDBDataSet5TableAdapters.InspeccionTableAdapter inspeccionTableAdapter;
        private System.Windows.Forms.CheckBox cbRalladuraSi;
        private System.Windows.Forms.CheckBox cbGomaResSi;
        private System.Windows.Forms.CheckBox cbGatoSi;
        private System.Windows.Forms.CheckBox cbRoturaCristalSi;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbCantidadCombus;
        private System.Windows.Forms.CheckBox cbSupIzq;
        private System.Windows.Forms.CheckBox cbInfIzq;
        private System.Windows.Forms.CheckBox cbSupDer;
        private System.Windows.Forms.CheckBox cbInfDer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource inspeccionBindingSource1;
        private System.Windows.Forms.BindingSource rentCarDBDataSet5BindingSource;
        private System.Windows.Forms.BindingSource rentCarDBDataSet5BindingSource1;
        private RentCarDBDataSet6 rentCarDBDataSet6;
        private System.Windows.Forms.BindingSource inspeccionBindingSource2;
        private RentCarDBDataSet6TableAdapters.InspeccionTableAdapter inspeccionTableAdapter1;
    }
}