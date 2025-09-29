using Sistema.DAL;
using Sistema.UI.Formularios;
using Sistema.UI.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var mensaje = new Mensajes();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Si no hay datos de conexión, abrir el formulario de conexión
            var datosConexion = GestorConexion.CargarDatosConexion();

            if (string.IsNullOrEmpty(datosConexion.servidor) ||
               string.IsNullOrEmpty(datosConexion.baseDatos) ||
               string.IsNullOrEmpty(datosConexion.usuario) ||
               string.IsNullOrEmpty(datosConexion.clave))
            {
                using (var frm = new frmConexion())
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        mensaje.mensajeError("No se pudo establecer la conexión a la base de datos. La aplicación se cerrará.");
                        return;
                    }
                }
            }
            Application.Run(new MDIInterfazMenu());
        }
    }
}
