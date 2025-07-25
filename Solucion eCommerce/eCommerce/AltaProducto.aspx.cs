using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace eCommerce
{


    public partial class Vender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // jQuery para validaciones unobtrusive
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "https://code.jquery.com/jquery-3.6.0.min.js",
                    DebugPath = "https://code.jquery.com/jquery-3.6.0.js",
                    CdnSupportsSecureConnection = true,
                    LoadSuccessExpression = "window.jQuery"
                });

            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
        }

        // valida que haya al menos una imagen en url
        protected void valFotos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool tieneAlMenosUna = !string.IsNullOrWhiteSpace(txtFoto1.Text) ||
                                   !string.IsNullOrWhiteSpace(txtFoto2.Text) ||
                                   !string.IsNullOrWhiteSpace(txtFoto3.Text);

            
            foreach (string key in Request.Form.Keys)
            {
                if (key.StartsWith("fotoExtra"))
                {
                    string valor = Request.Form[key];
                    if (!string.IsNullOrWhiteSpace(valor))
                    {
                        tieneAlMenosUna = true;
                        break;
                    }
                }
            }

            args.IsValid = tieneAlMenosUna;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["usuario"];

            
            List<string> urlsImagenes = new List<string>();

            if (!string.IsNullOrWhiteSpace(txtFoto1.Text)) urlsImagenes.Add(txtFoto1.Text);
            if (!string.IsNullOrWhiteSpace(txtFoto2.Text)) urlsImagenes.Add(txtFoto2.Text);
            if (!string.IsNullOrWhiteSpace(txtFoto3.Text)) urlsImagenes.Add(txtFoto3.Text);

            
            foreach (string key in Request.Form.Keys)
            {
                if (key.StartsWith("fotoExtra"))
                {
                    string valor = Request.Form[key];
                    if (!string.IsNullOrWhiteSpace(valor))
                        urlsImagenes.Add(valor);
                }
            }

            // Crear el producto
            Producto producto = new Producto
            {
                nombre = txtNombre.Text.Trim(),
                marca = txtMarca.Text.Trim(),
                tipo = txtTipo.Text.Trim(),
                precio = Convert.ToDecimal(txtPrecio.Text.Trim()),
                stock = Convert.ToInt32(txtStock.Text.Trim()),
                descripcion = txtDescripcion.Text.Trim(),
                estado = "Activo",
                DNIVendedor = usuario.DNI,
                descuento = string.IsNullOrEmpty(txtDescuento.Text) ? 0 : Convert.ToInt32(txtDescuento.Text),
                fechaPublicacion = DateTime.Now
            };

            
            ProductoNegocio negocio = new ProductoNegocio();
            negocio.AgregarProductoConImagenes(producto, urlsImagenes);

            lblResultado.Text = "Producto y fotos guardados correctamente.";
            lblResultado.CssClass = "text-success";
            lblResultado.Visible = true;

            
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtTipo.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtDescripcion.Text = "";
            txtDescuento.Text = "";
            txtFoto1.Text = "";
            txtFoto2.Text = "";
            txtFoto3.Text = "";
        }
    }
}