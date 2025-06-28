using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tipoSeleccionado = Request.QueryString["tipo"];

                if (!string.IsNullOrEmpty(tipoSeleccionado))
                {
                    lblTitulo.Text = "Productos de tipo: " + tipoSeleccionado;

                    ProductoNegocio negocio = new ProductoNegocio();
                    List<ProductosConImagenes> productos = negocio.ObtenerProductosConImagenes();

                    var productosFiltrados = productos
                        .Where(p => p.tipo != null && p.tipo.Equals(tipoSeleccionado, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    rptProductos.DataSource = productosFiltrados;
                    rptProductos.DataBind();
                }
                else
                {
                    lblTitulo.Text = "No se especificó un tipo válido.";
                }
            }
        }

        protected void rptProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item ||
               e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                ProductosConImagenes producto = (ProductosConImagenes)e.Item.DataItem;

                Repeater rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");

                if (producto.Imagenes != null && producto.Imagenes.Count > 0)
                {
                    rptImagenes.DataSource = producto.Imagenes;
                }
                else
                {
                    // En caso de no tener imágenes, usar una imagen por defecto
                    rptImagenes.DataSource = new List<string> { "~/img/sin-imagen.jpg" };
                }

                rptImagenes.DataBind();
            }
        }
    }
}