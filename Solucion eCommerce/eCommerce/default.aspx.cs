using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<ProductosConImagenes> productos = negocio.ObtenerProductosConImagenes();

                string terminoBusqueda = Request.QueryString["buscar"];

                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    string termino = terminoBusqueda.ToLower();

                    // Filtrar busqueda
                    productos = productos.Where(p =>
                        (!string.IsNullOrEmpty(p.nombre) && p.nombre.ToLower().Contains(termino)) ||
                        (!string.IsNullOrEmpty(p.descripcion) && p.descripcion.ToLower().Contains(termino)) ||
                        (!string.IsNullOrEmpty(p.tipo) && p.tipo.ToLower().Contains(termino)) ||
                        (!string.IsNullOrEmpty(p.marca) && p.marca.ToLower().Contains(termino))
                    ).ToList();
                }


                rptProductos.DataSource = productos;
                rptProductos.DataBind();
            }

        }

        protected void rptProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ProductosConImagenes producto = (ProductosConImagenes)e.Item.DataItem;
                Repeater rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");
                rptImagenes.DataSource = producto.Imagenes;
                rptImagenes.DataBind();
            }
        }
    }
}