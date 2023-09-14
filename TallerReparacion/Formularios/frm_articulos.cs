using System;
using System.Windows.Forms;
using TallerReparacion.Datos;

namespace TallerReparacion.Formularios
{
    public partial class frm_articulos : Form
    {
        string opcion = string.Empty;
        
        public frm_articulos(string tipo)
        {
            InitializeComponent();

            //Suscripcion al metodo TextBox_KeyDown de los textBox para que al pulsar Enter se pase al campo siguiente.
            txt_nombre_ar.KeyDown += TextBox_KeyDown;
            txt_codigo_ar.KeyDown += TextBox_KeyDown;
            txt_pcompra_ar.KeyDown += TextBox_KeyDown;
            txt_pventa_ar.KeyDown += TextBox_KeyDown;
            txt_stock_ar.KeyDown += TextBox_KeyDown;

            opcion = tipo;
            if (opcion == "Modificar")
            {
                this.Text = "Modificar articulos";
            }
            else
            {
                rb_activo.Visible = false;
                rb_inactivo.Visible = false;
            }
        }

        private void btn_validar_Click(object sender, EventArgs e)
        {
            int id_articulo = 1;
            //Valida si los campos nombre esta rellenos y no deja continuar hasta que se rellene
            while (string.IsNullOrEmpty(txt_nombre_ar.Text))
            {
                MessageBox.Show("Debe rellenar la descripcion del articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Prepara los datos de los textBox para pasarlos a la tabla de articulos
            if (opcion != "Alta")
            {
                id_articulo = Convert.ToInt32(txt_idarticulo.Text);
            }
            string descripcion = txt_nombre_ar.Text;
            string codigo = txt_codigo_ar.Text;
            float pcompra;
            float pventa;
            float.TryParse(txt_pcompra_ar.Text, out pcompra);
            float.TryParse(txt_pventa_ar.Text, out pventa);
            int stock;
            int.TryParse(txt_stock_ar.Text, out stock);
            bool activo = true;
            if (rb_inactivo.Checked)
            {
                activo = false;
            }

            DbManage db = new DbManage();
            bool resultado = true;
            string mensaje = string.Empty;
            switch (opcion)
            {
                case "Alta":
                    resultado = db.AltaArticulos(descripcion, codigo, stock, pcompra, pventa);
                    if (resultado)
                    {
                        MessageBox.Show("Articulo creado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Modificar":
                    resultado = db.ActualizaArticulos(id_articulo, descripcion, codigo, stock, pcompra, pventa, activo);
                    if (resultado)
                    {
                        MessageBox.Show("Articulo actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show("Opcion no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            this.Close();
            this.Owner.Activate();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Activate();
        }

        public string idArticulo
        {
            set { txt_idarticulo.Text = value; }
        }

        public string nombreArticulo
        {
            set { txt_nombre_ar.Text = value; }
        }

        public string codigoArticulo
        {
            set { txt_codigo_ar .Text = value; }
        }

        public string stockArticulo
        {
            set { txt_stock_ar .Text = value; }
        }

        public string precioCompra
        {
            set { txt_pcompra_ar .Text = value; }
        }

        public string precioVenta
        {
            set { txt_pventa_ar .Text = value; }
        }

        public bool activoArticulo
        {
            set { rb_activo.Checked = value; }
        }

        public bool inactivoArticulo
        {
            set { rb_inactivo.Checked = value; }
        }

        private void frm_articulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                    btn_cancelar.PerformClick();
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Metodo para que al pulsar Enter en los TextBox que estan definidos al principio se pase al campo siguiente y no se reproduzca ningun sonido.
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }
}
