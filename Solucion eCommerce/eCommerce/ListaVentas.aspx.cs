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
    public partial class ListaVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarVentas();
        }

        private void CargarVentas()
        {
            var negocioPedidos = new PedidoNegocio();
            var negocioUsuarios = new UsuarioNegocio();

            var pedidos = negocioPedidos.ListarTodosConDetalles();

            
            var listaAnonima = pedidos.Select(p =>
            {
                var usuario = negocioUsuarios.BuscarPorDNI(p.dni);
                string nombreCompleto = usuario != null ? $"{usuario.nombre} {usuario.apellido}" : "Desconocido";

                return new
                {
                    p.idPedido,
                    p.fechaPedido,
                    p.estado,
                    p.total,
                    p.nombreTipoPago,
                    p.entrega,
                    detalles = p.detalles,
                    cliente = nombreCompleto
                };
            })
            .OrderByDescending(p => p.fechaPedido)
            .ToList();

            gvPedidos.DataSource = listaAnonima;
            gvPedidos.DataBind();
        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerSeguimiento")
            {
                string idPedido = e.CommandArgument.ToString();
                Response.Redirect("SeguimientoPedidos.aspx?idPedido=" + idPedido);
            }
        }
    }
}