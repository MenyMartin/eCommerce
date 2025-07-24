using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace eCommerce
{
    public partial class Ventas : System.Web.UI.Page
    {
        public List<ProductosConImagenes> listaProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                ProductoNegocio negocio = new ProductoNegocio();
                listaProductos = negocio.listarPorVendedor(usuario.DNI);

                rptProductos.DataSource = listaProductos;
                rptProductos.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("AltaProducto.aspx");
        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EdicionProducto.aspx?id=" + idProducto);
            }
        }


        protected void rptProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var producto = (ProductosConImagenes)e.Item.DataItem;

                Repeater rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");
                rptImagenes.DataSource = producto.Imagenes;
                rptImagenes.DataBind();
            }
        }


    }
}