namespace TallerReparacion.Formularios
{
    partial class Frm_movimientos_ar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_movimientos_ar));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.img_movimientos = new System.Windows.Forms.ImageList(this.components);
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_validar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_origen = new System.Windows.Forms.TextBox();
            this.txt_id_ma = new System.Windows.Forms.TextBox();
            this.txt_cod_articulo = new System.Windows.Forms.TextBox();
            this.txt_tipo_ES = new System.Windows.Forms.TextBox();
            this.btn_fecha = new System.Windows.Forms.Button();
            this.imgPequeñas = new System.Windows.Forms.ImageList(this.components);
            this.calendarioFechas = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // txt_fecha
            // 
            this.txt_fecha.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fecha.Location = new System.Drawing.Point(68, 13);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(119, 27);
            this.txt_fecha.TabIndex = 1;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantidad.Location = new System.Drawing.Point(280, 11);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(71, 27);
            this.txt_cantidad.TabIndex = 2;
            this.txt_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad";
            // 
            // img_movimientos
            // 
            this.img_movimientos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_movimientos.ImageStream")));
            this.img_movimientos.TransparentColor = System.Drawing.Color.Transparent;
            this.img_movimientos.Images.SetKeyName(0, "cancelar_1.png");
            this.img_movimientos.Images.SetKeyName(1, "validar_1.png");
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_cancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cancelar.ImageIndex = 0;
            this.btn_cancelar.ImageList = this.img_movimientos;
            this.btn_cancelar.Location = new System.Drawing.Point(274, 112);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(77, 63);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // btn_validar
            // 
            this.btn_validar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_validar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_validar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_validar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_validar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_validar.ImageIndex = 1;
            this.btn_validar.ImageList = this.img_movimientos;
            this.btn_validar.Location = new System.Drawing.Point(16, 112);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(67, 63);
            this.btn_validar.TabIndex = 4;
            this.btn_validar.Text = "Validar";
            this.btn_validar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_validar.UseVisualStyleBackColor = false;
            this.btn_validar.Click += new System.EventHandler(this.Btn_validar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripcion movimiento";
            // 
            // txt_origen
            // 
            this.txt_origen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_origen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_origen.Location = new System.Drawing.Point(16, 74);
            this.txt_origen.MaxLength = 20;
            this.txt_origen.Name = "txt_origen";
            this.txt_origen.Size = new System.Drawing.Size(335, 27);
            this.txt_origen.TabIndex = 3;
            // 
            // txt_id_ma
            // 
            this.txt_id_ma.Location = new System.Drawing.Point(208, 239);
            this.txt_id_ma.Name = "txt_id_ma";
            this.txt_id_ma.Size = new System.Drawing.Size(100, 20);
            this.txt_id_ma.TabIndex = 7;
            this.txt_id_ma.Visible = false;
            // 
            // txt_cod_articulo
            // 
            this.txt_cod_articulo.Location = new System.Drawing.Point(124, 239);
            this.txt_cod_articulo.Name = "txt_cod_articulo";
            this.txt_cod_articulo.Size = new System.Drawing.Size(57, 20);
            this.txt_cod_articulo.TabIndex = 8;
            this.txt_cod_articulo.Visible = false;
            // 
            // txt_tipo_ES
            // 
            this.txt_tipo_ES.Location = new System.Drawing.Point(114, 152);
            this.txt_tipo_ES.Name = "txt_tipo_ES";
            this.txt_tipo_ES.Size = new System.Drawing.Size(100, 20);
            this.txt_tipo_ES.TabIndex = 9;
            this.txt_tipo_ES.Visible = false;
            // 
            // btn_fecha
            // 
            this.btn_fecha.BackColor = System.Drawing.Color.Transparent;
            this.btn_fecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_fecha.FlatAppearance.BorderSize = 0;
            this.btn_fecha.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Window;
            this.btn_fecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fecha.Font = new System.Drawing.Font("Calibri", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fecha.ImageIndex = 0;
            this.btn_fecha.ImageList = this.imgPequeñas;
            this.btn_fecha.Location = new System.Drawing.Point(161, 14);
            this.btn_fecha.Margin = new System.Windows.Forms.Padding(0);
            this.btn_fecha.Name = "btn_fecha";
            this.btn_fecha.Size = new System.Drawing.Size(25, 24);
            this.btn_fecha.TabIndex = 66;
            this.btn_fecha.UseVisualStyleBackColor = false;
            this.btn_fecha.Click += new System.EventHandler(this.Btn_fecha_Click);
            // 
            // imgPequeñas
            // 
            this.imgPequeñas.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPequeñas.ImageStream")));
            this.imgPequeñas.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPequeñas.Images.SetKeyName(0, "Calendario2.png");
            // 
            // calendarioFechas
            // 
            this.calendarioFechas.Location = new System.Drawing.Point(82, 13);
            this.calendarioFechas.Name = "calendarioFechas";
            this.calendarioFechas.TabIndex = 67;
            this.calendarioFechas.Visible = false;
            this.calendarioFechas.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalendarioFechas_DateSelected_1);
            // 
            // Frm_movimientos_ar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 187);
            this.ControlBox = false;
            this.Controls.Add(this.btn_fecha);
            this.Controls.Add(this.txt_tipo_ES);
            this.Controls.Add(this.txt_cod_articulo);
            this.Controls.Add(this.txt_id_ma);
            this.Controls.Add(this.txt_origen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_validar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.txt_fecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calendarioFechas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_movimientos_ar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entrada";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_movimientos_ar_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList img_movimientos;
        private System.Windows.Forms.Button btn_validar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_origen;
        private System.Windows.Forms.TextBox txt_id_ma;
        private System.Windows.Forms.TextBox txt_cod_articulo;
        private System.Windows.Forms.TextBox txt_tipo_ES;
        private System.Windows.Forms.Button btn_fecha;
        private System.Windows.Forms.ImageList imgPequeñas;
        private System.Windows.Forms.MonthCalendar calendarioFechas;
    }
}