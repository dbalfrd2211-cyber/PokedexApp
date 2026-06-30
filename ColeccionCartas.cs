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
      
        public ColeccionCartas()
        {
            InitializeComponent();
            DGVListadoCartas.DataSource = manager.AllDatoPokemon();
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
            if (string.IsNullOrEmpty(txtBuscarPokemon.Text))
            {
                DGVListadoCartas.DataSource = manager.AllDatoPokemon();

            }
            else
            {
                DGVListadoCartas.DataSource = manager.BuscarCartasPorNombre(txtBuscarPokemon.Text);

            }



        }

        private void ColeccionCartas_Load(object sender, EventArgs e)
        {
            DGVListadoCartas.DataSource = manager.AllDatoPokemon();
            DGVListadoCartas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            DGVListadoCartas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGVListadoCartas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void btnVolverCC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVListadoCartas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { if (DGVListadoCartas.Rows[e.RowIndex].DataBoundItem is Cartas c)
                {
                    VistaCartasMaestra detalle = manager.ObtenerDetallesCarta(c.IdPokemon);
                    if (detalle != null)
                    {
                        txtDetallesPokemon.Text =
                            $"Pokémon" +
                            $" Id:{detalle.Pokedex} - Nombre:{detalle.Nombre}" + Environment.NewLine +
                    $"Tipo: {detalle.Tipo1}/{detalle.Tipo2} | Región: {detalle.Region}" + Environment.NewLine +
                    $"Altura: {detalle.Altura}m | Peso: {detalle.Peso}kg" + Environment.NewLine +
                    $"---**********************+*******--" + Environment.NewLine +
                    $"Hp Carta: {detalle.HPCarta} | Rareza: {detalle.Rareza}" + Environment.NewLine +
                    $"Ataques y Efectos:" + Environment.NewLine +
                    // Reemplazamos el separador " | " de la vista por un salto de línea real
                    $"{detalle.DetallesAtaques.Replace(" | ", Environment.NewLine)}";

                        btnAñadirAColeccion.Enabled = true;
                    }
                    else
                    {
                        txtDetallesPokemon.Text = "No se encontraron detalles completos";
                    }
                }

            }
        }

        private void txtDetallesPokemon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
