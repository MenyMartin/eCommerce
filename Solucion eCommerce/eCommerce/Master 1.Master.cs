using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace eCommerce
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<ProductosConImagenes> productos = negocio.ObtenerProductosConImagenes();

                var tiposUnicos = productos
                    .Select(p => p.tipo)
                    .Distinct()
                    .OrderBy(t => t)
                    .Select(t => new { Tipo = t })
                    .ToList();

                rptCategorias.DataSource = tiposUnicos;
                rptCategorias.DataBind();

                var usuario = Session["usuario"] as dominio.Usuario;

                if (usuario != null && !string.IsNullOrEmpty(usuario.URLFotoPerfil))
                {
                    imgUsuario.Src = ResolveUrl(usuario.URLFotoPerfil);

                    // se ve Admin si el usuario es perfil 3
                    pnlAdmin.Visible = usuario.idPerfil.idPerfil == 3;
                    pnlVentas.Visible = usuario.idPerfil.idPerfil == 3;
                    pnlContacto.Visible = usuario.idPerfil.idPerfil != 3;
                    pnlMisPedidos.Visible = usuario.idPerfil.idPerfil != 3;
                }
                else
                {
                    imgUsuario.Src = ResolveUrl("~/img/sin-imagen.png");

                    // si no es Admin solo Contacto
                    pnlAdmin.Visible = false;
                    pnlContacto.Visible = true;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBuscado = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(textoBuscado))
            {
                Response.Redirect("~/default.aspx?buscar=" + Server.UrlEncode(textoBuscado));
            }
        }
    }
}