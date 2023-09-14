namespace TallerReparacion
{
    partial class frm_clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_clientes));
            this.dgv_clientes = new System.Windows.Forms.DataGridView();
            this.imagenClientes = new System.Windows.Forms.ImageList(this.components);
            this.gb_datosCliente = new System.Windows.Forms.GroupBox();
            this.rb_inactivo = new System.Windows.Forms.RadioButton();
            this.rb_activo = new System.Windows.Forms.RadioButton();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_idcliente = new System.Windows.Forms.TextBox();
            this.txt_provincia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_poblacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cpostal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.cb_filtro = new System.Windows.Forms.ComboBox();
            this.lb_filtro = new System.Windows.Forms.Label();
            this.btn_validar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_alta = new System.Windows.Forms.Button();
            this.btn_salir_cl = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_filtroNombre = new System.Windows.Forms.TextBox();
            this.txt_filtroMovil = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).BeginInit();
            this.gb_datosCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_clientes
            // 
            this.dgv_clientes.AllowUserToAddRows = false;
            this.dgv_clientes.AllowUserToDeleteRows = false;
            this.dgv_clientes.AllowUserToOrderColumns = true;
            this.dgv_clientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_clientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clientes.Location = new System.Drawing.Point(16, 13);
            this.dgv_clientes.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_clientes.MinimumSize = new System.Drawing.Size(900, 250);
            this.dgv_clientes.MultiSelect = false;
            this.dgv_clientes.Name = "dgv_clientes";
            this.dgv_clientes.ReadOnly = true;
            this.dgv_clientes.RowHeadersVisible = false;
            this.dgv_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_clientes.Size = new System.Drawing.Size(1035, 300);
            this.dgv_clientes.TabIndex = 0;
            this.dgv_clientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_clientes_CellClick);
            this.dgv_clientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_clientes_CellDoubleClick);
            this.dgv_clientes.SelectionChanged += new System.EventHandler(this.Dgv_clientes_SelectionChanged);
            // 
            // imagenClientes
            // 
            this.imagenClientes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenClientes.ImageStream")));
            this.imagenClientes.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenClientes.Images.SetKeyName(0, "insertar_1.png");
            this.imagenClientes.Images.SetKeyName(1, "salida_1.png");
            this.imagenClientes.Images.SetKeyName(2, "editar_1.png");
            this.imagenClientes.Images.SetKeyName(3, "validar_1.png");
            this.imagenClientes.Images.SetKeyName(4, "eliminar_1.png");
            this.imagenClientes.Images.SetKeyName(5, "cancelar_1.png");
            // 
            // gb_datosCliente
            // 
            this.gb_datosCliente.BackColor = System.Drawing.Color.Transparent;
            this.gb_datosCliente.Controls.Add(this.rb_inactivo);
            this.gb_datosCliente.Controls.Add(this.rb_activo);
            this.gb_datosCliente.Controls.Add(this.txt_telefono);
            this.gb_datosCliente.Controls.Add(this.label8);
            this.gb_datosCliente.Controls.Add(this.txt_idcliente);
            this.gb_datosCliente.Controls.Add(this.txt_provincia);
            this.gb_datosCliente.Controls.Add(this.label7);
            this.gb_datosCliente.Controls.Add(this.txt_poblacion);
            this.gb_datosCliente.Controls.Add(this.label6);
            this.gb_datosCliente.Controls.Add(this.label5);
            this.gb_datosCliente.Controls.Add(this.txt_cpostal);
            this.gb_datosCliente.Controls.Add(this.label4);
            this.gb_datosCliente.Controls.Add(this.txt_direccion);
            this.gb_datosCliente.Controls.Add(this.txt_email);
            this.gb_datosCliente.Controls.Add(this.label3);
            this.gb_datosCliente.Controls.Add(this.label2);
            this.gb_datosCliente.Controls.Add(this.label1);
            this.gb_datosCliente.Controls.Add(this.txt_nombre);
            this.gb_datosCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_datosCliente.Location = new System.Drawing.Point(16, 391);
            this.gb_datosCliente.Name = "gb_datosCliente";
            this.gb_datosCliente.Size = new System.Drawing.Size(1035, 178);
            this.gb_datosCliente.TabIndex = 21;
            this.gb_datosCliente.TabStop = false;
            // 
            // rb_inactivo
            // 
            this.rb_inactivo.AutoSize = true;
            this.rb_inactivo.Location = new System.Drawing.Point(948, 26);
            this.rb_inactivo.Name = "rb_inactivo";
            this.rb_inactivo.Size = new System.Drawing.Size(78, 23);
            this.rb_inactivo.TabIndex = 36;
            this.rb_inactivo.Text = "Inactivo";
            this.rb_inactivo.UseVisualStyleBackColor = true;
            // 
            // rb_activo
            // 
            this.rb_activo.AutoSize = true;
            this.rb_activo.Location = new System.Drawing.Point(875, 26);
            this.rb_activo.Name = "rb_activo";
            this.rb_activo.Size = new System.Drawing.Size(67, 23);
            this.rb_activo.TabIndex = 35;
            this.rb_activo.Text = "Activo";
            this.rb_activo.UseVisualStyleBackColor = true;
            // 
            // txt_telefono
            // 
            this.txt_telefono.AcceptsTab = true;
            this.txt_telefono.Location = new System.Drawing.Point(536, 70);
            this.txt_telefono.MaxLength = 20;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(199, 27);
            this.txt_telefono.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(532, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 30;
            this.label8.Text = "Telefono";
            // 
            // txt_idcliente
            // 
            this.txt_idcliente.Enabled = false;
            this.txt_idcliente.Location = new System.Drawing.Point(587, 15);
            this.txt_idcliente.Name = "txt_idcliente";
            this.txt_idcliente.ReadOnly = true;
            this.txt_idcliente.Size = new System.Drawing.Size(100, 27);
            this.txt_idcliente.TabIndex = 34;
            this.txt_idcliente.Visible = false;
            // 
            // txt_provincia
            // 
            this.txt_provincia.AcceptsTab = true;
            this.txt_provincia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_provincia.Enabled = false;
            this.txt_provincia.Location = new System.Drawing.Point(836, 135);
            this.txt_provincia.Name = "txt_provincia";
            this.txt_provincia.ReadOnly = true;
            this.txt_provincia.Size = new System.Drawing.Size(190, 27);
            this.txt_provincia.TabIndex = 0;
            this.txt_provincia.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(832, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "Provincia";
            // 
            // txt_poblacion
            // 
            this.txt_poblacion.AcceptsTab = true;
            this.txt_poblacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_poblacion.Location = new System.Drawing.Point(631, 135);
            this.txt_poblacion.MaxLength = 50;
            this.txt_poblacion.Name = "txt_poblacion";
            this.txt_poblacion.Size = new System.Drawing.Size(197, 27);
            this.txt_poblacion.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(627, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "Poblacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(526, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "Codigo postal";
            // 
            // txt_cpostal
            // 
            this.txt_cpostal.AcceptsTab = true;
            this.txt_cpostal.Location = new System.Drawing.Point(530, 135);
            this.txt_cpostal.Margin = new System.Windows.Forms.Padding(4);
            this.txt_cpostal.MaxLength = 5;
            this.txt_cpostal.Name = "txt_cpostal";
            this.txt_cpostal.Size = new System.Drawing.Size(94, 27);
            this.txt_cpostal.TabIndex = 5;
            this.txt_cpostal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_cpostal.Leave += new System.EventHandler(this.Txt_cpostal_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Direccion";
            // 
            // txt_direccion
            // 
            this.txt_direccion.AcceptsTab = true;
            this.txt_direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_direccion.Location = new System.Drawing.Point(11, 135);
            this.txt_direccion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_direccion.MaxLength = 100;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(511, 27);
            this.txt_direccion.TabIndex = 4;
            // 
            // txt_email
            // 
            this.txt_email.AcceptsTab = true;
            this.txt_email.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_email.Location = new System.Drawing.Point(741, 70);
            this.txt_email.MaxLength = 50;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(285, 27);
            this.txt_email.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Datos cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(737, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.AcceptsTab = true;
            this.txt_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nombre.Location = new System.Drawing.Point(11, 70);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombre.MaxLength = 50;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(518, 27);
            this.txt_nombre.TabIndex = 1;
            // 
            // cb_filtro
            // 
            this.cb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_filtro.FormattingEnabled = true;
            this.cb_filtro.Items.AddRange(new object[] {
            "Activos",
            "Inactivos",
            "Todos"});
            this.cb_filtro.Location = new System.Drawing.Point(444, 358);
            this.cb_filtro.Name = "cb_filtro";
            this.cb_filtro.Size = new System.Drawing.Size(101, 27);
            this.cb_filtro.TabIndex = 24;
            this.cb_filtro.SelectedValueChanged += new System.EventHandler(this.Cb_filtro_SelectedValueChanged);
            // 
            // lb_filtro
            // 
            this.lb_filtro.AutoSize = true;
            this.lb_filtro.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_filtro.Location = new System.Drawing.Point(327, 361);
            this.lb_filtro.Name = "lb_filtro";
            this.lb_filtro.Size = new System.Drawing.Size(108, 19);
            this.lb_filtro.TabIndex = 25;
            this.lb_filtro.Text = "Estado clientes";
            // 
            // btn_validar
            // 
            this.btn_validar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_validar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_validar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_validar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_validar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validar.ForeColor = System.Drawing.Color.Black;
            this.btn_validar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_validar.ImageIndex = 3;
            this.btn_validar.ImageList = this.imagenClientes;
            this.btn_validar.Location = new System.Drawing.Point(546, 325);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(95, 40);
            this.btn_validar.TabIndex = 22;
            this.btn_validar.Text = "Validar";
            this.btn_validar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_validar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_validar.UseVisualStyleBackColor = false;
            this.btn_validar.Visible = false;
            this.btn_validar.Click += new System.EventHandler(this.Btn_validar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_modificar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_modificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar.ForeColor = System.Drawing.Color.Black;
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar.ImageIndex = 2;
            this.btn_modificar.ImageList = this.imagenClientes;
            this.btn_modificar.Location = new System.Drawing.Point(852, 325);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(113, 40);
            this.btn_modificar.TabIndex = 20;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_modificar.UseVisualStyleBackColor = false;
            this.btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // btn_alta
            // 
            this.btn_alta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_alta.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_alta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_alta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alta.ForeColor = System.Drawing.Color.Black;
            this.btn_alta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_alta.ImageIndex = 0;
            this.btn_alta.ImageList = this.imagenClientes;
            this.btn_alta.Location = new System.Drawing.Point(751, 325);
            this.btn_alta.Name = "btn_alta";
            this.btn_alta.Size = new System.Drawing.Size(95, 40);
            this.btn_alta.TabIndex = 19;
            this.btn_alta.Text = "Alta";
            this.btn_alta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_alta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_alta.UseVisualStyleBackColor = false;
            this.btn_alta.Click += new System.EventHandler(this.Btn_alta_Click);
            // 
            // btn_salir_cl
            // 
            this.btn_salir_cl.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_salir_cl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir_cl.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_salir_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_salir_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir_cl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir_cl.ForeColor = System.Drawing.Color.Black;
            this.btn_salir_cl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir_cl.ImageIndex = 1;
            this.btn_salir_cl.ImageList = this.imagenClientes;
            this.btn_salir_cl.Location = new System.Drawing.Point(971, 325);
            this.btn_salir_cl.Name = "btn_salir_cl";
            this.btn_salir_cl.Size = new System.Drawing.Size(80, 40);
            this.btn_salir_cl.TabIndex = 18;
            this.btn_salir_cl.Text = "Salir";
            this.btn_salir_cl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir_cl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_salir_cl.UseVisualStyleBackColor = false;
            this.btn_salir_cl.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.Color.Black;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.ImageIndex = 5;
            this.btn_cancelar.ImageList = this.imagenClientes;
            this.btn_cancelar.Location = new System.Drawing.Point(647, 325);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(104, 40);
            this.btn_cancelar.TabIndex = 23;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Visible = false;
            this.btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 36;
            this.label10.Text = "Filtro nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 19);
            this.label9.TabIndex = 37;
            this.label9.Text = "Filtro telefono";
            // 
            // txt_filtroNombre
            // 
            this.txt_filtroNombre.Location = new System.Drawing.Point(122, 325);
            this.txt_filtroNombre.Name = "txt_filtroNombre";
            this.txt_filtroNombre.Size = new System.Drawing.Size(423, 27);
            this.txt_filtroNombre.TabIndex = 38;
            // 
            // txt_filtroMovil
            // 
            this.txt_filtroMovil.Location = new System.Drawing.Point(122, 358);
            this.txt_filtroMovil.Name = "txt_filtroMovil";
            this.txt_filtroMovil.Size = new System.Drawing.Size(137, 27);
            this.txt_filtroMovil.TabIndex = 39;
            // 
            // frm_clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 576);
            this.Controls.Add(this.dgv_clientes);
            this.Controls.Add(this.txt_filtroMovil);
            this.Controls.Add(this.txt_filtroNombre);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_filtro);
            this.Controls.Add(this.cb_filtro);
            this.Controls.Add(this.btn_validar);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_alta);
            this.Controls.Add(this.btn_salir_cl);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.gb_datosCliente);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frm_clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_clientes_FormClosing);
            this.Load += new System.EventHandler(this.Frm_clientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_clientes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).EndInit();
            this.gb_datosCliente.ResumeLayout(false);
            this.gb_datosCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_clientes;
        private System.Windows.Forms.Button btn_salir_cl;
        private System.Windows.Forms.ImageList imagenClientes;
        private System.Windows.Forms.Button btn_alta;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.GroupBox gb_datosCliente;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_provincia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_poblacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cpostal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button btn_validar;
        private System.Windows.Forms.TextBox txt_idcliente;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.ComboBox cb_filtro;
        private System.Windows.Forms.Label lb_filtro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_filtroNombre;
        private System.Windows.Forms.TextBox txt_filtroMovil;
        private System.Windows.Forms.RadioButton rb_inactivo;
        private System.Windows.Forms.RadioButton rb_activo;
    }
}