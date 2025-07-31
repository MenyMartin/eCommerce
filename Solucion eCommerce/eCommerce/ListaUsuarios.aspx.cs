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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        UsuarioNegocio negocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios(string filtro = "")
        {
            List<Usuario> lista;

            if (!string.IsNullOrEmpty(filtro))
                lista = negocio.BuscarUsuariosPorFiltro(filtro);
            else
                lista = negocio.ListarUsuariosPerfil1();

            gvUsuarios.DataSource = lista;
            gvUsuarios.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarUsuarios(filtro);
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerEstadisticas")
            {
                string dni = e.CommandArgument.ToString();
                Response.Redirect("Estadisticas.aspx?dni=" + dni);
            }
        }


    }
}