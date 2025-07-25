using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class PedidoDetalle
    {
        public int idDetallePedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subtotal { get; set; }

    }
}
