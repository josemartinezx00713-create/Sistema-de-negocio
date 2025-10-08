using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
     public  class oUsuario
    {
        public int idUsuario {  get; set; }
        public string dniUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string codigoUsuario { get; set; }
        public  string email {  get; set; }
        public string clave { get; set; }
        public int idRol { get ; set; }
    }
}