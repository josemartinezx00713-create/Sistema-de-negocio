using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entity;

namespace Sistema.DAL
{
    public class dUsuario
    {
        // listar
        public DataTable ListarUsuario()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al cargar el formulario");
            }

            return lista;
        }
        // listar rol
        public DataTable ListarRol()
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarRoles", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar los registros.");
            }

            return lista;
        }
        // buscar
        public DataTable BuscarUsuario(string nombre)
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarUsuarios", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al Buscar un registro");
            }

            return lista;
        }
        // registrar
        public bool RegistrarUsuario(oUsuario usuario)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuarios", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DniUsuario", usuario.dniUsuario);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.nombreUsuario);
                    cmd.Parameters.AddWithValue("@Codigo", usuario.codigoUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.email);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.idRol);
                    cmd.Parameters.AddWithValue("@Clave", usuario.clave);

                    SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    int resultado = Convert.ToInt32(respuesta.Value);
                    return resultado == 1;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }

            }
        }
        // actualizar
        public bool ActualizarUsuario(oUsuario usuario)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarUsuarios", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.idUsuario);
                    cmd.Parameters.AddWithValue("@DniUsuario", usuario.dniUsuario);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.nombreUsuario);
                    cmd.Parameters.AddWithValue("@Codigo", usuario.codigoUsuario);
                    cmd.Parameters.AddWithValue("@Email", usuario.email);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.idRol);

                    SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    int resultado = Convert.ToInt32(respuesta.Value);
                    return resultado == 1;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }

            }
        }
        // eliminar
        public bool EliminarUsuario(int idUsuario)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_EliminarUsuarios", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    int resultado = Convert.ToInt32(respuesta.Value);
                    return resultado == 1;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error al Eliminar un registro.");
                }

            }
        }
    }
}
