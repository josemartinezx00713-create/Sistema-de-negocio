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
    public class dProductos
    {
        public DataTable ListarProductos()
        {
            DataTable lista = new DataTable();
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_ListarProductos", cn))
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


        public DataTable BuscarProductos(int Filtro, string valor)
        {
            DataTable lista = new DataTable();

            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BuscarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Filtro", Filtro);
                    cmd.Parameters.AddWithValue("@Valor", valor);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        lista.Load(dr);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Error al buscar productos: {ex.Message}", ex);
            }

            return lista;
        }


        public bool RegistrarProductos(oProductos productos)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_RegistrarProductos", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", productos.codigo ?? string.Empty);
                cmd.Parameters.AddWithValue("@Stock", productos.stock);
                cmd.Parameters.AddWithValue("@Producto", productos.nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@IdCategoria", productos.idCategoria);
                cmd.Parameters.AddWithValue("@PrecioCompra", productos.costo);
                cmd.Parameters.AddWithValue("@PrecioVenta", productos.precio);

                SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(respuesta);

                cn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(respuesta.Value) == 1;
            }
        }



        public bool ActualizarProducto(oProductos productos)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarProductos", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", productos.idProducto);
                    cmd.Parameters.AddWithValue("@Codigo", productos.codigo);
                    cmd.Parameters.AddWithValue("@Stock", productos.stock);
                    cmd.Parameters.AddWithValue("@Producto", productos.nombre);
                    cmd.Parameters.AddWithValue("@IdCategoria", productos.idCategoria);
                    cmd.Parameters.AddWithValue("@PrecioCompra", productos.costo);
                    cmd.Parameters.AddWithValue("@PrecioVenta", productos.precio);

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

        public bool EliminarProducto(int idProducto)
        {
            using (SqlConnection cn = GestorConexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("sp_EliminarProductos", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

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
