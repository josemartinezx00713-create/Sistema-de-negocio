using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class oProductos
    {
        public int idProducto { get; set; }
        public string codigo { get; set; }
        public int stock { get; set; }
        public string nombre { get; set; }
        public int idCategoria { get; set; }
        public decimal costo { get; set; }
        public decimal precio { get; set; }
        //public DateTime fechaCreacion { get; set; }
    }
}
