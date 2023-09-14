namespace TallerReparacion.Formularios
{
    partial class frm_almacen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_almacen));
            this.dgv_articulos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_movimientos_ar = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.img_pequeña = new System.Windows.Forms.ImageList(this.components);
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.img_busqueda = new System.Windows.Forms.ImageList(this.components);
            this.btn_limpiar = new System.Windows.Forms.PictureBox();
            this.btn_salida_mv = new System.Windows.Forms.Button();
            this.btn_entrada_mv = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_alta = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.img_grande = new System.Windows.Forms.ImageList(this.components);
            this.btn_modificar_mv = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_estado = new System.Windows.Forms.ComboBox();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.lbl_seleccionar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_articulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_movimientos_ar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_limpiar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_articulos
            // 
            this.dgv_articulos.AllowUserToAddRows = false;
            this.dgv_articulos.AllowUserToDeleteRows = false;
            this.dgv_articulos.AllowUserToOrderColumns = true;
            this.dgv_articulos.AllowUserToResizeColumns = false;
            this.dgv_articulos.AllowUserToResizeRows = false;
            this.dgv_articulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_articulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_articulos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_articulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_articulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_articulos.Location = new System.Drawing.Point(15, 42);
            this.dgv_articulos.Margin = new System.Windows.Forms.Padding(6);
            this.dgv_articulos.MaximumSize = new System.Drawing.Size(1103, 243);
            this.dgv_articulos.MultiSelect = false;
            this.dgv_articulos.Name = "dgv_articulos";
            this.dgv_articulos.ReadOnly = true;
            this.dgv_articulos.RowHeadersVisible = false;
            this.dgv_articulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_articulos.Size = new System.Drawing.Size(1103, 241);
            this.dgv_articulos.StandardTab = true;
            this.dgv_articulos.TabIndex = 1;
            this.dgv_articulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_articulos_CellDoubleClick);
            this.dgv_articulos.SelectionChanged += new System.EventHandler(this.Dgv_articulos_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Articulos";
            // 
            // dgv_movimientos_ar
            // 
            this.dgv_movimientos_ar.AllowUserToAddRows = false;
            this.dgv_movimientos_ar.AllowUserToDeleteRows = false;
            this.dgv_movimientos_ar.AllowUserToOrderColumns = true;
            this.dgv_movimientos_ar.AllowUserToResizeColumns = false;
            this.dgv_movimientos_ar.AllowUserToResizeRows = false;
            this.dgv_movimientos_ar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_movimientos_ar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_movimientos_ar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_movimientos_ar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_movimientos_ar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_movimientos_ar.Location = new System.Drawing.Point(18, 327);
            this.dgv_movimientos_ar.Margin = new System.Windows.Forms.Padding(6);
            this.dgv_movimientos_ar.MultiSelect = false;
            this.dgv_movimientos_ar.Name = "dgv_movimientos_ar";
            this.dgv_movimientos_ar.ReadOnly = true;
            this.dgv_movimientos_ar.RowHeadersVisible = false;
            this.dgv_movimientos_ar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_movimientos_ar.Size = new System.Drawing.Size(678, 170);
            this.dgv_movimientos_ar.StandardTab = true;
            this.dgv_movimientos_ar.TabIndex = 22;
            this.dgv_movimientos_ar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_movimientos_ar_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 301);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Movimientos";
            // 
            // img_pequeña
            // 
            this.img_pequeña.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_pequeña.ImageStream")));
            this.img_pequeña.TransparentColor = System.Drawing.Color.Transparent;
            this.img_pequeña.Images.SetKeyName(0, "insertar_1.png");
            this.img_pequeña.Images.SetKeyName(1, "cancelar_1.png");
            this.img_pequeña.Images.SetKeyName(2, "editar_1.png");
            this.img_pequeña.Images.SetKeyName(3, "eliminar_1.png");
            this.img_pequeña.Images.SetKeyName(4, "validar_1.png");
            // 
            // txt_buscar
            // 
            this.txt_buscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_buscar.Location = new System.Drawing.Point(711, 327);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(407, 27);
            this.txt_buscar.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(707, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "Filtro articulo";
            // 
            // img_busqueda
            // 
            this.img_busqueda.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_busqueda.ImageStream")));
            this.img_busqueda.TransparentColor = System.Drawing.Color.Transparent;
            this.img_busqueda.Images.SetKeyName(0, "cancelar_1.png");
            this.img_busqueda.Images.SetKeyName(1, "buscar_1.png");
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.White;
            this.btn_limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_limpiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_limpiar.Image")));
            this.btn_limpiar.InitialImage = ((System.Drawing.Image)(resources.GetObject("btn_limpiar.InitialImage")));
            this.btn_limpiar.Location = new System.Drawing.Point(1092, 330);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(20, 20);
            this.btn_limpiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_limpiar.TabIndex = 33;
            this.btn_limpiar.TabStop = false;
            this.btn_limpiar.Click += new System.EventHandler(this.Btn_limpiar_Click);
            // 
            // btn_salida_mv
            // 
            this.btn_salida_mv.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_salida_mv.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salida_mv.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_salida_mv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_salida_mv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salida_mv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salida_mv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salida_mv.ImageIndex = 3;
            this.btn_salida_mv.ImageList = this.img_pequeña;
            this.btn_salida_mv.Location = new System.Drawing.Point(496, 292);
            this.btn_salida_mv.Name = "btn_salida_mv";
            this.btn_salida_mv.Size = new System.Drawing.Size(87, 30);
            this.btn_salida_mv.TabIndex = 9;
            this.btn_salida_mv.Text = "Salida";
            this.btn_salida_mv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salida_mv.UseVisualStyleBackColor = false;
            this.btn_salida_mv.Click += new System.EventHandler(this.Btn_salida_mv_Click);
            // 
            // btn_entrada_mv
            // 
            this.btn_entrada_mv.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_entrada_mv.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_entrada_mv.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_entrada_mv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_entrada_mv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_entrada_mv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_entrada_mv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_entrada_mv.ImageIndex = 0;
            this.btn_entrada_mv.ImageList = this.img_pequeña;
            this.btn_entrada_mv.Location = new System.Drawing.Point(396, 292);
            this.btn_entrada_mv.Name = "btn_entrada_mv";
            this.btn_entrada_mv.Size = new System.Drawing.Size(97, 30);
            this.btn_entrada_mv.TabIndex = 8;
            this.btn_entrada_mv.Text = "Entrada";
            this.btn_entrada_mv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_entrada_mv.UseVisualStyleBackColor = false;
            this.btn_entrada_mv.Click += new System.EventHandler(this.Btn_entrada_mv_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_modificar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_modificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar.ImageIndex = 2;
            this.btn_modificar.ImageList = this.img_pequeña;
            this.btn_modificar.Location = new System.Drawing.Point(913, 3);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(110, 35);
            this.btn_modificar.TabIndex = 5;
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
            this.btn_alta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_alta.ImageIndex = 0;
            this.btn_alta.ImageList = this.img_pequeña;
            this.btn_alta.Location = new System.Drawing.Point(1029, 3);
            this.btn_alta.Name = "btn_alta";
            this.btn_alta.Size = new System.Drawing.Size(89, 35);
            this.btn_alta.TabIndex = 4;
            this.btn_alta.Text = "Alta";
            this.btn_alta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_alta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_alta.UseVisualStyleBackColor = false;
            this.btn_alta.Click += new System.EventHandler(this.Btn_alta_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_salir.ImageIndex = 0;
            this.btn_salir.ImageList = this.img_grande;
            this.btn_salir.Location = new System.Drawing.Point(1028, 408);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(90, 88);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // img_grande
            // 
            this.img_grande.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_grande.ImageStream")));
            this.img_grande.TransparentColor = System.Drawing.Color.Transparent;
            this.img_grande.Images.SetKeyName(0, "salida_1.png");
            // 
            // btn_modificar_mv
            // 
            this.btn_modificar_mv.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_modificar_mv.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_modificar_mv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_modificar_mv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar_mv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar_mv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar_mv.ImageIndex = 2;
            this.btn_modificar_mv.ImageList = this.img_pequeña;
            this.btn_modificar_mv.Location = new System.Drawing.Point(586, 292);
            this.btn_modificar_mv.Name = "btn_modificar_mv";
            this.btn_modificar_mv.Size = new System.Drawing.Size(110, 30);
            this.btn_modificar_mv.TabIndex = 10;
            this.btn_modificar_mv.Text = "Modificar";
            this.btn_modificar_mv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar_mv.UseVisualStyleBackColor = false;
            this.btn_modificar_mv.Click += new System.EventHandler(this.Btn_modificar_mv_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(707, 367);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "Estado articulos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_estado
            // 
            this.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estado.FormattingEnabled = true;
            this.cmb_estado.Items.AddRange(new object[] {
            "Activos",
            "Inactivos",
            "Todos"});
            this.cmb_estado.Location = new System.Drawing.Point(711, 389);
            this.cmb_estado.Name = "cmb_estado";
            this.cmb_estado.Size = new System.Drawing.Size(131, 27);
            this.cmb_estado.TabIndex = 39;
            this.cmb_estado.SelectedIndexChanged += new System.EventHandler(this.Cmb_estado_SelectedIndexChanged);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_seleccionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_seleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seleccionar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_seleccionar.ImageIndex = 4;
            this.btn_seleccionar.ImageList = this.img_pequeña;
            this.btn_seleccionar.Location = new System.Drawing.Point(782, 3);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(125, 35);
            this.btn_seleccionar.TabIndex = 40;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_seleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_seleccionar.UseVisualStyleBackColor = false;
            this.btn_seleccionar.Visible = false;
            this.btn_seleccionar.Click += new System.EventHandler(this.Btn_seleccionar_Click);
            // 
            // lbl_seleccionar
            // 
            this.lbl_seleccionar.AutoSize = true;
            this.lbl_seleccionar.Location = new System.Drawing.Point(103, 15);
            this.lbl_seleccionar.Name = "lbl_seleccionar";
            this.lbl_seleccionar.Size = new System.Drawing.Size(192, 19);
            this.lbl_seleccionar.TabIndex = 41;
            this.lbl_seleccionar.Text = "(doble clic para seleccionar)";
            this.lbl_seleccionar.Visible = false;
            // 
            // frm_almacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_salir;
            this.ClientSize = new System.Drawing.Size(1142, 510);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_seleccionar);
            this.Controls.Add(this.cmb_estado);
            this.Controls.Add(this.btn_modificar_mv);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.btn_salida_mv);
            this.Controls.Add(this.btn_entrada_mv);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_alta);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_movimientos_ar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_articulos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_seleccionar);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frm_almacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion articulos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_articulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_movimientos_ar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_limpiar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_articulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_movimientos_ar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.ImageList img_pequeña;
        private System.Windows.Forms.Button btn_alta;
        private System.Windows.Forms.Button btn_entrada_mv;
        private System.Windows.Forms.Button btn_salida_mv;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList img_busqueda;
        private System.Windows.Forms.PictureBox btn_limpiar;
        private System.Windows.Forms.Button btn_modificar_mv;
        private System.Windows.Forms.ImageList img_grande;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_estado;
        public System.Windows.Forms.Button btn_seleccionar;
        public System.Windows.Forms.Button btn_salir;
        public System.Windows.Forms.Label lbl_seleccionar;
    }
}