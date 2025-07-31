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
    public partial class Estadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["dni"] != null)
                {
                    long dni = long.Parse(Request.QueryString["dni"]);
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario usuario = negocio.BuscarPorDNI(dni);

                    if (usuario != null)
                    {
                        
                        imgFotoPerfil.ImageUrl = usuario.URLFotoPerfil;
                        lblNombre.Text = usuario.nombre + " " + usuario.apellido;
                        lblDNI.Text = "DNI: " + usuario.DNI;
                        lblEmail.Text = "Email: " + usuario.email;
                        lblDireccion.Text = "Dirección: " + usuario.direccion;
                        lblEdad.Text = "Edad: " + usuario.edad.ToString();
                        lblFechaRegistro.Text = "Registrado el: " + usuario.fechaRegistro.ToString("dd/MM/yyyy");

                        lblDineroGastado.Text = "$" + usuario.dineroGastado.ToString("N2");
                        lblPedidosRealizados.Text = usuario.pedidosRealizados.ToString();
                        lblProductosPedidos.Text = usuario.productosPedidos.ToString();
                        lblProductoMasPedido.Text = usuario.productoMasPedido != null ? usuario.productoMasPedido.nombre +" "+ usuario.productoMasPedido.marca : "-";
                    }
                }
            }
        }
    }
}