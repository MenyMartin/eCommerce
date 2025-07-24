using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            

            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                lblNombre.Text = usuario.nombre;
                lblApellido.Text = usuario.apellido;
                lblDNI.Text = usuario.DNI.ToString();
                lblEdad.Text = usuario.edad.ToString();
                lblDireccion.Text = usuario.direccion;
                imgPerfil.ImageUrl = usuario.URLFotoPerfil;
                lblEmail.Text = usuario.email;
                lblPassword.Text = usuario.contraseña;
                lblFechaRegistro.Text = usuario.fechaRegistro.ToString("dd/MM/yyyy");
            }
        }
    }
}