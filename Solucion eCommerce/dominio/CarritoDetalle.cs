using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class CarritoDetalle
    {
        public int idDetalleCarrito { get; set; }
        public int idCarrito { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int precioUnitario { get; set; }

    }
}
