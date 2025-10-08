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
    public class bCuentasGasto
    {
        private static readonly dCuentasGasto cuentaDal = new dCuentasGasto();

        public static DataTable Listar()
        {
            try
            {
                return cuentaDal.ListarCuentas();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar los registros");
            }
        }

        public static DataTable Buscar(string nombre)
        {
            return cuentaDal.BuscarCuenta(nombre);
        }

        public static resultadoOperacion Registrar(oCuentasGasto cuenta)
        {
            try
            {
                bool resultado = cuentaDal.RegistrarCuenta(cuenta);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Cuenta registrada correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo registrar la cuenta" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

        public static resultadoOperacion Actualizar(oCuentasGasto cuenta)
        {
            try
            {
                bool resultado = cuentaDal.ActualizarCuenta(cuenta);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Cuenta actualizada correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo actualizar la cuenta" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

        public static string Eliminar(int idCuenta)
        {
            if (idCuenta <= 0)
                return "Debe especificar una cuenta válida";

            try
            {
                bool resultado = cuentaDal.EliminarCuenta(idCuenta);
                return resultado ? "Cuenta eliminada correctamente" : "No se pudo eliminar la cuenta";
            }
            catch
            {
                return "Error al eliminar la cuenta de gasto";
            }
        }
    }
}
