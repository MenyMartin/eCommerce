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
    public partial class MisPedidos : System.Web.UI.Page
    {
        public List<Pedido> listaPedidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                Usuario usuario = (Usuario)Session["usuario"];
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                long dni = ((Usuario)Session["usuario"]).DNI;

                listaPedidos = pedidoNegocio.ListarPedidosPorUsuario(dni);

                PedidoNegocio negocioPedido = new PedidoNegocio();
                foreach (Pedido pedido in listaPedidos)
                {
                    pedido.detalles = negocioPedido.ListarDetallesPorPedido(pedido.idPedido);
                }

                rptPedidos.DataSource = listaPedidos;
                rptPedidos.DataBind();
            }
        }

        protected void rptPedidos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Pedido pedido = (Pedido)e.Item.DataItem;

                Repeater rptDetalles = (Repeater)e.Item.FindControl("rptDetalles");
                rptDetalles.DataSource = pedido.detalles; // asegúrate que pedido.detalles ya esté cargado
                rptDetalles.DataBind();
            }
        }
    }
}