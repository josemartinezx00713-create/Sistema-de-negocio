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
    public partial class MDIMenu : Form
    {
        public static bool confirmarSalida = false;
        private Mensajes mensaje = new Mensajes();
        private Form formularioActivo = null;
        public MDIMenu()
        {
            InitializeComponent();
        }

        #region Metodos
        //private void centrarEtiquetas()
        //{
        //    try
        //    {
        //        var anchoContenedor = panelContenedor.ClientSize.Width;
        //        var altoContenedor = panelContenedor.ClientSize.Height;

        //        int espacioEntreLabels = 10; // Espacio entre los labels
        //        int altoTotal = titulo.Height + espacioEntreLabels + lblEmpresa.Height;

        //        int topInicial = (altoContenedor - altoTotal) / 2;

        //        titulo.Top = topInicial;
        //        titulo.Left = (anchoContenedor - titulo.Width) / 2;

        //        lblEmpresa.Top = titulo.Bottom + espacioEntreLabels;
        //        lblEmpresa.Left = (anchoContenedor - lblEmpresa.Width) / 2;
        //    }
        //    catch(Exception)
        //    {

        //    }
        //}


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
                    panelContenedor.Controls.Add(formularioHijo);
                    panelContenedor.Tag = formularioHijo;
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

        #endregion
        #region Eventos del formulario
        private void MDIMenu_Load(object sender, EventArgs e)
        {
            //centrarEtiquetas();
        }
        private void MDIMenu_Resize(object sender, EventArgs e)
        {
            //centrarEtiquetas();
        }
        private void MDIMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!confirmarSalida)
            {
                if(mensaje.mensajeConfirmar("¿Desea salir del sistema?") == DialogResult.OK)
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
        private void aperturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iconSalir_Click(object sender, EventArgs e)
        { 
             Close();
        }

        private void menuTitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmPlantilla(), true);
        }
    }
}
