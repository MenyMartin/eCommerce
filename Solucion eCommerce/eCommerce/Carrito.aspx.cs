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

                decimal total = items.Sum(x => x.Subtotal);
                lblTotal.Text = "Total: $" + total.ToString("0.00");
            }
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            string medioPago = ddlMedioPago.SelectedValue;

            if (string.IsNullOrEmpty(medioPago))
            {
                lblMensaje.Text = "Por favor, seleccione un medio de pago.";
                lblMensaje.CssClass = "alert alert-warning";
                return;
            }

            CarritoNegocio carritoNegocio = new CarritoNegocio();
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            Usuario usuario = (Usuario)Session["usuario"];
            usuario.DNI = ((Usuario)Session["usuario"]).DNI;

            long dni = usuario.DNI;
            var items = carritoNegocio.ObtenerItemsCarrito(usuario.DNI);

            if (items.Count == 0)
            {
                lblMensaje.Text = "El carrito está vacío.";
                lblMensaje.CssClass = "alert alert-info";
                return;
            }

            decimal total = items.Sum(x => x.cantidad * x.precioUnitario);

            // 1. Crear pedido
            Pedido nuevoPedido = new Pedido
            {
                dni = dni, //guardo el dni en sesion en dni atributo de Pedido
                fechaPedido = DateTime.Now,
                estado = "Pendiente",
                total = (decimal)total
            };

            int idPedido = pedidoNegocio.CrearPedido(nuevoPedido);

            // 2. Crear detalles
            foreach (var item in items)
            {
                PedidoDetalle detalle = new PedidoDetalle
                {
                    idPedido = idPedido,
                    idProducto = item.idProducto,
                    cantidad = item.cantidad,
                    precioUnitario = (int)item.precioUnitario,
                    subtotal = (int)(item.cantidad * item.precioUnitario)
                };

                pedidoNegocio.AgregarDetalle(detalle);
            }

            // 3. Cerrar carrito
            carritoNegocio.CerrarCarrito(dni);

            try
            {
                EmailService emailService = new EmailService();
                string cuerpo = $"Tu pedido #{idPedido} fue registrado exitosamente el {DateTime.Now}.<br>" +
                                $"Total: ${total}<br>" +
                                "Pronto recibirás más información sobre el estado del envío.";
                emailService.correoCompra(usuario.email, cuerpo, usuario.nombre);
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {                
                lblMensaje.Text = "Compra realizada, pero no se pudo enviar el email.";
                throw ex;
            }

            lblMensaje.Text = "¡Compra finalizada correctamente!";
            lblMensaje.CssClass = "alert alert-success";
            Response.Redirect("MiPerfil.aspx");
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
            }
        }


    }
}