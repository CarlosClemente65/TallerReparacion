using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TallerReparacion.Datos;

namespace TallerReparacion.Formularios
{
    public partial class frm_ordenes : Form
    {
        string opcion = string.Empty;
        string opcionMat = string.Empty;
        private int clienteSeleccionado;
        public string filtro_or = "A";
        private int idClienteSeleccion;
        private int idOrdenSeleccionada;
        private TextBox currentTextBox;
        private string filtroNombre;
        private string filtroMovil;
        private string filtroEo;

        public frm_ordenes()
        {
            InitializeComponent();

            //Suscribe los textBox al evento TextChanged para que cualquier cambio lance la funcion de actualizar el dgv
            txt_filtroNombre.TextChanged += TextBox_TextChanged;
            txt_filtroMovil.TextChanged += TextBox_TextChanged;

            //Desactiva el groupBox que contiene el detalle de campos
            grb_ordenes.Enabled = false;
            cb_filtro.SelectedIndex = 0;

            CargarDgvOrdenes(null, null, filtro_or, null);

            //Ajuste de las columnas del dgv_ordenes
            dgv_ordenes.Columns["id_orden"].Visible = false;
            dgv_ordenes.Columns["nombre_cl"].HeaderText = "Cliente";
            dgv_ordenes.Columns["nombre_cl"].Width = 250;
            dgv_ordenes.Columns["telefono_cl"].HeaderText = "Telefono";
            dgv_ordenes.Columns["email_cl"].HeaderText = "Correo electronico";
            dgv_ordenes.Columns["email_cl"].Width = 175;
            dgv_ordenes.Columns["terminal_or"].Visible = false;
            dgv_ordenes.Columns["fechaAlta_or"].HeaderText = "Fecha alta";
            dgv_ordenes.Columns["fechaAlta_or"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ordenes.Columns["fechaAlta_or"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ordenes.Columns["fechaAlta_or"].Width = 100;
            dgv_ordenes.Columns["fechaEstimada_or"].Visible = false;
            dgv_ordenes.Columns["fechaFin_or"].Visible = false;
            dgv_ordenes.Columns["descripcion_eo"].Visible = false;
            dgv_ordenes.Columns["id_cliente_or"].Visible = false;
            dgv_ordenes.Columns["descripcion_or"].Visible = false;
            dgv_ordenes.Columns["activo_or"].Visible = false;
            dgv_ordenes.Columns["estado_or"].Visible = false;
            dgv_ordenes.Columns["codigo_eo"].Visible = false;


            //Carga en el cbEstados los estados que hay en la tabla de la BBDD
            DataTable estados = new DbManage().ObtenerEstados();
            cbEstados.Items.Add("");

            foreach (DataRow dr in estados.Rows)
            {
                cbEstados.Items.Add(dr["descripcion_eo"]);
            }

        }


        #region dgv_ordenes
        private void Btn_alta_Click(object sender, EventArgs e)
        {
            opcion = "Alta";

            //Obtiene le numero de orden que corresponde (ultima + 1) y la asigna a la orden seleccionada para la carga del resto de datos.
            DbManage db = new DbManage();
            int UltimaOrden = db.ObtenerUltimaOrden();
            idOrdenSeleccionada = UltimaOrden;

            grb_ordenes.Enabled = true;
            CambiarColoresDGV(dgv_ordenes, false);
            CambiarColoresDGV(dgv_materiales, true);
            chk_orden.Checked = true;
            ActualizaDGVMateriales();
            EstadoBtnFormulario(false);
            EstadoBtnOrdenes(true);
            EstadoBtnMateriales(true);
            btn_editCliente.BackColor = SystemColors.Window;
            txt_filtroNombre.Enabled = false;
            txt_filtroMovil.Enabled = false;
            cb_filtro.Enabled = false;
            LimpiarCamposOrdenes();
            txt_orden.Text = Convert.ToString(UltimaOrden);
            txt_fechaAlta.Text = Convert.ToString(DateTime.Today);
            txt_cliente.Enabled = true;
            txt_cliente.Focus();
            txt_cliente.DeselectAll();
        }
        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgv_ordenes.Rows.Count > 0)
            {
                opcion = "Modificar";
                grb_ordenes.Enabled = true;
                CambiarColoresDGV(dgv_ordenes, false);
                CambiarColoresDGV(dgv_materiales, true);
                EstadoBtnFormulario(false);
                EstadoBtnOrdenes(true);
                EstadoBtnMateriales(true);
                btn_editCliente.BackColor = SystemColors.Window;
                txt_filtroNombre.Enabled = false;
                txt_filtroMovil.Enabled = false;
                cbEstados.Enabled = false;
                cb_filtro.Enabled = false;
                txt_cliente.Focus();
                txt_cliente.DeselectAll();
                idOrdenSeleccionada = Convert.ToInt32(dgv_ordenes.SelectedRows[0].Cells["id_orden"].Value);
            }
            else
            {
                MessageBox.Show("No hay ningun registro seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Frm_inicio formulario = Frm_inicio.GetInstance();
            formulario.Show();
            this.Close();
        }
        private DataTable ActualizadgvOrdenes(string filtroNombre = "", string filtroMovil = "", string filtroOr = "", string filtroEo = "")
        {
            DataTable dt = new DbManage().ObtenerOrdenes();
            DataTable dtOrdenada = new DataTable();

            //Filtar tabla
            if (!string.IsNullOrEmpty(filtroNombre) || !string.IsNullOrEmpty(filtroMovil) || !string.IsNullOrEmpty(filtroOr) || !string.IsNullOrEmpty(filtroEo))
            {
                // Realizar el filtrado en base a los parámetros de filtro
                DataView dv = dt.DefaultView;

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

                if (!string.IsNullOrEmpty(filtroOr))
                {
                    if (!string.IsNullOrEmpty(expresionFiltro))
                    {
                        expresionFiltro += " AND ";
                    }
                    switch (filtroOr)
                    {
                        case "A":
                            {
                                expresionFiltro += $"activo_or = true";
                                break;
                            }
                        case "I":
                            {
                                expresionFiltro += $"activo_or = false";
                                break;
                            }
                        case "T":
                            {
                                expresionFiltro += "(activo_or = true OR activo_or = false)";
                                break;
                            }
                    }
                }

                if (!string.IsNullOrEmpty(filtroEo))
                {
                    if (!string.IsNullOrEmpty(expresionFiltro))
                    {
                        expresionFiltro += " AND ";
                    }

                    expresionFiltro += $"descripcion_eo LIKE '%{filtroEo}%'";
                }

                dv.RowFilter = expresionFiltro;
                dt = dv.ToTable();
            }

            //Ordenar tabla
            if (dt.Rows.Count == 0)
            {
                //DataTable emptyTable = new DataTable();
                foreach (DataColumn col in dt.Columns)
                {
                    dtOrdenada.Columns.Add(col.ColumnName, col.DataType);
                }
                return dtOrdenada;

            }
            else
            {
                dtOrdenada = dt.AsEnumerable().OrderByDescending(row => Convert.ToDateTime(row["fechaAlta_or"])).ThenBy(row => row["nombre_cl"]).CopyToDataTable();

                return dtOrdenada;
            }
        }
        private void CargarDgvOrdenes(string filtroNombre = "", string filtroMovil = "", string filtroOr = "", string filtroEo = "")
        {
            //Desactiva el evento del dgv_ordenes para que no le afecten lo cambios de seleccion y evitar que se ejecute varias veces esta parte ya que hay una instruccion para seleccionar la ultima orden antes de los cambios.
            dgv_ordenes.SelectionChanged -= Dgv_ordenes_SelectionChanged;

            DataTable dt = ActualizadgvOrdenes(filtroNombre, filtroMovil, filtroOr, filtroEo);
            dgv_ordenes.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                idOrdenSeleccionada = 0;
            }
            bool flag = false;
            foreach (DataGridViewRow f in dgv_ordenes.Rows)
            {

                int idOrden = Convert.ToInt32(f.Cells["id_orden"].Value);
                if (idOrden == idOrdenSeleccionada)
                {
                    int i = f.Index;
                    dgv_ordenes.Rows[i].Selected = true;
                    flag = true;
                    break;
                }
                if (!flag)
                {
                    dgv_ordenes.Rows[0].Selected = true;
                    idOrdenSeleccionada = Convert.ToInt32(dgv_ordenes.SelectedRows[0].Cells["id_orden"].Value);
                    break;
                }
            }
            //Vuelve a activar el evento de los cambios en el dgv_ordenes.
            dgv_ordenes.SelectionChanged += Dgv_ordenes_SelectionChanged;

        }
        private void Dgv_ordenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ordenes.SelectedRows.Count > 0)
            {
                idOrdenSeleccionada = Convert.ToInt32(dgv_ordenes.SelectedRows[0].Cells["id_orden"].Value);
            }

