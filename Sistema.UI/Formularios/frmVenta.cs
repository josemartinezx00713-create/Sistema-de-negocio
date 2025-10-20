using Sistema.BLL;
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

namespace Sistema.UI.Formularios
{
    public partial class frmVenta : frmPlantilla
    {
        private Mensajes mensaje = new Mensajes();
        private DataTable detalleVenta = new DataTable();
        private Validaciones validaciones = new Validaciones();
        public frmVenta()
        {
            InitializeComponent();
        }

        #region Metodos 

        private void listarRegistros()
        {
            dgvProductos.DataSource = bProducto.listarProductos();
            if (dgvProductos.Rows.Count > 0)
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
            formatoGridListado();
        
        }

        private void formatoGridListado()
        {
            // Ajuste general: que el grid use todo el ancho disponible
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductos.Columns[0].Visible = false;
            dgvProductos.Columns[3].Visible = false;
            //dgvProductos.Columns[2].Visible = false;
            //dgvProductos.Columns[4].HeaderText = "PRECIO";
            //dgvListado.Columns[4].Visible = false;

            // Ajustar ancho específico para precio de venta
            dgvProductos.Columns[4].FillWeight = 70;

            // Formato decimal
            dgvProductos.Columns["P_VENTA"].DefaultCellStyle.Format = "N2";

            // Centrado de encabezados
            dgvProductos.Columns["P_VENTA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Alinear precios
            dgvProductos.Columns["P_VENTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void crearTabla()
        {
            try
            {
                detalleVenta.Columns.Add("idProducto", System.Type.GetType("System.Int32"));
                detalleVenta.Columns.Add("cant", System.Type.GetType("System.Int32"));
                detalleVenta.Columns.Add("nombreProducto", System.Type.GetType("System.String"));
                detalleVenta.Columns.Add("precioCosto", System.Type.GetType("System.Decimal"));
                detalleVenta.Columns.Add("precioVenta", System.Type.GetType("System.Decimal"));
                detalleVenta.Columns.Add("totalVenta", System.Type.GetType("System.Decimal"));
                detalleVenta.Columns.Add("costoVenta", System.Type.GetType("System.Decimal"));
                detalleVenta.Columns.Add("utilidadBruta", System.Type.GetType("System.Decimal"));

                dgvDetalle.DataSource = detalleVenta;
                formatoTabla();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al crear DataTable.");
            }
        }

        private void formatoTabla()
        {
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].HeaderText = "CANT";
            dgvDetalle.Columns[2].HeaderText = "DESCRIPCIÓN";
            dgvDetalle.Columns[3].Visible = false;
            dgvDetalle.Columns[4].HeaderText = "PRECIO";
            dgvDetalle.Columns[5].Visible = false;
            dgvDetalle.Columns[6].Visible = false;
            dgvDetalle.Columns[7].Visible = false;

            dgvDetalle.Columns["precioVenta"].DefaultCellStyle.Format = "N2";

            // Desactivar el autosize solo para la columna de nombreProducto
            dgvDetalle.Columns["nombreProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Alineación
            dgvDetalle.Columns["cant"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["precioVenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns["cant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["precioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[2].ReadOnly = true;
        }

        private void ajustarColumnas()
        {
            try
            {
                if (dgvDetalle.Columns.Count == 0)
                    return;

                dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ancho disponible sin bordes ni scrollbars
                int anchoDisponible = dgvDetalle.ClientSize.Width;

                // Anchos fijos para CANT y PRECIO
                int anchoCant = 65;
                int anchoPrecio = 120;

                // Ancho para la columna PRODUCTO
                int anchoProducto = anchoDisponible - (anchoCant + anchoPrecio + 20);

                // Asignar los anchos
                dgvDetalle.Columns["cant"].Width = anchoCant;
                dgvDetalle.Columns["nombreProducto"].Width = anchoProducto;
                dgvDetalle.Columns["precioVenta"].Width = anchoPrecio;
            }

            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error al ajustar el diseño del detalle.");
            }

        }

        public void agregarProducto(int idProducto, string producto, int cantidad, decimal precioCosto, decimal precioVenta)
        {
            try
            {
                bool registroDuplicado = false;

                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    if (fila.Cells["idProducto"].Value != null &&
                        Convert.ToInt32(fila.Cells["idProducto"].Value) == idProducto)
                    {
                        mensaje.mensajeInformacion($"El producto ya se encuentra en la lista.");
                        registroDuplicado = true;
                        break;
                    }
                }

                if (!registroDuplicado)
                {
                    DataRow nuevaFila = detalleVenta.NewRow();
                    nuevaFila["idProducto"] = idProducto;
                    nuevaFila["cant"] = cantidad;
                    nuevaFila["nombreProducto"] = producto;
                    nuevaFila["precioCosto"] = precioCosto;
                    nuevaFila["precioVenta"] = precioVenta;
                    nuevaFila["totalVenta"] = cantidad * precioVenta;
                    nuevaFila["costoVenta"] = cantidad * precioCosto;
                    nuevaFila["utilidadBruta"] = ((cantidad * precioVenta) - (cantidad * precioCosto));
                    detalleVenta.Rows.Add(nuevaFila);
                }

                calcularTotales();
                btnActualizar.Enabled = true;
                txtBuscar.Clear();
            }

            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error al agregar el producto.");
            }
        }

        private void calcularTotales()
        {
            try
            {
                decimal totalVenta = 0;
                decimal costoVenta = 0;
                decimal utilidadBruta = 0;

                foreach (DataRow fila in detalleVenta.Rows)
                {
                    totalVenta += Convert.ToDecimal(fila["totalVenta"]);
                    costoVenta += Convert.ToDecimal(fila["costoVenta"]);
                    utilidadBruta += Convert.ToDecimal(fila["utilidadBruta"]);
                }

                lblTotalVenta.Text = totalVenta.ToString("N2");
                lblCostoVenta.Text = costoVenta.ToString("N2");
                lblUtilidadBruta.Text = utilidadBruta.ToString("N2");
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al calcular totales.");
            }
        }


        private void bloquearControles()
        {
            panelVenta.Enabled = false;
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
        }

        private void desbloquearControles()
        {
            panelVenta.Enabled = true;
            detalleVenta.Clear();
            txtCliente.Text = "Cliente mostrador";
            lblTotalVenta.Text = "0.00";
            lblCostoVenta.Text = "0.00";
            lblUtilidadBruta.Text = "0.00";
            txtPrecio.Text = "0.00";
            txtDescripcion.Clear();
            btnActualizar.Enabled = true;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            dtpFecha.Value = DateTime.Now;
            tabControl.SelectedIndex = 0;
            txtBuscar.Focus();
        }

        private void Txt_KeyPressCantidad(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox txt)
            {
                Validaciones.numerosEnteros(e, txt.Text);
            }
        }

        private void Txt_KeyPressPrecio(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox txt)
            {
                Validaciones.validarDecimal(txt, e);
            }
        }

        #endregion

        #region Eventos del formulario
        private void frmVenta_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            listarRegistros();
            crearTabla();
            bloquearControles();
        }
        private void frmVenta_Shown(object sender, EventArgs e)
        {
            ajustarColumnas();
        }
        private void frmVenta_Resize(object sender, EventArgs e)
        {
            ajustarColumnas();
        }

