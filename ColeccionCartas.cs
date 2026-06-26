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
    public partial class ColeccionCartas : Form
    {
        private PokedexManager manager = new PokedexManager();
        private BindingList<AllDataPokemon> listaVisualizada;
        public ColeccionCartas()
        {
            InitializeComponent();
            btnAñadirAColeccion.Enabled = false;
        }

      
        private void btnCrearNuevaCarta_Click(object sender, EventArgs e)
        {
            FormNuevaCarta frm = new FormNuevaCarta();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtBuscarPokemon_TextChanged(sender, e);
            }

        }

        private void btnAñadirAColeccion_Click(object sender, EventArgs e)
        {
            if (DGVListadoCartas.CurrentRow?.DataBoundItem is Cartas c)
            {

                if (manager.AgregarCartaColeccion(c.IdPokemon, c.Hp, c.Rareza, c.NumeroDeColeccion))
                {
                    MessageBox.Show("¡Carta añadida a tu coleccion");
                }
            }
        }

        private void txtBuscarPokemon_TextChanged(object sender, EventArgs e)
        {
            if (!txtBuscarPokemon.Focused) return;

            var resultados = manager.ObtenerTodoDato()
                            .Where(p => p.Nombre.IndexOf(txtBuscarPokemon.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                            .ToList();

            listaVisualizada = new BindingList<AllDataPokemon>(resultados);
            DGVListadoCartas.DataSource = listaVisualizada;
        }

        private void ColeccionCartas_Load(object sender, EventArgs e)
        {
            var resultados = manager.ObtenerTodoDato();

            listaVisualizada = new BindingList<AllDataPokemon>(resultados);
            DGVListadoCartas.DataSource = listaVisualizada;
        }

        private void DGVListadoCartas_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVListadoCartas.CurrentRow?.DataBoundItem is AllDataPokemon pokemonSeleccionado)
            {
                txtBuscarPokemon.Text = pokemonSeleccionado.Nombre;
            }
        }
    }
}
