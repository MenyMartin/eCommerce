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
    public partial class SeguimientoPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int idPedido = Convert.ToInt32(Request.QueryString["id"]);
                CargarPedido();

            }
        }

        private void CargarPedido()
        {
            string idPedidoStr = Request.QueryString["idPedido"];
            if (string.IsNullOrEmpty(idPedidoStr))
            {
                Response.Redirect("ListaVentas.aspx");
                return;
            }

            int idPedido = int.Parse(idPedidoStr);

            var pedidoNegocio = new PedidoNegocio();
            var usuarioNegocio = new UsuarioNegocio();

            Pedido pedido = pedidoNegocio.BuscarPorIdConDetalles(idPedido);
            if (pedido == null)
            {
                Response.Redirect("ListaVentas.aspx");
                return;
            }

            Usuario cliente = usuarioNegocio.BuscarPorDNI(pedido.dni);

            lblEncabezado.Text = $"Pedido #{pedido.idPedido}";
            lblCliente.Text = cliente != null ? $"{cliente.nombre} {cliente.apellido}" : "Cliente desconocido";
            lblFecha.Text = pedido.fechaPedido.ToString("dd/MM/yyyy HH:mm");
            lblEstado.Text = pedido.estado;
            lblTotal.Text = pedido.total.ToString("0.00");
            lblTipoPago.Text = pedido.nombreTipoPago;
            lblEntrega.Text = pedido.entrega;

            rptDetalles.DataSource = pedido.detalles.Select(d => new
            {
                d.nombreProducto,
                d.marcaProducto,
                d.cantidad,
                subtotal = d.cantidad * d.precioUnitario
            }).ToList();
            rptDetalles.DataBind();

            hfIdPedido.Value = pedido.idPedido.ToString();
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            int idPedido = Convert.ToInt32(hfIdPedido.Value);
            string nuevoEstado = ddlEstadoNuevo.SelectedValue;

            PedidoNegocio negocio = new PedidoNegocio();
            negocio.CambiarEstadoPedido(idPedido, nuevoEstado);

            lblEstado.Text = nuevoEstado;

            lblMensaje.Text = "¡El estado del pedido se actualizó correctamente!";
            lblMensaje.CssClass = "alert alert-success";
        }
    }
}
