using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class oVenta
    {
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal CostoTotal { get; set; }
        public DataTable Detalles { get; set; }
    }
}
