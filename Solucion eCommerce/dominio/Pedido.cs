using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public long dni { get; set; }
        public DateTime fechaPedido { get; set; }
        public String estado { get; set; }
        public decimal total { get; set; }

        public int idTipoPago { get; set; }

        public List<PedidoDetalleExtendido> detalles { get; set; }

    }
}
