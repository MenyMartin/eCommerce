using System.Data.SqlClient;
using System;

internal class AccesoDatos
{
    private SqlConnection conexion;
    private SqlCommand comando;
    private SqlDataReader lector;
    public SqlDataReader Lector
    {
        get { return lector; }
    }

    public AccesoDatos()
    {
        conexion = new SqlConnection("server=.\\SQLEXPRESS; database=EcommenyDB; integrated security=true");
        comando = new SqlCommand();
    }

    public void setearConsulta(string consulta)
    {
        comando.CommandType = System.Data.CommandType.Text;
        comando.CommandText = consulta;
    }

    public void ejecutarLectura()
    {
        comando.Connection = conexion;
        try
        {
            conexion.Open();
            lector = comando.ExecuteReader();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void cerrarConexion()
    {
        if (lector != null && !lector.IsClosed)
        {
            lector.Close();
        }
        if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
        {
            conexion.Close();
        }
    }

    public void setearParametro(string nombre, object valor)
    {
        comando.Parameters.AddWithValue(nombre, valor);
    }

    public void limpiarParametros()
    {
        comando.Parameters.Clear();
    }

    // devuelve un único valor por ej SELECT MAX(Id)
    public object ejecutarScalar()
    {
        comando.Connection = conexion;
        try
        {
            conexion.Open();
            object resultado = comando.ExecuteScalar();
            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }

    
    public int ejecutarAccion()
    {
        comando.Connection = conexion;
        try
        {
            conexion.Open();
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
