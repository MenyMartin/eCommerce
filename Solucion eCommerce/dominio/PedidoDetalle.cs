using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class PedidoDetalle
    {
        public int idDetallePedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int precioUnitario { get; set; }
        public int subtotal { get; set; }

    }
}
