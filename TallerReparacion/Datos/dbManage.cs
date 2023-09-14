using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Data.SQLite;
using gestionBD;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;

namespace TallerReparacion.Datos
{
    public class DbManage
    {
        //Declaracion de variables
        string dbPath = ConfiguracionBD.RutaBD;
        ConexionDB conexionBD = new ConexionDB();

        #region Gestion clientes

        public DataTable ObtenerClientes(string estado)
        {
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);
            try
            {
                string sql = "SELECT * FROM clientes";
                if (estado == "A")
                {
                    sql += " WHERE activo_cl =1";
                }
                else if (estado == "I")
                {
                    sql += " WHERE activo_cl=0";
                }

                tabla = conexionBD.consultaSQL(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los clientes: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public DataTable ConsultaCliente(int idCliente)
        {
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);
            try
            {
                string sql = "SELECT * FROM clientes WHERE id_cliente = " + idCliente;
                tabla = conexionBD.consultaSQL(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del cliente: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public bool AltaCliente(string nombre, string telefono, string email, string direccion, string cpostal, string poblacion, string provincia)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "INSERT INTO clientes (nombre_cl, telefono_cl, email_cl, direccion_cl, cpostal_cl, poblacion_cl, provincia_cl) VALUES (@nombre, @telefono, @email, @direccion, @cpostal, @poblacion, @provincia)";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@nombre"] = nombre,
                    ["@telefono"] = telefono,
                    ["@email"] = email,
                    ["@direccion"] = direccion,
                    ["@cpostal"] = cpostal,
                    ["@poblacion"] = poblacion,
                    ["@provincia"] = provincia
                };
                conexionBD.operacionSQL(sql, parametros);
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el cliente: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }

        public bool ActualizaCliente(int idcliente, string nombre, string telefono, string email, string direccion, string cpostal, string poblacion, string provincia, bool activo)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "UPDATE clientes SET nombre_cl=@nombre, telefono_cl=@telefono, email_cl=@email, direccion_cl=@direccion, cpostal_cl=@cpostal, poblacion_cl=@poblacion, provincia_cl=@provincia, activo_cl=@activo WHERE id_cliente =@idcliente";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@idcliente"] = idcliente,
                    ["@nombre"] = nombre,
                    ["@telefono"] = telefono,
                    ["@email"] = email,
                    ["@direccion"] = direccion,
                    ["@cpostal"] = cpostal,
                    ["@poblacion"] = poblacion,
                    ["@provincia"] = provincia,
                    ["@activo"] = activo
                };
                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }
        #endregion

        #region utilidades

