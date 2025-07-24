using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace eCommerce
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            emailService.armarCorreo(txtEmail.Text, txtMensaje.Text, txtNombre.Text);

            try
            {
                emailService.enviarEmail();
                lblMensajeExito.Text = "¡Solicitud de contacto realizada con éxito!";
                lblMensajeExito.Visible = true;

                txtEmail.Text = "";
                txtMensaje.Text = "";
                txtNombre.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}