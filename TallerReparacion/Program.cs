using System;
using System.Drawing;
using System.Windows.Forms;

namespace TallerReparacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Frm_inicio inicioForm = Frm_inicio.GetInstance();
            Application.Run(inicioForm);
            

            
        }
    }
}
