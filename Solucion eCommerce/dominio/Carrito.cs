using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Carrito
    {
        public int IdCarrito { get; set; }
        public int idUsuario { get; set; }
        public Fecha fechaCreacion { get; set; }
        public bool activo { get; set; }

    }
}
