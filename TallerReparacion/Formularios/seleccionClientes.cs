using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TallerReparacion.Datos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TallerReparacion.Formularios
{
    public partial class frm_seleccionClientes : Form
    {
        public string filtro_cl = "A";
        public bool estadoBotonAlta = false;
        public bool estadoBotonModificar = false;

        public frm_seleccionClientes(int idCliente, string opcion)
        {
            InitializeComponent();
            //Suscribe los textBox al evento TextChanged para que cualquier cambio lance la funcion de actulizar el dgv
            txt_filtroNombre.TextChanged += TextBox_TextChanged;
            txt_filtroMovil.TextChanged += TextBox_TextChanged;

            DataTable dt = new DbManage().ObtenerClientes(filtro_cl);
            DataTable dtOrdenada = new DataTable();
            //Ordena la tabla por el campo nombre cliente
            if (dt.Rows.Count == 0)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    dtOrdenada.Columns.Add(col.ColumnName, col.DataType);
                }
            }
            else
            {
                dtOrdenada = dt.AsEnumerable().OrderBy(row => row["nombre_cl"]).CopyToDataTable();
            }

            dgv_seleccionClientes.DataSource = dtOrdenada;
            dgv_seleccionClientes.Columns["id_cliente"].HeaderText = "Nº";
            dgv_seleccionClientes.Columns["nombre_cl"].HeaderText = "Nombre cliente";
            dgv_seleccionClientes.Columns["telefono_cl"].HeaderText = "Telefono";
            dgv_seleccionClientes.Columns["email_cl"].HeaderText = "Correo electronico";
            dgv_seleccionClientes.Columns["direccion_cl"].HeaderText = "Direccion";
            dgv_seleccionClientes.Columns["cpostal_cl"].HeaderText = "Cod.postal";
            dgv_seleccionClientes.Columns["poblacion_cl"].HeaderText = "Poblacion";
            dgv_seleccionClientes.Columns["provincia_cl"].HeaderText = "Provincia";
            dgv_seleccionClientes.Columns["activo_cl"].Visible = false;
            dgv_seleccionClientes.Columns["id_cliente"].Width = 50;
            dgv_seleccionClientes.Columns["nombre_cl"].Width = 250;
            dgv_seleccionClientes.Columns["email_cl"].Width = 220;
            dgv_seleccionClientes.Columns["direccion_cl"].Width = 220;
            dgv_seleccionClientes.Columns["cpostal_cl"].Width = 80;
            dgv_seleccionClientes.Columns["cpostal_cl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Selecciona la fila del cliente que se ha pasado como parametro
            if (opcion == "Modificar")
            {
                DataGridViewRow row = dgv_seleccionClientes.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id_cliente"].Value) == idCliente);
                if (row != null)
                {
                    dgv_seleccionClientes.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    int rowIndex = row.Index;
                    dgv_seleccionClientes.FirstDisplayedScrollingRowIndex = rowIndex;
                }
            }
        }

        private void btn_alta_Click(object sender, EventArgs e)
        {
            estadoBotonAlta = true;
            estadoBotonModificar = false;
            DataGridViewRow clienteSeleccionado = null;
            if (dgv_seleccionClientes.Rows.Count > 0)
            {
                clienteSeleccionado = dgv_seleccionClientes.SelectedRows[0];
            }
            frm_clientes formulario = new frm_clientes(estadoBotonAlta, estadoBotonModificar, clienteSeleccionado);
            formulario.ShowDialog();
            DataTable dt = new DbManage().ObtenerClientes(filtro_cl);
            dgv_seleccionClientes.DataSource = dt;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            estadoBotonModificar = true;
            estadoBotonAlta = false;
            DataGridViewRow clienteSeleccionado = dgv_seleccionClientes.SelectedRows[0];
            frm_clientes formulario = new frm_clientes(estadoBotonAlta, estadoBotonModificar, clienteSeleccionado);
            formulario.ShowDialog();
            DataTable dt = new DbManage().ObtenerClientes(filtro_cl);
            dgv_seleccionClientes.DataSource = dt;
        }

        private void dgv_seleccionClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_seleccion.PerformClick();
        }

        private void dgv_seleccionClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_seleccion_Click(object sender, EventArgs e)
        {
            int clienteSeleccionado = obtenerClienteSeleccionado();
            this.Close();
        }

        public int obtenerClienteSeleccionado()
        {
            int clienteSeleccionado = 0;
            if (dgv_seleccionClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgv_seleccionClientes.SelectedRows[0];
                clienteSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["id_cliente"].Value);
            }
            return clienteSeleccionado;
        }

        private void btn_seleccion_Click_1(object sender, EventArgs e)
        {
            int clienteSeleccionado = obtenerClienteSeleccionado();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            string filtroNombre = txt_filtroNombre.Text;
            string filtroMovil = txt_filtroMovil.Text;
            DataTable dt = new DbManage().ObtenerClientes(filtro_cl);

            // Llamar a la función actualizar() con los valores de filtro
            if (string.IsNullOrEmpty(filtroNombre) && string.IsNullOrEmpty(filtroMovil))
            {
                actualizarClientes(null, null); // Sin filtros
            }
            else if (string.IsNullOrEmpty(filtroNombre))
            {
                actualizarClientes(null, filtroMovil); // Filtrar solo por teléfono
            }
            else if (string.IsNullOrEmpty(filtroMovil))
            {
                actualizarClientes(filtroNombre, null); // Filtrar solo por nombre
            }
            else
            {
                actualizarClientes(filtroNombre, filtroMovil); // Filtrar por nombre y teléfono
            }
        }
        private void actualizarClientes(string filtroNombre = "", string filtroMovil = "")
        {
            DataTable dt = new DbManage().ObtenerClientes(filtro_cl);

            if (dt.Rows.Count == 0)
            {
                DataTable emptyTable = new DataTable();
                foreach (DataColumn col in dt.Columns)
                {
                    emptyTable.Columns.Add(col.ColumnName, col.DataType);
                }
                dgv_seleccionClientes.DataSource = emptyTable;
            }
            else
            {
                dgv_seleccionClientes.DataSource = dt;
            }

            // Establecer la posicion de las columnas después de asignar la fuente de datos
            dgv_seleccionClientes.Columns["id_cliente"].DisplayIndex = 0;
            dgv_seleccionClientes.Columns["nombre_cl"].DisplayIndex = 1;
            dgv_seleccionClientes.Columns["telefono_cl"].DisplayIndex = 2;
            dgv_seleccionClientes.Columns["email_cl"].DisplayIndex = 3;
            dgv_seleccionClientes.Columns["direccion_cl"].DisplayIndex = 4;
            dgv_seleccionClientes.Columns["cpostal_cl"].DisplayIndex = 5;
            dgv_seleccionClientes.Columns["poblacion_cl"].DisplayIndex = 6;
            dgv_seleccionClientes.Columns["provincia_cl"].DisplayIndex = 7;
            dgv_seleccionClientes.Columns["activo_cl"].DisplayIndex = 8;

            //Establece la ordenacion de la tabla por la columna fecha alta
            dgv_seleccionClientes.Sort(dgv_seleccionClientes.Columns["nombre_cl"], ListSortDirection.Ascending);

            filtrarDGV(dt, filtroNombre, filtroMovil, filtro_cl);
        }

        private void filtrarDGV(DataTable dt, string filtroNombre = "", string filtroMovil = "", string filtroEstado = "")
        {
            if (!string.IsNullOrEmpty(filtroNombre) || !string.IsNullOrEmpty(filtroMovil) || !string.IsNullOrEmpty(filtroEstado))
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


                if (!string.IsNullOrEmpty(filtroEstado))
                {
                    if (!string.IsNullOrEmpty(expresionFiltro))
                    {
                        expresionFiltro += " AND ";
                    }
                    switch (filtroEstado)
                    {
                        case "A":
                            {
                                expresionFiltro += $"activo_cl = true";
                                break;
                            }
                        case "I":
                            {
                                expresionFiltro += $"activo_cl = false";
                                break;
                            }
                        case "T":
                            {
                                expresionFiltro += "(activo_cl = true OR activo_cl = false)";
                                break;
                            }
                    }
                }
                dv.RowFilter = expresionFiltro;
                dt = dv.ToTable();
            }
        }
    }
}
