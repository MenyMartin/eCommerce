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
            }
        }
    }
}