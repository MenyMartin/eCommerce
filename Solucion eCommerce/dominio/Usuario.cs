using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Usuario
    {
        public int idUsuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }
        public int dni { get; set; }
        public String direccion { get; set; }
        public String fotoPerfil { get; set; }
        public int idperfil { get; set; }
    }
}
