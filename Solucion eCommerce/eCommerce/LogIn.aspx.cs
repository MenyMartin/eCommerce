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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Response.Redirect("MiPerfil.aspx");
                }
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            pnlRegistro.Visible = true;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtEdad.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    lblMensaje.Text = "Por favor, completá todos los campos obligatorios.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    return;
                }                

                if (!int.TryParse(txtEdad.Text, out int edad) || edad < 0 || edad > 120)
                {
                    lblMensaje.Text = "La edad debe ser un número entre 0 y 120.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    return;
                }

                // validación de email 
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    lblMensaje.Text = "El email ingresado no es válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    return;
                }

                // validación de formato de DNI y edad
                if (!int.TryParse(txtDNI.Text, out int dni))
                {
                    lblMensaje.Text = "El DNI debe ser un número válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    return;
                }

                // validación de DNI no repetido
                UsuarioNegocio negocio = new UsuarioNegocio();

                if (negocio.ExisteDNI(dni))
                {
                    lblMensaje.Text = "Ya existe un usuario con ese DNI.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    return;
                }

                if (negocio.ExisteEmail(txtEmail.Text))
                {
                    lblMensaje.Text = "Ya existe un usuario registrado con ese email.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    return;
                }

                Usuario usuario = new Usuario();
                Perfil perfil = new Perfil();

                usuario.DNI = dni;
                usuario.nombre = txtNombre.Text;
                usuario.apellido = txtApellido.Text;
                usuario.edad = edad;
                usuario.direccion = txtDireccion.Text;
                usuario.URLFotoPerfil = txtURLFotoPerfil.Text;
                usuario.fechaRegistro = DateTime.Now;
                usuario.email = txtEmail.Text;
                usuario.contraseña = txtContraseña.Text;

                perfil.idPerfil = 1;
                usuario.idPerfil = perfil;
                
                negocio.agregarUsuario(usuario);

                lblMensaje.Text = "¡Registro exitoso!";
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Green;

                pnlRegistro.Visible = false;

                // Response.AddHeader("REFRESH", "2;URL=LogIn.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al registrar: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            pnlRegistro.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.login(email, clave);

            if (usuario != null)
            {
                Session["usuario"] = usuario;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }
    }
}