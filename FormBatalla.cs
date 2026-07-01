using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class FormFondo : Form
    {
        private VistaCartasMaestra miCarta;
        private VistaCartasMaestra cartaRival;
        private PokedexManager manager = new PokedexManager();

        private bool atacandoHaciaAdelante = true;
        private Point posicionOriginalMiCarta;
        private int dañoPendiente = 0;

        private int miHpActual;
        private int rivalHpActual;

        public FormFondo(VistaCartasMaestra jugador, VistaCartasMaestra rival)
        {
            InitializeComponent();
            this.miCarta = jugador;
            this.cartaRival = rival;

        }

        private void FormBatalla_Load(object sender, EventArgs e)
        {
            picMiCarta.BackColor = Color.Transparent;

            picCartaRival.BackColor = Color.Transparent;

            posicionOriginalMiCarta = picMiCarta.Location;

            miHpActual = miCarta.HPCarta;
            rivalHpActual = cartaRival.HPCarta;

            pbMiHp.Maximum = miCarta.HPCarta;
            pbMiHp.Value = miHpActual;

            pbHpRival.Maximum=cartaRival.HPCarta;
            pbHpRival.Value = rivalHpActual;

        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            btnAtacar.Enabled = false;
            dañoPendiente = 25;

            atacandoHaciaAdelante = true;
            timerAnimacion.Start();

              
        }


         private void obMiHp_Click(object sender, EventArgs e)
        {

        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            int velocidad = 20;

            if (atacandoHaciaAdelante)
            {
                picMiCarta.Left += velocidad;
                if (picMiCarta.Right >= picCartaRival.Left)
                {
                    atacandoHaciaAdelante = false;

                }
            }
            else
            {
                picMiCarta.Left -= velocidad;
                if (picMiCarta.Left <= posicionOriginalMiCarta.X)
                {
                    timerAnimacion.Stop();
                    picMiCarta.Location = posicionOriginalMiCarta;

                    AplicarDañoAlRival();
                }
            }
        }

        private void AplicarDañoAlRival()
        {
            rivalHpActual -= dañoPendiente;
            if (rivalHpActual < 0) rivalHpActual = 0;
            pbHpRival.Value = rivalHpActual;

            if (rivalHpActual == 0)
            {
                MessageBox.Show("¡Victoria! Derrotaste a tu pokemon rival",
                    "Fin del combate");

                int fechaHoy = Convert.ToInt32(DateTime.Now.ToString("yyyyMdd"));
                Partida nuevaPartida = new Partida(0, Sesion.IdUsuarioActual, 2,
                    Sesion.IdUsuarioActual, fechaHoy);
                BatallasDetalle nuevoDetalle = new BatallasDetalle(0, 0, Sesion.IdUsuarioActual,
                    miCarta.IdPokemon, cartaRival.IdPokemon);

                manager.GuardarResultadoBatalla(nuevaPartida, nuevoDetalle);
                this.Close();

            }
            else 
            {
                btnAtacar.Enabled = true;

            }
        }
    }

}
