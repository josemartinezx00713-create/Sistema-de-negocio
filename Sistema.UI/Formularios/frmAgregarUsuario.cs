using Sistema.BLL;
using Sistema.Entity;
using Sistema.UI.FormularioBase;
using Sistema.UI.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Sistema.UI.Formularios
{
    public partial class frmAgregarUsuario : frmAgregarRegistros
    {
        private Mensajes mensajes = new Mensajes();
        public event Action registroAgregado;
        Boolean actualizarRegistro = false;

        public frmAgregarUsuario()
        {
            InitializeComponent();
            CargarRoles();
            cboRoles.SelectedIndex = 0;
            
        }

        public frmAgregarUsuario(int id, string cedula, string nombre, string codigo, string email, int rol)
        {
            try
            {
                InitializeComponent();

                CargarRoles();

                txtId.Text = id.ToString();
                txtCedula.Text = cedula;
                txtNombre.Text = nombre;
                txtCodigo.Text = codigo;
                txtEmail.Text = email;
                rol = cboRoles.SelectedIndex;
                txtClave.Visible = false;
                label9.Visible = false;
                label6.Text = "  Editar un usuario";

                actualizarRegistro = true;

            }
            catch (Exception)
            {
                mensajes.mensajeError("Error al inicializar el formulario.");
            }
        }

        #region Metodos
        private void errorControl(string control)
        {
            switch (control)
            {
                case "IdRol":
                    errorIcon.SetError(cboRoles, "Este campo es obligatorio.");
                    cboRoles.Focus();
                    break;
                case "Cedula":
                    errorIcon.SetError(txtCedula, "Este campo es obligatorio.");
                    txtCedula.Focus();
                    break;
                case "Nombre":
                    errorIcon.SetError(txtNombre, "Este campo es obligatorio.");
                    txtNombre.Focus();
                    break;
                case "Codigo":
                    errorIcon.SetError(txtCodigo, "Este campo es obligatorio.");
                    txtCodigo.Focus();
                    break;
                case "Email":
                    errorIcon.SetError(txtEmail, "Este campo es obligatorio.");
                    txtEmail.Focus();
                    break;
                case "Clave":
                    errorIcon.SetError(txtClave, "Este campo es obligatorio.");
                    txtClave.Focus();
                    break;
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = "0";
            txtCedula.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtEmail.Clear();
            cboRoles.SelectedIndex = 0;
            txtClave.Clear();

            txtCedula.Focus();
        }
        private void CargarRoles()
        {
            try
            {
                var rol = bUsuario.listarRol();
                if (rol != null && rol.Rows.Count > 0)
                {
                    cboRoles.DataSource = rol;
                    cboRoles.ValueMember = "ID";
                    cboRoles.DisplayMember = "ROL";
                    cboRoles.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                mensajes.mensajeError("Error al cargar las categorías.");
            }
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                errorIcon.Clear();

                if (!int.TryParse(cboRoles.SelectedValue?.ToString(), out int idRol))
                {
                    mensajes.mensajeValidacion("Debe seleccionar un rol válido.");
                    errorIcon.SetError(cboRoles, "Este campo es obligatorio.");
                    cboRoles.Focus();
                    return;
                }

                oUsuario usuario = new oUsuario
                {
                    dniUsuario = txtCedula.Text,
                    nombreUsuario = txtNombre.Text,
                    codigoUsuario = txtCodigo.Text,
                    email = txtEmail.Text,
                    idRol = idRol,
                    clave = txtClave.Text,
                };

                resultadoOperacion resultado;

                // Reparación: Validar que txtId.Text no esté vacío antes de intentar el parseo
                int id = 0;
                if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text.Trim(), out id))
                {
                    id = 0;
                    txtId.Text = "0";
                }

                if (id == 0)
                {
                    resultado = bUsuario.RegistrarUsuario(usuario);
                }
                else
                {
                    usuario.idUsuario = id;
                    resultado = bUsuario.ActualizarUsuario(usuario);
                }

                if (resultado == null)
                {
                    mensajes.mensajeError("No se obtuvo respuesta del registro/actualización.");
                    return;
                }

                if (!resultado.esValido)
                {
                    mensajes.mensajeValidacion(resultado.mensaje);

                    if (!string.IsNullOrEmpty(resultado.campoInvalido))
                    {
                        errorControl(resultado.campoInvalido);
                    }
                    return;
                }
                mensajes.mensajeOk(resultado.mensaje);
                registroAgregado?.Invoke();
                LimpiarControles();
                if (actualizarRegistro) Close();
                txtNombre.Focus();
            }
            catch (Exception)
            {
                mensajes.mensajeError("Ocurrio un errror inesperado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
