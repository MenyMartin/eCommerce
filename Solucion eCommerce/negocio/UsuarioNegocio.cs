using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select * from Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.DNI = (int)datos.Lector["DNI"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.apellido = (string)datos.Lector["Apellido"];
                    aux.edad = (int)datos.Lector["Edad"];
                    aux.direccion = (string)datos.Lector["Direccion"];
                    aux.email = (string)datos.Lector["Email"];
                    aux.contraseña = (string)datos.Lector["Contraseña"];

                    aux.idPerfil = new Perfil();
                    aux.idPerfil.idPerfil = (int)datos.Lector["IdPerfil"];


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

        public Usuario ObtenerVendedor(int dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT DNI, Nombre, Apellido, URLFotoPerfil, FechaRegistro FROM Usuarios WHERE DNI = @DNI");
                datos.setearParametro("@DNI", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario vendedor = new Usuario
                    {
                        DNI = (int)(long)datos.Lector["DNI"],
                        nombre = datos.Lector["Nombre"].ToString(),
                        apellido = datos.Lector["Apellido"].ToString(),
                        URLFotoPerfil = datos.Lector["URLFotoPerfil"].ToString(),
                        fechaRegistro = (DateTime)datos.Lector["FechaRegistro"]
                    };

                    return vendedor;
                }

                return null;
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

        public void agregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Usuarios 
            (DNI, Nombre, Apellido, Edad, Direccion, URLFotoPerfil, FechaRegistro, IdPerfil, Email, Contraseña) 
            VALUES 
            (@DNI, @Nombre, @Apellido, @Edad, @Direccion, @URLFotoPerfil, @FechaRegistro, @IdPerfil, @Email, @Contraseña)");

                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Apellido", nuevo.apellido);
                datos.setearParametro("@Edad", nuevo.edad);
                datos.setearParametro("@Direccion", nuevo.direccion);
                datos.setearParametro("@URLFotoPerfil", nuevo.URLFotoPerfil);
                datos.setearParametro("@FechaRegistro", nuevo.fechaRegistro);                
                datos.setearParametro("@Email", nuevo.email);
                datos.setearParametro("@Contraseña", nuevo.contraseña);

                datos.setearParametro("@IdPerfil", nuevo.idPerfil.idPerfil);

                datos.ejecutarAccion();
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

        public bool ExisteDNI(int dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE DNI = @DNI");
                datos.setearParametro("@DNI", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector[0] > 0;

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ExisteEmail(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector[0] > 0;

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
