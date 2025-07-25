using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CarritoNegocio
    {
        public int ObtenerOCrearCarritoActivo(long dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("SELECT IdCarrito FROM Carritos WHERE dni = @dni AND activo = 1");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int idCarritoExistente = (int)datos.Lector["IdCarrito"];
                    return idCarritoExistente;
                }

                datos.cerrarConexion();
                datos.limpiarParametros();

                // 2. Crear nuevo carrito si no existe uno activo
                datos.setearConsulta("INSERT INTO Carritos (DNI, fechaCreacion, activo) OUTPUT INSERTED.IdCarrito VALUES (@dni, @fecha, 1)");
                datos.setearParametro("@dni", dni);
                datos.setearParametro("@fecha", DateTime.Now);

                object idNuevo = datos.ejecutarScalar();
                return Convert.ToInt32(idNuevo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener o crear el carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarOActualizarDetalle(int idCarrito, int idProducto, decimal precioUnitario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //consulto stock
                datos.setearConsulta("SELECT stock FROM Productos WHERE IdProducto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                if (!datos.Lector.Read())
                {
                    datos.cerrarConexion();
                    datos.limpiarParametros();
                    throw new Exception("Producto no encontrado.");
                }

                int stockActual = (int)datos.Lector["stock"];
                datos.cerrarConexion();
                datos.limpiarParametros();

                if (stockActual <= 0)
                {
                    throw new Exception("No hay stock disponible para este producto.");
                }

                //descuento 1
                datos.setearConsulta("UPDATE Productos SET stock = stock - 1 WHERE IdProducto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                datos.limpiarParametros();


                datos.setearConsulta("SELECT IdDetalle, Cantidad FROM CarritoDetalle WHERE idCarrito = @idCarrito AND IdProducto = @idProducto");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidadActual = (int)datos.Lector["Cantidad"];
                    datos.cerrarConexion();
                    datos.limpiarParametros();

                    datos.setearConsulta("UPDATE CarritoDetalle SET Cantidad = @nuevaCantidad WHERE IdCarrito = @idCarrito AND IdProducto = @idProducto");
                    datos.setearParametro("@nuevaCantidad", cantidadActual + 1);
                    datos.setearParametro("@idCarrito", idCarrito);
                    datos.setearParametro("@idProducto", idProducto);
                    datos.ejecutarAccion();
                }
                else
                {
                    datos.cerrarConexion();
                    datos.limpiarParametros();

                    datos.setearConsulta("INSERT INTO CarritoDetalle (IdCarrito, IdProducto, Cantidad, PrecioUnitario) VALUES (@idCarrito, @idProducto, 1, @precioUnitario)");
                    datos.setearParametro("@idCarrito", idCarrito);
                    datos.setearParametro("@idProducto", idProducto);
                    datos.setearParametro("@precioUnitario", precioUnitario);
                    datos.ejecutarAccion();
                }
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

        public List<CarritoVerItem> ObtenerItemsCarrito(long dni)
        {
            List<CarritoVerItem> items = new List<CarritoVerItem>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                                        SELECT 
                                            p.IdProducto AS idProducto,
                                            p.Nombre,
                                            p.Marca,
                                            cd.precioUnitario,
                                            SUM(cd.cantidad) AS Cantidad,
                                            SUM(cd.cantidad * cd.precioUnitario) AS Subtotal,
                                            (SELECT TOP 1 URLImagen FROM ProductoImagenes img WHERE img.IdProducto = p.IdProducto) AS ImagenURL
                                        FROM CarritoDetalle cd
                                        JOIN Productos p ON cd.idProducto = p.IdProducto
                                        JOIN Carritos c ON cd.idCarrito = c.IdCarrito
                                        WHERE c.DNI = @dni AND c.Activo = 1
                                        GROUP BY p.IdProducto, p.Nombre, p.Marca, cd.precioUnitario
    ");

                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();
                

                while (datos.Lector.Read())
                {
                    CarritoVerItem item = new CarritoVerItem
                    {
                        idProducto = (int)datos.Lector["idProducto"],
                        nombre = datos.Lector["Nombre"].ToString(),
                        marca = datos.Lector["Marca"].ToString(),
                        precioUnitario = Convert.ToDecimal(datos.Lector["precioUnitario"]),
                        cantidad = Convert.ToInt32(datos.Lector["Cantidad"]),
                        imagenURL = datos.Lector["ImagenURL"] != DBNull.Value
                                    ? datos.Lector["ImagenURL"].ToString()
                                    : "/assets/img/placeholder.png"
                    };

                    items.Add(item);
                }

                return items;
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

        public void QuitarItemCarrito(long dni, int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                int idCarrito = ObtenerOCrearCarritoActivo(dni);

                // Obtiene cantidad del carrito
                datos.setearConsulta("SELECT Cantidad FROM CarritoDetalle WHERE IdCarrito = @idCarrito AND IdProducto = @idProducto");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                if (!datos.Lector.Read())
                {
                    datos.cerrarConexion();
                    return;
                }

                int cantidadActual = (int)datos.Lector["Cantidad"];
                datos.cerrarConexion();

                //devuelve 1 al stock
                datos = new AccesoDatos();
                datos.setearConsulta("UPDATE Productos SET Stock = Stock + 1 WHERE IdProducto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                if (cantidadActual > 1)
                {
                    //saca 1 del carrito
                    datos = new AccesoDatos();
                    datos.setearConsulta("UPDATE CarritoDetalle SET Cantidad = Cantidad - 1 WHERE IdCarrito = @idCarrito AND IdProducto = @idProducto");
                    datos.setearParametro("@idCarrito", idCarrito);
                    datos.setearParametro("@idProducto", idProducto);
                    datos.ejecutarAccion();
                }
                else
                {
                    //elimina si queda en 0
                    datos = new AccesoDatos();
                    datos.setearConsulta("DELETE FROM CarritoDetalle WHERE IdCarrito = @idCarrito AND IdProducto = @idProducto");
                    datos.setearParametro("@idCarrito", idCarrito);
                    datos.setearParametro("@idProducto", idProducto);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al quitar producto del carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void CerrarCarrito(long dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Carritos SET Activo = 0 WHERE DNI = @dni AND Activo = 1");
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
