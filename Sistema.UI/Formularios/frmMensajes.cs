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
    public partial class frmMensajes : Form
    {
        public frmMensajes(string mensaje, string tipo)
        {
            InitializeComponent();
            this.Opacity = 1;
            timer1.Interval = 150;

            lblMensaje.Text = mensaje;

            switch (tipo.ToLower())
            {
                case "error":
                    picIcono.Image = Properties.Resources.icon_error_50;
                    this.BackColor = Color.FromArgb(255, 77, 77); //rojo
                    break;
                case "ok":
                    picIcono.Image = Properties.Resources.icon_ok_50;
                    this.BackColor = Color.FromArgb(46, 204, 113); //verde
                    break;
                case "info":
                    picIcono.Image = Properties.Resources.icon_info_50;
                    this.BackColor = Color.FromArgb(52, 152, 219); //azul
                    break;
                case "warning":
                    picIcono.Image = Properties.Resources.icon_warning_50;
                    this.BackColor = Color.FromArgb(255, 152, 0); //naranja
                    break;
                case "confirmar":
                    picIcono.Image = Properties.Resources.icon_confirm_50;
                    this.BackColor = Color.FromArgb(255, 44, 62, 80); //gris verdoso
                    break;
            }
        }

        #region Metodos
        private void centrarFormulario()
        {
            Rectangle screenArea = Screen.PrimaryScreen.WorkingArea;

            int margenDerecho = 10;

            //Posición X: Pegado al borde derecho.
            int posX = screenArea.Right - this.Width - margenDerecho;

            //Posición Y: Centrado verticalmente.
            int posY = screenArea.Top + (screenArea.Height - this.Height) / 2;

            this.Location = new Point(posX, posY);
                
        }
        #endregion



        #region Botones de comando
        private void iconAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void iconCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        private void frmMensajes_Load(object sender, EventArgs e)
        {
            centrarFormulario();
            timer1.Start();

            if (!iconCancelar.Visible)
            {
                iconAceptar.Location = new Point(265, 105);
            }
            else
            {
                iconAceptar.Location = new Point(109, 105);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.015;

            if (this.Opacity <= 0)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
