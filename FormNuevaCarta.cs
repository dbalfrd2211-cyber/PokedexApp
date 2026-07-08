using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PokedexApp
{
    public partial class FormNuevaCarta : Form
    {
        private string rutaImagenSeleccionada = "";
        public FormNuevaCarta()
        {
            InitializeComponent();
            txtIdPokemon.KeyPress += ValidacionesUI.SoloNumeros;
            txtHP.KeyPress += ValidacionesUI.SoloNumeros;
            txtNumeroColeccion.KeyPress += ValidacionesUI.SoloNumeros;
            txtPokedex.KeyPress += ValidacionesUI.SoloNumeros;
            txtAltura.KeyPress += ValidacionesUI.SoloNumeros;
            txtHPbase.KeyPress += ValidacionesUI.SoloNumeros;
            txtPeso.KeyPress += ValidacionesUI.SoloNumeros;


            PokedexManager manager = new PokedexManager();
            chkAtaques.DataSource = manager.ObtenerTodosLosAtaques();
            chkAtaques.DisplayMember = "Nombre";
            chkAtaques.ValueMember = "IdAtaque";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtIdPokemon.Text) || string.IsNullOrWhiteSpace(txtHP.Text) ||
                 string.IsNullOrWhiteSpace(txtNumeroColeccion.Text) || string.IsNullOrWhiteSpace(txtPokedex.Text) || 
                 string.IsNullOrWhiteSpace(txtAltura.Text) || string.IsNullOrWhiteSpace(txtHPbase.Text) || string.IsNullOrWhiteSpace(txtPeso.Text))
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
            if(cmbRegion.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar una región");
                return;
            }

            if (cmbUnidadPeso.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una unidad de peso");
            }
            if(cmbUnidadAltura.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una unidad de altura");
            }


            int hpBase = Convert.ToInt32(txtHPbase.Text);
            int idPokemon = Convert.ToInt32(txtIdPokemon.Text);
            int hp = Convert.ToInt32(txtHP.Text);
            //string rareza = cmbRareza.SelectedItem.ToString();
            int numeroColeccion = Convert.ToInt32(txtNumeroColeccion.Text);
            int pokedex = Convert.ToInt32(txtPokedex.Text);
            int idRegion = cmbRegion.SelectedIndex + 1; // Assuming regions are indexed from 1
            string nombre = txtNombre.Text;
            string tipo1 = cmbTipo1.SelectedItem.ToString();
            string rareza = cmbRareza.SelectedItem.ToString();
            //string detallesAtaque = txtDetallesAtaque.Text;
            double altura = Convert.ToDouble(txtAltura.Text);
            double peso = Convert.ToDouble(txtPeso.Text);
            if(cmbUnidadPeso.SelectedItem.ToString() == "g")
            {
                peso /= 1000; 
            }
            if (cmbUnidadAltura.SelectedItem.ToString() == "cm")
            {
                altura /= 100;
            }




            List<int> ataquesSeleccionados = new List<int>();
            foreach (var item in chkAtaques.CheckedItems)
            {
                var ataque = item as Ataques;
                if (ataque != null)
                {
                    ataquesSeleccionados.Add(ataque.IdAtaque);
                }
            }


            if (ataquesSeleccionados.Count == 0)
            {
                MessageBox.Show("Debes seleccionar al menos un ataque.");
                return;
            }

            PokedexManager manager = new PokedexManager();
        
            if (manager.CrearNuevaCarta(idPokemon, hp, rareza, numeroColeccion, nombre, tipo1, pokedex, idRegion, altura, peso,hpBase, ataquesSeleccionados)) //, nombre, detallesAtaque
            {

                if (!string.IsNullOrEmpty(rutaImagenSeleccionada))
                {
                    try
                    {
                        string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes");
                        if (!Directory.Exists(carpetaDestino))
                        {
                            Directory.CreateDirectory(carpetaDestino);
                        }

                        string nombreArchivo = idPokemon.ToString() + ".jpeg";
                        string rutaFinal = Path.Combine(carpetaDestino, nombreArchivo);

                        File.Copy(rutaImagenSeleccionada, rutaFinal, true);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la imagen: " + ex.Message);
                    }
                } 




                MessageBox.Show("Carta creada exitosamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al crear la carta. Verifica los datos ingresados.");
            }


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void chkAtaques_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (chkAtaques.CheckedItems.Count >= 4)
                {
                    e.NewValue = CheckState.Unchecked;
                    MessageBox.Show("Solo puedes seleccionar hasta 4 ataques.");
                }
            }
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagenSeleccionada = openFileDialog.FileName;
                picNuevaImagen.Image = Image.FromFile(rutaImagenSeleccionada);
            }

        }
    }
}