using Sistema.BLL;
using Sistema.Entity;
using Sistema.Modulos;
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
    public partial class frmAgregarProducto : frmAgregarRegistros
    {
        private Mensajes mensaje = new Mensajes();
        private Validaciones validaciones = new Validaciones();
        public event Action registroAgregado;
        Boolean actualizarRegistro = false;


        public frmAgregarProducto()
        {
            InitializeComponent();

            this.KeyPress += Validaciones.pasarFocus;
            this.KeyDown += Validaciones.controlarEsc;

        }

        public frmAgregarProducto(int id, string codigo, string nombre, decimal costo, decimal precio, int idcategoria, int stock)
        {
            try
            {
                InitializeComponent();
                cargarCategoria();

                
                txtId.Text = id.ToString();
                txtVar2.Text = codigo;
                txtVar3.Text = nombre;
                txtVar4.Text = costo.ToString("0.00"); 
                txtPrecioVenta.Text = precio.ToString("0.00");
                txtStock.Text = stock.ToString();

                
                cboCatalogo.SelectedValue = idcategoria; 

                
                label7.Visible = false;
                label1.Text = "Actualizar producto";

                actualizarRegistro = true;
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error al inicializar el formulario.");
            }
        }


        #region "Metodos"
        private void cargarCategoria()
        {
            try
            {
                var categoria = bCategoria.Listar();
                if (categoria != null && categoria.Rows.Count > 0)
                {
                    cboCatalogo.DataSource = categoria;
                    cboCatalogo.ValueMember = "ID";
                    cboCatalogo.DisplayMember = "CATEGORIA";
                    cboCatalogo.SelectedIndex = 0;
                }
                else
                {
                    mensaje.mensajeError("No hay categoria para mostrar.");
                }
            }
            catch (Exception ex)
            {
                mensaje.mensajeError("Error al cargar las categorias: " + ex.Message);
            }
        }

        private void errorControl(string control)
        {
            switch (control)
            {
                case "IdCategoria":
                    errorIcono.SetError(cboCatalogo, "Este campo es obligatorio.");
                    cboCatalogo.Focus();
                    break;
                case "Codigo":
                    errorIcono.SetError(txtVar2, "Este campo es obligatorio.");
                    txtVar2.Focus();
                    break;
                case "Nombre":
                    errorIcono.SetError(txtVar3, "Este campo es obligatorio.");
                    txtVar3.Focus();
                    break;
                case "Costo":
                    errorIcono.SetError(txtVar4, "Este campo es obligatorio.");
                    txtVar4.Focus();
                    break;
                case "Precio":
                    errorIcono.SetError(txtPrecioVenta, "Este campo es obligatorio.");
                    txtPrecioVenta.Focus();
                    break;
                case "Stock":
                    errorIcono.SetError(txtStock, "Este campo es obligatorio.");
                    txtStock.Focus();
                    break;
            }
        }
        private void Guardar()
        {
            try
            {
                errorIcono.Clear();

                if (!int.TryParse(cboCatalogo.SelectedValue?.ToString(), out int idCategoria))
                {
                    mensaje.mensajeValidacion("Debe seleccionar una categoria válido.");
                    errorIcono.SetError(cboCatalogo, "Este campo es obligatorio.");
                    cboCatalogo.Focus();
                    return;
                }

                oProductos producto = new oProductos
                {
                    codigo = txtVar2.Text,
                    nombre = txtVar3.Text,
                    costo = decimal.Parse(txtVar4.Text.Trim()),
                    precio = decimal.Parse(txtPrecioVenta.Text.Trim()),
                    idCategoria = idCategoria,
                    stock = int.Parse(txtStock.Text.Trim()),
                    
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
                    resultado = bProductos.RegistrarProductos(producto);
                }
                else
                {
                    producto.idProducto = id;
                    resultado = bProductos.Actualizar(producto);
                }

                if (resultado == null)
                {
                    mensaje.mensajeError("No se obtuvo respuesta del registro/actualización.");
                    return;
                }

                if (!resultado.esValido)
                {
                    mensaje.mensajeValidacion(resultado.mensaje);

                    if (!string.IsNullOrEmpty(resultado.campoInvalido))
                    {
                        errorControl(resultado.campoInvalido);
                    }
                    return;
                }
                mensaje.mensajeOk(resultado.mensaje);
                registroAgregado?.Invoke();
                Limpiar();
                if (actualizarRegistro) Close();
                txtVar3.Focus();
            }
            catch (Exception)
            {
                mensaje.mensajeError("Ocurrio un errror inesperado");
            }
        }


        private void Limpiar()
        {
            dtpFecha.Value = DateTime.Now;
            txtId.Clear();
            txtVar2.Text = "*****";
            if (cboCatalogo.Items.Count > 0) cboCatalogo.SelectedIndex = 0;
            txtVar4.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            txtStock.Text = "0";
            txtVar2.Focus();
        }


        #endregion

        #region "botones de comando"


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar errores previos
                errorIcono.Clear();

                // Validar que no haya campos vacíos
                bool datosValidos = true;

                foreach (Control control in panel1.Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2TextBox txt)
                    {
                        if (string.IsNullOrWhiteSpace(txt.Text))
                        {
                            errorIcono.SetError(txt, "Este campo es obligatorio.");
                            datosValidos = false;
                        }
                    }

                    if (control is Guna.UI2.WinForms.Guna2ComboBox cbo)
                    {
                        if (cbo.SelectedIndex < 0)
                        {
                            errorIcono.SetError(cbo, "Debe seleccionar una opción.");
                            datosValidos = false;
                        }
                    }
                }

                if (!datosValidos)
                {
                    mensaje.mensajeValidacion("Hay campos obligatorios sin completar. Por favor, revise.");
                    return;
                }

                // Confirmación antes de guardar
                DialogResult confirmacion = MessageBox.Show(
                    "¿Desea guardar el producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.No)
                    return;

                // Llamar al método Guardar
                Guardar();
            }
            catch (Exception ex)
            {
                mensaje.mensajeError("Ocurrió un error al procesar la solicitud: " + ex.Message);
            }

        }

        #endregion

        #region "botones"
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion

        private void frmAgregarProducto_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            txtVar4.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            cargarCategoria();
        }

        
    }
}
