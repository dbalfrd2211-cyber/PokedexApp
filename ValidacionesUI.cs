using System.Windows.Forms;

namespace PokedexApp
{
    internal class ValidacionesUI
    {
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
