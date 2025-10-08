using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.UI.Modulos;

namespace Sistema.Modulos
{
    public class Validaciones
    {
        private static Mensajes mensaje = new Mensajes();

        // Maneja la tecla Enter como Tab
        public static void pasarFocus(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                mensaje.mensajeError($"Error en pasarFocus: {ex.Message}");
            }
        }

        // Maneja Escape para cerrar el formulario
        public static void controlarEsc(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (sender is Form formulario)
                    {
                        formulario.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje.mensajeError($"Error en controlarEsc: {ex.Message}");
            }
        }

        // Validar que la entrada sea un número decimal
        public static void validarDecimal(object sender, KeyPressEventArgs e)
        {
            if (sender == null)
            {
                e.Handled = true;
                return;
            }

            string currentText = "";

            if (sender is TextBox tb)
                currentText = tb.Text;
            else if (sender is Guna.UI2.WinForms.Guna2TextBox gtb)
                currentText = gtb.Text;
            else
            {
                e.Handled = true;
                return;
            }

            // Permitir teclas de control (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir dígitos (0-9)
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir punto (.) o coma (,) como separador decimal (solo uno)
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // Usar punto como estándar
                char decimalSeparator = '.';

                // Si ya existe el separador, bloquear
                if (currentText.Contains(decimalSeparator))
                {
                    e.Handled = true;
                    return;
                }

                // Permitir si no existe
                e.KeyChar = decimalSeparator; // Convertir coma a punto si quieres
                e.Handled = false;
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }



        // Formato decimal
        public static void formatoDecimal(Guna.UI2.WinForms.Guna2TextBox txt)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = 0m.ToString("N2");
                    return;
                }

                if (decimal.TryParse(txt.Text, out decimal valor))
                {
                    txt.Text = valor.ToString("N2");
                }
                else
                {
                    mensaje.mensajeValidacion("Número inválido.");
                    txt.Focus();
                }
            }
            catch (Exception)
            {
                mensaje.mensajeError("Error en formato decimal.");
            }
        }

        // Digitar solo números enteros
        public static void numerosEnteros(KeyPressEventArgs e, string textoActual)
        {
            try
            {
                // Permitir teclas de control (ej. Backspace)
                if (char.IsControl(e.KeyChar))
                    return;

                // Permitir solo dígitos
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                // Evitar que el primer dígito sea 0
                if (e.KeyChar == '0' && string.IsNullOrEmpty(textoActual))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                mensaje.mensajeError("Error en formato entero: " + ex.Message);
            }
        }
    }
}
