using Sistema.Formularios;
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
using static Sistema.UI.Modulos.ColoresUI;

namespace Sistema.UI.Formularios
{
    public partial class MDIInterfazMenu : Form
    {

        public MDIInterfazMenu()
        {
            InitializeComponent();
        }
        public static bool confirmarSalida = false;
        private Mensajes mensaje = new Mensajes();
        private Form formularioActivo = null;

        #region Metodos formulario

        private void AbrirFormulario(Form formularioHijo, bool esHijoDelPanelContenedor = true)
        {
            try
            {
                //Si el formulario debe ser hijo del panel contenedor
                if (esHijoDelPanelContenedor)
                {
                    //Cerrar el formulario activo si existe
                    if (formularioActivo != null)
                    {
                        formularioActivo.Close();
                    }
                    //Configurar el formulario hijo
                    formularioActivo = formularioHijo;
                    formularioHijo.TopLevel = false;
                    formularioHijo.FormBorderStyle = FormBorderStyle.None;
                    formularioHijo.Dock = DockStyle.Fill;
                    //Agregar el formulario al panel contenedor
                    panelCentral.Controls.Add(formularioHijo);
                    panelCentral.Tag = formularioHijo;
                    formularioHijo.BringToFront();
                    formularioHijo.Show();
                }
                else //Si no, abrirlo como un formulario independiente
                {
                    formularioHijo.TopLevel = true;
                    formularioHijo.FormBorderStyle = FormBorderStyle.Sizable;
                    formularioHijo.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                mensaje.mensajeError("Error al abrir el formulario: " + ex.Message);
            }
        }
        private void MDIInterfazMenu_Load(object sender, EventArgs e)
        {
            // Fondo de la ventana
            this.BackColor = ColoresUII.ObtenerColor(ElementoUI.FondoGeneral);

            // Panel lateral
            panelMenuLateral.BackColor = ColoresUII.ObtenerColor(ElementoUI.PanelLateral);

            // Botón Ingresos
            btnInicio.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonNormal);
            btnInicio.ForeColor = Color.White;
        }
        private void MDIInterfazMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!confirmarSalida)
            {
                if (mensaje.mensajeConfirmar("¿Desea salir del sistema?") == DialogResult.OK)
                {
                    confirmarSalida = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion


        #region Metodos de botones
        //Boton Inicio

        private void btnInicio_MouseEnter(object sender, EventArgs e)
        {
            btnInicio.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }
        private void btnInicio_MouseLeave(object sender, EventArgs e)
        {
            btnInicio.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonNormal);
        }

        private void btnInicio_MouseDown(object sender, MouseEventArgs e)
        {
            btnInicio.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonPressed);
        }

        private void btnInicio_MouseUp(object sender, MouseEventArgs e)
        {
            btnInicio.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        //Boton Ventas

        private void btnVentas_MouseDown(object sender, MouseEventArgs e)
        {
            btnVentas.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonPressed);
        }

        private void btnVentas_MouseEnter(object sender, EventArgs e)
        {
            btnVentas.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }
        private void btnVentas_MouseLeave(object sender, EventArgs e)
        {
            btnVentas.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonNormal);
        }

        private void btnVentas_MouseUp(object sender, MouseEventArgs e)
        {
            btnVentas.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        
        //Boton Reportes

        private void btnReportes_MouseEnter(object sender, EventArgs e)
        {
            btnReportes.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        private void btnReportes_MouseUp(object sender, MouseEventArgs e)
        {
            btnReportes.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        private void btnReportes_MouseLeave(object sender, EventArgs e)
        {
            btnReportes.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonNormal);
        }

        private void btnReportes_MouseDown(object sender, MouseEventArgs e)
        {
            btnReportes.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonPressed);
        }

        //Boton Salir

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            btnSalir.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        private void btnSalir_MouseUp(object sender, MouseEventArgs e)
        {
            btnSalir.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        private void btnSalir_MouseDown(object sender, MouseEventArgs e)
        {
            btnSalir.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonPressed);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonNormal);
        }

        //Boton Productos
        private void btnProducto_MouseUp(object sender, MouseEventArgs e)
        {
            btnProducto.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        private void btnProducto_MouseLeave(object sender, EventArgs e)
        {
            btnProducto.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonNormal);
        }

        private void btnProducto_MouseDown(object sender, MouseEventArgs e)
        {
            btnProducto.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonPressed);
        }

        private void btnProducto_MouseEnter(object sender, EventArgs e)
        {
            btnProducto.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        //Boton Egresos

        private void btnEgreso_MouseUp(object sender, MouseEventArgs e)
        {
            btnEgreso.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        private void btnEgreso_MouseLeave(object sender, EventArgs e)
        {
            btnEgreso.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonNormal);
        }

        private void btnEgreso_MouseEnter(object sender, EventArgs e)
        {
            btnEgreso.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonHover);
        }

        private void btnEgreso_MouseDown(object sender, MouseEventArgs e)
        {
            btnEgreso.BackColor = ColoresUII.ObtenerColor(ElementoUI.BotonPressed);
        }

        //Clics en botones
        private void iconSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmVenta(), true);
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void panelMenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void administradorDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios(), true);
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmGastos(), true);
        }

        private void listadoDeGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatalogoGasto frm = new frmCatalogoGasto();
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmGastos(), true);
        }
    }
}
