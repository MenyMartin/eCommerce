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
                    ProductosConImagenes producto = productoNeg.ObtenerProductoConImg(idProducto);

                    if (producto != null)
                    {
                        
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

                        rptImagenes.DataSource = producto.Imagenes;
                        rptImagenes.DataBind();

                        UsuarioNegocio userNeg = new UsuarioNegocio();
                        Usuario vendedor = userNeg.ObtenerVendedor(producto.DNIVendedor);
                        if (vendedor != null)
                        {
                            lblVendedor.Text = vendedor.nombre + " " + vendedor.apellido;
                            imgVendedor.ImageUrl = vendedor.URLFotoPerfil;
                        }

                        if (Session["usuario"] is Usuario usuario)
                        {
                            //bloqueado o agotado
                            if (producto.estado == "Bloqueado" || producto.estado == "Agotado")
                                btnAgregarAlCariito.Visible = false;

                            // Si es admin
                            if (usuario.idPerfil.idPerfil == 3)
                            {
                                if (producto.estado == "Bloqueado")
                                {
                                    btnDesbloquearProducto.Visible = true;
                                    btnBloquearProducto.Visible = false;
                                }
                                else
                                {
                                    btnBloquearProducto.Visible = true;
                                    btnDesbloquearProducto.Visible = false;
                                }

                                btnAgregarAlCariito.Visible = false; // el admin no compra
                            }

                            //no se puede autocomprar
                            if (usuario.DNI == producto.DNIVendedor)
                            {
                                btnAgregarAlCariito.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int idProducto = Convert.ToInt32(Request.QueryString["id"]);
            ProductoNegocio productoNeg = new ProductoNegocio();
            ProductosConImagenes producto = productoNeg.ObtenerProductoConImg(idProducto);

            if (producto != null)
            {
                CarritoNegocio carritoNeg = new CarritoNegocio();
                int idCarrito = carritoNeg.ObtenerOCrearCarritoActivo(usuario.DNI);

                decimal precio = producto.precio;
                if (producto.descuento > 0)
                    precio *= (1 - producto.descuento / 100.0m);

                carritoNeg.AgregarOActualizarDetalle(idCarrito, idProducto, precio);

                Response.Redirect("Carrito.aspx");
            }
        }

        protected void btnBloquearProducto_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int idProducto = int.Parse(Request.QueryString["id"]);
                ProductoNegocio productoNeg = new ProductoNegocio();
                productoNeg.ActualizarEstadoProducto(idProducto, "Bloqueado");
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnDesbloquearProducto_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int idProducto = int.Parse(Request.QueryString["id"]);
                ProductoNegocio productoNeg = new ProductoNegocio();
                productoNeg.ActualizarEstadoProducto(idProducto, "Activo");
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}