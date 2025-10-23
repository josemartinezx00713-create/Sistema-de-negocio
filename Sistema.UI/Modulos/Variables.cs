using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.UI.Modulos
{
    public class Variables
    {
        public static int idUsuario { get; set; } = 2;
        public static string usuario { get; set; }
        public static int terminarVenta { get; set; } = 0;
        public static decimal montoEfectivo { get; set; } = 0;
        public static decimal montoTarjeta { get; set; } = 0;
        public static decimal cambio { get; set; } = 0;
        public static string numeroFactura { get; set; }
        public static int idProducto { get; set; }
        public static string nombreProducto { get; set; }
        public static int cantidad { get; set; }
        public static decimal precioCompra { get; set; } = 0;
        public static decimal precioVenta { get; set; } = 0;
        public static int stock { get; set; }
    }
}
