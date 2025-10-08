using Sistema.BLL;
using Sistema.Modulos;
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

namespace Sistema.Formularios
{
    public partial class frmGastos : Form
    {
        private Mensajes mensaje = new Mensajes();

        public frmGastos()
        {
            InitializeComponent();
        }


            #region Métodos

            private void listarRegistros()
            {
                try
                {
                    DataTable dt = bGasto.Listar();

                    dgvListado.DataSource = dt;
                    formatoGrid();
                }
                catch (Exception)
                {
                    mensaje.mensajeError("Error al listar los registros.");
                }
            }

            private void buscarRegistros(DateTime fechaInicio, DateTime fechaFinal)
            {
                try
                {
                    DataTable dt = bGasto.Buscar(fechaInicio, fechaFinal);

                    if (dt.Rows.Count > 0)
                    {
                        dgvListado.DataSource = dt;
                        formatoGrid();
                    }
                    else
                    {
                        mensaje.mensajeInformacion("No se encontraron registros en el rango seleccionado.");
                        listarRegistros();
                    }
                }
                catch (Exception)
                {
                    mensaje.mensajeError("Error al buscar los registros.");
                }
            }

            private void formatoGrid()
            {
                if (dgvListado.Columns.Contains("MONTO"))
                {
                    dgvListado.Columns["MONTO"].DefaultCellStyle.Format = "N2";
                }

                if (dgvListado.Columns.Count > 0)
                {
                    dgvListado.Columns[0].Visible = false; // ocultar ID
                }
            }

            #endregion

            #region Botones de comando

            private void iconAgregar_Click(object sender, EventArgs e)
            {
                frmAgregarGastos frm = new frmAgregarGastos();
                frm.registroAgregado += listarRegistros;
                mostrarModal.MostrarConCapaTransparente(this, frm);
            }

            private void iconCerrar_Click(object sender, EventArgs e)
            {
                Close();
            }

            private void iconBuscar_Click(object sender, EventArgs e)
            {
                DateTime fechaInicio = dtpFechaInicial.Value.Date;
                DateTime fechaFinal = dtpFechaFinal.Value.Date;

                if (fechaInicio > fechaFinal)
                {
                    mensaje.mensajeValidacion("La fecha inicial no puede ser mayor que la fecha final.");
                    return;
                }

                buscarRegistros(fechaInicio, fechaFinal);
            }

        #endregion

        #region Eventos del Formulario

        private void frmGastos_Load_1(object sender, EventArgs e)
        {
            listarRegistros();

            dtpFechaInicial.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
        }

        #endregion


    }
    }
