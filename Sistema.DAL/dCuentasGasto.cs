using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL
{
    public class dCuentasGasto
    {
        public DataTable ListarCuentas()
        {
            DataTable lista = new DataTable();
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarCuentasGasto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch
            {
                throw new ApplicationException("Error al listar las cuentas de gasto");
            }
            return lista;
        }

        public DataTable BuscarCuenta(string nombre)
        {
            DataTable lista = new DataTable();
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarCuentaGasto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch
            {
                throw new ApplicationException("Error al buscar la cuenta de gasto");
            }
            return lista;
        }

        public bool RegistrarCuenta(oCuentasGasto cuenta)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarCuentaGasto", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", cuenta.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", cuenta.Descripcion);

                    SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(respuesta.Value) == 1;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }

        public bool ActualizarCuenta(oCuentasGasto cuenta)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarCuentaGasto", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCuenta", cuenta.IdCuenta);
                    cmd.Parameters.AddWithValue("@Nombre", cuenta.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", cuenta.Descripcion);

                    SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(respuesta.Value) == 1;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }

        public bool EliminarCuenta(int idCuenta)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_EliminarCuentaGasto", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCuenta", idCuenta);

                    SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(respuesta.Value) == 1;
                }
                catch
                {
                    throw new ApplicationException("Error al eliminar la cuenta de gasto");
                }
            }
        }
    }
}
