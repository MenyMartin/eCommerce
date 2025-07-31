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

        public Usuario ObtenerVendedor(long dni)
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

        public Usuario login(string email, string contraseña)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña");
                datos.setearParametro("@Email", email);
                datos.setearParametro("@Contraseña", contraseña);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.DNI = (long)datos.Lector["DNI"];
                    usuario.nombre = (string)datos.Lector["Nombre"];
                    usuario.apellido = (string)datos.Lector["Apellido"];
                    usuario.edad = (int)datos.Lector["Edad"];
                    usuario.direccion = (string)datos.Lector["Direccion"];
                    usuario.URLFotoPerfil = (string)datos.Lector["URLFotoPerfil"];
                    usuario.fechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    usuario.email = (string)datos.Lector["Email"];
                    usuario.contraseña = (string)datos.Lector["Contraseña"];

                    
                    usuario.idPerfil = new Perfil();
                    usuario.idPerfil.idPerfil = (int)datos.Lector["IdPerfil"];

                    return usuario;
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

        public void ActualizarPerfil(long dni, int nuevoPerfil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Usuarios SET IdPerfil = @Perfil WHERE DNI = @DNI");
                datos.setearParametro("@Perfil", nuevoPerfil);
                datos.setearParametro("@DNI", dni);
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

        public List<Usuario> ListarUsuariosPerfil1()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT DNI, Nombre, Apellido, Edad, Direccion, URLFotoPerfil, Email, FechaRegistro
                               FROM Usuarios
                               WHERE idPerfil = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        DNI = (long)datos.Lector["DNI"],
                        nombre = datos.Lector["Nombre"].ToString(),
                        apellido = datos.Lector["Apellido"].ToString(),
                        edad = (int)datos.Lector["Edad"],
                        direccion = datos.Lector["Direccion"].ToString(),
                        URLFotoPerfil = datos.Lector["URLFotoPerfil"].ToString(),
                        email = datos.Lector["Email"].ToString(),
                        fechaRegistro = Convert.ToDateTime(datos.Lector["FechaRegistro"]),
                        
                    };
                    lista.Add(usuario);
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

        public List<Usuario> BuscarUsuariosPorFiltro(string filtro)
        {
            List<Usuario> listaFiltrada = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = @"SELECT u.DNI, u.nombre, u.apellido, u.edad, u.direccion, u.URLFotoPerfil, 
                                u.fechaRegistro, u.email
                         FROM Usuarios u
                         WHERE u.nombre LIKE @filtro
                            OR u.apellido LIKE @filtro
                            OR u.email LIKE @filtro
                            OR u.direccion LIKE @filtro
                            OR CAST(u.DNI AS VARCHAR) LIKE @filtro";

                datos.setearConsulta(query);
                datos.setearParametro("@filtro", "%" + filtro + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.DNI = (long)datos.Lector["DNI"];
                    aux.nombre = datos.Lector["nombre"].ToString();
                    aux.apellido = datos.Lector["apellido"].ToString();
                    aux.email = datos.Lector["email"].ToString();
                    aux.direccion = datos.Lector["direccion"].ToString();
                    aux.URLFotoPerfil = datos.Lector["URLFotoPerfil"].ToString();
                    aux.edad = (int)datos.Lector["edad"];
                    aux.fechaRegistro = (DateTime)datos.Lector["fechaRegistro"];
                    

                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;
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
