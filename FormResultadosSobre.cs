using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class FormResultadosSobre : Form
    {
        private List<Cartas> cartasRecibidas;
        public FormResultadosSobre(List<Cartas> cartas)
        {
            InitializeComponent();
            this.cartasRecibidas = cartas;
            MostrarCartasObtenidas();
        }

        private void MostrarCartasObtenidas()
        {
            if (cartasRecibidas != null && cartasRecibidas.Count >= 3)
            {
               
                picCarta1.Image = CargarImagenCarta(cartasRecibidas[0]);
                picCarta2.Image = CargarImagenCarta(cartasRecibidas[1]);
                picCarta3.Image = CargarImagenCarta(cartasRecibidas[2]);
            }
        }

        private Image CargarImagenCarta(Cartas carta)
        {
            string ruta = Path.Combine(Application.StartupPath, "Imagenes", carta.IdPokemon + ".jpeg");
            return File.Exists(ruta) ? Image.FromFile(ruta) : null;
        }
        

        private void picCarta3_Click(object sender, EventArgs e)
        {
            if (cartasRecibidas != null && cartasRecibidas.Count >= 3 && picCarta3.Image != null)
            {
              
                FormVisorCarta visor = new FormVisorCarta(picCarta3.Image);
                visor.ShowDialog();
            }
        }

        private void FormResultadosSobre_Load(object sender, EventArgs e)
        {

        }
    }
}
