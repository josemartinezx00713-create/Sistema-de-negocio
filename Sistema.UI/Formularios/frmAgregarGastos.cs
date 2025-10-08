using Sistema.BLL;
using Sistema.Entity;
using Sistema.Modulos;
using Sistema.UI.FormularioBase;
using Sistema.UI.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Sistema.Formularios
{
    public partial class frmAgregarGastos : frmAgregarPlantilla
    {
        private Mensajes mensaje = new Mensajes();
        private Validaciones validaciones = new Validaciones();
        public event Action registroAgregado;

        public frmAgregarGastos()
        {
            InitializeComponent();

            this.KeyPress += Validaciones.pasarFocus;
            this.KeyDown += Validaciones.controlarEsc;
        }

        #region Métodos

        private void cargarCatalogo()
        {
            try
            {
                var gasto = bCuentasGasto.Listar();
                if (gasto != null && gasto.Rows.Count > 0)
                {
                    cboCatalogo.DataSource = gasto;
                    cboCatalogo.ValueMember = "ID";
                    cboCatalogo.DisplayMember = "NOMBRE";
                    cboCatalogo.SelectedIndex = 0;
                }
                else
                {
                    mensaje.mensajeError("No hay cuentas de gasto para mostrar.");
                }
            }
            catch (Exception ex)
            {
                mensaje.mensajeError("Error al cargar catálogo de cuentas de gasto: " + ex.Message);
            }
        }

        private void Guardar()
        {
            try
            {
                oGasto gasto = new oGasto
                {
                    IdUsuario = 2,
                    Fecha = dtpFecha.Value.Date,
                    Monto = decimal.Parse(txtMonto.Text.Trim()),
                    IdCuenta = Convert.ToInt32(cboCatalogo.SelectedValue),
                    Descripcion = txtVar4.Text.Trim()
                };

                var resultado = bGasto.Registrar(gasto);

                if (resultado.esValido)
                {
                    mensaje.mensajeOk(resultado.mensaje);
                    Limpiar();
                    registroAgregado?.Invoke();
                }
                else
                {
                    mensaje.mensajeError(resultado.mensaje);
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al guardar el registro.");
            }
        }

        private void Limpiar()
        {
            dtpFecha.Value = DateTime.Now;
            txtMonto.Text = "0.00";
            if (cboCatalogo.Items.Count > 0) cboCatalogo.SelectedIndex = 0;
            txtVar4.Text = "Ninguna";
            txtMonto.Focus();
        }

        #endregion

        #region Botones de comando
        private void iconButton1_Click(object sender, EventArgs e)
        {
            errorIcono.Clear();
            bool datosValidos = true;

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox gunaTextBox)
                {
                    if (string.IsNullOrWhiteSpace(gunaTextBox.Text))
                    {
                        errorIcono.SetError(gunaTextBox, "Este campo es obligatorio.");
                        datosValidos = false;
                    }
                }

                if (control is Guna.UI2.WinForms.Guna2ComboBox gunaComboBox)
                {
                    if (gunaComboBox.SelectedIndex < 0)
                    {
                        errorIcono.SetError(gunaComboBox, "Este campo es obligatorio.");
                        datosValidos = false;
                    }
                }
            }

            if (!datosValidos)
            {
                mensaje.mensajeValidacion("Información incompleta, revise los campos obligatorios.");
                return;
            }

            DateTime fecha = dtpFecha.Value.Date;
            DateTime fechaActual = DateTime.Now.Date;
            decimal.TryParse(txtMonto.Text.Trim(), out decimal monto);

            if (fecha > fechaActual)
            {
                mensaje.mensajeValidacion("La fecha no puede ser mayor que la fecha actual.");
                return;
            }

            if (monto <= 0)
            {
                mensaje.mensajeValidacion("El monto debe ser mayor a cero.");
                txtMonto.Focus();
                return;
            }

            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    

        #endregion

        #region Eventos del Formulario

        private void frmAgregarGastos_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Cajas de texto    
        private void txtMonto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(sender, e);
        }

        private void txtMonto_Leave_1(object sender, EventArgs e)
        {
            Validaciones.formatoDecimal((Guna.UI2.WinForms.Guna2TextBox)sender);
        }
        #endregion

        private void frmAgregarGastos_Load_1(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            txtMonto.Text = "0.00";
            cargarCatalogo();
        }

        
    }
}
    
