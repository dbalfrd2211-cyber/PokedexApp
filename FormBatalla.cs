using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Console;

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
        private Point posicionOriginalRival;
        public FormBatalla(List<Cartas> equipoJugador, List<Cartas> equipoRival)
        {
            InitializeComponent();
            this.miEquipo = equipoJugador;
            this.equipoRival = equipoRival;

        }

        private void FormBatalla_Load(object senderz, EventArgs e)
        {
            posicionOriginalMiCarta = picMiCarta.Location;
            posicionOriginalRival = picCartaRival.Location;


            PictureBox[] slotsMisCartas = { picMiCarta1, picMiCarta2, picMiCarta3 };

            for (int i = 0; i < miEquipo.Count; i++)
            {
                if (i < slotsMisCartas.Length)
                {

                    Image img = CargarImagen(miEquipo[i].IdPokemon);
                    if (img != null)
                    {
                        slotsMisCartas[i].Image = img;
                        slotsMisCartas[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    slotsMisCartas[i].Tag = i;
                    slotsMisCartas[i].Click += Slot_Click;
                }
            }

                PictureBox[] slotsRival = { picRCarta1, picRCarta2, picRCarta3 };
            for (int i = 0; i < equipoRival.Count; i++)
            {
                if (i < slotsRival.Length)
                {
                    Image img = CargarImagen(equipoRival[i].IdPokemon);
                    if (img != null)
                    {
                        slotsRival[i].Image = img;
                        slotsRival[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    slotsRival[i].Tag = i;
                    slotsRival[i].Click += SlotRival_Click;
                }
                CargarPokemonActual();
            }
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
        private void SlotRival_Click(object sender, EventArgs e)
        {
            PictureBox clickedSlot = (PictureBox)sender;
            indiceRival = (int)clickedSlot.Tag;

            // Limpiar bordes del rival
            foreach (var slot in new PictureBox[] { picRCarta1, picRCarta2, picRCarta3 })
            {
                slot.BorderStyle = BorderStyle.None;
            }
            clickedSlot.BorderStyle = BorderStyle.Fixed3D;

            CargarPokemonActual();
        }

        private void CargarPokemonActual()
        {
            if (miEquipo == null || equipoRival == null) return;
            if (indiceMiCarta < 0 || indiceMiCarta >= miEquipo.Count) return;
            if (indiceRival < 0 || indiceRival >= equipoRival.Count) return;

            var cartaMia = miEquipo[indiceMiCarta];
            var cartaRival = equipoRival[indiceRival];
            if (cartaMia != null && picMiCarta != null)
            {
                picMiCarta.Image = CargarImagen(cartaMia.IdPokemon);
            }
            picMiCarta.Image = CargarImagen(cartaMia.IdPokemon);
            picCartaRival.Image = CargarImagen(cartaRival.IdPokemon);


            miHpActual = cartaMia.Hp;
            rivalHpActual = cartaRival.Hp;

            pbMiHp.Maximum = cartaMia.Hp;
            pbMiHp.Value = miHpActual;

            pbHpRival.Maximum = cartaRival.Hp;
            pbHpRival.Value = rivalHpActual;

            Button[] botonesAtaque = { btnAtaque1, btnAtaque2, btnAtaque3, btnAtaque4 };
            for(int i = 0; i < botonesAtaque.Length; i++)
            {
                if (i < cartaMia.Ataques.Count)
                {
                    botonesAtaque[i].Text = cartaMia.Ataques[i].Nombre;
                    botonesAtaque[i].Tag = cartaMia.Ataques[i];
                    botonesAtaque[i].Enabled = true;
                    botonesAtaque[i].Click -= BotonAtaque_Click; // Evitar múltiples suscripciones
                    botonesAtaque[i].Click += BotonAtaque_Click;
                }
                else
                {
                    botonesAtaque[i].Text = "N/A";
                    botonesAtaque[i].Enabled = false;
                }
            }
            Button[] botonesRAtaque = { btnRAtaque1, btnRAtaque2, btnRAtaque3, btnRAtaque4 };
            

            for (int i = 0; i < botonesRAtaque.Length; i++)
            {
                if (i < cartaRival.Ataques.Count)
                {
                    botonesRAtaque[i].Text = cartaRival.Ataques[i].Nombre;
                    botonesRAtaque[i].Tag = cartaRival.Ataques[i];
                    botonesRAtaque[i].Enabled = true;
                    botonesRAtaque[i].Click -= BotonRAtaque_Click; // Evitar múltiples suscripciones
                    botonesRAtaque[i].Click += BotonRAtaque_Click;
                }
                else
                {
                    botonesRAtaque[i].Text = "N/A";
                    botonesRAtaque[i].Enabled = false;
                }
            }



        }



        

        private Image CargarImagen(int idPokemon)
        {
            string nombreArchivo = idPokemon.ToString() + ".jpeg";
            string ruta = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo);

            if (File.Exists(ruta))
            {
                return Image.FromFile(ruta);
            }
            else
            {
                // Si no existe, puedes devolver null o una imagen por defecto
                return null;
            }
        }



        private void btnAtacar_Click(object sender, EventArgs e)
        {
           //btnAtacar.Enabled = false;
           //dañoPendiente = 25;
           //atacandoHaciaAdelante = true;
           //timerAnimacion.Start();

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
                    timerAnimacion.Stop();
                    picMiCarta.Location = posicionOriginalMiCarta;
                    //atacandoHaciaAdelante = false;
                    AplicarDañoAlRival();   
                }
            }
            else
            {
                picCartaRival.Left -= velocidad;
                if (picCartaRival.Left <= picMiCarta.Right)
                {
                    //atacandoHaciaAdelante = true;
                    timerAnimacion.Stop();
                    picCartaRival.Location = posicionOriginalRival;


                    AplicarDañoAMiCarta();  
                }

                //AplicarDañoAlRival();
                
            }
           //if(!atacandoHaciaAdelante && picMiCarta.Left <= posicionOriginalMiCarta.X)
           //{
           //    timerAnimacion.Stop();
           //    picMiCarta.Location = posicionOriginalMiCarta;
           //    AplicarDañoAlRival();
           //}
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



        private void BotonAtaque_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            Ataques ataqueSeleccionado = (Ataques)boton.Tag;

            dañoPendiente = ataqueSeleccionado.Danio;
            MostrarNarrador($"¡{miEquipo[indiceMiCarta].Nombre} usó {ataqueSeleccionado.Nombre}!");
            atacandoHaciaAdelante = true;
            timerAnimacion.Start();
        }
        private void BotonRAtaque_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            Ataques ataqueSeleccionado = (Ataques)boton.Tag;
            dañoPendiente = ataqueSeleccionado.Danio;
            MostrarNarrador($"¡{equipoRival[indiceRival].Nombre} usó {ataqueSeleccionado.Nombre}!");
            atacandoHaciaAdelante = false;
            timerAnimacion.Start();
        }

        private void AplicarDañoAMiCarta()
        {
            miHpActual -= dañoPendiente;
            pbMiHp.Value = Math.Max(0, miHpActual);
            if (miHpActual <= 0)
            {
                indiceMiCarta++;
                if (indiceMiCarta < miEquipo.Count)
                {
                    MessageBox.Show("¡Tu Pokémon se debilitó! Entra el siguiente.");
                    CargarPokemonActual();
                    btnAtacar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("¡Has perdido la batalla!");
                    this.Close();
                }
            }
        }

        private void MostrarNarrador(string mensaje)
        {
            lblNarrador.Text = mensaje;


            lblNarrador.Refresh();
        }
    }
}
