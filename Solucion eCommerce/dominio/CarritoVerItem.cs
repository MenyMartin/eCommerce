using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class CarritoVerItem
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string imagenURL { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal Subtotal
        {
            get { return precioUnitario * cantidad; }
        }
    }
}
