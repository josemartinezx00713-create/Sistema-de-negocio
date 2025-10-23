using Sistema.BLL;
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
    public partial class frmCategoria: Form
    {
        private Mensajes mensaje = new Mensajes();
        private readonly bCategoria bll = new bCategoria();
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = bCategoria.Listar();
                dgvListado.Columns[0].Visible = false;
            }
            catch
            {
                mensaje.mensajeError("Error al listar categorias.");
            }
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtCategoria.Clear();
            txtDescripcion.Clear();
        }

        private void Guardar()
        {
            var dato = new oCategoria
            {
                Nombre = txtCategoria.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            if (string.IsNullOrEmpty(txtId.Text))
            {
                var resultado = bCategoria.Registrar(dato);
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
                dato.idCategoria = Convert.ToInt32(txtId.Text);
                var resultado = bCategoria.Actualizar(dato);
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

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            txtBuscar.Text = "Buscar categoria...";
            txtBuscar.ForeColor = Color.Gray;

            
            txtBuscar.Enter += txtBuscar_Enter;
            txtBuscar.Leave += txtBuscar_Leave;

            Listar();
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar categoria...";
                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void Buscar(string Valor)
        {
            dgvListado.DataSource = bCategoria.Buscar(Valor);
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar categoria...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            tabContenedor.SelectedIndex = 1;
            txtCategoria.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e) => Guardar();

        //private void txtBuscar_TextChanged(object sender, EventArgs e) => Buscar(txtBuscar.Text);
    }
}
