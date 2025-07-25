﻿using System;
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
                datos.setearConsulta("INSERT INTO Pedidos (DNI, FechaPedido, Estado, Total) OUTPUT INSERTED.IdPedido VALUES (@dni, @fecha, @estado, @total)");
                datos.setearParametro("@dni", pedido.dni);
                datos.setearParametro("@fecha", pedido.fechaPedido);
                datos.setearParametro("@estado", pedido.estado);
                datos.setearParametro("@total", pedido.total);
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
                datos.setearConsulta("SELECT IdPedido, DNI, FechaPedido, Estado, Total FROM Pedidos WHERE DNI = @idUsuario");
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
    }
}
