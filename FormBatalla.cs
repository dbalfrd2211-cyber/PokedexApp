using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace PokedexApp
{
    public partial class FormBatalla : Form 
    {
        private int idJugadorLogueado;
        private int idJugadorRival;

        private List<CartaBatalla> miEquipo;
        private List<CartaBatalla> equipoRival;

        private string jugadorLogueado;
        private string jugadorRival;

        private int indiceMi = 0;
        private int indiceRival = 0;

        private bool miTurno = true;
        private bool atacando = false;
        private Ataques ataquePendiente;

        private Point posicionOriginalMiCarta;
        private Point posicionOriginalRival;

        private PictureBox[] slotsMisCartas;
        private PictureBox[] slotsRival;
        private Button[] botonesMiAtaque;
        private Button[] botonesRivalAtaque;

        private Dictionary<int, Image> cacheImagenes = new Dictionary<int, Image>();

        public FormBatalla(List<CartaBatalla> equipoAnfitrion, List<CartaBatalla> equipoRival, string nombreAnfitrion, string nombreRival, int idAnfitrion, int idRival)
        {
            InitializeComponent();

            this.miEquipo = equipoAnfitrion;
            this.equipoRival = equipoRival;

            this.jugadorLogueado = nombreAnfitrion;
            this.jugadorRival = nombreRival;

            this.idJugadorLogueado = idAnfitrion;
            this.idJugadorRival = idRival;

            this.DoubleBuffered = true;

            // Asignar posiciones iniciales de diseño
            posicionOriginalMiCarta = picMiCarta.Location;
            posicionOriginalRival = picCartaRival.Location;

            InicializarArreglosControles();
        }

        private void FormBatalla_Load(object senderz, EventArgs e)
        {
            CargarImagenesEquipos();
            CargarPokemonActual();

            miTurno = true;
            ActualizarIndicadoresTurno();
            ConfigurarTurno(true);
            MostrarNarrador("¡La batalla ha comenzado! Elige un ataque.");
        }

        private void InicializarArreglosControles()
        {
            slotsMisCartas = new PictureBox[] { picMiCarta1, picMiCarta2, picMiCarta3 };
            slotsRival = new PictureBox[] { picRCarta1, picRCarta2, picRCarta3 };

            botonesMiAtaque = new Button[] { btnAtaque1, btnAtaque2, btnAtaque3, btnAtaque4 };
            botonesRivalAtaque = new Button[] { btnRAtaque1, btnRAtaque2, btnRAtaque3, btnRAtaque4 };
        }

        private void CargarImagenesEquipos()
        {

            for (int i = 0; i < miEquipo.Count; i++)
            {
                if (i >= slotsMisCartas.Length) break;

                Image img = ObtenerImagen(miEquipo[i].IdPokemon);
                if (img != null)
                {
                    slotsMisCartas[i].Image = img;
                    slotsMisCartas[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                slotsMisCartas[i].Tag = i;
                slotsMisCartas[i].Click += Slot_Click;
            }

            for (int i = 0; i < equipoRival.Count; i++)
            {
                if (i >= slotsRival.Length) break;

                Image img = ObtenerImagen(equipoRival[i].IdPokemon);
                if (img != null)
                {
                    slotsRival[i].Image = img;
                    slotsRival[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                slotsRival[i].Tag = i;
                slotsRival[i].Click += SlotRival_Click;
            }
        }
        

        //Eventos
        private void Slot_Click(object sender, EventArgs e)
        {
            if (atacando || !miTurno) return; 

            PictureBox slotClickeado = (PictureBox)sender;
            int nuevoIndice = (int)slotClickeado.Tag;

            CartaBatalla pokemonSeleccionado = miEquipo[nuevoIndice];

            if (pokemonSeleccionado.HpActual <= 0)
            {
                MessageBox.Show($"¡{pokemonSeleccionado.Nombre} no tiene energías para combatir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            indiceMi = nuevoIndice;

            foreach (var slot in slotsMisCartas) slot.BorderStyle = BorderStyle.None;
            slotClickeado.BorderStyle = BorderStyle.Fixed3D;

            CargarPokemonActual();
        }

        private void SlotRival_Click(object sender, EventArgs e)
        {
            if (atacando || miTurno) return;

            PictureBox slotClickeado = (PictureBox)sender;
            int nuevoIndice = (int)slotClickeado.Tag;

            CartaBatalla rivalSeleccionado = equipoRival[nuevoIndice];
            if (rivalSeleccionado.HpActual <= 0)
            {
                MessageBox.Show($"¡El rival {rivalSeleccionado.Nombre} ya está debilitado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            indiceRival = nuevoIndice;

            foreach (var slot in slotsRival) slot.BorderStyle = BorderStyle.None;
            slotClickeado.BorderStyle = BorderStyle.Fixed3D;

            CargarPokemonActual();
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
           //btnAtacar.Enabled = false;
           //dañoPendiente = 25;
           //atacandoHaciaAdelante = true;
           //timerAnimacion.Start();

        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            int velocidad = 25;
            bool haciaAdelante = (bool)timerAnimacion.Tag;

            if (haciaAdelante)
            {
                picMiCarta.Left += velocidad;
                if (picMiCarta.Right >= picCartaRival.Left)
                {
                    timerAnimacion.Stop();
                    picMiCarta.Location = posicionOriginalMiCarta;
                    AplicarDaño(ataquePendiente, esRivalAfirmado: true);
                    FinalizarTurno();
                }
            }
            else
            {
                picCartaRival.Left -= velocidad;
                if (picCartaRival.Left <= picMiCarta.Right)
                {
                    timerAnimacion.Stop();
                    picCartaRival.Location = posicionOriginalRival;
                    AplicarDaño(ataquePendiente, esRivalAfirmado: false);
                    FinalizarTurno();
                }
            }
        }

        private void BotonAtaque_Click(object sender, EventArgs e)
        {
            if (atacando || !miTurno) return;

            Button boton = (Button)sender;
            Ataques ataqueSeleccionado = (Ataques)boton.Tag;

            PrepararEjecucionAtaque(ataqueSeleccionado, miEquipo[indiceMi].Nombre, true);
        }

        private void BotonRAtaque_Click(object sender, EventArgs e)
        {
            if (atacando || miTurno) return;

            Button boton = (Button)sender;
            Ataques ataqueSeleccionado = (Ataques)boton.Tag;

            PrepararEjecucionAtaque(ataqueSeleccionado, equipoRival[indiceRival].Nombre, false);
        }

        private void PrepararEjecucionAtaque(Ataques ataque, string nombrePokemon, bool haciaAdelante)
        {
            atacando = true;
            ConfigurarTurno(false);

            ataquePendiente = ataque;
            MostrarNarrador($"¡{nombrePokemon} usó {ataque.Nombre}!");

            timerAnimacion.Tag = haciaAdelante;
            timerAnimacion.Start();
        }

        //Metodos
        private void CargarPokemonActual()
        {
            if (miEquipo == null || equipoRival == null || miEquipo.Count == 0 || equipoRival.Count == 0)
            {
                MessageBox.Show("Los equipos no han sido inicializados o están vacíos.", "Error de Equipos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (indiceMi >= miEquipo.Count || indiceRival >= equipoRival.Count) return;

            var miPokemon = miEquipo[indiceMi];
            var rivalPokemon = equipoRival[indiceRival];

            picMiCarta.Image = ObtenerImagen(miPokemon?.IdPokemon ?? 0);
            picCartaRival.Image = ObtenerImagen(rivalPokemon?.IdPokemon ?? 0);

            ActualizarBarrasVida();

            ActualizarBotonesAtaque(miPokemon, botonesMiAtaque, BotonAtaque_Click);
            ActualizarBotonesAtaque(rivalPokemon, botonesRivalAtaque, BotonRAtaque_Click);
        }

        private void ActualizarBotonesAtaque(CartaBatalla pokemon, Button[] botones, EventHandler eventoClick)
        {
            if (pokemon == null || pokemon.Ataques == null)
            {
                MessageBox.Show("¡Alerta! Se intentó cargar un Pokémon o lista de ataques vacía.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (botones == null) return;

            for (int i = 0; i < botones.Length; i++)
            {
                if (botones[i] == null) continue;

                botones[i].Click -= eventoClick;

                if (i < pokemon.Ataques.Count)
                {
                    var ataque = pokemon.Ataques[i];
                    botones[i].Text = $"{ataque.Nombre}\n{ataque.Danio} Pts Daño";
                    botones[i].Tag = ataque;
                    botones[i].Enabled = true;
                    botones[i].Click += eventoClick;
                }
                else
                {
                    botones[i].Text = "N/A";
                    botones[i].Enabled = false;
                }
            }
        }

        private Image ObtenerImagen(int id)
        {
            if (cacheImagenes.ContainsKey(id))
                return cacheImagenes[id];

            string ruta = Path.Combine(Application.StartupPath, "Imagenes", $"{id}.jpeg");
            if (File.Exists(ruta))
            {
                cacheImagenes[id] = Image.FromFile(ruta);
                return cacheImagenes[id];
            }
            return null;
        }

        private void AplicarDaño(Ataques ataque, bool esRivalAfirmado)
        {
            if (ataque == null) return;

            CartaBatalla usuario = esRivalAfirmado ? miEquipo[indiceMi] : equipoRival[indiceRival];
            CartaBatalla objetivo = esRivalAfirmado ? equipoRival[indiceRival] : miEquipo[indiceMi];

            int danioCalculado = ataque.Danio;

            // Aplicar modificador de daño del atacante
            if (usuario.ModificadorAtaque > 0)
            {
                danioCalculado += usuario.ModificadorAtaque;
            }

            // Mitigación por reflejo del defensor
            if (objetivo.TieneReflejo && ataque.Danio > 0)
            {
                danioCalculado /= 2;
            }

            if (danioCalculado < 0) danioCalculado = 0;
            if (ataque.Danio > 0 && danioCalculado == 0) danioCalculado = 1;

            objetivo.HpActual -= danioCalculado;

            if (ataque.IdEfecto > 0)
            {
                AplicarEfectoAtaque(ataque.IdEfecto, usuario, objetivo);
            }

            ActualizarBarrasVida();

            if (objetivo.HpActual <= 0)
            {
                objetivo.HpActual = 0;
                MessageBox.Show($"¡{objetivo.Nombre} se ha debilitado!", "Combate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (esRivalAfirmado)
                    BuscarSiguientePokemonVivoRival();
                else
                    BuscarSiguientePokemonVivoMio();
            }
        }

        private void BuscarSiguientePokemonVivoRival()
        {
            int buscados = 0;
            while (buscados < equipoRival.Count)
            {
                indiceRival = (indiceRival + 1) % equipoRival.Count;
                if (equipoRival[indiceRival].HpActual > 0)
                {
                    CargarPokemonActual();
                    return;
                }
                buscados++;
            }

            PokedexManager manager = new PokedexManager();
            manager.RegistrarResultadoBatalla(this.idJugadorLogueado, true);  // Gana
            manager.RegistrarResultadoBatalla(this.idJugadorRival, false);

            MessageBox.Show("¡Felicidades, has derrotado a todos los Pokémon del rival!\n¡VICTORIA!", "Fin de la Batalla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void FinalizarTurno()
        {
            CartaBatalla pokemonActivo = miTurno ? miEquipo[indiceMi] : equipoRival[indiceRival];

            // Control de Estado: Dormido
            if (pokemonActivo.Estado == "Dormido")
            {
                pokemonActivo.TurnosDormido--;

                if (pokemonActivo.TurnosDormido <= 0)
                {
                    pokemonActivo.Estado = "Normal";
                    pokemonActivo.TurnosDormido = 0;
                    MostrarNarrador($"¡{pokemonActivo.Nombre} se ha despertado!");
                }
                else
                {
                    MostrarNarrador($"¡{pokemonActivo.Nombre} está profundamente dormido y pierde el turno!");

                    // Cambiamos de turno sin permitir atacar
                    miTurno = !miTurno;
                    ActualizarIndicadoresTurno();
                    FinalizarTurno();
                    return;
                }
            }

            // Flujo normal: Intercambiar turnos y liberar candado de ataque
            atacando = false;
            miTurno = !miTurno;

            ActualizarIndicadoresTurno();
            ConfigurarTurno(true);
        }

        private void BuscarSiguientePokemonVivoMio()
        {
            int buscados = 0;
            while (buscados < miEquipo.Count)
            {
                indiceMi = (indiceMi + 1) % miEquipo.Count;
                if (miEquipo[indiceMi].HpActual > 0)
                {
                    CargarPokemonActual();
                    return;
                }
                buscados++;
            }

            PokedexManager manager = new PokedexManager();
            manager.RegistrarResultadoBatalla(this.idJugadorLogueado, false); // Pierde
            manager.RegistrarResultadoBatalla(this.idJugadorRival, true);

            MessageBox.Show("Todos tus Pokémon se han debilitado...\n¡HAS PERDIDO!", "Fin de la Batalla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        /*private void AplicarDañoAlRival()
        {
            if (esMiCarta) miEquipo[indiceMi].HpCombate -= cantidad;
            else equipoRival[indiceRival].HpCombate -= cantidad;

            ActualizarBarrasVida();
        }

        private void AplicarDañoAMiCarta()
        {
            var mia = miEquipo[indiceMiCarta];
            mia.HpCombate -= dañoPendiente;

            ActualizarBarrasVida();

            if (mia.HpCombate <= 0)
            {
                indiceMiCarta++;
                if (indiceMiCarta < miEquipo.Count)
                {
                    MessageBox.Show("¡Tu Pokémon se debilitó! Entra el siguiente.");
                    CargarPokemonActual();
                    ConfigurarTurno(true);
                }
                else
                {
                    MessageBox.Show("¡Has perdido la batalla!");
                    this.Close();
                }
            }
        }
        */

        private void ActualizarIndicadoresTurno()
        {
            if (miTurno)
            {
                lblMiTurno.Text = $"¡Tu turno, {jugadorLogueado}!";
                lblMiTurno.Visible = true;
                lblTurnoRival.Visible = false;
            }
            else
            {
                lblTurnoRival.Text = $"¡Turno de {jugadorRival}!";
                lblTurnoRival.Visible = true;
                lblMiTurno.Visible = false;
            }
        }

        private void ConfigurarTurno(bool habilitar)
        {
            bool seActivaMio = habilitar && miTurno;
            bool seActivaRival = habilitar && !miTurno;
            CartaBatalla pokemonActivo = miTurno ? miEquipo[indiceMi] : equipoRival[indiceRival];

            if (habilitar && pokemonActivo.Estado == "Dormido")
            {
                MostrarNarrador($"¡{pokemonActivo.Nombre} está profundamente dormido y no puede actuar!");
                ConfigurarTurno(false);
                Task.Delay(1500).ContinueWith(t => this.Invoke((MethodInvoker)FinalizarTurno));
                return;
            }

            // EFECTO PARALIZADO 
            if (habilitar && pokemonActivo.Estado == "Paralizado")
            {
                Random rand = new Random();
                if (rand.Next(0, 2) == 0)
                {
                    MostrarNarrador($"¡{pokemonActivo.Nombre} está paralizado y no puede moverse!");
                    ConfigurarTurno(false);
                    Task.Delay(1500).ContinueWith(t => this.Invoke((MethodInvoker)FinalizarTurno));
                    return;
                }
            }

            foreach (var btn in botonesMiAtaque) btn.Enabled = seActivaMio;
            foreach (var btn in botonesRivalAtaque) btn.Enabled = seActivaRival;
        }


        private void MostrarNarrador(string mensaje)
        {
            lblNarrador.Text = mensaje;
            lblNarrador.Refresh();
        }

        private void ActualizarBarrasVida()
        {
            var miPokemon = miEquipo[indiceMi];
            var rivalPokemon = equipoRival[indiceRival];

            double escalaMi = 1.5;
            pnlMiVidaFondo.Width = Math.Max(100, (int)(miPokemon.Hp * escalaMi));

            double miPorcentaje = (double)miPokemon.HpActual / miPokemon.Hp;
            pnlMiVidaBarra.Width = (int)(miPorcentaje * pnlMiVidaFondo.Width);
            lblHpAnfitrion.Text = $"{miPokemon.HpActual} / {miPokemon.Hp} HP";


            double escalaRival = 1.5;
            pnlRivalVidaFondo.Width = Math.Max(100, (int)(rivalPokemon.Hp * escalaRival));

            double rivalPorcentaje = (double)rivalPokemon.HpActual / rivalPokemon.Hp;
            pnlRivalVidaBarra.Width = (int)(rivalPorcentaje * pnlRivalVidaFondo.Width);
            lblHpRival.Text = $"{rivalPokemon.HpActual} / {rivalPokemon.Hp} HP";

            pnlMiVidaFondo.Refresh();
            pnlMiVidaBarra.Refresh();
            pnlRivalVidaFondo.Refresh();
            pnlRivalVidaBarra.Refresh();
        }

        private void AplicarEfectoAtaque(int idEfecto, CartaBatalla usuario, CartaBatalla objetivo)
        {
            switch (idEfecto)
            {
                case 1: // Ataque +1
                    usuario.ModificadorAtaque += 1;
                    MostrarNarrador($"¡El Ataque de {usuario.Nombre} aumentó!");
                    break;

                case 2: // Ataque +2
                    usuario.ModificadorAtaque += 2;
                    MostrarNarrador($"¡El Ataque de {usuario.Nombre} aumentó drásticamente!");
                    break;

                case 3: // Velocidad +2
                    usuario.ModificadorVelocidad += 2;
                    MostrarNarrador($"¡La Velocidad de {usuario.Nombre} aumentó muchísimo!");
                    break;

                case 4: // Especial +1
                    usuario.ModificadorEspecial += 1;
                    MostrarNarrador($"¡El Ataque Especial de {usuario.Nombre} aumentó!");
                    break;

                case 5: // Especial +2
                    usuario.ModificadorEspecial += 2;
                    MostrarNarrador($"¡El Ataque Especial de {usuario.Nombre} aumentó drásticamente!");
                    break;

                case 6: // Defensa +1
                    usuario.ModificadorDefensa += 1;
                    MostrarNarrador($"¡La Defensa de {usuario.Nombre} aumentó!");
                    break;

                case 7: // Defensa +2
                    usuario.ModificadorDefensa += 2;
                    MostrarNarrador($"¡La Defensa de {usuario.Nombre} aumentó drásticamente!");
                    break;

                case 8: // Curar50
                    int saludACurar50 = (int)(usuario.Hp * 0.5);
                    usuario.HpActual = Math.Min(usuario.Hp, usuario.HpActual + saludACurar50);
                    MostrarNarrador($"¡{usuario.Nombre} restauró el 50% de sus PS!");
                    break;

                case 9: // Descanso
                    usuario.HpActual = usuario.Hp; 
                    usuario.Estado = "Dormido";
                    usuario.TurnosDormido = 2;
                    MostrarNarrador($"¡{usuario.Nombre} recuperó todos sus PS y se durmió para descansar!");
                    break;

                case 12: // DefensaRival -1 
                    objetivo.ModificadorDefensa -= 1;
                    MostrarNarrador($"¡La Defensa de {objetivo.Nombre} bajó!");
                    break;

                case 13: // DefensaRival -2
                    objetivo.ModificadorDefensa -= 2;
                    MostrarNarrador($"¡La Defensa de {objetivo.Nombre} cayó drásticamente!");
                    break;

                case 14: // AtaqueRival -1
                    objetivo.ModificadorAtaque -= 1;
                    MostrarNarrador($"¡El Ataque de {objetivo.Nombre} bajó!");
                    break;

                case 15: // VelocidadRival -1
                    objetivo.ModificadorVelocidad -= 1;
                    MostrarNarrador($"¡La Velocidad de {objetivo.Nombre} bajó!");
                    break;

                case 16: // Dormir 
                    objetivo.Estado = "Dormido";
                    objetivo.TurnosDormido = 2;
                    MostrarNarrador($"¡{objetivo.Nombre} se ha quedado dormido!");
                    break;

                case 17: // Paralizar
                    objetivo.Estado = "Paralizado";
                    MostrarNarrador($"¡{objetivo.Nombre} ha sido paralizado!");
                    break;

                case 18: // Envenenar 
                    objetivo.Estado = "Envenenado";
                    MostrarNarrador($"¡{objetivo.Nombre} ha sido envenenado!");
                    break;

                case 19: // EnvenenamientoGrave
                    objetivo.Estado = "EnvenenadoGrave";
                    MostrarNarrador($"¡{objetivo.Nombre} fue envenenado gravemente!");
                    break;

                case 20: // Confundir
                    objetivo.Estado = "Confundido";
                    MostrarNarrador($"¡¡{objetivo.Nombre} empezó a sentirse confundido!");
                    break;

                case 28: // ReiniciarEstadisticas
                    usuario.ModificadorAtaque = 0;
                    usuario.ModificadorDefensa = 0;
                    usuario.ModificadorVelocidad = 0;
                    usuario.ModificadorEspecial = 0;
                    objetivo.ModificadorAtaque = 0;
                    objetivo.ModificadorDefensa = 0;
                    objetivo.ModificadorVelocidad = 0;
                    objetivo.ModificadorEspecial = 0;
                    MostrarNarrador($"¡Todas las alteraciones de estadísticas volvieron a la normalidad!");
                    break;

                case 34: // Sustituto
                    int costoSustituto = (int)(usuario.Hp * 0.25);
                    usuario.HpActual = Math.Max(1, usuario.HpActual - costoSustituto);
                    MostrarNarrador($"¡{usuario.Nombre} creó un sustituto sacrificando PS!");
                    break;

                case 36: // KOInstantaneo 
                    objetivo.HpActual = 0;
                    MostrarNarrador($"¡Es un golpe fulminante! ¡KO instantáneo!");
                    break;

                case 37: // DanoFijo40
                    objetivo.HpActual = Math.Max(0, objetivo.HpActual - 40);
                    MostrarNarrador($"¡Causó un daño fijo de 40 PS!");
                    break;

                case 38: // DanoNivel 
                    int danioNivel = 50;
                    objetivo.HpActual = Math.Max(0, objetivo.HpActual - danioNivel);
                    MostrarNarrador($"¡Causó {danioNivel} puntos de daño por su nivel!");
                    break;

                case 39: // MitadPS 
                    objetivo.HpActual = Math.Max(1, (int)(objetivo.HpActual / 2));
                    MostrarNarrador($"¡Los PS de {objetivo.Nombre} se redujeron a la mitad!");
                    break;

                case 41: // DanoAleatorioNivel 
                    Random rnd = new Random();
                    int multiplicador = rnd.Next(1, 11);
                    objetivo.HpActual = Math.Max(0, objetivo.HpActual - multiplicador);
                    MostrarNarrador($"¡Causó daño aleatorio basado en el nivel!");
                    break;

                case 42: // AutoDebilitacion 
                    usuario.HpActual = 0;
                    MostrarNarrador($"¡{usuario.Nombre} se sacrificó y se ha debilitado!");
                    break;

                default:
                    break;
            }
        }
    }
}
 