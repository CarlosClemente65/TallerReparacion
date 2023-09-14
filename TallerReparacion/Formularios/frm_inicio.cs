using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerReparacion.Datos;
using TallerReparacion.Formularios;

namespace TallerReparacion
{
    public partial class Frm_inicio : Form
    {
        //Control para hacer las copias de seguridad de la base de datos
        //Si la variable controlBakcupBD se estable en 'true' se lanzara el chequeo de la base de datos, y si se establece en 'false' no se hara la copia de seguridad. 
        private static bool controlBackupBD = false;
        private static Frm_inicio instance;

        public static Frm_inicio GetInstance()
        {
            //Creamos una instancia del formulario inicio para que cada vez que se cargue no se creen varias instancias del mismo, ya que al llamarse desde varios metodos, se crea un formulario cada vez.
            if (instance == null)
            {
                instance = new Frm_inicio();
            }
            return instance;
        }
        public Frm_inicio()
        {
            InitializeComponent();
            ConexionDB conexion = new ConexionDB();
            Load += Frm_inicio_Load; //Asocia el evento Load al metodo Frm_inicio_Load
        }

        private async void Frm_inicio_Load(object sender, EventArgs e)
        {
            // Realizar chequeo de existencia de la base de datos
            ConexionDB conexion = new ConexionDB();
            conexion.ChequeoDll();
            conexion.ChequeoDB();
            if (controlBackupBD)
            {
                controlBackupBD = false;

                // Realizar la copia de seguridad
                await Task.Run(() =>
                {
                    DbManage db = new DbManage();
                    db.BackupBD();
                });
            }
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario hizo clic en "No", cancelamos el cierre del formulario
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Btn_clientes_Click(object sender, EventArgs e)
        {
            frm_clientes formulario = new frm_clientes();
            this.Hide();
            formulario.Show();
        }

        private void Btn_articulos_Click(object sender, EventArgs e)
        {
            frm_almacen formulario = new frm_almacen();
            this.Hide();
            formulario.Show();
        }

        private void Btn_ordenes_Click(object sender, EventArgs e)
        {
            frm_ordenes formulario = new frm_ordenes();
            this.Hide();
            formulario.Show();
        }

        private void Frm_inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Frm_inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
