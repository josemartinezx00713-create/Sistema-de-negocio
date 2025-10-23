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
    public class dCategoria
    {
        public DataTable ListarCategorias()
        {
            DataTable lista = new DataTable();
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarCategoria", cn))
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

        public bool RegistrarCategoria(oCategoria dato)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarCategoria", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Categoria", dato.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", dato.Descripcion);

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
        public bool ActualizarCategoria(oCategoria dato)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_EditarCategoria", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCategoria", dato.idCategoria);
                    cmd.Parameters.AddWithValue("@Categoria", dato.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", dato.Descripcion);

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


        public DataTable BuscarCategoria(string valor)
        {
            DataTable lista = new DataTable();
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarCategoria", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch
            {
                throw new ApplicationException("Error al buscar la categoría");
            }
            return lista;
        }




    }
}
