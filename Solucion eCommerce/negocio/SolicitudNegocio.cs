using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class SolicitudNegocio
    {
        public void CrearSolicitud(long dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO SolicitudesCambioRol (DNISolicitante) VALUES (@DNI)");
                datos.setearParametro("@DNI", dni);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool SolicitudExistente(long dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM SolicitudesCambioRol WHERE DNISolicitante = @DNI AND Estado = 'Pendiente'");
                datos.setearParametro("@DNI", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = datos.Lector.GetInt32(0);
                    return cantidad > 0;
                }

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
