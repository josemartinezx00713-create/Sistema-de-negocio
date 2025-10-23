using Sistema.BLL;
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

namespace Sistema.UI.Formularios
{
    public partial class frmProductos: frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();
        public frmProductos()
        {
            InitializeComponent();
        }

        #region "Metodos"
        private void listarRegistros()
        {
            try
            {
                DataTable dt = bProductos.ListarProductos();

                // Mostrar los nombres de las columnas en la ventana de salida de Visual Studio
                string columnas = string.Join(", ", dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName));
                System.Diagnostics.Debug.WriteLine("Columnas del DataTable: " + columnas);


                dgvListado.DataSource = dt;
                formatoGrid();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al listar los registros.");
            }
        }



        private void formatoGrid()
        {
            // Mostrar todas las columnas primero (opcional)
            foreach (DataGridViewColumn col in dgvListado.Columns)
            {
                col.Visible = true;
            }

            // Ocultar la columna ID si existe
            if (dgvListado.Columns.Contains("ID"))
            {
                dgvListado.Columns["ID"].Visible = false;
            }

            // Ocultar la columna CATEGORIA si existe
            if (dgvListado.Columns.Contains("CATEGORIA"))
            {
                dgvListado.Columns["CATEGORIA"].Visible = false;
            }

            // Formato para la columna MONTO si existe
            if (dgvListado.Columns.Contains("MONTO"))
            {
                dgvListado.Columns["MONTO"].DefaultCellStyle.Format = "N2";
            }
        }


        private void SeleccionarRegistros(int filaSeleccionada)
        {
            try
            {

                int id = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["ID"].Value);
                string codigo = dgvListado.Rows[filaSeleccionada].Cells["CODIGO"].Value?.ToString();
                string nombre = dgvListado.Rows[filaSeleccionada].Cells["PRODUCTO"].Value?.ToString();
                decimal costo = Convert.ToDecimal(dgvListado.Rows[filaSeleccionada].Cells["P_COMPRA"].Value);
                decimal precio = Convert.ToDecimal(dgvListado.Rows[filaSeleccionada].Cells["PRECIO"].Value);
                int idcategoria = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["CATEGORIA"].Value);
                int stock = Convert.ToInt32(dgvListado.Rows[filaSeleccionada].Cells["STOCK"].Value);

                frmAgregarProducto frm = new frmAgregarProducto(id, codigo, nombre, costo, precio, idcategoria, stock);
                frm.registroAgregado += listarRegistros;
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
                string nombre = dgvListado.Rows[2].Cells["PRODUCTO"].Value?.ToString();
                if (mensaje.mensajeConfirmar("¿Seguro que desea eliminar el Producto " + nombre + "?") == DialogResult.OK)
                {
                    int id = Convert.ToInt32(dgvListado.Rows[fila].Cells["ID"].Value);
                    string resultado = bProductos.Eliminar(id);

                    if (resultado.Contains("éxito"))
                    {
                        mensaje.mensajeOk(resultado);
                    }
                    else
                    {
                        mensaje.mensajeInformacion(resultado);
                    }

                    listarRegistros();
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar el registro.");
            }
        }

        private void Buscar(int Filtro, string Valor)
        {
            dgvListado.DataSource = bProductos.Buscar(Filtro, Valor);
        }



        #endregion

        #region "Botones"
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null)
            {
                SeleccionarRegistros(dgvListado.CurrentRow.Index);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarProducto frm = new frmAgregarProducto();
            frm.registroAgregado += listarRegistros;
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow != null)
            {
                EliminarRegistro(dgvListado.CurrentRow.Index);
            }
        }

        //private void txtBuscar_TextChanged(object sender, EventArgs e) => Buscar(txtBuscar.Text);



        #endregion

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    dgvListado.DataSource = bProductos.Buscar(txtBuscar.Text.Trim());
            //    if (dgvListado.Rows.Count > 0)
            //    {
            //        btnActualizar.Enabled = true;
            //        btnEliminar.Enabled = true;
            //    }
            //    else
            //    {
            //        btnActualizar.Enabled = false;
            //        btnEliminar.Enabled = false;
            //    }
            //}
            //catch (Exception)
            //{
            //    mensaje.mensajeError("Error al buscar registros.");
            //}
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            listarRegistros();
        }
    }
}
