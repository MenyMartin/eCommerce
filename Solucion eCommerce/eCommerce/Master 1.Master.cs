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
                }
                else
                {
                    
                    imgUsuario.Src = ResolveUrl("~/img/sin-imagen.png");
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