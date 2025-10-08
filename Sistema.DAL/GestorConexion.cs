using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sistema.DAL
{
    public static class GestorConexion
    {
        private static readonly string carpeta =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LaTerminal");

        private static readonly string archivo = Path.Combine(carpeta, "conexion.json");

        /// <summary>
        /// Guardar la cadena de conexión en un archivo JSON.
        /// </summary>
        /// 

        public static void GuardarConexion(DatosConexion datosConexion)
        {
            try
            {
                if (!Directory.Exists(carpeta))
                  Directory.CreateDirectory(carpeta);

                //Convertir el objeto a JSON
                var json = JsonSerializer.Serialize(datosConexion, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(archivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la conexión: " + ex.Message);
            }
        }

        /// <summary>
        /// Cargar la cadena de conexión desde un archivo JSON.
        /// </summary>
        /// 

        public static DatosConexion CargarDatosConexion()
        {
            try
            {
                if (!File.Exists(archivo))
                    return new DatosConexion();

                var json = File.ReadAllText(archivo);
                return JsonSerializer.Deserialize<DatosConexion>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar la conexión: " + ex.Message);
            }
        }

        /// <summary>
        /// Devolver la cadena de conexión lista para usar desde nuestros metodos.
        /// </summary>
        /// 

        public static SqlConnection ObtenerConexion()
        {
            var datosConexion = CargarDatosConexion();

            if(string.IsNullOrEmpty(datosConexion.servidor) ||
                string.IsNullOrEmpty(datosConexion.baseDatos) ||
                string.IsNullOrEmpty(datosConexion.usuario) ||
                string.IsNullOrEmpty(datosConexion.clave))
            {
                throw new Exception("La configuración de la conexión es incompleta.");
            }
            return new SqlConnection(datosConexion.CadenaConexion);
        }

        /// <summary>
        /// Probar la conexión a la base de datos con los datos proporcionados.
        /// </summary>
        /// 

        public static bool ProbarConexion(DatosConexion datosConexion, out string error)
        {
            try
            {
                using (var cn = new SqlConnection(datosConexion.CadenaConexion))
                {
                    cn.Open();
                    error = null;
                    return true;
                }
               
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
