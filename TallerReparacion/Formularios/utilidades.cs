using System;
using System.Data;
using System.Windows.Forms;
using TallerReparacion.Datos;

namespace TallerReparacion.Formularios
{
    internal class utilidades
    {
        public void CalculaStock(int cod_articulo)
        {
            DataTable tabla = new DbManage().ObtenerMovimientos(cod_articulo);
            int stock = 0;
            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    string tipoMovimiento = row.Field<string>(3);
                    long cantidadMovimiento = row.Field<long>(5);
                    if (tipoMovimiento == "Entrada")
                    {
                        stock += (int)cantidadMovimiento;
                    }
                    else if (tipoMovimiento == "Salida")
                    {
                        stock -= (int)cantidadMovimiento;
                    }
                }
            }

            if (stock < 0)
            {
                MessageBox.Show($"El stock del articulo {cod_articulo} es menor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (stock < 3)
            {
                MessageBox.Show($"El stock del articulo {cod_articulo} es menor de tres unidades.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            DbManage db = new DbManage();
            bool resultado = db.ActualizaStock(cod_articulo, stock);
            if (!resultado)
            {
                MessageBox.Show("Error al actualizar el stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}