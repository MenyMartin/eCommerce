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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int idProducto = int.Parse(Request.QueryString["id"]);

                    ProductoNegocio productoNeg = new ProductoNegocio();
                    ProductosConImagenes productoConImg = productoNeg.ObtenerProductoConImg(idProducto);

                    if (productoConImg != null)
                    {
                        lblNombre.Text = productoConImg.nombre;
                        lblMarca.Text = productoConImg.marca;
                        lblPrecio.Text = productoConImg.precio.ToString("N2");
                        lblStock.Text = productoConImg.stock.ToString();
                        lblTipo.Text = productoConImg.tipo;
                        lblFecha.Text = productoConImg.fechaPublicacion.ToShortDateString();
                        lblDescripcion.Text = productoConImg.descripcion;

                        rptImagenes.DataSource = productoConImg.Imagenes;
                        rptImagenes.DataBind();

                        UsuarioNegocio userNeg = new UsuarioNegocio();
                        Usuario vendedor = userNeg.ObtenerVendedor(productoConImg.DNIVendedor);

                        if (vendedor != null)
                        {
                            lblVendedor.Text = vendedor.nombre + " " + vendedor.apellido;
                            imgVendedor.ImageUrl = vendedor.URLFotoPerfil;
                        }
                    }
                }
            }
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {

        }
    }
}