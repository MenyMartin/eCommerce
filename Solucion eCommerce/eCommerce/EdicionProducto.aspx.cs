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
    public partial class EdicionProducto : System.Web.UI.Page
    {

        private string urlImagenAEliminar
        {
            get { return ViewState["urlImagenAEliminar"] as string; }
            set { ViewState["urlImagenAEliminar"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (int.TryParse(Request.QueryString["id"], out int idProducto))
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    ProductosConImagenes producto = negocio.ObtenerProductoConImg(idProducto);

                    if (producto != null)
                    {

                        txtNombre.Text = producto.nombre;
                        txtMarca.Text = producto.marca;
                        txtTipo.Text = producto.tipo;
                        txtPrecio.Text = producto.precio.ToString("0.00");
                        txtStock.Text = producto.stock.ToString();
                        txtDescripcion.Text = producto.descripcion;
                        txtDescuento.Text = producto.descuento.ToString();


                        rptImagenes.DataSource = producto.Imagenes;
                        rptImagenes.DataBind();
                    }
                    else
                    {

                        Response.Write("Producto no encontrado.");
                    }
                }
                else
                {

                    Response.Write("ID de producto inválido.");
                }
            }
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(urlImagenAEliminar))
            {
                int idProducto = Convert.ToInt32(Request.QueryString["id"]);


                ProductoNegocio negocio = new ProductoNegocio();
                negocio.EliminarImagenProducto(idProducto, urlImagenAEliminar);


                Response.Redirect(Request.RawUrl);
            }
        }


    }
}