        #endregion

        #region Botones de comando
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now.Date;
            DateTime fechaVenta = dtpFecha.Value.Date;

            try
            {
                if (fechaVenta > fechaActual)
                {
                    mensaje.mensajeValidacion("La fecha de venta no puede ser mayor que la fecha actual.");
                    return;
                }

                if (string.IsNullOrEmpty(txtCliente.Text))
                {
                    mensaje.mensajeValidacion("Debe ingresar el nombre del cliente.");
                    txtCliente.Focus();
                    return;
                }

                if (dgvDetalle.Rows.Count == 0)
                {
                    mensaje.mensajeValidacion("Debe agregar al menos un producto al carrito de compras.");
                    return;
                }

                if (!decimal.TryParse(lblTotalVenta.Text.Replace("C$", "").Trim(), out decimal totalVenta) || totalVenta <= 0)
                {
                    mensaje.mensajeValidacion("El total de la venta debe ser mayor a cero.");
                    return;
                }

                if (!decimal.TryParse(lblCostoVenta.Text.Replace("C$", "").Trim(), out decimal costoVenta))
                {
                    mensaje.mensajeValidacion("No se pudo obtener el costo de venta.");
                    return;
                }

                if (!decimal.TryParse(lblUtilidadBruta.Text.Replace("C$", "").Trim(), out decimal utilidadBruta))
                {
                    mensaje.mensajeValidacion("No se pudo obtener la utilidad de la venta.");
                    return;
                }

                string cliente = txtCliente.Text.Trim();

                if (mensaje.mensajeConfirmar("¿Desea registrar esta venta?") == DialogResult.Yes)
                {
                    //GuardarVenta(Variables.idUsuario, fechaVenta, cliente, totalVenta, costoVenta, detalleVenta);
                }
            }

            catch (Exception)
            {
                mensaje.mensajeError("Ocurrió un error inesperado.");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(txtIdVenta.Text.Trim(), out int idVenta);

                mensaje.mensajeInformacion("Funcionalidad en desarrollo.");
            }

