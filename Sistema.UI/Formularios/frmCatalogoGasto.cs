using Guna.UI2.WinForms;
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
using Sistema.UI.FormularioBase;
using Sistema.UI.Modulos;
using Sistema.Entity;
using Sistema.DAL;
using Sistema.BLL;


namespace Sistema.Formularios
{
    public partial class frmCatalogoGasto : Form
    {

        private Mensajes mensaje = new Mensajes();
        private readonly bCuentasGasto bll = new bCuentasGasto();
        public frmCatalogoGasto()
        {
            InitializeComponent();
        }

        private void frmCatalogoEgreso_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = bCuentasGasto.Listar();
                dgvListado.Columns[0].Visible = false;
            }
            catch
            {
                mensaje.mensajeError("Error al listar cuentas de gasto.");
            }
        }

        private void Buscar(string nombre)
        {
            dgvListado.DataSource = bCuentasGasto.Buscar(nombre);
        }

        private void Guardar()
        {
            var cuenta = new oCuentasGasto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            if (string.IsNullOrEmpty(txtId.Text))
            {
                var resultado = bCuentasGasto.Registrar(cuenta);
                // Asumiendo que resultadoOperacion tiene una propiedad 'Exito' (bool) para indicar éxito
                if (!resultado.Exito)
                {
                    mensaje.mensajeOk("Cuenta registrada con éxito.");
                    Listar();
                    Limpiar();
                }
                else
                {
                    mensaje.mensajeError("No se pudo registrar la cuenta.");

                }
            }
            else
            {
                cuenta.IdCuenta = Convert.ToInt32(txtId.Text);
                var resultado = bCuentasGasto.Actualizar(cuenta);
                // Asumiendo que resultadoOperacion tiene una propiedad 'Exito' (bool) para indicar éxito
                if (resultado.Exito)
                {
                    mensaje.mensajeOk("Cuenta actualizada con éxito.");
                    Listar();
                    Limpiar();
                }
                else
                {
                    mensaje.mensajeError("No se pudo actualizar la cuenta.");
                }
            }
        }

        private void Eliminar()
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                mensaje.mensajeValidacion("Selecciona una cuenta para eliminar.");
                return;
            }

            int idCuenta = Convert.ToInt32(txtId.Text);
            // El método Eliminar devuelve un string, no un bool. Se debe comparar el resultado.
            string resultado = bCuentasGasto.Eliminar(idCuenta);
            if (resultado == "OK")
            {
                mensaje.mensajeOk("Cuenta eliminada con éxito.");
                Listar();
                Limpiar();
            }
            else
            {
                mensaje.mensajeError("No se pudo eliminar la cuenta.");
            }
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        // === EVENTOS ===
        

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvListado.Rows[e.RowIndex].Cells["IdCuenta"].Value.ToString();
                txtNombre.Text = dgvListado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvListado.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                tabContenedor.SelectedIndex = 1;
            }
        }

       

        private void iconAgregar_Click_1(object sender, EventArgs e)
        {
            tabContenedor.SelectedIndex = 1;
            txtNombre.Focus();
        }

        private void iconCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void iconGuardar_Click_1(object sender, EventArgs e) => Guardar();

        private void iconCancelar_Click(object sender, EventArgs e)
        {
            tabContenedor.SelectedIndex = 0;
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e) => Buscar(txtBuscar.Text);

    }
}