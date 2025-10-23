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
    
    public class bCategoria
    {
        private static readonly dCategoria categoriaDal = new dCategoria();
        public static DataTable Listar()
        {
            try
            {
                return categoriaDal.ListarCategorias();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar los registros");
            }
        }

        public static resultadoOperacion Registrar(oCategoria dato)
        {
            try
            {
                bool resultado = categoriaDal.RegistrarCategoria(dato);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Categoria registrada correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo registrar la categoria" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

        public static DataTable Buscar(string valor)
        {
            return categoriaDal.BuscarCategoria(valor);
        }

        public static resultadoOperacion Actualizar(oCategoria dato)
        {
            try
            {
                bool resultado = categoriaDal.ActualizarCategoria(dato);
                return resultado
                    ? new resultadoOperacion { esValido = true, mensaje = "Categoria actualizada correctamente" }
                    : new resultadoOperacion { esValido = false, mensaje = "No se pudo actualizar la categoria" };
            }
            catch (Exception ex)
            {
                return new resultadoOperacion { esValido = false, mensaje = ex.Message };
            }
        }

    }
}
