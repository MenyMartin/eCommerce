using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        public int idProducto { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String marca { get; set; }
        public String tipo { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int DNIVendedor { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public String estado { get; set; }
        public int descuento { get; set; }

    }
}
