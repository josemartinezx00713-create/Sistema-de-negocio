using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.UI.Formularios;
namespace Sistema.UI.Modulos
{
    public class Mensajes
    {
        public void mensajeError(string mensaje)
        {
            frmMensajes frm = new frmMensajes(mensaje, "error");
            frm.ShowDialog();
        }
        public void mensajeOk(string mensaje)
        {
            frmMensajes frm = new frmMensajes(mensaje, "ok");
            frm.ShowDialog();
        }
        public void mensajeValidacion(string mensaje)
        {
            frmMensajes frm = new frmMensajes(mensaje, "warning");
            frm.ShowDialog();
        }
        public void mensajeInformacion(string mensaje)
        {
            frmMensajes frm = new frmMensajes(mensaje, "info");
            frm.ShowDialog();
        }
        public DialogResult mensajeConfirmar(string mensaje)
        {
            frmMensajes frm = new frmMensajes(mensaje, "confirmar");
            return frm.ShowDialog();
        }

        internal void mensajeOk(bool resultado)
        {
            throw new NotImplementedException();
        }

        internal void mensajeError(object mensaje)
        {
            throw new NotImplementedException();
        }
    }
}
