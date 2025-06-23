using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ProductosConImagenes : Producto
    {
        public List<string> Imagenes { get; set; }
    }
}
