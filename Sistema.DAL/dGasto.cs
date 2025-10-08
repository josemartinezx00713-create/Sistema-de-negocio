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
    public class dGasto
    {
        // Listar
        public DataTable ListarGastos()
        {
            DataTable lista = new DataTable();
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarGastos", cn))
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
                throw new ApplicationException("Error al listar los gastos");
            }
            return lista;
        }

        // Buscar por fechas
        public DataTable BuscarGastos(DateTime fechaInicio, DateTime fechaFinal)
        {
            DataTable lista = new DataTable();
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarGastos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinal", fechaFinal);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch
            {
                throw new ApplicationException("Error al buscar los gastos");
            }
            return lista;
        }

        // Registrar
        public bool RegistrarGasto(oGasto gasto)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarGasto", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", gasto.Fecha);
                    cmd.Parameters.AddWithValue("@IdCuenta", gasto.IdCuenta);
                    cmd.Parameters.AddWithValue("@Monto", gasto.Monto);
                    cmd.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
                    cmd.Parameters.AddWithValue("@IdUsuario", gasto.IdUsuario);

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

        // Actualizar
        public bool ActualizarGasto(oGasto gasto)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarGasto", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdGasto", gasto.IdGasto);
                    cmd.Parameters.AddWithValue("@Fecha", gasto.Fecha);
                    cmd.Parameters.AddWithValue("@IdCuenta", gasto.IdCuenta);
                    cmd.Parameters.AddWithValue("@Monto", gasto.Monto);
                    cmd.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
                    cmd.Parameters.AddWithValue("@IdUsuario", gasto.IdUsuario);

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

        // Eliminar
        public bool EliminarGasto(int idGasto)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_EliminarGasto", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdGasto", idGasto);

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
                    throw new ApplicationException("Error al eliminar el gasto");
                }
            }
        }
    }
}
