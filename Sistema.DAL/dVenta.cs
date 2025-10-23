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
    public class dVenta
    {
        public bool RegistrarVenta(oVenta venta, out int nVenta, out string factura)
        {
            nVenta = 0;
            factura = string.Empty;
            try
            {
                using (SqlConnection cn = GestorConexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                    cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@Cliente", venta.Cliente);
                    cmd.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);
                    cmd.Parameters.AddWithValue("@CostoTotal", venta.CostoTotal);
                    cmd.Parameters.AddWithValue("@Detalles", venta.Detalles);

                    SqlParameter numeroVenta = new SqlParameter("@Venta", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(numeroVenta);

                    SqlParameter numeroFactura = new SqlParameter("@Factura", SqlDbType.VarChar, 20)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(numeroFactura);

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
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al agregar el registro.");
            }
        }
        }
}
