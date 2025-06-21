using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using Microsoft.SqlServer.Server;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select * from Productos");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.idProducto = (int)datos.Lector["IdProducto"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.marca = (string)datos.Lector["Marca"];
                    aux.tipo = (string)datos.Lector["Tipo"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.stock = (int)datos.Lector["Stock"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.fechaPublicacion = new Fecha();
                    aux.fechaPublicacion = (Fecha)datos.Lector["FechaPublicacion"];
                    aux.URLFotoProducto = (string)datos.Lector["URLFotoProducto"];
                    aux.estado = (string)datos.Lector["Estado"];
                    aux.DNIVendedor = (int)datos.Lector["DNIVendedor"];
                                        

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            
        }
    }
}
