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

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.idProducto = (int)datos.Lector["IdProducto"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.marca = (string)datos.Lector["Marca"];
                    aux.tipo = (string)datos.Lector["Tipo"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.stock = (int)datos.Lector["Stock"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
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

        public List<string> obtenerImagenes(int idProducto)
        {
            List<string> imagenes = new List<string>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT URLImagen" +
                                     "FROM ProductoImagenes " +
                                     "WHERE IdProducto = @IdProducto ORDER BY IdImagen;");
                datos.setearParametro("@IdProducto", idProducto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string urlImagen = (string)datos.Lector["URLImagen"];
                    imagenes.Add(urlImagen);
                }
                return imagenes;
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

        public List<ProductosConImagenes> ObtenerProductosConImagenes()
        {
            List<ProductosConImagenes> productosConImg = new List<ProductosConImagenes>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT IdProducto, Nombre, Descripcion, Marca, Tipo, Precio, Stock, DNIVendedor, FechaPublicacion, Estado 
                                      FROM Productos
                                      WHERE Estado = 'Activo'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ProductosConImagenes producto = new ProductosConImagenes
                    {
                        idProducto = Convert.ToInt32(datos.Lector["IdProducto"]),
                        nombre = datos.Lector["Nombre"]?.ToString() ?? "",
                        descripcion = datos.Lector["Descripcion"]?.ToString() ?? "",
                        marca = datos.Lector["Marca"]?.ToString() ?? "",
                        tipo = datos.Lector["Tipo"]?.ToString() ?? "",
                        precio = datos.Lector["Precio"] != DBNull.Value ? (decimal)datos.Lector["Precio"] : 0,
                        stock = datos.Lector["Stock"] != DBNull.Value ? (int)datos.Lector["Stock"] : 0,
                        DNIVendedor = datos.Lector["DNIVendedor"] != DBNull.Value ? Convert.ToInt32(datos.Lector["DNIVendedor"]) : 0,
                        fechaPublicacion = datos.Lector["FechaPublicacion"] != DBNull.Value ? (DateTime)datos.Lector["FechaPublicacion"] : DateTime.MinValue,
                        estado = datos.Lector["Estado"]?.ToString() ?? "",
                    };

                    productosConImg.Add(producto);
                }

                datos.cerrarConexion();

                foreach (var producto in productosConImg)
                {
                    datos.limpiarParametros();
                    datos.setearConsulta("SELECT URLImagen FROM ProductoImagenes WHERE IdProducto = @IdProducto");
                    datos.setearParametro("@IdProducto", producto.idProducto);
                    datos.ejecutarLectura();

                    if (producto.Imagenes == null)
                        producto.Imagenes = new List<string>();

                    while (datos.Lector.Read())
                    {
                        producto.Imagenes.Add(datos.Lector["URLImagen"].ToString());
                    }
                    datos.cerrarConexion();
                }

                return productosConImg;
            
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
