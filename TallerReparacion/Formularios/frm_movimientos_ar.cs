using System;
using System.Drawing;
using System.Windows.Forms;
using TallerReparacion.Datos;

namespace TallerReparacion.Formularios
{
    public partial class Frm_movimientos_ar : Form
    {
        string opcion = string.Empty;
        int id_movimiento;
        private DateTime? fechaDB;
        public Frm_movimientos_ar(int id_movimiento, DateTime fecha, int cod_articulo, string tipo_ES, string origen, int cantidad, string tipoMovimiento, bool cargarFechaDB = false)
        {
            InitializeComponent();
            switch (tipoMovimiento)
            {
                case "E":
                    this.Text = "Entrada articulos";
                    txt_tipo_ES.Text = "Entrada";
                    opcion = "E";
                    txt_fecha.Text = fecha.ToString("dd/MM/yyyy");
                    txt_cod_articulo.Text = Convert.ToString(cod_articulo);
                    txt_tipo_ES.Text = tipo_ES;
                    txt_origen.Text = origen;
                    txt_cantidad.Text = Convert.ToString(cantidad);
                    break;
                case "S":
                    this.Text = "Salida articulos";
                    txt_tipo_ES.Text = "Salida";
                    opcion = "S";
                    txt_fecha.Text = fecha.ToString("dd/MM/yyyy");
                    txt_cod_articulo.Text = Convert.ToString(cod_articulo);
                    txt_tipo_ES.Text = tipo_ES;
                    txt_origen.Text = origen;
                    txt_cantidad.Text = Convert.ToString(cantidad);
                    break;
                case "M":
                    this.Text = "Modificar movimiento";
                    opcion = "M";
                    txt_id_ma.Text = Convert.ToString(id_movimiento);
                    fechaDB = fecha;
                    if (cargarFechaDB)
                    {
                        txt_fecha.Text = fechaDB?.ToString("dd-MM-yyyy");
                    }
                    txt_cod_articulo.Text = Convert.ToString(cod_articulo);
                    txt_tipo_ES.Text = tipo_ES;
                    txt_origen.Text = origen;
                    txt_cantidad.Text = Convert.ToString(cantidad);
                    break;
            }
        }

        private void Btn_validar_Click(object sender, EventArgs e)
        {
            //Valida si el campo cantidad esta relleno y no deja continuar hasta que se rellene
            while (string.IsNullOrEmpty(txt_cantidad.Text))
            {
                MessageBox.Show("Debe rellenar la fecha y cantidad del movimiento del articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Prepara los datos de los textBox para pasarlos a la tabla de articulos
            if (opcion == "M")
            {
                id_movimiento = Convert.ToInt32(txt_id_ma.Text);
            }
            DateTime fecha = Convert.ToDateTime(txt_fecha.Text);
            int cod_articulo = Convert.ToInt32(txt_cod_articulo.Text);
            string tipo_ES = txt_tipo_ES.Text;
            string origen = txt_origen.Text.ToUpper();
            int cantidad = Convert.ToInt32(txt_cantidad.Text);

            DbManage db = new DbManage();
            bool resultado = true;
            string mensaje = string.Empty;
            switch (opcion)
            {
                case "E":
                    resultado = db.AltaMovimientos(fecha, cod_articulo, tipo_ES, origen, cantidad, 0);
                    if (resultado)
                    {
                        MessageBox.Show("Entrada creada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "S":
                    resultado = db.AltaMovimientos(fecha, cod_articulo, tipo_ES, origen, cantidad, 0);
                    if (resultado)
                    {
                        MessageBox.Show("Salida creada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "M":
                    resultado = db.ModificarMovimiento(id_movimiento, fecha, cod_articulo, tipo_ES, origen, cantidad);
                    if (resultado)
                    {
                        MessageBox.Show("Movimiento actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show("Opcion no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            utilidades utilidad = new utilidades();
            utilidad.CalculaStock(cod_articulo);
            this.Close();
            this.Owner.Activate();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Activate();
        }


        private void Frm_movimientos_ar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (calendarioFechas.Visible == true)
                {
                    calendarioFechas.Visible = false;
                    calendarioFechas.SendToBack();
                    txt_fecha.Focus();
                }
                else
                {
                    btn_cancelar.PerformClick();
                }
            }
        }

        private void Btn_fecha_Click(object sender, EventArgs e)
        {
            // Ubicación para mostrar el calendario
            Point location = new Point(txt_fecha.Left, txt_fecha.Top);

            // Establece la ubicación del calendario
            calendarioFechas.Location = location;
            calendarioFechas.Visible = true;
            calendarioFechas.BringToFront();
        }

        private void CalendarioFechas_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            //Event para pasar la fecha seleccionada en el calendario al txtBox correspondiente
            txt_fecha.Text = e.Start.ToShortDateString();

            //Oculta el calendario
            calendarioFechas.Visible = false;
            calendarioFechas.SendToBack();

            //Pone el foco en el siguiente control en funcion del textBox seleccionado
            txt_cantidad.Focus();
        }
    }
}
