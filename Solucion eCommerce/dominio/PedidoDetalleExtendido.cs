using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class PedidoDetalleExtendido : PedidoDetalle
    {
        public string nombreProducto { get; set; }
        public string marcaProducto { get; set; }
    }
}
