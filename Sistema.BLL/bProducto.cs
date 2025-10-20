using Sistema.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.BLL
{
    public class bProducto
    {
        private static readonly dProducto productoDal = new dProducto();
        public static DataTable listarProductos()
        {
            try
            {
                return productoDal.ListarProductos();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar los registros");
            }
        }
    }
}
