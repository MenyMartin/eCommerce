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
        public long DNISolicitante { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }
        
    }
}