        public string ObtenerProvincia(string codPro)
        {
            string nombreProvincia = "";
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);
            try
            {
                string sql = "SELECT * FROM provincias WHERE cod_provincia = '" + codPro + "'";
                tabla = conexionBD.consultaSQL(sql);
                if (tabla.Rows.Count > 0)
                {
                    nombreProvincia = tabla.Rows[0]["nombre_provincia"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La provincia no existe en la tabla: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return nombreProvincia;
        }

        public void BackupBD()
        {
            conectar conexionBD = new conectar(dbPath);
            int intervaloCopias = 28;
            string backupPath = @".\datos\";
            string[] backupFiles = Directory.GetFiles(backupPath, "backup_*.db");
            DateTime ultimaFechaBackup = DateTime.MinValue;
            string ultimoFicheroBackup = null;
            string mensajeCopia = string.Empty;
            if (backupFiles.Length > 0)
            {
                foreach (string file in backupFiles)
                {
                    string fileName = Path.GetFileName(file);
                    string fileDateStr = fileName.Substring(7, 13);
                    DateTime fileDate = DateTime.ParseExact(fileDateStr, "ddMMyyyy_HHmm", CultureInfo.InvariantCulture);
                    if (fileDate > ultimaFechaBackup)
                    {
                        ultimaFechaBackup = fileDate;
                        ultimoFicheroBackup = fileName;
                    }
                }
                mensajeCopia = $"La ultima copia de seguridad se hizo el {ultimaFechaBackup:d 'de' MMMM 'de' yyyy} a las {ultimaFechaBackup:HH:mm}. \nQuiere hacer una nueva?";
            }
            else
            {
                mensajeCopia = "No se ha hecho ninguna copia de seguridad todavia. \nQuiere hacer una nueva? ";
            }
            if (ultimoFicheroBackup == null || (DateTime.Now - ultimaFechaBackup).TotalDays >= intervaloCopias)
            {
                DialogResult resultado = MessageBox.Show(mensajeCopia, "Chequeo copia de seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {

                    string backupName = $"backup_{DateTime.Now:ddMMyyyy_HHmm}.db";
                    string backupFullPath = Path.Combine(backupPath, backupName);
                    try
                    {
                        using (SQLiteConnection srcCon = conexionBD.crearConexion())
                        using (SQLiteConnection destCon = new SQLiteConnection("Data Source=" + backupFullPath + ";Version=3"))
                        {
                            destCon.Open();
                            srcCon.BackupDatabase(destCon, "main", "main", -1, null, 0);
                            destCon.Close();
                        }
                        MessageBox.Show("Copia de seguridad realizada con exito", "Copia de seguridad");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Ha ocurrido un error al hacer la copida de seguridad de la base de datos: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #endregion


        #region Gestion articulos
        public bool AltaArticulos(string descripcion, string codigo, int stock, float pcompra, float pventa)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "INSERT INTO articulos (nombre_ar, codigo_ar, stock_ar, precioCompra_ar, precioVenta_ar) VALUES (@descripcion, @codigo, @stock, @pcompra, @pventa)";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@descripcion"] = descripcion,
                    ["@codigo"] = codigo,
                    ["@stock"] = stock,
                    ["@pcompra"] = pcompra,
                    ["@pventa"] = pventa
                };
                conexionBD.operacionSQL(sql, parametros);
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el articulo: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }


        public bool ActualizaArticulos(int idarticulo, string descripcion, string codigo, int stock, float pcompra, float pventa, bool activo)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "UPDATE articulos SET nombre_ar=@descripcion, codigo_ar=@codigo, stock_ar=@stock, precioCompra_ar=@pcompra, precioVenta_ar=@pventa, activo_ar=@activo WHERE id_ar =@idarticulo";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@idarticulo"] = idarticulo,
                    ["@descripcion"] = descripcion,
                    ["@codigo"] = codigo,
                    ["@stock"] = stock,
                    ["@pcompra"] = pcompra,
                    ["@pventa"] = pventa,
                    ["@activo"] = activo
                };
                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el articulo: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }

        public DataTable ObtenerArticulos(string estado, int? idArticulo = null)
        {
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "SELECT * FROM articulos";
                if (idArticulo.HasValue)
                {
                    sql += " WHERE id_ar = " + idArticulo;
                }
                else
                {
                    if (estado == "A")
                    {
                        sql += " WHERE activo_ar =1";
                    }
                    else if (estado == "I")
                    {
                        sql += " WHERE activo_ar=0";
                    }
                }

                tabla = conexionBD.consultaSQL(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los articulos: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public bool ActualizaStock(int idarticulo, int stock)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "UPDATE articulos SET stock_ar=@stock WHERE id_ar =@idarticulo";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@idarticulo"] = idarticulo,
                    ["@stock"] = stock,
                };
                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el stock: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }


        #endregion


        #region Gestion movimientos articulos

        public DataTable ObtenerMovimientos(int cod_articulo)
        {
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);
            try
            {
                string sql = "SELECT * FROM movimientos_ar WHERE codigo_ar_ma=" + cod_articulo;

                tabla = conexionBD.consultaSQL(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los estados: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public bool AltaMovimientos(DateTime fecha, int cod_articulo, string tipo_ES, string origen, int cantidad, int idOrden)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "INSERT INTO movimientos_ar (fecha_ma, codigo_ar_ma, tipo_ma, origen_ma, cantidad_ma, id_orden) VALUES (@fecha, @cod_articulo, @tipo_ES, @origen, @cantidad, @idOrden)";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@fecha"] = fecha,
                    ["@cod_articulo"] = cod_articulo,
                    ["@tipo_ES"] = tipo_ES,
                    ["@origen"] = origen,
                    ["@cantidad"] = cantidad,
                    ["@idOrden"] = idOrden
                };
                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el articulo: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }

        public bool ModificarMovimiento(int id_movimiento, DateTime fecha, int cod_articulo, string tipo_ES, string origen, int cantidad)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "UPDATE movimientos_ar SET id_ma=@id_movimiento, fecha_ma=@fecha, codigo_ar_ma=@cod_articulo, tipo_ma=@tipo_ES, origen_ma=@origen, cantidad_ma=@cantidad WHERE id_ma =@id_movimiento";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@id_movimiento"] = id_movimiento,
                    ["@fecha"] = fecha,
                    ["@cod_articulo"] = cod_articulo,
                    ["@tipo_ES"] = tipo_ES,
                    ["@origen"] = origen,
                    ["@cantidad"] = cantidad
                };

                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el movimiento: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }

