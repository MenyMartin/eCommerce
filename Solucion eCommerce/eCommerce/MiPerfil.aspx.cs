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
    public partial class MiPerfil : System.Web.UI.Page
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

                lblNombre.Text = usuario.nombre;
                lblApellido.Text = usuario.apellido;
                lblDNI.Text = usuario.DNI.ToString();
                lblEdad.Text = usuario.edad.ToString();
                lblDireccion.Text = usuario.direccion;
                imgPerfil.ImageUrl = usuario.URLFotoPerfil;
                lblEmail.Text = usuario.email;
                lblPassword.Text = usuario.contraseña;
                lblFechaRegistro.Text = usuario.fechaRegistro.ToString("dd/MM/yyyy");

                //if (usuario.idPerfil.idPerfil == 3)
                //{
                //    btnPanelAdmin.Visible = true;
                //}

                //----- secion pedidos                

                long dni = ((Usuario)Session["usuario"]).DNI;

                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                List<Pedido> pedidos = pedidoNegocio.ListarPedidosPorUsuario(dni);


                PedidoNegocio negocioPedido = new PedidoNegocio();

                foreach (Pedido pedido in pedidos)
                {
                    pedido.detalles = negocioPedido.ListarDetallesPorPedido(pedido.idPedido);
                }

                rptPedidos.DataSource = pedidos;
                rptPedidos.DataBind();
            }

            
        }

        protected void rptPedidos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                
                var pedido = (Pedido)e.Item.DataItem;

                
                var rptDetalles = (Repeater)e.Item.FindControl("rptDetalles");
                rptDetalles.DataSource = pedido.detalles;
                rptDetalles.DataBind();
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        //protected void btnPanelAdmin_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Admin.aspx");
        //}
    }
}