using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.UI.Modulos
{
    public class ColoresUI
    {
        public enum ElementoUI
        {
            FondoGeneral,
            PanelLateral,
            TextoPrincipal,
            TextoSecundario,
            Tarjeta,
            BotonNormal,
            BotonHover,
            BotonPressed,
            OpcionActiva,
            Sombra
        }

        public static class ColoresUII
        {
            public static Color ObtenerColor(ElementoUI tipo)
            {
                switch (tipo)
                {
                    case ElementoUI.FondoGeneral:
                        return Color.FromArgb(255, 30, 45, 65); // Azul oscuro del fondo del logo

                    case ElementoUI.PanelLateral:
                        return Color.FromArgb(255, 45, 60, 85); // Un azul-gris ligeramente más claro para el panel lateral

                    case ElementoUI.TextoPrincipal:
                        return Color.FromArgb(255, 255, 255, 255); // Blanco, como el texto "LA TERMINAL"

                    case ElementoUI.TextoSecundario:
                        return Color.FromArgb(255, 170, 180, 190); // Gris claro para texto secundario

                    case ElementoUI.Tarjeta:
                        return Color.FromArgb(255, 60, 75, 100); // Un tono más claro del azul-gris para tarjetas

                    case ElementoUI.BotonNormal:
                        return Color.FromArgb(255, 30, 45, 65); // Azul oscuro para el botón normal

                    case ElementoUI.BotonHover:
                        return Color.FromArgb(255, 200, 120, 0); // Naranja un poco más oscuro para el hover

                    case ElementoUI.BotonPressed:
                        return Color.FromArgb(255, 150, 90, 0); // Naranja más oscuro para el pressed

                    case ElementoUI.OpcionActiva:
                        return Color.FromArgb(255, 80, 95, 120); // Un tono azul-gris para resaltar la opción activa

                    case ElementoUI.Sombra:
                        return Color.FromArgb(60, 0, 0, 0); // Sombra semitransparente (puede mantenerse o ajustarse al color de fondo)

                    default:
                        return Color.Black;
                }
            }
        }
    }
}
