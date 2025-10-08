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
    public class bGasto
    {
        private static readonly dGasto gastoDal = new dGasto();

        public static DataTable Listar()
        {
            return gastoDal.ListarGastos();
        }

        public static DataTable Buscar(DateTime fechaInicio, DateTime fechaFinal)
        {
            return gastoDal.BuscarGastos(fechaInicio, fechaFinal);
        }

        public static resultadoOperacion Registrar(oGasto gasto)
        {
            try
            {
                bool resultado = gastoDal.RegistrarGasto(gasto);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Gasto registrado correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo registrar el gasto" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

        public static resultadoOperacion Actualizar(oGasto gasto)
        {
            try
            {
                bool resultado = gastoDal.ActualizarGasto(gasto);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Gasto actualizado correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo actualizar el gasto" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

        public static string Eliminar(int idGasto)
        {
            if (idGasto <= 0)
                return "Debe especificar un gasto válido";

            try
            {
                bool resultado = gastoDal.EliminarGasto(idGasto);
                return resultado ? "Gasto eliminado correctamente" : "No se pudo eliminar el gasto";
            }
            catch
            {
                return "Error al eliminar el gasto";
            }
        }
    }
}
