using System;
using System.Data;
using System.Windows.Forms;
using TallerReparacion.Datos;
using System.Linq;


namespace TallerReparacion
{
    public partial class frm_clientes : Form
    {
        string opcion = string.Empty;
        int indiceSeleccion = 0;
        private bool cierreFormulario = false;
        public bool estado = true;
        public string filtro_cl = "A";
        private bool estadoBotonAlta;
        private bool estadoBotonModificar;
        private DataGridViewRow clienteSeleccionado;

        public frm_clientes()
        {
            InitializeComponent();
            KeyPreview = true;

            //Suscribe los textBox al evento TextChanged para que cualquier cambio lance la funcion de actualizar el dgv
            txt_filtroNombre.TextChanged += TextBox_TextChanged;
            txt_filtroMovil.TextChanged += TextBox_TextChanged;

            //Suscrite los textBox al evento TextBox_KeyDown para que al pulsar Enter se pase al campo siguiente.
            txt_nombre.KeyDown += TextBox_KeyDown;
            txt_telefono.KeyDown += TextBox_KeyDown;
            txt_email.KeyDown += TextBox_KeyDown;
            txt_direccion.KeyDown += TextBox_KeyDown;
            txt_cpostal.KeyDown += TextBox_KeyDown;
            txt_poblacion.KeyDown += TextBox_KeyDown;

            cb_filtro.SelectedIndex = 0;
            txt_filtroNombre.Focus();

            DataTable dt = CargarDGVClientes(null, null);
            dgv_clientes.DataSource = dt;
            dgv_clientes.Columns["id_cliente"].HeaderText = "Nº";
            dgv_clientes.Columns["nombre_cl"].HeaderText = "Nombre cliente";
            dgv_clientes.Columns["telefono_cl"].HeaderText = "Telefono";
            dgv_clientes.Columns["email_cl"].HeaderText = "Correo electronico";
            dgv_clientes.Columns["direccion_cl"].HeaderText = "Direccion";
            dgv_clientes.Columns["cpostal_cl"].HeaderText = "Cod.postal";
            dgv_clientes.Columns["poblacion_cl"].HeaderText = "Poblacion";
            dgv_clientes.Columns["provincia_cl"].HeaderText = "Provincia";
            dgv_clientes.Columns["activo_cl"].HeaderText = "Activo";
            dgv_clientes.Columns["id_cliente"].Width = 50;
            dgv_clientes.Columns["nombre_cl"].Width = 250;
            dgv_clientes.Columns["email_cl"].Width = 220;
            dgv_clientes.Columns["direccion_cl"].Width = 220;
            dgv_clientes.Columns["cpostal_cl"].Width = 80;
            dgv_clientes.Columns["cpostal_cl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_clientes.Columns["activo_cl"].Visible = false;

            EstadoBotones(true);
            RellenarCampos();
            EstadoCampos(false);
        }

        public frm_clientes(bool estadoBotonAlta, bool estadoBotonModificar, DataGridViewRow id_cliente) : this()
        {
            //Metodo con sobrecarga del formulario de clientes que se utiliza cuando se quiere dar de alta un nuevo cliente desde el formulario de ordenes, desde el que se pasa el estado de los botones alta o modificar para simular que desde este formulario se ha pulsado el boton de alta o modificar.
            this.estadoBotonAlta = estadoBotonAlta;
            this.estadoBotonModificar = estadoBotonModificar;
            this.clienteSeleccionado = id_cliente;
        }

        private void Frm_clientes_Load(object sender, EventArgs e)
        {
            //Metodo en la carga del formulario de clientes que chequea si desde el formulario de ordenes se ha llamado a este formulario y se le han pasado las variables estadoBotonAlta y estadoBotonModificar para simular la pulsacion de un boton u otro y dar de alta o modificar el cliente correspondiente.
            if (this.estadoBotonAlta)
            {
                btn_alta.PerformClick();
            }

            if (this.estadoBotonModificar)
            {
                if (this.clienteSeleccionado != null)
                {
                    foreach (DataGridViewRow fila in dgv_clientes.Rows)
                    {
                        if (fila.Cells["id_cliente"].Value.ToString() == this.clienteSeleccionado.Cells["id_cliente"].Value.ToString())
                        {
                            fila.Selected = true;
                            break;
                        }
                    }
                }
                btn_modificar.PerformClick();
            }

            //Posiciona los botones de validar y cancelar encima de los de alta y modificar
            int btnAltaX = btn_alta.Left;
            int btnAltaY = btn_alta.Top;
            btn_validar.Left = btnAltaX;
            btn_validar.Top = btnAltaY;

            int btnModificarX = btn_modificar.Left;
            int btnModificarY = btn_modificar.Top;
            btn_cancelar.Left = btnModificarX;
            btn_cancelar.Top = btnModificarY;
            txt_filtroNombre.Focus();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Frm_inicio formulario = Frm_inicio.GetInstance();
            formulario.Show();
            this.Close();
        }

        private void Btn_alta_Click(object sender, EventArgs e)
        {
            opcion = "Alta";
            if (dgv_clientes.SelectedRows.Count > 0)
            {
                indiceSeleccion = Convert.ToInt32(dgv_clientes.SelectedRows[0].Cells["id_cliente"].Value);
            }
            EstadoBotones(false);
            VaciarCampos();
            EstadoCampos(true);
            rb_activo.Checked = true;
            txt_nombre.Focus();
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            opcion = "Modificar";
            if (dgv_clientes.Rows.Count > 0)
            {
                if (dgv_clientes.SelectedRows.Count > 0)
                {
                    indiceSeleccion = Convert.ToInt32(dgv_clientes.SelectedRows[0].Cells["id_cliente"].Value);
                }
                EstadoBotones(false);
                EstadoCampos(true);
                txt_nombre.Focus();
            }
            else
            {
                MessageBox.Show("No hay ningun cliente seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_validar_Click(object sender, EventArgs e)
        {
            //Valida si los campos nombre y telefono estan rellenos y no deja continuar hasta que se rellenen
            while (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_telefono.Text))
            {
                MessageBox.Show("Debe rellenar los campos Nombre y Telefono obligatoriamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Prepara los datos de los textBox para pasarlos a la tabla de clientes
            int idcliente = 1;
            if (opcion != "Alta")
            {
                idcliente = int.Parse(txt_idcliente.Text);
            }
            string nombre = txt_nombre.Text;
            string telefono = txt_telefono.Text;
            string email = txt_email.Text;
            string direccion = txt_direccion.Text;
            string cpostal = txt_cpostal.Text;
            string poblacion = txt_poblacion.Text;
            string provincia = txt_provincia.Text;
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
                    resultado = db.AltaCliente(nombre, telefono, email, direccion, cpostal, poblacion, provincia);
                    if (resultado)
                    {
                        MessageBox.Show("Cliente creado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el ciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Modificar":
                    resultado = db.ActualizaCliente(idcliente, nombre, telefono, email, direccion, cpostal, poblacion, provincia, activo);
                    if (resultado)
                    {
                        MessageBox.Show("Cliente actualizado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el ciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show("Opcion no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            DataTable dt = CargarDGVClientes(null, null);
            dgv_clientes.DataSource = dt;

            //Selecciona la fila del cliente que estaba seleccionado
            DataGridViewRow row = dgv_clientes.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id_cliente"].Value) == indiceSeleccion);
            if (row != null)
            {
                dgv_clientes.CurrentCell = row.Cells[0];
                row.Selected = true;
                int rowIndex = row.Index;
                dgv_clientes.FirstDisplayedScrollingRowIndex = rowIndex;
            }

            EstadoBotones(true);
            RellenarCampos();
            EstadoCampos(false);
            txt_filtroNombre.Focus();
        }


        private void Btn_cancelar_Click(object sender, EventArgs e)
        {

            if (opcion == "Alta")
            {
                VaciarCampos();
            }
            //Selecciona la fila del cliente que estaba seleccionado
            DataGridViewRow row = dgv_clientes.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id_cliente"].Value) == indiceSeleccion);
            if (row != null)
            {
                dgv_clientes.CurrentCell = row.Cells[0];
                row.Selected = true;
                int rowIndex = row.Index;
                dgv_clientes.FirstDisplayedScrollingRowIndex = rowIndex;
            }
            RellenarCampos();
            EstadoBotones(true);
            EstadoCampos(false);
            txt_filtroNombre.Focus();
        }

        private void EstadoBotones(bool estado)
        {
            btn_alta.Visible = estado;
            btn_modificar.Visible = estado;
            btn_salir_cl.Visible = estado;
            lb_filtro.Visible = estado;
            cb_filtro.Visible = estado;
            btn_validar.Visible = !estado;
            btn_cancelar.Visible = !estado;
            dgv_clientes.Enabled = estado;
            txt_filtroNombre.Enabled = estado;
            txt_filtroMovil.Enabled = estado;
        }

        private void Dgv_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RellenarCampos();
            EstadoCampos(false);
        }

        private void RellenarCampos()
        {
            if (dgv_clientes.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgv_clientes.SelectedRows[0];
                txt_idcliente.Text = fila.Cells["id_cliente"].Value.ToString();
                txt_nombre.Text = fila.Cells["nombre_cl"].Value.ToString();
                txt_telefono.Text = fila.Cells["telefono_cl"].Value.ToString();
                txt_email.Text = fila.Cells["email_cl"].Value.ToString();
                txt_direccion.Text = fila.Cells["direccion_cl"].Value.ToString();
                txt_cpostal.Text = fila.Cells["cpostal_cl"].Value.ToString();
                txt_poblacion.Text = fila.Cells["poblacion_cl"].Value.ToString();
                txt_provincia.Text = fila.Cells["provincia_cl"].Value.ToString();
                if (Convert.ToBoolean(fila.Cells["activo_cl"].FormattedValue) == true)
                {
                    rb_activo.Checked = true;
                    rb_inactivo.Checked = false;
                }
                else
                {
                    rb_activo.Checked = false;
                    rb_inactivo.Checked = true;
                }
            }
        }

        private void VaciarCampos()
        {
            foreach (Control control in gb_datosCliente.Controls)
            {
                if (control is TextBox txtbox)
                {
                    txtbox.Text = string.Empty;
                }
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private void EstadoCampos(bool estado)
        {
            gb_datosCliente.Enabled = estado;
            //if (opcion == "Modificar")
            //{
            //    rb_activo.Enabled = estado;
            //    rb_inactivo.Enabled = estado;
            //}
        }

        private void Dgv_clientes_SelectionChanged(object sender, EventArgs e)
        {
            RellenarCampos();
            EstadoCampos(false);
        }

        private void Txt_cpostal_Leave(object sender, EventArgs e)
        {
            //Metodo para chequear el contenido del txt_cpostal para que solo admita numeros (primera parte del if) y en el caso de que no se introduzca nada, el campo provincia se vacie.
            if (!string.IsNullOrEmpty(txt_cpostal.Text))
            {
                if (!int.TryParse(txt_cpostal.Text, out int numero))
                {
                    MessageBox.Show("El codigo postal solo deben ser numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cpostal.Focus();
                }
                txt_cpostal.Text = numero.ToString().PadLeft(5, '0');


                string codProvincia = txt_cpostal.Text.Substring(0, 2);

                DbManage db = new DbManage();
                string nombreProvincia = db.ObtenerProvincia(codProvincia);
                txt_provincia.Text = nombreProvincia;
            }
            else
            {
                txt_provincia.Text = "";
            }
        }

        private void Dgv_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_modificar_Click(sender, e);
        }


        private void Frm_clientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (btn_salir_cl.Visible == true)
                {
                    // Si el boton salir esta activado, se simula la pulsación del botón btn_salir
                    btn_salir_cl.PerformClick();
                }
                else
                {
                    // Si el boton salir está desactivado, se simula la pulsación del botón btn_cancelar
                    btn_cancelar.PerformClick();
                }
            }
        }

        private void Frm_clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cierreFormulario && e.CloseReason == CloseReason.UserClosing)
            {
                cierreFormulario = true;
                btn_salir_cl.PerformClick();
            }
        }


        private void Cb_filtro_SelectedValueChanged(object sender, EventArgs e)
        {
            int indexFiltro = cb_filtro.SelectedIndex;
            switch (indexFiltro)
            {
                case 0:
                    filtro_cl = "A";
                    break;
                case 1:
                    filtro_cl = "I";
                    break;
                case 2:
                    filtro_cl = "T";
                    break;
            }
            DataTable dt = CargarDGVClientes(null, null);
            dgv_clientes.DataSource = dt;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            string filtroNombre = txt_filtroNombre.Text;
            string filtroMovil = txt_filtroMovil.Text;

            DataTable dt = CargarDGVClientes(filtroNombre, filtroMovil);

            dgv_clientes.DataSource = dt;
        }

        private DataTable CargarDGVClientes(string filtroNombre = "", string filtroMovil = "")
        {
            DataTable tabla = new DbManage().ObtenerClientes(filtro_cl);
            DataTable dtOrdenada = new DataTable();

            if (!string.IsNullOrEmpty(filtroNombre) || !string.IsNullOrEmpty(filtroMovil))
            {
                // Realizar el filtrado en base a los parámetros de filtro
                DataView dv = tabla.DefaultView;

                string expresionFiltro = "";
                if (!string.IsNullOrEmpty(filtroNombre))
                {
                    expresionFiltro += $"nombre_cl LIKE '%{filtroNombre}%'";
                }

                if (!string.IsNullOrEmpty(filtroMovil))
                {
                    if (!string.IsNullOrEmpty(expresionFiltro))
                    {
                        expresionFiltro += " AND ";
                    }
                    expresionFiltro += $"telefono_cl LIKE '%{filtroMovil}%'";
                }

                dv.RowFilter = expresionFiltro;
                tabla = dv.ToTable();
            }

            //Ordena la tabla por el campo nombre cliente
            if (tabla.Rows.Count == 0)
            {
                //DataTable emptyTable = new DataTable();
                foreach (DataColumn col in tabla.Columns)
                {
                    dtOrdenada.Columns.Add(col.ColumnName, col.DataType);
                }
            }
            else
            {
                dtOrdenada = tabla.AsEnumerable().OrderBy(row => row["nombre_cl"]).CopyToDataTable();
            }
            return dtOrdenada;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Metodo para que al pulsar Enter en los TextBox que se han indicado al principio se pase al campo siguiente y no se reproduzca ningun sonido.
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
