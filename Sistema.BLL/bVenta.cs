using Sistema.DAL;
using Sistema.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.BLL
{
    public class bVenta
    {
        private static readonly dVenta dalVenta = new dVenta();

        public static resultadoOperacion validarVenta(oVenta venta)
        {
            if (venta.Detalles == null || venta.Detalles.Rows.Count == 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Debe agregar al menos un producto al carrito de compras.",
                };

            if (venta.TotalVenta <= 0)
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "El total de la venta debe ser mayor a cero.",
                    campoInvalido = "totalGeneral"
                };

            

            return new resultadoOperacion { esValido = true };

        }

        public static resultadoOperacion registrarVenta(oVenta venta)
        {
            var validacion = validarVenta(venta);
            if (!validacion.esValido)
                return validacion;

            try
            {
                string numeroFactura;
                bool resultado = dalVenta.RegistrarVenta(venta, out int numeroVenta,out numeroFactura);

                if (resultado)
                {
                    return new resultadoOperacion
                    {
                        esValido = true,
                        mensaje = "Venta realizada satisfactoriamente.",
                        numeroFactura = numeroFactura
                    };
                }
                else
                {
                    return new resultadoOperacion
                    {
                        esValido = false,
                        mensaje = "No se puedo crear el registro. Verfique los datos."
                    };
                }
            }

            catch (Exception)
            {
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ocurrió un error inesperado al guardar el registro."
                };
            }
        }
    }
}
