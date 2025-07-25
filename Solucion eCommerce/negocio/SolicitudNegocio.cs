using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

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

        public List<Solicitud> ListarPendientes()
        {
            List<Solicitud> lista = new List<Solicitud>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT s.DNISolicitante, u.nombre + ' ' + u.apellido AS NombreCompleto
                            FROM SolicitudesCambioRol s
                            JOIN Usuarios u ON s.DNISolicitante = u.DNI
                            WHERE s.estado = 'Pendiente'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Solicitud
                    {
                        DNI = (long)datos.Lector["DNISolicitante"],
                        NombreCompleto = datos.Lector["NombreCompleto"].ToString()
                    });
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void CambiarEstado(long dni, string nuevoEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE SolicitudesCambioRol SET estado = @estado WHERE DNISolicitante = @dni");
                datos.setearParametro("@estado", nuevoEstado);
                datos.setearParametro("@dni", dni);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
    }
}
