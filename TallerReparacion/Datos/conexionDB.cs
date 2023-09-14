using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using gestionBD;
using System.Collections.Generic;

namespace TallerReparacion.Datos
{
    public class ConfiguracionBD
    {
        //Establece la configuracion de la base de datos (ruta y nombre)
        public static string RutaBD { get; set; }

        static ConfiguracionBD()
        {
            string ruta = @".\datos\";
            string nombre = "tallerReparacion.db";
            RutaBD = Path.Combine(ruta, nombre);
        }
    }

    public class ConexionDB
    {
        //Asignacion de variables
        string dbPath = ConfiguracionBD.RutaBD;
        //private SQLiteConnection conexion;

        public void ChequeoDB()
        {
            //Chequear si existe el la base de datos
            conectar conexionBD = new conectar(dbPath);
            bool resultado = conexionBD.chequeoBD();
            if (resultado)
            {
                //En el caso de que no exista la base de datos, se lanza la creacion de las tablas
                TablaClientes();
                TablaArticulos();
                TablaMovimientosArticulos();
                TablaOrdenes();
                TablaMateriales();
                TablaProvincias();
                TablaEstados_or();
            }
        }

        public void ChequeoDll()
        {
            //Chequear si estan en la carpeta de instalacion las dos librerias necesarias y no provocar una excepcion
            bool resultado = true;
            List<string> librerias = new List<string>();
            librerias.Add("gestionBD.dll");
            librerias.Add("System.Data.SQLite.dll");

            foreach (string fichero in librerias)
            {
                if (!File.Exists(fichero))
                {
                    MessageBox.Show($"Falta la libreria {fichero} en la carpeta de instalacion.\n\n Debe volver a instalar la aplicacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultado = false;
                }
                if (!resultado)
                {
                    Application.Exit();
                }
            }
        }
        public void CrearTablas(string sql, string tabla)
        {
            conectar conexion = new conectar(dbPath);
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conexion.crearConexion());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la creacion de la tabla de {tabla} " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        public void TablaClientes()
        {
            //Crea la tabla de clientes
            string sql = @"CREATE TABLE clientes
                            (id_cliente INTEGER PRIMARY KEY AUTOINCREMENT, 
                            nombre_cl VARCHAR(50) NOT NULL, 
                            telefono_cl VARCHAR(20) NOT NULL, 
                            email_cl VARCHAR(50),
                            direccion_cl VARCHAR(100), 
                            cpostal_cl VARCHAR(5), 
                            poblacion_cl VARCHAR (50), 
                            provincia_cl VARCHAR(50),
                            activo_cl BOOL DEFAULT 1);
                            ";
            CrearTablas(sql, "clientes");
        }

        public void TablaArticulos()
        {
            //Crea la tabla del articulos
            string sql = @"CREATE TABLE articulos 
                            (id_ar INTEGER PRIMARY KEY AUTOINCREMENT, 
                            nombre_ar VARCHAR(50) NOT NULL, 
                            codigo_ar VARCHAR(20),
                            stock_ar NUMERIC,
                            precioCompra_ar NUMERIC (8,2), 
                            precioVenta_ar NUMERIC (8,2), 
                            activo_ar BOOL DEFAULT 1);
                            ";
            CrearTablas(sql, "articulos");
        }

        public void TablaMovimientosArticulos()
        {
            //Crea la tabla del movimiento de articulos
            string sql = @"CREATE TABLE movimientos_ar 
                            (id_ma INTEGER PRIMARY KEY AUTOINCREMENT, 
                            fecha_ma DATE NOT NULL DEFAULT CURRENT_TIMESTAMP, 
                            codigo_ar_ma INTEGER NOT NULL,
                            tipo_ma VARCHAR (10),
                            origen_ma VARCHAR (20),
                            cantidad_ma INTEGER NOT NULL,
                            id_orden INTEGER,
                            FOREIGN KEY (codigo_ar_ma) REFERENCES articulos (id_ar) ON DELETE RESTRICT);
                            ";
            CrearTablas(sql, "movimientos de articulos");
        }

        public void TablaOrdenes()
        {
            //Crea la tabla de ordenes de reparacion
            string sql = @"CREATE TABLE ordenes (
                            id_orden INTEGER PRIMARY KEY AUTOINCREMENT, 
                            id_cliente_or INTEGER, 
                            fechaAlta_or DATE, 
                            terminal_or VARCHAR (50), 
                            descripcion_or VARCHAR (150), 
                            fechaEstimada_or DATE, 
                            fechaFin_or DATE, 
                            estado_or INTEGER, 
                            activo_or BOOL DEFAULT 1, 
                            FOREIGN KEY (id_cliente_or) REFERENCES clientes(id_cliente) ON DELETE RESTRICT);";
            CrearTablas(sql, "ordenes de reparacion");
        }

