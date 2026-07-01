using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class FormMultijugador : Form
    {
        private Usuario usuarioLogueado;

        public FormMultijugador(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;
        }

        private void btnCombate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Buscando un oponente en la Arena...", 
            "Matchmaking", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIntercambio_Click(object sender, EventArgs e)
        {
            IntercambioCartas ventanaIntercambio = new IntercambioCartas(usuarioLogueado);
            this.Hide();

            ventanaIntercambio.ShowDialog();
            this.Show();
        }
    }
}
