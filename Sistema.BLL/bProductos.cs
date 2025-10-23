using Sistema.DAL;
using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.BLL
{
    public class bProductos
    {
        private static readonly dProductos datos = new dProductos();

        public static DataTable ListarProductos()
        {
            return datos.ListarProductos();
        }

        public static resultadoOperacion RegistrarProductos(oProductos producto)
        {
            try
            {
                bool resultado = datos.RegistrarProductos(producto);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Producto registrado correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo registrar el Producto" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

        public static resultadoOperacion Actualizar(oProductos producto)
        {
            try
            {
                bool resultado = datos.ActualizarProducto(producto);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Producto actualizado correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo actualizar el Producto" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

        public static string Eliminar(int idProducto)
        {
            if (idProducto <= 0)
                return "Debe especificar un Producto válido";

            try
            {
                bool resultado = datos.EliminarProducto(idProducto);
                return resultado ? "Producto eliminado correctamente" : "No se pudo eliminar el Producto";
            }
            catch
            {
                return "Error al eliminar el Producto";
            }
        }

        public static DataTable Buscar(int Filtro, string Valor)
        {
            return datos.BuscarProductos(Filtro, Valor);
        }

    }
}
