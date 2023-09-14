using System;
using System.Data;
using System.Windows.Forms;
using TallerReparacion.Datos;
using System.Linq;

namespace TallerReparacion.Formularios
{
    public partial class frm_almacen : Form
    {
        string opcion = string.Empty;
        public string filtro_ar = "A";
        public int articuloSeleccionado = 0;
        string filtroArticulo = "";


        public frm_almacen()
        {
            InitializeComponent();
            KeyPreview = true;

            //Suscribe el txt_buscar al evento TextChanged para que cualquier cambio lance la funcion de actualizar el dgv
            txt_buscar.TextChanged += TextBox_TextChanged;

            cmb_estado.SelectedIndex = 0;
            txt_buscar.Focus();

            //Actualiza tabla articulos
            dgv_articulos.DataSource = CargarDGVArticulos(null);
            dgv_articulos.Columns["id_ar"].HeaderText = "Cod.";
            dgv_articulos.Columns["nombre_ar"].HeaderText = "Descripcion";
            dgv_articulos.Columns["codigo_ar"].HeaderText = "Codigo";
            dgv_articulos.Columns["stock_ar"].HeaderText = "Stock";
            dgv_articulos.Columns["precioCompra_ar"].HeaderText = "Precio compra";
            dgv_articulos.Columns["precioVenta_ar"].HeaderText = "Precio venta";
            dgv_articulos.Columns["activo_ar"].HeaderText = "Activo";
            dgv_articulos.Columns["id_ar"].Width = 50;
            dgv_articulos.Columns["nombre_ar"].Width = 300;
            dgv_articulos.Columns["codigo_ar"].Width = 200;
            dgv_articulos.Columns["stock_ar"].Width = 150;
            dgv_articulos.Columns["stock_ar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_articulos.Columns["precioCompra_ar"].Width = 150;
            dgv_articulos.Columns["precioCompra_ar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_articulos.Columns["precioVenta_ar"].Width = 150;
            dgv_articulos.Columns["precioVenta_ar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            int id_articulo = 0;
            if (dgv_articulos.Rows.Count > 0)
            {
                id_articulo = Convert.ToInt32(dgv_articulos.Rows[0].Cells["id_ar"].Value.ToString());
            }

            //Actualiza tabla movimientos
            dgv_movimientos_ar.DataSource = CargaDGVMovimientos(id_articulo);
            dgv_movimientos_ar.Columns["id_ma"].HeaderText = "Cod.";
            dgv_movimientos_ar.Columns["id_ma"].Visible = false;
            dgv_movimientos_ar.Columns["id_ma"].Width = 50;
            dgv_movimientos_ar.Columns["fecha_ma"].HeaderText = "Fecha";
            dgv_movimientos_ar.Columns["fecha_ma"].Width = 100;
            dgv_movimientos_ar.Columns["codigo_ar_ma"].HeaderText = "Cod.articulo";
            dgv_movimientos_ar.Columns["codigo_ar_ma"].Visible = false;
            dgv_movimientos_ar.Columns["tipo_ma"].HeaderText = "E/S";
            dgv_movimientos_ar.Columns["tipo_ma"].Width = 75;
            dgv_movimientos_ar.Columns["origen_ma"].HeaderText = "Descripcion movimiento";
            dgv_movimientos_ar.Columns["origen_ma"].Width = 330;
            dgv_movimientos_ar.Columns["cantidad_ma"].HeaderText = "Cantidad";
            dgv_movimientos_ar.Columns["cantidad_ma"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_movimientos_ar.Columns["cantidad_ma"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_movimientos_ar.Columns["cantidad_ma"].Width = 100;
            dgv_movimientos_ar.Columns["id_orden"].HeaderText = "Orden";
            dgv_movimientos_ar.Columns["id_orden"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_movimientos_ar.Columns["id_orden"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_movimientos_ar.Columns["id_orden"].Width = 70;

            ActivarBotones();
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
            if (dgv_articulos.SelectedRows.Count > 0)
            {
                articuloSeleccionado = Convert.ToInt32(dgv_articulos.SelectedRows[0].Cells["id_ar"].Value);
            }
            frm_articulos formulario = new frm_articulos(opcion);
            formulario.ShowDialog(this);
            dgv_articulos.DataSource = CargarDGVArticulos(null);

            //Selecciona la fila del articulo que estaba seleccionado
            DataGridViewRow row = dgv_articulos.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id_ar"].Value) == articuloSeleccionado);
            if (row != null)
            {
                dgv_articulos.CurrentCell = row.Cells[0];
                row.Selected = true;
                int rowIndex = row.Index;
                dgv_articulos.FirstDisplayedScrollingRowIndex = rowIndex;
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            opcion = "Modificar";
            frm_articulos formulario = new frm_articulos(opcion);
            if (dgv_articulos.SelectedRows.Count > 0)
            {
                articuloSeleccionado = Convert.ToInt32(dgv_articulos.SelectedRows[0].Cells["id_ar"].Value);

                //Recalcula el stock del articulo
                utilidades utilidad = new utilidades();
                utilidad.CalculaStock(articuloSeleccionado);

                //Actualiza el dgv_articulos por si hay cambios en el stock.
                dgv_articulos.DataSource = CargarDGVArticulos(null);

                //Selecciona la fila del articulo que estaba seleccionado
                DataGridViewRow fila = dgv_articulos.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id_ar"].Value) == articuloSeleccionado);
                if (fila != null)
                {
                    dgv_articulos.CurrentCell = fila.Cells[0];
                    fila.Selected = true;
                    int rowIndex = fila.Index;
                    dgv_articulos.FirstDisplayedScrollingRowIndex = rowIndex;
                }

                //DataGridViewRow fila = dgv_articulos.SelectedRows[0];
                string campo1 = fila.Cells[0].Value.ToString();
                string campo2 = fila.Cells[1].Value.ToString();
                string campo3 = fila.Cells[2].Value.ToString();
                string campo4 = fila.Cells[3].Value.ToString();
                string campo5 = fila.Cells[4].Value.ToString();
                string campo6 = fila.Cells[5].Value.ToString();
                bool campo7 = Convert.ToBoolean(fila.Cells[6].Value);

                formulario.idArticulo = campo1;
                formulario.nombreArticulo = campo2;
                formulario.codigoArticulo = campo3;
                formulario.stockArticulo = campo4;
                formulario.precioCompra = campo5;
                formulario.precioVenta = campo6;
                if (campo7 == true)
                {
                    formulario.activoArticulo = true;
                }
                else
                {
                    formulario.inactivoArticulo = true;
                }


                formulario.ShowDialog(this);
                dgv_articulos.DataSource = CargarDGVArticulos(filtroArticulo);
            }
            else
            {
                MessageBox.Show("No hay ningun articulo seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                formulario.inactivoArticulo = true;
            }

            //Selecciona la fila del articulo que estaba seleccionado
            DataGridViewRow row = dgv_articulos.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id_ar"].Value) == articuloSeleccionado);
            if (row != null)
            {
                dgv_articulos.CurrentCell = row.Cells[0];
                row.Selected = true;
                int rowIndex = row.Index;
                dgv_articulos.FirstDisplayedScrollingRowIndex = rowIndex;
            }
        }

        private void ActivarBotones()
        {
            if (articuloSeleccionado != 0 && articuloSeleccionado > dgv_articulos.Rows.Count - 1)
            {
                articuloSeleccionado = 0;
            }
            if (articuloSeleccionado != 0)
            {
                dgv_articulos.Rows[articuloSeleccionado].Selected = true;
            }
            dgv_articulos.Focus();
        }

        private void Dgv_articulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btn_seleccionar.Visible == true)
            {
                Btn_seleccionar_Click(sender, e);
            }
            else
            {
                Btn_modificar_Click(sender, e);
            }
        }

        private void Btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_buscar.Text = "";
            dgv_articulos.Focus();
        }

        private void Btn_entrada_mv_Click(object sender, EventArgs e)
        {
            if (dgv_articulos.SelectedRows.Count > 0)
            {
                articuloSeleccionado = dgv_articulos.CurrentRow.Index;
                //Prepara los datos para pasarlos al formulario
                int id_movimiento = 1;
                DateTime fecha = DateTime.Now;
                DataGridViewRow fila = dgv_articulos.SelectedRows[0];
                int cod_articulo = Convert.ToInt32(fila.Cells[0].Value);
                string tipo_ES = "Entrada";
                string origen = "";
                int cantidad = 0;
                string opcion = "E";
                Frm_movimientos_ar formulario = new Frm_movimientos_ar(id_movimiento, fecha, cod_articulo, tipo_ES, origen, cantidad, opcion, false);
                formulario.ShowDialog(this);
                dgv_movimientos_ar.DataSource = CargaDGVMovimientos(cod_articulo);
                dgv_articulos.DataSource = CargarDGVArticulos(filtroArticulo);
            }
            else
            {
                MessageBox.Show("No hay ningun articulo seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Formulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_modificar_mv_Click(object sender, EventArgs e)
        {
            if (dgv_articulos.SelectedRows.Count > 0)
            {
                //Almacena el articulo seleccionado para posicionarse en el cuando acabe el proceso
                DataGridViewRow row = dgv_articulos.SelectedRows[0];
                articuloSeleccionado = Convert.ToInt32(row.Cells["id_ar"].Value);

                if (dgv_movimientos_ar.Rows.Count > 0)
                {
                    DataGridViewRow fila = dgv_movimientos_ar.SelectedRows[0];
                    int id_movimiento = Convert.ToInt32(fila.Cells[0].Value);
                    DateTime fecha = Convert.ToDateTime(fila.Cells[1].Value);
                    int cod_articulo = Convert.ToInt32(fila.Cells[2].Value);
                    string tipo_ES = fila.Cells[3].Value.ToString();
                    string origen = fila.Cells[4].Value.ToString();
                    int cantidad = Convert.ToInt32(fila.Cells[5].Value);
                    int orden = Convert.ToInt32(fila.Cells[6].Value);
                    if (orden > 0)
                    {
                        DialogResult respuesta = MessageBox.Show($"Movimiento generado desde la orden de reparacion nº {orden}.\nModifiquelo desde alli", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string opcion = "M";
                    Frm_movimientos_ar formulario = new Frm_movimientos_ar(id_movimiento, fecha, cod_articulo, tipo_ES, origen, cantidad, opcion, true);
                    formulario.ShowDialog(this);
                    dgv_movimientos_ar.DataSource = CargaDGVMovimientos(cod_articulo);
                    dgv_articulos.DataSource = CargarDGVArticulos(filtroArticulo);

                    //Selecciona la fila del articulo que estaba seleccionado
                    DataGridViewRow filaAr = dgv_articulos.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id_ar"].Value) == articuloSeleccionado);
                    if (filaAr != null)
                    {
                        dgv_articulos.CurrentCell = filaAr.Cells[0];
                        filaAr.Selected = true;
                        int rowIndex = filaAr.Index;
                        dgv_articulos.FirstDisplayedScrollingRowIndex = rowIndex;
                    }
                }
                else
                {
                    MessageBox.Show("Este articulo no tiene movimientos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay ningun articulo seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_salida_mv_Click(object sender, EventArgs e)
        {
            if (dgv_articulos.SelectedRows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("Las salidas deben hacerse desde la ordenes de trabajo. Continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (respuesta == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int id_movimiento = 1;
                    DateTime fecha = DateTime.Now;
                    DataGridViewRow fila = dgv_articulos.SelectedRows[0];
                    int cod_articulo = Convert.ToInt32(fila.Cells[0].Value);
                    string tipo_ES = "Salida";
                    string origen = "";
                    int cantidad = 0;
                    opcion = "S";
                    Frm_movimientos_ar formulario = new Frm_movimientos_ar(id_movimiento, fecha, cod_articulo, tipo_ES, origen, cantidad, opcion, false);
                    formulario.ShowDialog(this);
                    dgv_movimientos_ar.DataSource = CargaDGVMovimientos(cod_articulo);
                    dgv_articulos.DataSource = CargarDGVArticulos(filtroArticulo);
                }
            }
            else
            {
                MessageBox.Show("No hay ningun articulo seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Dgv_articulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_articulos.SelectedRows.Count > 0)
            {
                if (int.TryParse(dgv_articulos.SelectedRows[0].Cells["id_ar"].Value.ToString(), out int codArticulo))
                {
                    dgv_movimientos_ar.DataSource = CargaDGVMovimientos(codArticulo);
                }
                else
                {
                    MessageBox.Show("Error al obtener el código de artículo seleccionado.");
                }
            }
        }

        private void Cmb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice_estado = cmb_estado.SelectedIndex;
            switch (indice_estado)
            {
                case 0:
                    filtro_ar = "A";
                    break;
                case 1:
                    filtro_ar = "I";
                    break;
                case 2:
                    filtro_ar = "T";
                    break;
            }
            dgv_articulos.DataSource = CargarDGVArticulos(filtroArticulo);
        }

        private void Dgv_movimientos_ar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_modificar_mv_Click(sender, e);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            string filtroArticulo = txt_buscar.Text;
            dgv_articulos.DataSource = CargarDGVArticulos(filtroArticulo);
        }

        private DataTable CargarDGVArticulos(string filtroArticulo)
        {
            DataTable tabla = new DbManage().ObtenerArticulos(filtro_ar);
            DataTable dtOrdenada = new DataTable();

            if (!string.IsNullOrEmpty(filtroArticulo))
            {
                // Realizar el filtrado en base a los parámetros de filtro
                DataView dv = tabla.DefaultView;

                string expresionFiltro = "";
                if (!string.IsNullOrEmpty(filtroArticulo))
                {
                    expresionFiltro += $"nombre_ar LIKE '%{filtroArticulo}%'";
                }

                dv.RowFilter = expresionFiltro;
                tabla = dv.ToTable();
            }

            //Ordena la tabla por el campo nombre articulo
            if (tabla.Rows.Count == 0)
            {
                foreach (DataColumn col in tabla.Columns)
                {
                    dtOrdenada.Columns.Add(col.ColumnName, col.DataType);
                }
            }
            else
            {
                dtOrdenada = tabla.AsEnumerable().OrderBy(row => row["nombre_ar"]).CopyToDataTable();
            }
            return dtOrdenada;
        }

        private DataTable CargaDGVMovimientos(int cod_articulo)
        {
            DataTable tabla = new DbManage().ObtenerMovimientos(cod_articulo);
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
                dtOrdenada = tabla.AsEnumerable().OrderByDescending(row => row["fecha_ma"]).CopyToDataTable();
            }
            return dtOrdenada;
        }

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (dgv_articulos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgv_articulos.SelectedRows[0];
                articuloSeleccionado = Convert.ToInt32(fila.Cells["id_ar"].Value);
            }
            else
            {
                articuloSeleccionado = 0;
            }
            this.Close();
        }

    }
}
