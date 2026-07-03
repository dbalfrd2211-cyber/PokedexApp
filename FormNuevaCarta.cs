using PokedexApp;
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
    public partial class FormNuevaCarta : Form
    {
        public FormNuevaCarta()
        {
            InitializeComponent();
            txtIdPokemon.KeyPress += ValidacionesUI.SoloNumeros;
            txtHP.KeyPress += ValidacionesUI.SoloNumeros;
            txtNumeroColeccion.KeyPress += ValidacionesUI.SoloNumeros;
            txtPokedex.KeyPress += ValidacionesUI.SoloNumeros;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtIdPokemon.Text) || string.IsNullOrWhiteSpace(txtHP.Text) ||
                 string.IsNullOrWhiteSpace(txtNumeroColeccion.Text) || string.IsNullOrWhiteSpace(txtPokedex.Text))
            {
                MessageBox.Show("Debes llenar todos los campos numéricos.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debes llenar el campo Nombre.");
                return;
            }

            if (cmbRareza.SelectedIndex == -1 || cmbTipo1.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar una rareza y un tipo");
                return;
            }
        

            int idPokemon = Convert.ToInt32(txtIdPokemon.Text);
            int hp = Convert.ToInt32(txtHP.Text);
            //string rareza = cmbRareza.SelectedItem.ToString();
            int numeroColeccion = Convert.ToInt32(txtNumeroColeccion.Text);
            int pokedex = Convert.ToInt32(txtPokedex.Text);

            string nombre = txtNombre.Text;
            string tipo1 = cmbTipo1.SelectedItem.ToString();
            string rareza = cmbRareza.SelectedItem.ToString();
        //string detallesAtaque = txtDetallesAtaque.Text;

        
        



        PokedexManager manager = new PokedexManager();
        if (manager.CrearNuevaCarta(idPokemon, hp, rareza, numeroColeccion, nombre, tipo1, pokedex)) //, nombre, detallesAtaque
            {
                MessageBox.Show("Carta creada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al crear la carta. Verifica los datos ingresados.");
            }
        }
    }
}