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
    }
}