        public bool BorrarMovimientos(int idOrden)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "DELETE FROM movimientos_ar WHERE id_orden = @idOrden AND tipo_ma = 'Salida'";

                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@idOrden"] = idOrden
                };

                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar los movimientos de la orden: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }

            return resultado;
        }


        #endregion

        #region Ordenes
        public DataTable ObtenerEstados()
        {
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);
            try
            {
                string sql = "SELECT * FROM estados_or";
                tabla = conexionBD.consultaSQL(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los estados: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return tabla;
        }
        public void CargarEstados(ListBox lb, DataTable dt, string columna)
        {
            lb.Items.Clear();
            foreach (DataRow fila in dt.Rows)
            {
                lb.Items.Add(fila[columna].ToString());
            }
        }

        public DataTable ObtenerOrdenes()
        {
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);
            try
            {
                string sql = "SELECT ordenes.id_orden, clientes.nombre_cl, clientes.telefono_cl, clientes.email_cl, ordenes.terminal_or, ordenes.fechaAlta_or, ordenes.fechaEstimada_or, ordenes.fechaFin_or, estados_or.descripcion_eo, estados_or.codigo_eo, ordenes.id_cliente_or, ordenes.descripcion_or, ordenes.activo_or, ordenes.estado_or " + "FROM ordenes " + "INNER JOIN clientes ON ordenes.id_cliente_or = clientes.id_cliente " + "INNER JOIN estados_or ON ordenes.estado_or = estados_or.codigo_eo";
                tabla = conexionBD.consultaSQL(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las ordenes: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public int ObtenerUltimaOrden()
        {
            int maximo = 0;
            DataTable UltimaOrden = new DataTable();
            conectar conexionBD = new conectar(dbPath);
            try
            {
                string sql = "SELECT id_orden FROM ordenes";
                UltimaOrden = conexionBD.consultaSQL(sql);
                if (UltimaOrden.Rows.Count > 0)
                {
                    //maximo = UltimaOrden.AsEnumerable().Max(fila => fila.Field<Int32>("id_orden"));
                    foreach (DataRow fila in UltimaOrden.Rows)
                    {
                        string valor = fila["id_orden"].ToString();
                        if (int.TryParse(valor, out int numero))
                        {
                            // La conversión fue exitosa, actualiza el máximo si es necesario
                            if (numero > maximo)
                            {
                                maximo = numero;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la ultima orden: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return maximo+1;
        }

        public bool ActualizarOrdenes(string tipo, int idOrden, int idCliente, DateTime fechaAlta, DateTime? fechaEstimada, DateTime? fechaFin, string terminal, string descripcion, int estado, bool activo)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "";
                if (tipo == "Modificar")
                {
                    sql += "UPDATE ordenes SET id_cliente_or=@idCliente, fechaAlta_or=@fechaAlta, fechaEstimada_or=@fechaEstimada, fechaFin_or=@fechaFin, terminal_or=@terminal, descripcion_or=@descripcion, estado_or=@estado, activo_or=@activo WHERE id_orden =@idOrden";
                }
                else
                {
                    sql += "INSERT INTO ordenes (id_cliente_or, fechaAlta_or, fechaEstimada_or, fechaFin_or, terminal_or, descripcion_or, estado_or, activo_or) VALUES (@idCliente, @fechaAlta, @fechaEstimada, @fechaFin, @terminal, @descripcion, @estado, @activo)";
                }

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@idcliente"] = idCliente,
                    ["@fechaAlta"] = fechaAlta,
                    ["@fechaEstimada"] = fechaEstimada,
                    ["@fechaFin"] = fechaFin,
                    ["@terminal"] = terminal,
                    ["@descripcion"] = descripcion,
                    ["@estado"] = estado,
                    ["@activo"] = activo,
                    ["@idOrden"] = idOrden
                };
                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                if (tipo == "Modificar")
                {
                    MessageBox.Show("Error al actualizar la orden: " + ex.Message);
                }
                else
                {
                    MessageBox.Show("Error al dar de alta la orden: " + ex.Message);
                }
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }

        public DataTable ObtenerMateriales(int idOrden, int? idMaterial = null)
        {
            DataTable tabla = new DataTable();
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "SELECT materiales.fechaAlta_ma, materiales.id_material, articulos.nombre_ar, materiales.cantidad, materiales.precio, materiales.importe, materiales.cod_articulo, materiales.id_orden  FROM materiales INNER JOIN articulos ON materiales.cod_articulo = articulos.id_ar WHERE materiales.id_orden=" + idOrden;
                if (idMaterial.HasValue)
                {
                    sql += " AND id_material=" + idMaterial;
                }
                tabla = conexionBD.consultaSQL(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los materiales: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return tabla;
        }

        public bool AltaMateriales(int codArticulo, int idOrdenMat, decimal cantidad, decimal precio, decimal importe, DateTime fechaAlta)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "INSERT INTO materiales (cod_articulo, id_orden, cantidad, precio, importe, fechaAlta_ma) VALUES (@codArticulo, @idOrden, @cantidad, @precio, @importe, @fechaAlta)";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@codArticulo"] = codArticulo,
                    ["@idOrden"] = idOrdenMat,
                    ["@cantidad"] = cantidad,
                    ["@precio"] = precio,
                    ["@importe"] = importe,
                    ["@fechaAlta"] = fechaAlta
                };
                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de alta los materiales en la orden: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }

        public bool ModificarMateriales(int idMaterial, int idArticulo, int idOrdenMat, decimal cantidad, decimal precio, decimal importe, DateTime fechaAlta)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "UPDATE materiales SET id_material= @idMaterial, cod_articulo = @idArticulo, id_orden = @idOrden, cantidad = @cantidad, precio = @precio, importe = @importe, fechaAlta_ma = @fechaAlta WHERE id_material = @idMaterial";

                //Prepara un diccionario con los campos a pasar a la sentencia SQL que se pasa como parametro al metodo operacionSQL que los configura antes de ejecutar la sentencia
                Dictionary<string, object> parametros = new Dictionary<string, object>
                {
                    ["@idMaterial"] = idMaterial,
                    ["@idArticulo"] = idArticulo,
                    ["@idOrden"] = idOrdenMat,
                    ["@cantidad"] = cantidad,
                    ["@precio"] = precio,
                    ["@importe"] = importe,
                    ["@fechaAlta"] = fechaAlta
                };
                conexionBD.operacionSQL(sql, parametros);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los materiales de la orden: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }

        public bool EliminarMateriales(int idMaterial)
        {
            bool resultado = false;
            conectar conexionBD = new conectar(dbPath);

            try
            {
                string sql = "DELETE FROM materiales WHERE id_material =" + idMaterial;

                conexionBD.operacionSQL(sql);

                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el material de la orden: " + ex.Message);
            }
            finally
            {
                conexionBD.cerrarConexion();
            }
            return resultado;
        }


        #endregion

    }
}
