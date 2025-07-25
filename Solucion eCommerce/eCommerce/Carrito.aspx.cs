using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

                if (Session["MensajeCarrito"] != null)
                {
                    lblMensaje.Text = Session["MensajeCarrito"].ToString();
                    lblMensaje.Visible = true;
                    Session.Remove("MensajeCarrito");
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

        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                Usuario usuario = (Usuario)Session["usuario"];

                int idProducto = Convert.ToInt32(e.CommandArgument);
                usuario.DNI = ((Usuario)Session["usuario"]).DNI;
                long dni = usuario.DNI;

                CarritoNegocio negocio = new CarritoNegocio();
                negocio.QuitarItemCarrito(dni, idProducto);

                Session["MensajeCarrito"] = "Producto eliminado correctamente del carrito.";
                Response.Redirect("Carrito.aspx");

                //negocio.ObtenerItemsCarrito(usuario.DNI); // método que recarga los datos del carrito
            }
        }
    }
}