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

        //los de aqui para mi giro
        private int anchoOriginal = 0;
        private List<int> posicionesIzquierdasOriginales = new List<int>();
        private List<PictureBox> listaPics;
        private Timer timerGiro = new Timer();
        private int pasosGiro = 0;
       
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
            listaPics = new List<PictureBox> { picCarta1, picCarta2, picCarta3 };

            if (listaPics.Count > 0) anchoOriginal = listaPics[0].Width;
            foreach (var pic in listaPics) posicionesIzquierdasOriginales.Add(pic.Left);

            timerGiro.Interval = 30;
            timerGiro.Tick += timerGirar_Tick;

            
            foreach (var pic in listaPics)
            {
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                string rutaReverso = Path.Combine(Application.StartupPath, "Imagenes", "reverso.png");
                if (File.Exists(rutaReverso)) pic.Image = Image.FromFile(rutaReverso);
            }

            timerGiro.Start();
        

        }

        private void timerGirar_Tick(object sender, EventArgs e)
        {
            pasosGiro++;

            foreach (var pic in listaPics)
            {
                
                if (pasosGiro <= 10)
                {
                   
                    pic.Width -= 10;
                    pic.Left += 5; 
                }
                else if (pasosGiro == 11)
                {

                    int index = listaPics.IndexOf(pic);
                    pic.Image = CargarImagenCarta(cartasRecibidas[index]);
                    pic.Width = 10;
                }
                else if (pasosGiro <= 20)
                {
                    pic.Width += 10;
                    pic.Left -= 5;
                }
            }

            if (pasosGiro >= 20)
            {
                timerGiro.Stop();

                for (int i = 0; i < listaPics.Count; i++)
                {
                    listaPics[i].Width = anchoOriginal;
                    listaPics[i].Left = posicionesIzquierdasOriginales[i];
                }
            }
        }

        private void btnContinuarReclamar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
