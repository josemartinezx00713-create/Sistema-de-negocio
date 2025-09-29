using Sistema.DAL;
using Sistema.Entity;
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

namespace Sistema.UI.Formularios
{
    public partial class frmConexion : Form
    {
        private Mensajes mensajes = new Mensajes();

        public frmConexion()
        {
            InitializeComponent();
        }

        #region Botones de comando
        private void iconCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void iconAceptar_Click(object sender, EventArgs e)
        {
            errorIcono.Clear();
            bool datosValidos = true;

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        errorIcono.SetError(textBox, "Este campo es obligatorio.");
                        datosValidos = false;
                    }
                }
            }
            if (!datosValidos)
            {
                mensajes.mensajeValidacion("Información incompleta. Por favor, complete todos los campos obligatorios.");
                return;
            }

            var datosConexion = new DatosConexion 
            {
                servidor = txtServidor.Text.Trim(),
                baseDatos = txtBasededatos.Text.Trim(),
                usuario = txtUsuario.Text.Trim(),
                clave = txtClave.Text.Trim()
            };

            try
            {
                if(GestorConexion.ProbarConexion(datosConexion, out string error))
                {
                    GestorConexion.GuardarConexion(datosConexion);
                    mensajes.mensajeOk("Conexión exitosa y datos guardados.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    mensajes.mensajeError("Error de conexión: " + error);
                }
            }
            catch (Exception ex)
            {
                mensajes.mensajeError("Ocurrió un error al guardar los datos de conexión: " + ex.Message);
            }
        }
        #endregion


    }
}
