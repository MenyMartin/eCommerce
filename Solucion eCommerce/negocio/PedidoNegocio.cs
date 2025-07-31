using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PedidoNegocio
    {
        public int CrearPedido(Pedido pedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Pedidos (DNI, FechaPedido, Estado, Total, IdTipoPago) OUTPUT INSERTED.IdPedido VALUES (@dni, @fecha, @estado, @total, @IdTipoPago)");
                datos.setearParametro("@dni", pedido.dni);
                datos.setearParametro("@fecha", pedido.fechaPedido);
                datos.setearParametro("@estado", pedido.estado);
                datos.setearParametro("@total", pedido.total);
                datos.setearParametro("@IdTipoPago", pedido.idTipoPago);
                return (int)datos.ejecutarScalar();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarDetalle(PedidoDetalle detalle)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO PedidoDetalle (IdPedido, IdProducto, Cantidad, PrecioUnitario) VALUES (@idPedido, @idProducto, @cantidad, @precioUnitario)");
                datos.setearParametro("@idPedido", detalle.idPedido);
                datos.setearParametro("@idProducto", detalle.idProducto);
                datos.setearParametro("@cantidad", detalle.cantidad);
                datos.setearParametro("@precioUnitario", detalle.precioUnitario);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<PedidoDetalleExtendido> ListarDetallesPorPedido(int idPedido)
        {
            List<PedidoDetalleExtendido> lista = new List<PedidoDetalleExtendido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                                       SELECT 
                                           pd.idDetalle,
                                           pd.idPedido,
                                           pd.idProducto,
                                           p.Nombre,
                                           p.Marca,
                                           pd.cantidad,
                                           pd.precioUnitario,
                                           pd.subtotal
                                       FROM PedidoDetalle pd
                                       JOIN Productos p ON pd.idProducto = p.IdProducto
                                       WHERE pd.idPedido = @idPedido
                                   ");

                datos.setearParametro("@idPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PedidoDetalleExtendido detalle = new PedidoDetalleExtendido
                    {
                        idDetallePedido = (int)datos.Lector["idDetalle"],
                        idPedido = (int)datos.Lector["idPedido"],
                        idProducto = (int)datos.Lector["idProducto"],
                        nombreProducto = datos.Lector["Nombre"].ToString(),
                        marcaProducto = datos.Lector["Marca"].ToString(),
                        cantidad = (int)datos.Lector["cantidad"],
                        precioUnitario = Convert.ToDecimal(datos.Lector["precioUnitario"]),
                        subtotal = Convert.ToDecimal(datos.Lector["subtotal"])
                    };

                    lista.Add(detalle);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Pedido> ListarPedidosPorUsuario(long idUsuario)
        {
            List<Pedido> pedidos = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(" SELECT p.idPedido, p.dni, p.fechaPedido, p.estado, p.total, p.idTipoPago, mp.tipoPago FROM Pedidos p " +
                                     "LEFT JOIN MediosDePago mp ON p.idTipoPago = mp.idTipoPago WHERE p.dni = @idusuario ORDER BY p.fechaPedido DESC");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.idPedido = (int)datos.Lector["IdPedido"];
                    pedido.dni = (long)datos.Lector["DNI"];
                    pedido.fechaPedido = (DateTime)datos.Lector["FechaPedido"];
                    pedido.estado = datos.Lector["Estado"].ToString();
                    pedido.total = Convert.ToDecimal(datos.Lector["Total"]);
                    pedido.nombreTipoPago = datos.Lector["tipoPago"] != DBNull.Value ? datos.Lector["tipoPago"].ToString() : "No especificado";



                    PedidoNegocio negocioDetalle = new PedidoNegocio();
                    pedido.detalles = negocioDetalle.ListarDetallesPorPedido(pedido.idPedido);

                    pedidos.Add(pedido);
                }

                return pedidos;
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

        public int ObtenerCantidadTotalComprada(long dni, int idProducto)
        {
            int total = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"
            SELECT SUM(pd.cantidad)
            FROM PedidoDetalle pd
            INNER JOIN Pedidos p ON pd.idPedido = p.idPedido
            WHERE p.dni = @dni AND pd.idProducto = @idProducto");

                datos.setearParametro("@dni", dni);
                datos.setearParametro("@idProducto", idProducto);

                object resultado = datos.ejecutarScalar();

                if (resultado != DBNull.Value && resultado != null)
                    total = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return total;
        }
    }
}
