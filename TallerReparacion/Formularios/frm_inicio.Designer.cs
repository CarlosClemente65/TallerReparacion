namespace TallerReparacion
{
    partial class Frm_inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_inicio));
            this.imagenes = new System.Windows.Forms.ImageList(this.components);
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_ordenes = new System.Windows.Forms.Button();
            this.btn_articulos = new System.Windows.Forms.Button();
            this.btn_clientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imagenes
            // 
            this.imagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenes.ImageStream")));
            this.imagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenes.Images.SetKeyName(0, "clientes2.png");
            this.imagenes.Images.SetKeyName(1, "almacen3.png");
            this.imagenes.Images.SetKeyName(2, "reparacion.png");
            this.imagenes.Images.SetKeyName(3, "salida_1.png");
            this.imagenes.Images.SetKeyName(4, "personas.png");
            this.imagenes.Images.SetKeyName(5, "clientes.png");
            this.imagenes.Images.SetKeyName(6, "clientes_1.png");
            this.imagenes.Images.SetKeyName(7, "almacen_2.png");
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Transparent;
            this.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.FlatAppearance.BorderSize = 0;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_salir.ImageKey = "salida_1.png";
            this.btn_salir.ImageList = this.imagenes;
            this.btn_salir.Location = new System.Drawing.Point(619, 157);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(5);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(86, 99);
            this.btn_salir.TabIndex = 3;
            this.btn_salir.Text = "Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.Btn_salir_Click);
            // 
            // btn_ordenes
            // 
            this.btn_ordenes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ordenes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ordenes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_ordenes.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_ordenes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_ordenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ordenes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ordenes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ordenes.ImageIndex = 2;
            this.btn_ordenes.ImageList = this.imagenes;
            this.btn_ordenes.Location = new System.Drawing.Point(495, 30);
            this.btn_ordenes.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ordenes.Name = "btn_ordenes";
            this.btn_ordenes.Size = new System.Drawing.Size(210, 100);
            this.btn_ordenes.TabIndex = 2;
            this.btn_ordenes.Text = "Ordenes de reparacion";
            this.btn_ordenes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ordenes.UseVisualStyleBackColor = false;
            this.btn_ordenes.Click += new System.EventHandler(this.Btn_ordenes_Click);
            // 
            // btn_articulos
            // 
            this.btn_articulos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_articulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_articulos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_articulos.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_articulos.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_articulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_articulos.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_articulos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_articulos.ImageIndex = 7;
            this.btn_articulos.ImageList = this.imagenes;
            this.btn_articulos.Location = new System.Drawing.Point(261, 30);
            this.btn_articulos.Margin = new System.Windows.Forms.Padding(4);
            this.btn_articulos.Name = "btn_articulos";
            this.btn_articulos.Size = new System.Drawing.Size(210, 100);
            this.btn_articulos.TabIndex = 1;
            this.btn_articulos.Text = "Gestion almacen";
            this.btn_articulos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_articulos.UseVisualStyleBackColor = false;
            this.btn_articulos.Click += new System.EventHandler(this.Btn_articulos_Click);
            // 
            // btn_clientes
            // 
            this.btn_clientes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_clientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clientes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_clientes.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_clientes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clientes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_clientes.ImageIndex = 6;
            this.btn_clientes.ImageList = this.imagenes;
            this.btn_clientes.Location = new System.Drawing.Point(26, 30);
            this.btn_clientes.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clientes.Name = "btn_clientes";
            this.btn_clientes.Size = new System.Drawing.Size(210, 100);
            this.btn_clientes.TabIndex = 0;
            this.btn_clientes.Text = "Gestion de clientes";
            this.btn_clientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_clientes.UseVisualStyleBackColor = false;
            this.btn_clientes.Click += new System.EventHandler(this.Btn_clientes_Click);
            // 
            // Frm_inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelButton = this.btn_salir;
            this.ClientSize = new System.Drawing.Size(726, 270);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_ordenes);
            this.Controls.Add(this.btn_articulos);
            this.Controls.Add(this.btn_clientes);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Frm_inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taller de reparacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_inicio_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_inicio_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_clientes;
        private System.Windows.Forms.ImageList imagenes;
        private System.Windows.Forms.Button btn_articulos;
        private System.Windows.Forms.Button btn_ordenes;
        private System.Windows.Forms.Button btn_salir;
    }
}