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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if(txtIdPokemon.Text == "" || txtHP.Text == "" ||txtNumeroColeccion.Text == "")
            {
                MessageBox.Show("Debes llenar los campos IdPokemon, HP y Numero de coleccion con numeros");
                return;
            }
            if(cmbRareza.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar una rareza");
                return;
            }
        

            int idPokemon = Convert.ToInt32(txtIdPokemon.Text);
            int hp = Convert.ToInt32(txtHP.Text);
            string rareza = cmbRareza.SelectedItem.ToString();
            int numeroColeccion = Convert.ToInt32(txtNumeroColeccion.Text);
            //string nombre = txtNombre.Text;
            //string detallesAtaque = txtDetallesAtaque.Text;

            PokedexManager manager = new PokedexManager();

            if (manager.CrearNuevaCarta(idPokemon, hp, rareza, numeroColeccion)) //, nombre, detallesAtaque
            {
                MessageBox.Show("Carta creada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al crear la carta. Verifica los datos ingresados.");
            }
        }

        private void cmbRareza_SelectedIndexChanged(object sender, EventArgs e)
        {
            //borrar
            


        }

        private void FormNuevaCarta_Load(object sender, EventArgs e)
        {
          //borrra

        
        }

        private void txtNumeroColeccion_TextChanged(object sender, EventArgs e)
        {
            //borarra
        }
    }
}