        public void TablaMateriales()
        {
            //Crea la tabla de materiales de las ordenes
            string sql = @"CREATE TABLE materiales (
                            id_material INTEGER PRIMARY KEY AUTOINCREMENT,
                            cod_articulo INTEGER,
                            id_orden INTEGER NOT NULL,
                            cantidad NUMERIC (4,2) NOT NULL,
                            precio NUMERIC (5,2) NOT NULL,
                            importe NUMERIC (5,2) NOT NULL,
                            fechaAlta_ma DATE,
                            FOREIGN KEY (id_orden) REFERENCES ordenes (id_orden) ON DELETE RESTRICT,
                            FOREIGN KEY (cod_articulo) REFERENCES articulos (id_ar) ON DELETE RESTRICT)";
            CrearTablas(sql, "materiales ordenes");
        }
        public void TablaEstados_or()
        {
            //Crea la tabla de estados de ordenes
            //Esta tabla no se ejecuta ya que se ha creado manualmente los valores en el comboBox
            string sql = @"CREATE TABLE estados_or 
                            (id_estado INTEGER PRIMARY KEY AUTOINCREMENT, 
                            codigo_eo INTEGER, 
                            descripcion_eo VARCHAR (20), 
                            activo_or BOOL DEFAULT 1);
                            ";
            CrearTablas(sql, "estados de ordenes");

            //Rellena la tabla con los valores
            string sql2 = @"INSERT INTO estados_or 
                            (id_estado, codigo_eo, descripcion_eo, activo_or) 
                            VALUES 
                                (1,0,'Orden creada', true), 
                                (2,1,'Pedido material', true), 
                                (3,2,'Orden en reparacion', true),
                                (4,3,'Orden terminada',true), 
                                (5,4,'Avisado cliente',true), 
                                (6,5,'Orden cerrada',true);";
            CrearTablas(sql2, "valores de estados de ordenes");
        }

        public void TablaProvincias()
        {
            //Crea la tabla de provincias
            string sql = @"CREATE TABLE provincias 
                            (id_provincia INTEGER PRIMARY KEY AUTOINCREMENT, 
                            cod_provincia VARCHAR (2), 
                            nombre_provincia VARCHAR (20));
                            ";
            CrearTablas(sql, "provincias");

            //Rellena la tabla con los valores
            string sql2 = (@"INSERT INTO provincias 
                            (id_provincia, cod_provincia, nombre_provincia) 
                            VALUES
                            (1,'02','Albacete'),
                            (2,'03','Alicante'),
                            (3,'04','Almeria'),
                            (4,'01','Alava'),
                            (5,'33','Asturias'),
                            (6,'05','Avila'),
                            (7,'06','Badajoz'),
                            (8,'07','Islas Baleares'),
                            (9,'08','Barcelona'),
                            (10,'48','Bizkaia'),
                            (11,'09','Burgos'),
                            (12,'10','Caceres'),
                            (13,'11','Cadiz'),
                            (14,'39','Cantabria'),
                            (15,'12','Castellon'),
                            (16,'51','Ceuta'),
                            (17,'13','Ciudad Real'),
                            (18,'14','Cordoba'),
                            (19,'15','La Coruña'),
                            (20,'16','Cuenca'),
                            (21,'20','Gipuzkoa'),
                            (22,'17','Girona'),
                            (23,'18','Granada'),
                            (24,'19','Guadalajara'),
                            (25,'21','Huelva'),
                            (26,'22','Huesca'),
                            (27,'23','Jaen'),
                            (28,'24','Leon'),
                            (29,'25','Lleida'),
                            (30,'27','Lugo'),
                            (31,'28','Madrid'),
                            (32,'29','Malaga'),
                            (33,'52','Melilla'),
                            (34,'30','Murcia'),
                            (35,'31','Navarra'),
                            (36,'32','Ourense'),
                            (37,'34','Palencia'),
                            (38,'35','Las Palmas'),
                            (39,'36','Pontevedra'),
                            (40,'26','La Rioja'),
                            (41,'37','Salamanca'),
                            (42,'38','Santa Cruz de Tenerife'),
                            (43,'40','Segovia'),
                            (44,'41','Sevilla'),
                            (45,'42','Soria'),
                            (46,'43','Tarragona'),
                            (47,'44','Teruel'),
                            (48,'45','Toledo'),
                            (49,'46','Valencia'),
                            (50,'47','Valladolid'),
                            (51,'49','Zamora'),
                            (52,'50','Zaragoza')");
            CrearTablas(sql2, "registros de provincias");
        }
    }
}
