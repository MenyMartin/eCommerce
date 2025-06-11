using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Producto
    {
        public int idProducto { get; set; }
        public String nombre { get; set; }
        public String marca { get; set; }
        public String tipo { get; set; }
        public int precio { get; set; }
        public int stock { get; set; }
        public int idVendedor { get; set; }

    }
}
