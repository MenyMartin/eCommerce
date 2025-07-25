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
    public partial class Carrito : System.Web.UI.Page
    {
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

                CarritoNegocio negocio = new CarritoNegocio();
                var items = negocio.ObtenerItemsCarrito(usuario.DNI);

                rptCarrito.DataSource = items;
                rptCarrito.DataBind();                

                //decimal total = items.Sum(x => x.Subtotal);
                //lblTotal.Text = "Total: $" + total.ToString("0.00");
            }
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            
        }
    }
}