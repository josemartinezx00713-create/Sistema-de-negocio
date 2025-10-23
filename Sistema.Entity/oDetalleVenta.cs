using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class oDetalleVenta
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal subtotal { get; set; }
    }
}
