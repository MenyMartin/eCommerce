using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        public long DNI { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }
        
    }
}
