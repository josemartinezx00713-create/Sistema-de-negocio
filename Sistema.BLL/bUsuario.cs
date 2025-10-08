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
    public class bUsuario
    {
        private static readonly dUsuario usuarioDal = new dUsuario();
        public static DataTable listarUsuarios()
        {
            try
            {
                return usuarioDal.ListarUsuario();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar los registros");
            }
        }

        public static DataTable buscarUsuarios(string nombre)
        {
            try
            {
                return usuarioDal.BuscarUsuario(nombre);
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al buscar los resgistros");
            }
        }

        public static DataTable listarRol()
        {
            try
            {
                return usuarioDal.ListarRol();
            }
            catch (Exception)
            {
                throw new ApplicationException("Error al listar registros.");
            }
        }

        private static resultadoOperacion validarUsuario(oUsuario usuario)
        {

            if (string.IsNullOrWhiteSpace(usuario.dniUsuario))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese la identificación del usuario.",
                    campoInvalido = "dniUsuario"
                };

            if (string.IsNullOrWhiteSpace(usuario.nombreUsuario))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el nombre del usuario.",
                    campoInvalido = "nombreUsuario"
                };

            if (string.IsNullOrWhiteSpace(usuario.codigoUsuario))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el codigo del usuario.",
                    campoInvalido = "codigoUsuario"
                };

            if (!Validar.emailValidado(usuario.email))
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ingrese el email del usuario.",
                    campoInvalido = "email"
                };

            //if (!Validar.claveSegura(usuario.clave))
            //    return new resultadoOperacion
            //    {
            //        esValido = false,
            //        mensaje = "Ingrese una contraseña segura",
            //        campoInvalido = "clave"
            //    };
            return new resultadoOperacion { esValido = true };
        }

        public static resultadoOperacion RegistrarUsuario(oUsuario usuario)
        {
            var validacion = validarUsuario(usuario);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = usuarioDal.RegistrarUsuario(usuario);

                if (resultado)
                {
                    return new resultadoOperacion
                    {
                        esValido = true,
                        mensaje = "Registro almacenado satisfactoriamente"
                    };
                }
                else
                {
                    return new resultadoOperacion
                    {
                        esValido = false,
                        mensaje = "No se puedo crear el registro. Verfique los datos"
                    };
                }
            }
            catch (Exception)
            {
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ocurrió un error inesperado al guardar el registro"
                };
            }
        }

        public static resultadoOperacion ActualizarUsuario(oUsuario usuario)
        {
            var validacion = validarUsuario(usuario);
            if (!validacion.esValido)
                return validacion;

            try
            {
                bool resultado = usuarioDal.ActualizarUsuario(usuario);

                if (resultado)
                {
                    return new resultadoOperacion
                    {
                        esValido = true,
                        mensaje = "Registro editado satisfactoriamente"
                    };
                }
                else
                {
                    return new resultadoOperacion
                    {
                        esValido = false,
                        mensaje = "No se puedo editar el registro. Verfique los datos"
                    };
                }
            }
            catch (Exception)
            {
                return new resultadoOperacion
                {
                    esValido = false,
                    mensaje = "Ocurrió un error inesperado al editar el registro"
                };
            }
        }

        public static string EliminarUsuario(int idUsuario)
        {

            if (idUsuario <= 0)
                return "Debe espesificar un regustro valido";

            try
            {
                bool resultado = usuarioDal.EliminarUsuario(idUsuario);

                if (resultado)
                {
                    return "Registro eliminado de forma exitosa";
                }
                else
                {
                    return "No se pudo eliminar el registro";
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error inesperado al eliminar el registro.");
            }

        }
    }
}