            ActualizaDetalle();
            ActualizaDGVMateriales();

        }
        private void Dgv_ordenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_modificar_Click(sender, e);
        }
        private void ActualizaDetalle()
        {
            if (dgv_ordenes.Rows.Count == 0)
            {
                LimpiarCamposOrdenes();
                return;
            }
            else
            {
                if (idOrdenSeleccionada != 0)
                {
                    //Desactiva el evento del dgv_ordenes para que no le afecten lo cambios de seleccion y evitar que se ejecute varias veces esta parte ya que hay una instruccion para seleccionar la ultima orden antes de los cambios.
                    dgv_ordenes.SelectionChanged -= Dgv_ordenes_SelectionChanged;

                    foreach (DataGridViewRow f in dgv_ordenes.Rows)
                    {
                        int idOrden = Convert.ToInt32(f.Cells["id_orden"].Value);
                        if (idOrden == idOrdenSeleccionada)
                        {
                            int i = f.Index;
                            dgv_ordenes.Rows[i].Selected = true;
                            break;
                        }
                    }

                }
                else
                {
                    dgv_ordenes.Rows[0].Selected = true;
                }

                //Activa el evento del dgv_ordenes de nuevo.
                dgv_ordenes.SelectionChanged += Dgv_ordenes_SelectionChanged;

            }

            DataGridViewRow fila = dgv_ordenes.SelectedRows[0];
            txt_orden.Text = fila.Cells["id_orden"].Value.ToString();
            txt_cliente.Text = fila.Cells["nombre_cl"].Value.ToString();
            txt_idCliente.Text = fila.Cells["id_cliente_or"].Value.ToString();
            clienteSeleccionado = Convert.ToInt32(fila.Cells["id_cliente_or"].Value);
            txt_dispositivo.Text = fila.Cells["terminal_or"].Value.ToString();
            txt_telefono.Text = fila.Cells["telefono_cl"].Value.ToString();
            txt_email.Text = fila.Cells["email_cl"].Value.ToString();
            txt_descripcion.Text = fila.Cells["descripcion_or"].Value.ToString();
            txt_fechaAlta.Text = ((DateTime)fila.Cells["fechaAlta_or"].Value).ToString("dd.MM.yyyy");
            if (fila.Cells["fechaEstimada_or"].Value != null && DateTime.TryParse(fila.Cells["fechaEstimada_or"].Value.ToString(), out DateTime fechaEstimada))
            {
                txt_fechaEstimada.Text = fechaEstimada.ToString("dd.MM.yyyy");
            }
            else
            {
                txt_fechaEstimada.Text = "";
            }
            if (fila.Cells["fechaFin_or"].Value != null && DateTime.TryParse(fila.Cells["fechaFin_or"].Value.ToString(), out DateTime fechaFin))
            {
                txt_fechaFin.Text = fechaFin.ToString("dd.MM.yyyy");
            }
            else
            {
                txt_fechaFin.Text = "";
            }
            string codigoEstado = fila.Cells["codigo_eo"].Value.ToString();
            int indice = Convert.ToInt32(codigoEstado);
            cbx_estado.SelectedIndex = indice;
            bool activo = (bool)fila.Cells["activo_or"].Value;
            chk_orden.Checked = activo;
        }

        #endregion

        #region detalle campos
        private void Btn_validar_Click(object sender, EventArgs e)
        {
            //Validar si estan los datos rellenos
            while (string.IsNullOrEmpty(txt_idCliente.Text) || string.IsNullOrEmpty(txt_descripcion.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente y una descripcion obligatoriamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grb_ordenes.Enabled = false;
            CambiarColoresDGV(dgv_materiales, false);
            CambiarColoresDGV(dgv_ordenes, true);
            EstadoBtnMateriales(false);
            EstadoBtnOrdenes(false);
            EstadoBtnFormulario(true);
            btn_editCliente.BackColor = Color.Transparent;
            txt_filtroNombre.Enabled = true;
            txt_filtroNombre.Text = "";
            txt_filtroMovil.Enabled = true;
            txt_filtroMovil.Text = "";
            cbEstados.Enabled = true;
            cb_filtro.Enabled = true;
            lbl_cliente.Enabled = false;

            //Prepara los datos de los textBox para pasarlos a la tabla de ordenes
            DbManage db = new DbManage();
            if (cbx_estado.SelectedIndex == 5)
            {
                DialogResult mb = MessageBox.Show("Ha establecido el estado de la orden como cerrada. \nQuiere dejarla orden como inactiva?", "Desactivar orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mb == DialogResult.Yes)
                {
                    chk_orden.Checked = false;
                }
            }

            if (cbx_estado.SelectedIndex == 3 && txt_fechaFin.Text == "")
            {
                DialogResult mb = MessageBox.Show("Ha dejado la orden como terminada y no tiene fecha de finalizacion. \nQuiere grabar la fecha actual?", "Finalizar orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mb == DialogResult.Yes)
                {
                    txt_fechaFin.Text = Convert.ToString(DateTime.Now.Date);
                }
            }

            //int idOrden = db.ObtenerUltimaOrden() + 1;
            //if (opcion != "Alta")
            //{
            int idOrden = Convert.ToInt32(txt_orden.Text);
            //}
            int idCliente = Convert.ToInt32(txt_idCliente.Text);
            DateTime fechaAlta = Convert.ToDateTime(txt_fechaAlta.Text);
            string terminal = txt_dispositivo.Text;
            string descripcion = txt_descripcion.Text;
            DateTime? fechaEstimada = null;
            if (!string.IsNullOrEmpty(txt_fechaEstimada.Text))
            {
                fechaEstimada = Convert.ToDateTime(txt_fechaEstimada.Text);
            }
            DateTime? fechaFin = null;
            if (!string.IsNullOrEmpty(txt_fechaFin.Text))
            {
                fechaFin = Convert.ToDateTime(txt_fechaFin.Text);
            }
            int estadoOrden = Convert.ToInt32(cbx_estado.SelectedIndex);
            bool activo = chk_orden.Checked;

            //Hace la llamada para dar de alta o modificar la orden que se esta creando / modificando
            bool resultado = true;
            string mensaje = string.Empty;

            switch (opcion)
            {
                case "Alta":
                    resultado = db.ActualizarOrdenes("Alta", idOrden, idCliente, fechaAlta, fechaEstimada, fechaFin, terminal, descripcion, estadoOrden, activo);
                    if (resultado)
                    {
                        MessageBox.Show("Orden creada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al dar de alta la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Modificar":
                    resultado = db.ActualizarOrdenes("Modificar", idOrden, idCliente, fechaAlta, fechaEstimada, fechaFin, terminal, descripcion, estadoOrden, activo);
                    if (resultado)
                    {
                        MessageBox.Show("Orden modificada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                default:
                    MessageBox.Show("Opcion no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            if (dgv_materiales.Rows.Count > 0)
            {
                int codArticulo = 1;
                //Elimina los materiales de la tabla de movimientos articulos para luego actualizarlos
                db.BorrarMovimientos(idOrden);

                //Una vez eliminados se dan de alta todas las lineas en la tabla de movimientos de articulos

                // Recorre todas las filas del DataGridView
                foreach (DataGridViewRow row in dgv_materiales.Rows)
                {
                    // Extrae los valores de cada columna necesarios para el movimiento
                    DateTime fechaMovimiento = DateTime.Now.Date;
                    codArticulo = Convert.ToInt32(row.Cells["cod_articulo"].Value);
                    string tipoES = "Salida";  // Asigna "Salida" ya que es una salida de material por orden de reparación
                    string origen = $"Orden nº {idOrden}";  // Asigna "Orden" como origen del movimiento
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);

                    // Llama a la función para dar de alta el movimiento en la tabla de movimientos de artículos
                    bool altaExitosa = db.AltaMovimientos(fechaMovimiento, codArticulo, tipoES, origen, cantidad, idOrden);

                    // Verifica si el alta fue exitosa
                    if (!altaExitosa)
                    {
                        MessageBox.Show("Error al actualizar los movimientos de artículos.");
                    }

                    utilidades utilidad = new utilidades();
                    utilidad.CalculaStock(codArticulo);
                }
            }
            LimpiarCamposOrdenes();

            //Desactiva el dgv_ordenes para el evento de cambios de seleccion
            dgv_ordenes.SelectionChanged -= Dgv_ordenes_SelectionChanged;

            //Actualiza el dgv por si se ha modificado algun dato de los clientes
            CargarDgvOrdenes(null, null, filtro_or, null);

            dgv_ordenes.Focus();
            dgv_ordenes.Select();

            //Activa de nuevo el evento del cambio de seleccion en el dgv_ordenes
            dgv_ordenes.SelectionChanged += Dgv_ordenes_SelectionChanged;

            //Selecciona la fila de la orden seleccionada al entrar a modificar
            foreach (DataGridViewRow fila in dgv_ordenes.Rows)
            {
                if (fila.Cells["id_orden"].Value.ToString() == idOrdenSeleccionada.ToString())
                {
                    fila.Selected = true;
                    break;
                }
            }
        }
        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            grb_ordenes.Enabled = false;
            CambiarColoresDGV(dgv_ordenes, true);
            CambiarColoresDGV(dgv_materiales, false);
            EstadoBtnMateriales(false);
            EstadoBtnOrdenes(false);
            EstadoBtnFormulario(true);
            btn_editCliente.BackColor = Color.Transparent;
            txt_filtroNombre.Enabled = true;
            txt_filtroMovil.Enabled = true;
            cbEstados.Enabled = true;
            cb_filtro.Enabled = true;
            lbl_cliente.Visible = false;
            dgv_ordenes.Focus();
            dgv_ordenes.Select();
        }
        private void Txt_descripcion_Enter(object sender, EventArgs e)
        {
            txt_descripcion.SelectionStart = txt_descripcion.TextLength;
        }
        private void Btn_editCliente_Click(object sender, EventArgs e)
        {
            EditCliente(clienteSeleccionado);

            DataTable dt = new DbManage().ConsultaCliente(idClienteSeleccion);
            if (dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                if (opcion == "Alta")
                {
                    txt_idCliente.Text = fila[0].ToString();
                    txt_cliente.Text = fila[1].ToString();
                    txt_telefono.Text = fila[2].ToString();
                    txt_email.Text = fila[3].ToString();
                    txt_dispositivo.Focus();
                }

                if (opcion == "Modificar")
                {
                    if (txt_idCliente.Text != fila[0].ToString())
                    {
                        DialogResult respuesta = MessageBox.Show("Ha modificado el cliente. Esta seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (respuesta == DialogResult.Yes)
                        {
                            txt_idCliente.Text = fila[0].ToString();
                            txt_cliente.Text = fila[1].ToString();
                            txt_telefono.Text = fila[2].ToString();
                            txt_email.Text = fila[3].ToString();
                            this.Refresh();
                            txt_dispositivo.Focus();
                        }
                    }
                }
            }
        }
        private void EditCliente(int clienteSeleccionado)
        {
            frm_seleccionClientes formulario = new frm_seleccionClientes(clienteSeleccionado, opcion);
            formulario.ShowDialog(this);
            idClienteSeleccion = formulario.obtenerClienteSeleccionado();
        }
        private void Txt_cliente_Enter(object sender, EventArgs e)
        {
            lbl_cliente.Visible = true;
            lbl_cliente.Enabled = true;
        }
        private void Txt_cliente_Leave(object sender, EventArgs e)
        {
            lbl_cliente.Visible = false;
        }
        private void Btn_fechaAlta_Click(object sender, EventArgs e)
        {
            //Control para mostrar el calendario en el campo de la fecha de alta
            currentTextBox = txt_fechaAlta; // Asigna el TextBox asociado al calendario

            // Ubicación para mostrar el calendario
            Point location = new Point(txt_fechaAlta.Left, txt_fechaAlta.Top);

            // Establece la ubicación del calendario
            calendarioFechas.Location = location;
            calendarioFechas.Visible = true;
            calendarioFechas.BringToFront();
        }
        private void Btn_fechaEstimada_Click(object sender, EventArgs e)
        {
            //Control para mostrar el calendario en el campo de la fecha estimada
            currentTextBox = txt_fechaEstimada; // Asigna el TextBox asociado al calendario

            // Ubicación para mostrar el calendario
            Point location = new Point(txt_fechaEstimada.Left, txt_fechaEstimada.Top);

            // Establece la ubicación del calendario
            calendarioFechas.Location = location;
            calendarioFechas.Visible = true;
            calendarioFechas.BringToFront();
        }
        private void Btn_fechaFin_Click(object sender, EventArgs e)
        {
            //Control para mostrar el calendario en el campo de la fecha fin
            currentTextBox = txt_fechaFin; // Asigna el TextBox asociado al calendario

            // Ubicación para mostrar el calendario
            Point location = new Point(txt_fechaFin.Right - calendarioFechas.Width, txt_fechaFin.Top);

            // Establece la ubicación del calendario
            calendarioFechas.Location = location;
            calendarioFechas.Visible = true;
            calendarioFechas.BringToFront();
        }

        #endregion


        #region materiales
        private void Btn_nuevoMaterial_Click(object sender, EventArgs e)
        {
            CargarCamposMateriales("Alta", 1);
            opcionMat = "Alta";
        }
        private void Btn_modificarMaterial_Click(object sender, EventArgs e)
        {
            //if (dgv_ordenes.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("No hay ninguna orden seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            if (dgv_materiales.Rows.Count > 0)
            {
                opcionMat = "Modificar";
                DataGridViewRow fila = dgv_materiales.SelectedRows[0];
                int idMaterial = Convert.ToInt32(fila.Cells["id_material"].Value);
                CargarCamposMateriales("Modificar", idMaterial);
            }
            //}
        }
        private void Btn_borrarMaterial_Click(object sender, EventArgs e)
        {
            if (dgv_materiales.Rows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("Esta seguro de borrar el material?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                {
                    return;
                }

                DataGridViewRow fila = dgv_materiales.SelectedRows[0];
                int idMaterial = Convert.ToInt32(fila.Cells["id_material"].Value);

                DbManage db = new DbManage();
                bool resultado = db.EliminarMateriales(idMaterial);
                if (resultado)
                {
                    ActualizaDGVMateriales();
                    MessageBox.Show("Material eliminado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el material", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ActualizaDGVMateriales()
        {

            DataTable tabla = new DbManage().ObtenerMateriales(idOrdenSeleccionada);
            DataTable dtOrdenada = new DataTable();

            //Ordena la tabla por el campo fecha
            if (tabla.Rows.Count == 0)
            {
                foreach (DataColumn col in tabla.Columns)
                {
                    dtOrdenada.Columns.Add(col.ColumnName, col.DataType);
                }
            }
            else
            {
                dtOrdenada = tabla.AsEnumerable().OrderByDescending(row => row["fechaAlta_ma"]).CopyToDataTable();
            }

            dgv_materiales.DataSource = dtOrdenada;

            dgv_materiales.Columns["nombre_ar"].HeaderText = "Descripcion";
            dgv_materiales.Columns["nombre_ar"].Width = 195;
            dgv_materiales.Columns["cantidad"].HeaderText = "Cantidad";
            dgv_materiales.Columns["cantidad"].Width = 70;
            dgv_materiales.Columns["cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_materiales.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_materiales.Columns["precio"].HeaderText = "Precio";
            dgv_materiales.Columns["precio"].Width = 60;
            dgv_materiales.Columns["precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_materiales.Columns["precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_materiales.Columns["importe"].HeaderText = "Importe";
            dgv_materiales.Columns["importe"].Width = 80;
            dgv_materiales.Columns["importe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_materiales.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_materiales.Columns["fechaAlta_ma"].HeaderText = "Fecha";
            dgv_materiales.Columns["fechaAlta_ma"].Width = 80;
            dgv_materiales.Columns["fechaAlta_ma"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_materiales.Columns["fechaAlta_ma"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_materiales.Columns["id_material"].Visible = false;
            dgv_materiales.Columns["cod_articulo"].Visible = false;
            dgv_materiales.Columns["id_orden"].Visible = false;

            if (dgv_materiales.Enabled == false)
            {
                CambiarColoresDGV(dgv_materiales, false);
            }
            else
            {
                CambiarColoresDGV(dgv_materiales, true);
            }
        }
        private void CargarCamposMateriales(string opcion, int idMaterial)
        {
            panelMateriales.Visible = true;
            panelMateriales.BringToFront();
            if (opcion == "Alta")
            {
                foreach (Control control in panelMateriales.Controls)
                {
                    if (control is TextBox cuadro)
                    {
                        cuadro.Text = "";
                    }
                }
            }
            else
            {
                DataTable tabla = new DbManage().ObtenerMateriales(idOrdenSeleccionada, idMaterial);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    txt_fechaAlta_ma.Text = fila[0].ToString();
                    txt_idMaterial.Text = fila[1].ToString();
                    txt_descripcionMat.Text = fila[2].ToString();
                    txt_cantidadMat.Text = fila[3].ToString();
                    txt_precioMat.Text = fila[4].ToString();
                    txt_importeMat.Text = fila[5].ToString();
                    txt_articuloMat.Text = fila[6].ToString();
                    txt_ordenMat.Text = fila[7].ToString();
                }
            }
            if (txt_ordenMat.Text == "")
            {
                txt_ordenMat.Text = txt_orden.Text;
            }
        }
        private void Btn_validarMat_Click(object sender, EventArgs e)
        {
            //Prepara los datos para pasarlos a la tabla
            int idMaterial = 1;
            DateTime fechaAlta_ma = DateTime.Now.Date;
            if (opcionMat == "Modificar")
            {
                idMaterial = Convert.ToInt32(txt_idMaterial.Text);
                fechaAlta_ma = Convert.ToDateTime(txt_fechaAlta_ma.Text);
            }
            int idArticulo = Convert.ToInt32(txt_articuloMat.Text);
            int idOrdenMat = Convert.ToInt32(txt_ordenMat.Text);
            decimal cantidad = Convert.ToDecimal(txt_cantidadMat.Text);
            decimal precio = Convert.ToDecimal(txt_precioMat.Text);
            decimal importe = Convert.ToDecimal(txt_importeMat.Text);

            DbManage db = new DbManage();
            bool resultado = true;

            switch (opcionMat)
            {
                case "Alta":
                    DateTime fechaAlta = DateTime.Now.Date;
                    resultado = db.AltaMateriales(idArticulo, idOrdenMat, cantidad, precio, importe, fechaAlta);
                    if (resultado)
                    {
                        MessageBox.Show("Articulo creado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al dar de alta el articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Modificar":
                    resultado = db.ModificarMateriales(idMaterial, idArticulo, idOrdenMat, cantidad, precio, importe, fechaAlta_ma);
                    if (resultado)
                    {
                        MessageBox.Show("Orden modificada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show("Opcion no valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            foreach (Control control in panelMateriales.Controls)
            {
                if (control is TextBox cuadro)
                {
                    cuadro.Text = "";
                }
            }
            ActualizaDGVMateriales();
            panelMateriales.Visible = false;
        }
        private void Btn_cancelarMat_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelMateriales.Controls)
            {
                if (control is TextBox cuadro)
                {
                    cuadro.Text = "";
                }
            }
            panelMateriales.Visible = false;
        }
        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            // Crea una instancia de un nuevo formulario del almacen de articulos
            frm_almacen formulario = new frm_almacen();

            //Se pone como visible el boton seleccionar que solo sirve en este proceso
            formulario.btn_seleccionar.Visible = true;
            formulario.btn_seleccionar.BringToFront();
            formulario.btn_salir.Visible = false;
            formulario.lbl_seleccionar.Visible = true;
            this.Hide();
            formulario.ShowDialog(this);

            //Obtiene el codigo del articulo que se ha seleccionado en el formulario de almacen
            int idArticuloSeleccionado = Convert.ToInt32(formulario.articuloSeleccionado);

            DataTable tabla = new DbManage().ObtenerArticulos("A", idArticuloSeleccionado);
            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                txt_descripcionMat.Text = fila[1].ToString();
                decimal precio = Convert.ToDecimal(fila[5]);
                txt_precioMat.Text = precio.ToString("N2");
                txt_articuloMat.Text = fila[0].ToString();
                txt_ordenMat.Text = idOrdenSeleccionada.ToString();
            }
            this.Show();
            txt_cantidadMat.Focus();
        }
        private void Txt_cantidadMat_Leave(object sender, EventArgs e)
        {
            string txtCantidad = txt_cantidadMat.Text.Replace('.', ',');
            string txtPrecio = txt_precioMat.Text.Replace('.', ',');

            if (float.TryParse(txtCantidad, out float cantidad) && float.TryParse(txtPrecio, out float precio))
            {
                float importe = (float)Math.Round((cantidad * precio), 2);
                txt_cantidadMat.Text = cantidad.ToString("N2");
                txt_precioMat.Text = precio.ToString("N2");
                txt_importeMat.Text = importe.ToString("N2");
            }
        }
        private void Txt_precioMat_Leave(object sender, EventArgs e)
        {
            string txtCantidad = txt_cantidadMat.Text.Replace('.', ',');
            string txtPrecio = txt_precioMat.Text.Replace('.', ',');

            if (float.TryParse(txtCantidad, out float cantidad) && float.TryParse(txtPrecio, out float precio))

            {
                float importe = (float)Math.Round((cantidad * precio), 2);
                txt_cantidadMat.Text = cantidad.ToString("N2");
                txt_precioMat.Text = precio.ToString("N2");
                txt_importeMat.Text = importe.ToString("N2");
            }
        }
        private void Txt_descripcionMat_Enter(object sender, EventArgs e)
        {
            label23.Visible = true;
        }
        private void Txt_descripcionMat_Leave(object sender, EventArgs e)
        {
            label23.Visible = false;
        }

        #endregion


        #region utilidades
        public void ColorEstados()
        {
            foreach (DataGridViewRow fila in dgv_ordenes.Rows)
            {
                int codigoEstado = Convert.ToInt32(fila.Cells["codigo_eo"].Value);
                switch (codigoEstado)
                {
                    case 1: //Pedido material (rojo)
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.DefaultCellStyle.ForeColor = Color.Red;
                        fila.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 183, 177);
                        fila.DefaultCellStyle.SelectionForeColor = Color.Black;
                        break;
                    case 2: //Orden en reparacion (azul)
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.DefaultCellStyle.ForeColor = Color.RoyalBlue;
                        fila.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 230, 241);
                        fila.DefaultCellStyle.SelectionForeColor = Color.Black;
                        break;
                    case 3: //Orden terminada (naranja)
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        fila.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 215, 160);
                        fila.DefaultCellStyle.SelectionForeColor = Color.Black; break;
                    case 4: //Avisado el cliente (rosa)
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.DefaultCellStyle.ForeColor = Color.Magenta;
                        fila.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 219, 216);
                        fila.DefaultCellStyle.SelectionForeColor = Color.Black;
                        break;
                    case 5: //Orden cerrada (verde)
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.DefaultCellStyle.ForeColor = Color.Green;
                        fila.DefaultCellStyle.SelectionBackColor = Color.FromArgb(213, 245, 227);
                        fila.DefaultCellStyle.SelectionForeColor = Color.Black;
                        break;
                    default:
                        fila.DefaultCellStyle.ForeColor = default;
                        break;
                }
            }
        }
        private void Frm_ordenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (grb_ordenes.Enabled == true)
                {
                    if (panelMateriales.Visible == true)
                    {
                        foreach (Control control in panelMateriales.Controls)
                        {
                            if (control is TextBox cuadro)
                            {
                                cuadro.Text = "";
                            }
                        }
                        panelMateriales.Visible = false;
                        panelMateriales.SendToBack();

                        return;
                    }

                    if (calendarioFechas.Visible == true)
                    {
                        calendarioFechas.Visible = false;
                        currentTextBox.Focus();
                        return;
                    }

                    btn_cancelarMat.PerformClick();
                    btn_cancelar.PerformClick();
                }
                else
                {
                    btn_salir.PerformClick();
                }
            }

            if (e.KeyCode == Keys.F11)
            {
                if (txt_cliente.Focused == true)
                {
                    EditCliente(clienteSeleccionado);
                }
                if (txt_descripcionMat.Focused == true)
                {
                    btn_buscar.PerformClick();
                }
            }
        }
        private void CambiarColoresDGV(DataGridView dgv, bool activo)
        {
            if (activo)
            {
                // Restaurar los colores por defecto
                dgv.Enabled = true;
                dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                dgv.DefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.WindowText;
            }
            else
            {
                // Difuminar el DataGridView
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
                dgv.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.DefaultCellStyle.SelectionBackColor = SystemColors.Control;
                dgv.DefaultCellStyle.SelectionForeColor = SystemColors.GrayText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
                dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.DimGray;
                dgv.Enabled = false;
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            filtroNombre = txt_filtroNombre.Text;
            filtroMovil = txt_filtroMovil.Text;

            // Llamar a la función actualizarOrdenes() con los valores de filtro
            if (string.IsNullOrEmpty(filtroNombre) && string.IsNullOrEmpty(filtroMovil) && string.IsNullOrEmpty(filtroEo))
            {
                CargarDgvOrdenes(null, null, filtro_or, null); // Sin filtros
            }
            else if (string.IsNullOrEmpty(filtroNombre))
            {
                CargarDgvOrdenes(null, filtroMovil, filtro_or, filtroEo); // Filtrar solo por teléfono
            }
            else if (string.IsNullOrEmpty(filtroMovil))
            {
                CargarDgvOrdenes(filtroNombre, null, filtro_or, filtroEo); // Filtrar solo por nombre
            }
            else
            {
                CargarDgvOrdenes(filtroNombre, filtroMovil, filtro_or, filtroEo); // Filtrar por nombre y teléfono
            }
        }
        private void EstadoBtnMateriales(bool estado)
        {
            btn_nuevoMaterial.Visible = estado;
            btn_modificarMaterial.Visible = estado;
            btn_borrarMaterial.Visible = estado;
        }
        private void EstadoBtnOrdenes(bool estado)
        {
            btn_validar.Visible = estado;
            btn_cancelar.Visible = estado;
        }
        private void EstadoBtnFormulario(bool estado)
        {
            btn_alta.Visible = estado;
            btn_modificar.Visible = estado;
            btn_salir.Visible = estado;
        }
        private void Cb_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexFiltro = cb_filtro.SelectedIndex;
            txt_filtroNombre.Text = "";
            txt_filtroMovil.Text = "";
            switch (indexFiltro)
            {
                case 0:
                    filtro_or = "A";
                    break;
                case 1:
                    filtro_or = "I";
                    break;
                case 2:
                    filtro_or = "T";
                    break;
            }
            CargarDgvOrdenes(filtroNombre, filtroMovil, filtro_or, filtroEo);
            ActualizaDetalle();
            ActualizaDGVMateriales();
            dgv_ordenes.Focus();
        }
        private void CalendarioFechas_DateSelected(object sender, DateRangeEventArgs e)
        {
            //Event para pasar la fecha seleccionada en el calendario al txtBox correspondiente
            currentTextBox.Text = e.Start.ToShortDateString(); //Variable que tiene el nombre del textBox seleccionado

            //Oculta el calendario
            calendarioFechas.Visible = false;
            calendarioFechas.SendToBack();

            //Control de que la fecha estimada no sea anterior a la de alta
            if (!string.IsNullOrWhiteSpace(txt_fechaAlta.Text) && !string.IsNullOrWhiteSpace(txt_fechaEstimada.Text))
            {
                DateTime fechaAlta = DateTime.Parse(txt_fechaAlta.Text);
                DateTime fechaEstimada = DateTime.Parse(txt_fechaEstimada.Text);

                if (fechaEstimada < fechaAlta)
                {
                    MessageBox.Show("La fecha estimada de la reparacion es anterior a la fecha de alta. Modifiquela.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_fechaEstimada.Text = "";
                    txt_fechaEstimada.Focus();
                }
            }

            //Control de que la fecha fin no sea anterior a la de alta
            if (!string.IsNullOrWhiteSpace(txt_fechaAlta.Text) && !string.IsNullOrWhiteSpace(txt_fechaFin.Text))
            {
                DateTime fechaFin = DateTime.Parse(txt_fechaFin.Text);
                DateTime fechaAlta = DateTime.Parse(txt_fechaAlta.Text);

                if (fechaFin < fechaAlta)
                {
                    MessageBox.Show("La fecha de finalizacion de la reparacion es anterior a la fecha de alta. Modifiquela.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_fechaFin.Text = "";
                    txt_fechaFin.Focus();
                }
            }

            //Pone el foco en el siguiente control en funcion del textBox seleccionado
            string nombreTxtBox = currentTextBox.Name;
            switch (nombreTxtBox)
            {
                case "txt_fechaAlta":
                    txt_fechaEstimada.Focus();
                    break;

                case "txt_fechaEstimada":
                    txt_fechaFin.Focus();
                    break;

                case "txt_fechaFin":
                    txt_descripcion.Focus();
                    break;

            }
        }

        private void LimpiarCamposOrdenes()
        {
            txt_idCliente.Text = "";
            txt_orden.Text = "";
            txt_cliente.Text = "";
            txt_dispositivo.Text = "";
            txt_fechaAlta.Text = "";
            txt_fechaEstimada.Text = "";
            txt_fechaFin.Text = "";
            txt_telefono.Text = "";
            txt_email.Text = "";
            txt_descripcion.Text = "";
            cbx_estado.SelectedIndex = 0;
        }

        private void CbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroEo = cbEstados.SelectedItem.ToString();
            txt_filtroNombre.Text = "";
            txt_filtroMovil.Text = "";
            CargarDgvOrdenes(null, null, filtro_or, filtroEo);
            ActualizaDetalle();
            ActualizaDGVMateriales();
            dgv_ordenes.Focus();

        }

        #endregion

    }
}
