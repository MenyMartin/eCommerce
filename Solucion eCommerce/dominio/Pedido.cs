using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Pedido
    {
        public int idPedido { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaPedido { get; set; }
        public String estado { get; set; }
        public int total { get; set; }

    }
}
