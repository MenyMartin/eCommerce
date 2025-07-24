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
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
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
            Button btn = (Button)sender;
            string urlImagen = btn.CommandArgument;

            if (!string.IsNullOrEmpty(urlImagen))
            {
                int idProducto = Convert.ToInt32(Request.QueryString["id"]);

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.EliminarImagenProducto(idProducto, urlImagen);

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(Request.QueryString["id"]);

                Producto producto = new Producto();
                producto.idProducto = idProducto;
                producto.nombre = txtNombre.Text.Trim();
                producto.marca = txtMarca.Text.Trim();
                producto.tipo = txtTipo.Text.Trim();
                producto.precio = decimal.Parse(txtPrecio.Text.Trim());
                producto.stock = int.Parse(txtStock.Text.Trim());
                producto.descripcion = txtDescripcion.Text.Trim();
                producto.descuento = int.Parse(txtDescuento.Text.Trim());

                ProductoNegocio negocio = new ProductoNegocio();

                
                negocio.ActualizarProducto(producto);


                List<string> nuevasImagenes = new List<string>();

                
                if (!string.IsNullOrWhiteSpace(txtFoto1.Text))
                    nuevasImagenes.Add(txtFoto1.Text.Trim());
                if (!string.IsNullOrWhiteSpace(txtFoto2.Text))
                    nuevasImagenes.Add(txtFoto2.Text.Trim());
                if (!string.IsNullOrWhiteSpace(txtFoto3.Text))
                    nuevasImagenes.Add(txtFoto3.Text.Trim());

                
                foreach (string clave in Request.Form.AllKeys)
                {
                    if (clave.StartsWith("fotoExtra"))
                    {
                        string urlExtra = Request.Form[clave];
                        if (!string.IsNullOrWhiteSpace(urlExtra))
                            nuevasImagenes.Add(urlExtra.Trim());
                    }
                }

                if (nuevasImagenes.Count > 0)
                {
                    negocio.AgregarImagenesProducto(idProducto, nuevasImagenes);
                }


                Response.Redirect("EdicionProducto.aspx?id=" + idProducto);
            }
            catch (Exception ex)
            {
                
                Response.Write("Error al actualizar: " + ex.Message);
            }
        }
    }
}
