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

            // 1. Obtenemos los detalles
            VistaCartasMaestra miPokemonInfo = manager.ObtenerDetallesCarta(1);
            VistaCartasMaestra rivalPokemonInfo = manager.ObtenerDetallesCarta(25);

            if (miPokemonInfo != null && rivalPokemonInfo != null)
            {
                // 2. Convertimos los objetos 'VistaCartasMaestra' a 'Cartas'
                // Esto es necesario porque FormBatalla requiere List<Cartas>
                Cartas miCarta = new Cartas(0, miPokemonInfo.IdPokemon, miPokemonInfo.HPCarta, miPokemonInfo.Rareza,
                                            miPokemonInfo.NumeroColeccion, miPokemonInfo.Nombre, "", "");

                Cartas rivalCarta = new Cartas(0, rivalPokemonInfo.IdPokemon, rivalPokemonInfo.HPCarta, rivalPokemonInfo.Rareza,
                                               rivalPokemonInfo.NumeroColeccion, rivalPokemonInfo.Nombre, "", "");

                // 3. Creamos las listas que espera el constructor de FormBatalla
                List<Cartas> miEquipo = new List<Cartas> { miCarta };
                List<Cartas> equipoRival = new List<Cartas> { rivalCarta };

                // 4. Abrimos la batalla enviando las LISTAS
                FormBatalla arena = new FormBatalla(miEquipo, equipoRival);
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