            catch (Exception)
            {
                mensaje.mensajeError("Error al imprimir factura.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            desbloquearControles();
        }

        #endregion

        #region Cajas de Texto

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //string nombre = txtBuscar.Text.Trim();
            //string connectionString = ConexionDB.obtenerConexion();

            //try
            //{
            //    using (SqlConnection conexion = new SqlConnection(connectionString))
            //    using (SqlCommand command = new SqlCommand("sp_BuscarProductos", conexion))
            //    {
            //        command.CommandType = CommandType.StoredProcedure;
            //        command.Parameters.AddWithValue("@Nombre", nombre);

            //        SqlDataAdapter adapter = new SqlDataAdapter(command);
            //        DataTable dt = new DataTable();
            //        adapter.Fill(dt);

            //        dgvListado.DataSource = dt;

            //    }
            //}
            //catch (Exception)
            //{
            //    mensaje.MensajeError("Error al buscar registros.");
            //}
        }

        //private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            e.SuppressKeyPress = true;
        //            if (dgvListado.CurrentRow != null)
        //            {
        //                int cantidad = 1;
        //                int.TryParse(dgvListado.CurrentRow.Cells["ID"].Value.ToString(), out int idProducto);
        //                string producto = dgvListado.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
        //                decimal.TryParse(dgvListado.CurrentRow.Cells["P_COMPRA"].Value.ToString(), out decimal precioCompra);
        //                decimal.TryParse(dgvListado.CurrentRow.Cells["P_VENTA"].Value.ToString(), out decimal precioVenta);
        //                agregarProducto(idProducto, producto, cantidad, precioCompra, precioVenta);
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        mensaje.mensajeError(ex.Message);
        //    }
        //}

        //private void txtDescripción_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.SuppressKeyPress = true;
        //        txtPrecio.Focus();
        //    }
        //}

        //private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    Validaciones.validarDecimal(sender, e);
        //}

        //private void txtPrecio_Leave(object sender, EventArgs e)
        //{
        //    Validaciones.formatoDecimal((Guna.UI2.WinForms.Guna2TextBox)sender);
        //}

        #endregion

        #region Eventos del DatagridView Listado

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int cantidad = 1;
                    int.TryParse(dgvProductos.CurrentRow.Cells["ID"].Value.ToString(), out int idProducto);
                    string producto = dgvProductos.CurrentRow.Cells["PRODUCTO"].Value.ToString();
                    decimal.TryParse(dgvProductos.CurrentRow.Cells["P_COMPRA"].Value.ToString(), out decimal precioCompra);
                    decimal.TryParse(dgvProductos.CurrentRow.Cells["P_VENTA"].Value.ToString(), out decimal precioVenta);
                    agregarProducto(idProducto, producto, cantidad, precioCompra, precioVenta);
                }
                catch (Exception)
                {
                    mensaje.mensajeError("Error al seleccionar el registro.");
                }
            }
        }

        #endregion

        #region Eventos del DataGridView Detalles

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (e.Control is TextBox txt)
                {
                    txt.KeyPress -= Txt_KeyPressCantidad;
                    txt.KeyPress -= Txt_KeyPressPrecio;

                    if (dgvDetalle.CurrentCell.ColumnIndex == 1)
                        txt.KeyPress += Txt_KeyPressCantidad;
                    else if (dgvDetalle.CurrentCell.ColumnIndex == 4)
                        txt.KeyPress += Txt_KeyPressPrecio;
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al validar cantidad.");
            }
        }


        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "cant")
                {
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        mensaje.mensajeValidacion("La cantidad debe ser un número entero mayor a cero.");
                        e.Cancel = true;
                    }
                }

                if (dgvDetalle.Columns[e.ColumnIndex].Name == "precioVenta")
                {
                    decimal.TryParse(e.FormattedValue.ToString(), out decimal precioVenta);
                    decimal.TryParse(dgvDetalle.CurrentRow.Cells["precioCosto"].Value.ToString(), out decimal precioCosto);
                    if (precioVenta <= precioCosto)
                    {
                        mensaje.mensajeValidacion($"El precio de venta debe ser mayor que el precio de costo: {precioCosto:N2}");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al validar datos.");
            }
        }


        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvDetalle.Rows[e.RowIndex];

                    // Validar que las celdas necesarias no estén vacías
                    if (fila.Cells["cant"].Value != null && fila.Cells["precioVenta"].Value != null)
                    {
                        int cantidad = Convert.ToInt32(fila.Cells["cant"].Value);
                        decimal precioVenta = Convert.ToDecimal(fila.Cells["precioVenta"].Value);
                        decimal precioCosto = Convert.ToDecimal(fila.Cells["precioCosto"].Value);

                        // Recalcular valores de la fila editada
                        fila.Cells["totalVenta"].Value = cantidad * precioVenta;
                        fila.Cells["costoVenta"].Value = cantidad * precioCosto;
                        fila.Cells["utilidadBruta"].Value = (cantidad * precioVenta) - (cantidad * precioCosto);

                        // Recalcular los totales generales
                        calcularTotales();
                    }
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al editar registro.");
            }
        }


        private void dgvDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                calcularTotales();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al eliminar registro.");
            }
        }




        #endregion

        
    }
}
