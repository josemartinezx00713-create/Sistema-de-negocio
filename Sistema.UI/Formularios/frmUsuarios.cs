using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.UI.FormularioBase;
using Sistema.UI.Modulos;

namespace Sistema.UI.Formularios
{
    public partial class frmUsuarios : frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();
        public frmUsuarios()
        {
            InitializeComponent();
        }
        #region Metodos
        private void ListarUsuarios()
        {
            dgvListado.DataSource = bUsuario.listarUsuarios();
            if (dgvListado.Rows.Count > 0)
            {
                btnSalir.Enabled = true;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                txtBuscar.Enabled = true;
            }
            else
            {
                btnSalir.Enabled = false;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                txtBuscar.Enabled = false;
            }
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[1].Visible = false;
            dgvListado.Columns[5].Visible = false;

            txtBuscar.Focus();
        }

        private void SeleccionarRegistros(int filaSeleccionada)
        {
            try
            {

                int id = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["ID"].Value);
                string cedula = dgvListado.Rows[filaSeleccionada].Cells["IDENTIFICACION"].Value?.ToString();
                string nombre = dgvListado.Rows[filaSeleccionada].Cells["USUARIO"].Value?.ToString();
                string codigo = dgvListado.Rows[filaSeleccionada].Cells["CODIGO"].Value?.ToString();
                string email = dgvListado.Rows[filaSeleccionada].Cells["EMAIL"].Value?.ToString();
                int rol = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["IDROL"].Value);

                frmAgregarUsuario frm = new frmAgregarUsuario(id, cedula, nombre, codigo, email, rol);
                frm.registroAgregado += ListarUsuarios;
                mostrarModal.MostrarConCapaTransparente(this, frm);
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al seleccionar el registro.");
            }
        }

        private void EliminarRegistro(int fila)
        {
            try
            {
                string nombre = dgvListado.Rows[2].Cells["USUARIO"].Value?.ToString();
                if (mensaje.mensajeConfirmar("¿Seguro que desea eliminar el usuario " + nombre + "?") == DialogResult.OK)
                {
                    int id = Convert.ToInt32(dgvListado.Rows[fila].Cells["ID"].Value);
                    string resultado = bUsuario.EliminarUsuario(id);

                    if (resultado.Contains("éxito"))
                    {
                        mensaje.mensajeOk(resultado);
                    }
                    else
                    {
                        mensaje.mensajeInformacion(resultado);
                    }

                    ListarUsuarios();
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar el registro.");
            }
        }
        #endregion

        #region Botones
        private void iconAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario frm = new frmAgregarUsuario();
            frm.registroAgregado += ListarUsuarios;
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void iconEditar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null)
            {
                SeleccionarRegistros(dgvListado.CurrentRow.Index);
            }
        }

        private void iconEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null)
            {
                EliminarRegistro(dgvListado.CurrentRow.Index);
            }
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = bUsuario.buscarUsuarios(txtBuscar.Text.Trim());
                if (dgvListado.Rows.Count > 0)
                {
                    btnActualizar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    btnActualizar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al buscar registros.");
            }
        }
    }
}
