namespace TallerReparacion.Formularios
{
    partial class frm_articulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_articulos));
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombre_ar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_codigo_ar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_pventa_ar = new System.Windows.Forms.TextBox();
            this.txt_pcompra_ar = new System.Windows.Forms.TextBox();
            this.rb_inactivo = new System.Windows.Forms.RadioButton();
            this.rb_activo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_stock_ar = new System.Windows.Forms.TextBox();
            this.txt_idarticulo = new System.Windows.Forms.TextBox();
            this.img_articulos = new System.Windows.Forms.ImageList(this.components);
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_validar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Codigo articulo";
            // 
            // txt_nombre_ar
            // 
            this.txt_nombre_ar.AcceptsTab = true;
            this.txt_nombre_ar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nombre_ar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre_ar.Location = new System.Drawing.Point(20, 37);
            this.txt_nombre_ar.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.txt_nombre_ar.MaxLength = 50;
            this.txt_nombre_ar.Name = "txt_nombre_ar";
            this.txt_nombre_ar.Size = new System.Drawing.Size(641, 27);
            this.txt_nombre_ar.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Descripcion";
            // 
            // txt_codigo_ar
            // 
            this.txt_codigo_ar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codigo_ar.Location = new System.Drawing.Point(20, 98);
            this.txt_codigo_ar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_codigo_ar.MaxLength = 20;
            this.txt_codigo_ar.Name = "txt_codigo_ar";
            this.txt_codigo_ar.Size = new System.Drawing.Size(275, 27);
            this.txt_codigo_ar.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "Precio venta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Precio compra";
            // 
            // txt_pventa_ar
            // 
            this.txt_pventa_ar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pventa_ar.Location = new System.Drawing.Point(503, 98);
            this.txt_pventa_ar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_pventa_ar.Name = "txt_pventa_ar";
            this.txt_pventa_ar.Size = new System.Drawing.Size(159, 27);
            this.txt_pventa_ar.TabIndex = 4;
            this.txt_pventa_ar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_pcompra_ar
            // 
            this.txt_pcompra_ar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pcompra_ar.Location = new System.Drawing.Point(316, 98);
            this.txt_pcompra_ar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_pcompra_ar.Name = "txt_pcompra_ar";
            this.txt_pcompra_ar.Size = new System.Drawing.Size(159, 27);
            this.txt_pcompra_ar.TabIndex = 3;
            this.txt_pcompra_ar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rb_inactivo
            // 
            this.rb_inactivo.AutoSize = true;
            this.rb_inactivo.Location = new System.Drawing.Point(322, 167);
            this.rb_inactivo.Margin = new System.Windows.Forms.Padding(4);
            this.rb_inactivo.Name = "rb_inactivo";
            this.rb_inactivo.Size = new System.Drawing.Size(81, 23);
            this.rb_inactivo.TabIndex = 7;
            this.rb_inactivo.TabStop = true;
            this.rb_inactivo.Text = "Inactivo";
            this.rb_inactivo.UseVisualStyleBackColor = true;
            // 
            // rb_activo
            // 
            this.rb_activo.AutoSize = true;
            this.rb_activo.Location = new System.Drawing.Point(225, 167);
            this.rb_activo.Margin = new System.Windows.Forms.Padding(4);
            this.rb_activo.Name = "rb_activo";
            this.rb_activo.Size = new System.Drawing.Size(70, 23);
            this.rb_activo.TabIndex = 6;
            this.rb_activo.TabStop = true;
            this.rb_activo.Text = "Activo";
            this.rb_activo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 19);
            this.label5.TabIndex = 39;
            this.label5.Text = "Stock";
            // 
            // txt_stock_ar
            // 
            this.txt_stock_ar.Enabled = false;
            this.txt_stock_ar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_stock_ar.Location = new System.Drawing.Point(20, 167);
            this.txt_stock_ar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_stock_ar.Name = "txt_stock_ar";
            this.txt_stock_ar.Size = new System.Drawing.Size(175, 27);
            this.txt_stock_ar.TabIndex = 5;
            this.txt_stock_ar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_idarticulo
            // 
            this.txt_idarticulo.Enabled = false;
            this.txt_idarticulo.Location = new System.Drawing.Point(529, 5);
            this.txt_idarticulo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_idarticulo.Name = "txt_idarticulo";
            this.txt_idarticulo.Size = new System.Drawing.Size(132, 27);
            this.txt_idarticulo.TabIndex = 40;
            this.txt_idarticulo.Visible = false;
            // 
            // img_articulos
            // 
            this.img_articulos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_articulos.ImageStream")));
            this.img_articulos.TransparentColor = System.Drawing.Color.Transparent;
            this.img_articulos.Images.SetKeyName(0, "cancelar_1.png");
            this.img_articulos.Images.SetKeyName(1, "validar_1.png");
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cancelar.ImageIndex = 0;
            this.btn_cancelar.ImageList = this.img_articulos;
            this.btn_cancelar.Location = new System.Drawing.Point(584, 135);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 62);
            this.btn_cancelar.TabIndex = 9;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_validar
            // 
            this.btn_validar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_validar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_validar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_validar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_validar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_validar.ImageIndex = 1;
            this.btn_validar.ImageList = this.img_articulos;
            this.btn_validar.Location = new System.Drawing.Point(503, 135);
            this.btn_validar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(78, 62);
            this.btn_validar.TabIndex = 8;
            this.btn_validar.Text = "Validar";
            this.btn_validar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_validar.UseVisualStyleBackColor = false;
            this.btn_validar.Click += new System.EventHandler(this.btn_validar_Click);
            // 
            // frm_articulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_cancelar;
            this.ClientSize = new System.Drawing.Size(687, 210);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_validar);
            this.Controls.Add(this.txt_idarticulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_stock_ar);
            this.Controls.Add(this.rb_inactivo);
            this.Controls.Add(this.rb_activo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_pventa_ar);
            this.Controls.Add(this.txt_pcompra_ar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nombre_ar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_codigo_ar);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_articulos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta articulos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_articulos_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nombre_ar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_codigo_ar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_pventa_ar;
        private System.Windows.Forms.TextBox txt_pcompra_ar;
        private System.Windows.Forms.RadioButton rb_inactivo;
        private System.Windows.Forms.RadioButton rb_activo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_stock_ar;
        private System.Windows.Forms.TextBox txt_idarticulo;
        private System.Windows.Forms.ImageList img_articulos;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_validar;
    }
}