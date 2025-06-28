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
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        ProductoNegocio negocio = new ProductoNegocio();
                        ProductosConImagenes producto = negocio.ObtenerProductoConImg(id);

                        lblNombre.Text = producto.nombre;
                        lblMarca.Text = producto.marca;
                        lblStock.Text = producto.stock.ToString();
                        lblTipo.Text = producto.tipo;
                        lblFecha.Text = producto.fechaPublicacion.ToShortDateString();
                        lblDescripcion.Text = producto.descripcion;

                        if (producto.descuento > 0)
                        {
                            lblPrecioTachado.Text = "$" + producto.precio.ToString("0.00");
                            lblPrecioTachado.Visible = true;

                            decimal precioConDescuento = producto.precio * (1 - producto.descuento / 100.0m);
                            lblPrecioConDescuento.Text = "$" + precioConDescuento.ToString("0.00");
                        }
                        else
                        {
                            lblPrecioConDescuento.Text = "$" + producto.precio.ToString("0.00");
                        }

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