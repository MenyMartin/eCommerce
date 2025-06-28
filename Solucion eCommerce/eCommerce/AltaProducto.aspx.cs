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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            List<HttpPostedFile> archivos = new List<HttpPostedFile>();

            // Agregar los 3 FileUpload iniciales si tienen archivo
            if (fuFoto1.HasFile) archivos.Add(fuFoto1.PostedFile);
            if (fuFoto2.HasFile) archivos.Add(fuFoto2.PostedFile);
            if (fuFoto3.HasFile) archivos.Add(fuFoto3.PostedFile);

            // Agregar archivos subidos por inputs dinámicos
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    // Omitir los 3 iniciales, que ya están en fuFoto1..3, para no duplicar
                    // Podemos identificar por nombre o índice, por seguridad filtrar:
                    string clave = Request.Files.AllKeys[i];
                    if (clave == "fuFoto1" || clave == "fuFoto2" || clave == "fuFoto3")
                        continue;

                    archivos.Add(file);
                }
            }

            // Ahora procesar la lista 'archivos' (guardar en disco, base, etc)
            foreach (var archivo in archivos)
            {
                // Ejemplo: guardar en servidor
                string ruta = Server.MapPath("~/img/productos/") + Path.GetFileName(archivo.FileName);
                archivo.SaveAs(ruta);
            }

            lblResultado.Text = "Producto y fotos guardados correctamente.";
            lblResultado.Visible = true;
        }
    }
}