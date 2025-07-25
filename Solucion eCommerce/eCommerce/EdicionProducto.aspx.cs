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

                if (Request.QueryString["msg"] == "ok")
                {
                    lblMensaje.Text = "Producto actualizado correctamente.";
                    lblMensaje.Visible = true;
                    lblMensaje.CssClass = "alert alert-success text-center d-block";
                }

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
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtMarca.Text) ||
                    string.IsNullOrWhiteSpace(txtTipo.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtStock.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtDescuento.Text))
                {
                    lblMensaje.Text = "Por favor, completá todos los campos.";
                    lblMensaje.CssClass = "alert alert-danger text-center d-block";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    lblMensaje.Text = "El precio debe ser un número válido.";
                    lblMensaje.CssClass = "alert alert-danger text-center d-block";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    lblMensaje.Text = "El stock debe ser un número entero.";
                    lblMensaje.CssClass = "alert alert-danger text-center d-block";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!int.TryParse(txtDescuento.Text, out int descuento))
                {
                    lblMensaje.Text = "El descuento debe ser un número entero.";
                    lblMensaje.CssClass = "alert alert-danger text-center d-block";
                    lblMensaje.Visible = true;
                    return;
                }

                int idProducto = Convert.ToInt32(Request.QueryString["id"]);

                Producto producto = new Producto();
                producto.idProducto = idProducto;
                producto.nombre = txtNombre.Text.Trim();
                producto.marca = txtMarca.Text.Trim();
                producto.tipo = txtTipo.Text.Trim();
                producto.precio = precio;
                producto.stock = stock;
                producto.descuento = descuento; ;

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


                Response.Redirect("EdicionProducto.aspx?id=" + idProducto + "&msg=ok");
            }
            catch (Exception ex)
            {
                
                Response.Write("Error al actualizar: " + ex.Message);
            }
        }
    }
}
