using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class oGasto
    {
        public int IdGasto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCuenta { get; set; }
        public string Cuenta { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}
