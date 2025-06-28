using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace eCommerce
{
    public partial class Ofertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<ProductosConImagenes> productos = negocio.ObtenerProductosConImagenes();

                var ofertas = productos.Where(p => p.descuento > 0).ToList();

                rptOfertas.DataSource = ofertas;
                rptOfertas.DataBind();
            }
        }

        protected void rptOfertas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var producto = (ProductosConImagenes)e.Item.DataItem;
                Repeater rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");
                if (rptImagenes != null)
                {
                    rptImagenes.DataSource = producto.Imagenes;
                    rptImagenes.DataBind();
                }
            }
        }
    }
}