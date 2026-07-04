using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class FormBatalla : Form
    {
        private List<Cartas> miEquipo;
        private List<Cartas> equipoRival;
        private int indiceMiCarta = 0;
        private int indiceRival = 0;

        private PokedexManager manager = new PokedexManager();
        private bool atacandoHaciaAdelante = true;
        private Point posicionOriginalMiCarta;
        private int dañoPendiente = 0;
        private int miHpActual;
        private int rivalHpActual;

        public FormBatalla(List<Cartas> equipoJugador, List<Cartas> equipoRival)
        {
            InitializeComponent();
            this.miEquipo = equipoJugador;
            this.equipoRival = equipoRival;

        }

        private void FormBatalla_Load(object senderz, EventArgs e)
        {
            posicionOriginalMiCarta = picMiCarta.Location;

            if (miEquipo == null || miEquipo.Count == 0) 
            {
                MessageBox.Show("¡Error! El equipo llegó vacio al combate");
                return;
            }

            PictureBox[] slotsMisCartas = { picMiCarta1, picMiCarta2, picMiCarta3 };
            for (int i = 0; i < miEquipo.Count; i++)
            {
                if (i < slotsMisCartas.Length)
                {
                    Image img = CargarImagen(miEquipo[i].Imagen);
                    if (img != null)
                    {
                        slotsMisCartas[i].Image = img;
                        slotsMisCartas[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    slotsMisCartas[i].Tag=i;
                    slotsMisCartas[i].Click += Slot_Click;
                }
            }
            CargarPokemonActual();
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            PictureBox clickedSlot = (PictureBox)sender;
            indiceMiCarta = (int)clickedSlot.Tag;

            foreach (var slot in new PictureBox[] { picMiCarta1, picMiCarta2, picMiCarta3 })
            { 
                slot.BorderStyle = BorderStyle.None;
            }
            clickedSlot.BorderStyle = BorderStyle.Fixed3D;
            CargarPokemonActual();


        }

        private void CargarPokemonActual()
        {
            var cartaMia = miEquipo[indiceMiCarta];
            var cartaRival = equipoRival[indiceRival];

            picMiCarta.Image = CargarImagen(cartaMia.Imagen);
            picCartaRival.Image = CargarImagen(cartaRival.Imagen);


            miHpActual = cartaMia.Hp;
            rivalHpActual = cartaRival.Hp;

            pbMiHp.Maximum = cartaMia.Hp;
            pbMiHp.Value = miHpActual;

            pbHpRival.Maximum = cartaRival.Hp;
            pbHpRival.Value = rivalHpActual;
        }

        private Image CargarImagen(string imagen)
        {
            if (string.IsNullOrEmpty(imagen) )return null;
            
            string ruta = Path.Combine(Application.StartupPath, "Imagenes", imagen);

            if (!File.Exists(ruta))
            {
                return null; 
            }
            return Image.FromFile(ruta);

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
            pbHpRival.Value = Math.Max(0, rivalHpActual);

            if (rivalHpActual <= 0)
            {
                indiceRival++;
                if (indiceRival < equipoRival.Count)
                {
                    MessageBox.Show("¡El rival se debilitó! Entra el siguiente.");
                    CargarPokemonActual();
                    btnAtacar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("¡Victoria total!");
                    this.Close();
                }
            }
            else
            {

                btnAtacar.Enabled = true;
            }
        }

        private void ConfigurarSlots()
        {
            PictureBox[] slots = { picMiCarta, picMiCarta2, picMiCarta3 };
            for (int i = 0; i < miEquipo.Count; i++)
            {
                slots[i].Tag = i;

                slots[i].Image = CargarImagen(miEquipo[i].Imagen);
                slots[i].Click += (s, e) =>
                {
                    indiceMiCarta = (int)((PictureBox)s).Tag;
                    CargarPokemonActual();
                };
            }
        }

    }
}
