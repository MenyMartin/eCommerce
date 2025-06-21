using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int DNI { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }
        public int dni { get; set; }
        public String direccion { get; set; }
        public String URLFotoPerfil { get; set; }
        public Fecha fechaRegistro { get; set; }
        public int idperfil { get; set; }
        public String email { get; set; }
        public String contraseña { get; set; }
    }
}
