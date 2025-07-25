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

                if (usuario.idPerfil.idPerfil == 1)
                {
                    btnSolicitarVendedor.Visible = true;
                    btnAlta.Visible = false;
                    lblTituloMisProductos.Visible = false;
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

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dynamic producto = e.Item.DataItem;
                string estado = Convert.ToString(producto.estado);

                Button btnBaja = (Button)e.Item.FindControl("btnBaja");
                Button btnAlta = (Button)e.Item.FindControl("btnAlta");

                if (estado == "Inactivo")
                {
                    btnBaja.Visible = false;
                    btnAlta.Visible = true;
                }
                else
                {
                    btnBaja.Visible = true;
                    btnAlta.Visible = false;
                }
            }
        }

        protected void btnBaja_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                ProductoNegocio negocio = new ProductoNegocio();

                negocio.DarDeBajaProducto(idProducto);
                
                Response.Redirect("Ventas.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Error al dar de baja el producto: " + ex.Message);
            }
        }

        protected void btnAlta_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                ProductoNegocio negocio = new ProductoNegocio();

                negocio.ActivarProducto(idProducto);

                Response.Redirect("Ventas.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Error al dar de alta el producto: " + ex.Message);
            }
        }

        protected void btnSolicitarVendedor_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] is Usuario usuario)
            {
                SolicitudNegocio solicitudNeg = new SolicitudNegocio();

                bool yaSolicitado = solicitudNeg.SolicitudExistente(usuario.DNI);
                if (!yaSolicitado)
                {
                    solicitudNeg.CrearSolicitud(usuario.DNI);
                    btnSolicitarVendedor.Text = "Solicitud enviada";
                    btnSolicitarVendedor.Enabled = false;
                }
                else
                {
                    btnSolicitarVendedor.Text = "Ya enviaste una solicitud";
                    btnSolicitarVendedor.Enabled = false;
                }
            }
        }
    }
}