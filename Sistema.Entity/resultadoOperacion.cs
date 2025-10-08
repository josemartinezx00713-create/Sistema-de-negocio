using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class resultadoOperacion
    {
        public bool esValido { get; set; }
        public string mensaje { get; set; }
        public string campoInvalido { get; set; }
        public bool Exito { get; set; }
    }
}
