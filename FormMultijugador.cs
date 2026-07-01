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
            PokedexManager manager = new PokedexManager();

            // 1. Obtenemos dos cartas de prueba desde tu base de datos (Ej: Bulbasaur #1 y Pikachu #25)
            VistaCartasMaestra miPokemon = manager.ObtenerDetallesCarta(1);
            VistaCartasMaestra rivalPokemon = manager.ObtenerDetallesCarta(25);

            // 2. Revisamos que existan y abrimos tu nueva arena
            if (miPokemon != null && rivalPokemon != null)
            {
                FormFondo arena = new FormFondo(miPokemon, rivalPokemon);
                this.Hide();
                arena.ShowDialog();
                this.Show();
            }
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
