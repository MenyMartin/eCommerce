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
    public partial class Admin : System.Web.UI.Page
    {      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<ProductosConImagenes> listaProductos = negocio.ObtenerTodosProductosConImagenes();

                rptProductos.DataSource = listaProductos;
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