namespace TallerReparacion.Formularios
{
    partial class frm_seleccionClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_seleccionClientes));
            this.dgv_seleccionClientes = new System.Windows.Forms.DataGridView();
            this.botonesGrandes = new System.Windows.Forms.ImageList(this.components);
            this.btn_seleccion = new System.Windows.Forms.Button();
            this.botonesPequeño = new System.Windows.Forms.ImageList(this.components);
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_alta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_filtroMovil = new System.Windows.Forms.TextBox();
            this.txt_filtroNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seleccionClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_seleccionClientes
            // 
            this.dgv_seleccionClientes.AllowUserToAddRows = false;
            this.dgv_seleccionClientes.AllowUserToDeleteRows = false;
            this.dgv_seleccionClientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_seleccionClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_seleccionClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_seleccionClientes.Location = new System.Drawing.Point(16, 50);
            this.dgv_seleccionClientes.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_seleccionClientes.MultiSelect = false;
            this.dgv_seleccionClientes.Name = "dgv_seleccionClientes";
            this.dgv_seleccionClientes.ReadOnly = true;
            this.dgv_seleccionClientes.RowHeadersVisible = false;
            this.dgv_seleccionClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_seleccionClientes.Size = new System.Drawing.Size(1125, 218);
            this.dgv_seleccionClientes.TabIndex = 0;
            this.dgv_seleccionClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_seleccionClientes_CellDoubleClick);
            this.dgv_seleccionClientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_seleccionClientes_KeyDown);
            // 
            // botonesGrandes
            // 
            this.botonesGrandes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("botonesGrandes.ImageStream")));
            this.botonesGrandes.TransparentColor = System.Drawing.Color.Transparent;
            this.botonesGrandes.Images.SetKeyName(0, "cancelar_1.png");
            this.botonesGrandes.Images.SetKeyName(1, "validar_1.png");
            // 
            // btn_seleccion
            // 
            this.btn_seleccion.BackColor = System.Drawing.Color.Transparent;
            this.btn_seleccion.FlatAppearance.BorderSize = 0;
            this.btn_seleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seleccion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_seleccion.ImageIndex = 3;
            this.btn_seleccion.ImageList = this.botonesPequeño;
            this.btn_seleccion.Location = new System.Drawing.Point(16, 275);
            this.btn_seleccion.Name = "btn_seleccion";
            this.btn_seleccion.Size = new System.Drawing.Size(137, 36);
            this.btn_seleccion.TabIndex = 24;
            this.btn_seleccion.Text = "Seleccionar";
            this.btn_seleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_seleccion.UseVisualStyleBackColor = false;
            this.btn_seleccion.Click += new System.EventHandler(this.btn_seleccion_Click_1);
            // 
            // botonesPequeño
            // 
            this.botonesPequeño.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("botonesPequeño.ImageStream")));
            this.botonesPequeño.TransparentColor = System.Drawing.Color.Transparent;
            this.botonesPequeño.Images.SetKeyName(0, "insertar_1.png");
            this.botonesPequeño.Images.SetKeyName(1, "editar_1.png");
            this.botonesPequeño.Images.SetKeyName(2, "cancelar_1.png");
            this.botonesPequeño.Images.SetKeyName(3, "validar_1.png");
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.FlatAppearance.BorderSize = 0;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.ImageIndex = 2;
            this.btn_cancelar.ImageList = this.botonesPequeño;
            this.btn_cancelar.Location = new System.Drawing.Point(159, 275);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(115, 36);
            this.btn_cancelar.TabIndex = 25;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.BackColor = System.Drawing.Color.Transparent;
            this.btn_modificar.FlatAppearance.BorderSize = 0;
            this.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modificar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modificar.ImageIndex = 1;
            this.btn_modificar.ImageList = this.botonesPequeño;
            this.btn_modificar.Location = new System.Drawing.Point(1028, 275);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(113, 36);
            this.btn_modificar.TabIndex = 27;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.UseVisualStyleBackColor = false;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_alta
            // 
            this.btn_alta.BackColor = System.Drawing.Color.Transparent;
            this.btn_alta.FlatAppearance.BorderSize = 0;
            this.btn_alta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_alta.ImageIndex = 0;
            this.btn_alta.ImageList = this.botonesPequeño;
            this.btn_alta.Location = new System.Drawing.Point(930, 275);
            this.btn_alta.Name = "btn_alta";
            this.btn_alta.Size = new System.Drawing.Size(92, 36);
            this.btn_alta.TabIndex = 26;
            this.btn_alta.Text = "Nuevo";
            this.btn_alta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_alta.UseVisualStyleBackColor = false;
            this.btn_alta.Click += new System.EventHandler(this.btn_alta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(949, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "(doble clic para seleccionar)";
            // 
            // txt_filtroMovil
            // 
            this.txt_filtroMovil.Location = new System.Drawing.Point(320, 23);
            this.txt_filtroMovil.Name = "txt_filtroMovil";
            this.txt_filtroMovil.Size = new System.Drawing.Size(100, 27);
            this.txt_filtroMovil.TabIndex = 31;
            // 
            // txt_filtroNombre
            // 
            this.txt_filtroNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_filtroNombre.Location = new System.Drawing.Point(79, 23);
            this.txt_filtroNombre.Name = "txt_filtroNombre";
            this.txt_filtroNombre.Size = new System.Drawing.Size(240, 27);
            this.txt_filtroNombre.TabIndex = 30;
            // 
            // frm_seleccionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 322);
            this.ControlBox = false;
            this.Controls.Add(this.txt_filtroMovil);
            this.Controls.Add(this.txt_filtroNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_alta);
            this.Controls.Add(this.btn_seleccion);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.dgv_seleccionClientes);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_seleccionClientes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccion de cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seleccionClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_seleccionClientes;
        private System.Windows.Forms.ImageList botonesGrandes;
        private System.Windows.Forms.Button btn_seleccion;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button btn_alta;
        private System.Windows.Forms.ImageList botonesPequeño;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_filtroMovil;
        private System.Windows.Forms.TextBox txt_filtroNombre;
    }
}