using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace PokedexApp
{
    public partial class FormBatalla : Form
    {
        private Dictionary<Cartas, int> modificadoresAtaque = new Dictionary<Cartas, int>();
        private Dictionary<Cartas, int> modificadoresDefensa = new Dictionary<Cartas, int>();
        private Dictionary<Cartas, int> modificadoresVelocidad = new Dictionary<Cartas, int>();
        private Dictionary<Cartas, int> modificadoresEspecial = new Dictionary<Cartas, int>();

        private Dictionary<Cartas, int> turnosDormido = new Dictionary<Cartas, int>();
        private Dictionary<Cartas, bool> tieneReflejo = new Dictionary<Cartas, bool>();
        private Dictionary<Cartas, int> turnosReflejo = new Dictionary<Cartas, int>();

        private Dictionary<Cartas, string> estadoPokemon = new Dictionary<Cartas, string>();
        private Dictionary<Cartas, bool> tieneDrenadoras = new Dictionary<Cartas, bool>();

        private string jugadorLogueado;
        private string jugadorRival;

        private List<Cartas> miEquipo;
        private List<Cartas> equipoRival;

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

        public FormBatalla(List<Cartas> equipoJugador, List<Cartas> equipoRival, string jugador, string rival)
        {
            InitializeComponent();

            this.miEquipo = equipoJugador;
            this.equipoRival = equipoRival;

            this.jugadorLogueado = jugador;
            this.jugadorRival = rival;

            this.DoubleBuffered = true;

            posicionOriginalMiCarta = picMiCarta.Location;
            posicionOriginalRival = picCartaRival.Location;

            InicializarArreglosControles();
        }

        private void FormBatalla_Load(object senderz, EventArgs e)
        {

            foreach (var carta in miEquipo) carta.HpCombate = carta.Hp;
            foreach (var carta in equipoRival) carta.HpCombate = carta.Hp;

            CargarMiniaturasEquipos();
            CargarPokemonActual();

            miTurno = true;
            ActualizarIndicadoresTurno();
            ConfigurarTurno(true);
            MostrarNarrador("¡La batalla ha comenzado! Elige un ataque.");
            /*MiTurno = true;
            ActualizarIndicadoresTurno();
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

                foreach (var carta in miEquipo) carta.HpCombate = carta.Hp;
                foreach (var carta in equipoRival) carta.HpCombate = carta.Hp;
                //CargarPokemonActual();
            }*/
        }

        private void InicializarArreglosControles()
        {
            // Imagenes de cartas
            slotsMisCartas = new PictureBox[] { picMiCarta1, picMiCarta2, picMiCarta3 };
            slotsRival = new PictureBox[] { picRCarta1, picRCarta2, picRCarta3 };

            // Botones de ataque
            botonesMiAtaque = new Button[] { btnAtaque1, btnAtaque2, btnAtaque3, btnAtaque4 };
            botonesRivalAtaque = new Button[] { btnRAtaque1, btnRAtaque2, btnRAtaque3, btnRAtaque4 };
        }

        private void CargarMiniaturasEquipos()
        {
            // Cargar imagenes del Jugador Logueado
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

            // Cargar imagenes del Usuario2
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
            if (atacando) return; // Bloquear si hay una animación en curso

            PictureBox slotClickeado = (PictureBox)sender;
            int nuevoIndice = (int)slotClickeado.Tag;

            // Validar que el Pokémon seleccionado no esté debilitado antes de cambiarlo
            if (miEquipo[nuevoIndice].HpCombate <= 0)
            {
                MessageBox.Show($"¡{miEquipo[nuevoIndice].Nombre} no tiene energías para combatir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            indiceMi = nuevoIndice;

            // Resaltar visualmente la miniatura activa usando los bordes del control
            foreach (var slot in slotsMisCartas) slot.BorderStyle = BorderStyle.None;
            slotClickeado.BorderStyle = BorderStyle.Fixed3D;

            CargarPokemonActual();
        }

        private void SlotRival_Click(object sender, EventArgs e)
        {
            if (atacando) return;

            PictureBox slotClickeado = (PictureBox)sender;
            int nuevoIndice = (int)slotClickeado.Tag;

            if (equipoRival[nuevoIndice].HpCombate <= 0)
            {
                MessageBox.Show($"¡El rival {equipoRival[nuevoIndice].Nombre} ya está debilitado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (haciaAdelante) // Ataque del Jugador 1 -> Rival
            {
                picMiCarta.Left += velocidad;
                if (picMiCarta.Right >= picCartaRival.Left)
                {
                    timerAnimacion.Stop();
                    picMiCarta.Location = posicionOriginalMiCarta; // Retornar de inmediato
                    AplicarDaño(ataquePendiente, esRivalAfirmado: true);
                    FinalizarTurno();
                }
            }
            else // Ataque del Rival -> Jugador 1
            {
                picCartaRival.Left -= velocidad;
                if (picCartaRival.Left <= picMiCarta.Right)
                {
                    timerAnimacion.Stop();
                    picCartaRival.Location = posicionOriginalRival; // Retornar de inmediato
                    AplicarDaño(ataquePendiente, esRivalAfirmado: false);
                    FinalizarTurno();
                }
            }
            /*int velocidad = 20;

            if (atacandoHaciaAdelante)
            {
                picMiCarta.Left += velocidad;
                if (picMiCarta.Right >= picCartaRival.Left)
                {
                    timerAnimacion.Stop();
                    picMiCarta.Location = posicionOriginalMiCarta;
                    //atacandoHaciaAdelante = false;
                    AplicarDañoAlRival();

                    FinalizarTurno();
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
                    FinalizarTurno();
                }

                //AplicarDañoAlRival();
                
            }
           //if(!atacandoHaciaAdelante && picMiCarta.Left <= posicionOriginalMiCarta.X)
           //{
           //    timerAnimacion.Stop();
           //    picMiCarta.Location = posicionOriginalMiCarta;
           //    AplicarDañoAlRival();
           //}*/
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
            ConfigurarTurno(false); // Inhabilitar los botones de ambos durante la animación

            ataquePendiente = ataque;
            MostrarNarrador($"¡{nombrePokemon} usó {ataque.Nombre}!");

            // Asignar dirección del movimiento al temporizador físico
            // Si es verdadero se desplaza de Izquierda a Derecha, si es falso de Derecha a Izquierda
            timerAnimacion.Tag = haciaAdelante;
            timerAnimacion.Start();
        }

        //Metodos
        private void CargarPokemonActual()
        {
            if (indiceMi >= miEquipo.Count || indiceRival >= equipoRival.Count) return;

            var miPokemon = miEquipo[indiceMi];
            var rivalPokemon = equipoRival[indiceRival];

            // 1. Renderizar imágenes principales en los templos de combate
            picMiCarta.Image = ObtenerImagen(miPokemon.IdPokemon);
            picCartaRival.Image = ObtenerImagen(rivalPokemon.IdPokemon);


            ActualizarBarrasVida();

            // 4. Mapear y actualizar los paneles de comandos/botones de ataque
            ActualizarBotonesAtaque(miPokemon, botonesMiAtaque, BotonAtaque_Click);
            ActualizarBotonesAtaque(rivalPokemon, botonesRivalAtaque, BotonRAtaque_Click);

            /*if (miEquipo == null || equipoRival == null) return;
            var cartaMia = miEquipo[indiceMiCarta];
            var cartaRival = equipoRival[indiceRival];

            // Carga de imágenes
            picMiCarta.Image = CargarImagen(cartaMia.IdPokemon);
            picCartaRival.Image = CargarImagen(cartaRival.IdPokemon);

            // Configuración inicial de barras
            pbMiHp.Maximum = cartaMia.Hp;
            pbMiHp.Value = Math.Max(0, Math.Min(cartaMia.HpCombate, cartaMia.Hp));

            pbHpRival.Maximum = cartaRival.Hp;
            pbHpRival.Value = Math.Max(0, Math.Min(cartaRival.HpCombate, cartaRival.Hp));

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
            }*/
        }

        private void ActualizarBotonesAtaque(Cartas pokemon, Button[] botones, EventHandler eventoClick)
        {
            for (int i = 0; i < botones.Length; i++)
            {
                // Remover suscripciones previas para evitar llamadas duplicadas en memoria
                botones[i].Click -= eventoClick;

                if (i < pokemon.Ataques.Count)
                {
                    var ataque = pokemon.Ataques[i];

                    // Diseñar el texto en dos líneas limpias: Nombre arriba, daño abajo
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
                // Almacenar en el diccionario para no volver a leer del disco duro
                cacheImagenes[id] = Image.FromFile(ruta);
                return cacheImagenes[id];
            }
            return null;
        }

        private int ObtenerModificador(Dictionary<Cartas, int> diccionario, Cartas pokemon)
        {
            return diccionario.ContainsKey(pokemon) ? diccionario[pokemon] : 0;
        }

        private void AplicarDaño(Ataques ataque, bool esRivalAfirmado)
        {
            if (ataque == null) return;

            Cartas usuario = esRivalAfirmado ? miEquipo[indiceMi] : equipoRival[indiceRival];
            Cartas objetivo = esRivalAfirmado ? equipoRival[indiceRival] : miEquipo[indiceMi];

            // 1. Reducir vida por el daño base del ataque
            int danioCalculado = ataque.Danio;

            int modAtaque = ObtenerModificador(modificadoresAtaque, usuario);
            if (modAtaque > 0)
            {
                danioCalculado += modAtaque; // O la lógica de multiplicación/suma que tengas pensada
            }

            if (tieneReflejo.ContainsKey(objetivo) && tieneReflejo[objetivo])
            {
                if (ataque.Danio > 0)
                {
                    danioCalculado /= 2; // Reduce el impacto físico a la mitad
                }
            }

            if (danioCalculado < 0) danioCalculado = 0;
            if (ataque.Danio > 0 && danioCalculado == 0) danioCalculado = 1; // Al menos causa 1 de daño si el ataque genera golpe

            objetivo.HpCombate -= danioCalculado;

            // 2. Ejecutar el efecto asignado desde la base de datos (si existe)
            if (ataque.IdEfecto > 0)
            {
                AplicarEfectoAtaque(ataque.IdEfecto, usuario, objetivo);
            }

            ActualizarBarrasVida();

            // 3. Validar si el objetivo sobrevivió o cayó debilitado tras recibir daño + efectos
            if (objetivo.HpCombate <= 0)
            {
                objetivo.HpCombate = 0;
                MessageBox.Show($"¡{objetivo.Nombre} se ha debilitado!", "Combate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (esRivalAfirmado)
                    BuscarSiguientePokemonVivoRival();
                else
                    BuscarSiguientePokemonVivoMio();
            }

        }

        private void BuscarSiguientePokemonVivoRival()
        {
            // Buscar cíclicamente la siguiente carta que tenga vida disponible
            int buscados = 0;
            while (buscados < equipoRival.Count)
            {
                indiceRival = (indiceRival + 1) % equipoRival.Count;
                if (equipoRival[indiceRival].HpCombate > 0)
                {
                    CargarPokemonActual();
                    return;
                }
                buscados++;
            }

            // Si salió del bucle, todas las cartas del rival cayeron
            MessageBox.Show("¡Felicidades, has derrotado a todos los Pokémon del rival!\n¡VICTORIA!", "Fin de la Batalla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void FinalizarTurno()
        {
            // Identificar quién acaba de terminar su turno para aplicarle los efectos de fin de turno
            Cartas pokemonActivo = miTurno ? miEquipo[indiceMi] : equipoRival[indiceRival];
            Cartas pokemonBanquillo = miTurno ? equipoRival[indiceRival] : miEquipo[indiceMi];

            // EFECTO: CONTROL DE ESTADO DORMIDO
            // Verificamos si el Pokémon tiene un estado registrado en el diccionario
            string estadoActual = estadoPokemon.ContainsKey(pokemonActivo) ? estadoPokemon[pokemonActivo] : "Normal";

            if (estadoActual == "Dormido")
            {
                if (!turnosDormido.ContainsKey(pokemonActivo))
                {
                    turnosDormido[pokemonActivo] = 2;
                }

                turnosDormido[pokemonActivo]--;

                if (turnosDormido[pokemonActivo] <= 0)
                {
                    estadoPokemon[pokemonActivo] = "Normal"; // Despierta en el diccionario
                    turnosDormido[pokemonActivo] = 0;
                    MostrarNarrador($"¡{pokemonActivo.Nombre} se ha despertado!");
                }
                else
                {
                    MostrarNarrador($"¡{pokemonActivo.Nombre} está profundamente dormido!");
                    ConfigurarTurno(false);
                    Task.Delay(1500).ContinueWith(t => this.Invoke((MethodInvoker)FinalizarTurno));
                    return;
                }
            }

            // EFECTO: DRENADORAS
            // Validamos usando el diccionario de drenadoras
            if (tieneDrenadoras.ContainsKey(pokemonActivo) && tieneDrenadoras[pokemonActivo] && pokemonActivo.HpCombate > 0)
            {
                int danioDrenadoras = (int)(pokemonActivo.Hp * 0.125M); // 1/8 de la vida máxima
                pokemonActivo.HpCombate = Math.Max(0, pokemonActivo.HpCombate - danioDrenadoras);

                // El rival se cura el daño infligido
                pokemonBanquillo.HpCombate = Math.Min(pokemonBanquillo.Hp, pokemonBanquillo.HpCombate + danioDrenadoras);

                MostrarNarrador($"¡Las drenadoras restan salud a {pokemonActivo.Nombre} y curan a {pokemonBanquillo.Nombre}!");
                ActualizarBarrasVida();
            }

            // EFECTO: ENVENENAMIENTO
            // Obtenemos el estado actual del diccionario de forma segura
            string estadoFinTurno = estadoPokemon.ContainsKey(pokemonActivo) ? estadoPokemon[pokemonActivo] : "Normal";

            if (estadoFinTurno == "Envenenado" && pokemonActivo.HpCombate > 0)
            {
                int danioVeneno = (int)(pokemonActivo.Hp * 0.0625M); // 1/16 de la vida
                pokemonActivo.HpCombate = Math.Max(0, pokemonActivo.HpCombate - danioVeneno);

                MostrarNarrador($"¡El veneno resta salud a {pokemonActivo.Nombre}!");
                ActualizarBarrasVida();
            }

            // EFECTO: REDUCCIÓN DE TURNOS DE REFLEJO
            if (tieneReflejo.ContainsKey(pokemonActivo) && tieneReflejo[pokemonActivo])
            {
                // Si el contador no existe, lo inicializamos en 5 por defecto
                if (!turnosReflejo.ContainsKey(pokemonActivo))
                {
                    turnosReflejo[pokemonActivo] = 5;
                }

                turnosReflejo[pokemonActivo]--;

                if (turnosReflejo[pokemonActivo] <= 0)
                {
                    tieneReflejo[pokemonActivo] = false;
                    turnosReflejo[pokemonActivo] = 0;
                    MostrarNarrador($"¡El Reflejo de {pokemonActivo.Nombre} se ha desvanecido!");
                }
            }

            // Validar si algún Pokémon se debilitó por efectos secundarios de fin de turno
            if (pokemonActivo.HpCombate <= 0)
            {
                pokemonActivo.HpCombate = 0;
                ActualizarBarrasVida();
                MessageBox.Show($"¡{pokemonActivo.Nombre} se ha debilitado por daño secundario!", "Combate");

                if (miTurno) BuscarSiguientePokemonVivoMio();
                else BuscarSiguientePokemonVivoRival();
            }

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
                if (miEquipo[indiceMi].HpCombate > 0)
                {
                    // Resaltar visualmente la nueva miniatura activa de tu equipo
                    foreach (var slot in slotsMisCartas) slot.BorderStyle = BorderStyle.None;
                    slotsMisCartas[indiceMi].BorderStyle = BorderStyle.Fixed3D;

                    CargarPokemonActual();
                    return;
                }
                buscados++;
            }
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

            // Obtener el Pokémon que intenta actuar
            Cartas pokemonActivo = miTurno ? miEquipo[indiceMi] : equipoRival[indiceRival];

            // Obtener el estado actual del diccionario de forma segura
            string estadoActualTurno = estadoPokemon.ContainsKey(pokemonActivo) ? estadoPokemon[pokemonActivo] : "Normal";

            // Control de Estado: Dormido
            if (habilitar && estadoActualTurno == "Dormido")
            {
                // Si no tiene turnos asignados en el diccionario, lo inicializamos en 2
                if (!turnosDormido.ContainsKey(pokemonActivo))
                {
                    turnosDormido[pokemonActivo] = 2;
                }

                // Restamos un turno en el diccionario
                turnosDormido[pokemonActivo]--;

                if (turnosDormido[pokemonActivo] <= 0)
                {
                    estadoPokemon[pokemonActivo] = "Normal"; // Cambia el estado a Normal en el diccionario
                    turnosDormido[pokemonActivo] = 0;
                    MostrarNarrador($"¡{pokemonActivo.Nombre} se ha despertado!");
                }
                else
                {
                    MostrarNarrador($"¡{pokemonActivo.Nombre} está profundamente dormido!");
                    ConfigurarTurno(false);
                    Task.Delay(1500).ContinueWith(t => this.Invoke((MethodInvoker)FinalizarTurno));
                    return;
                }
            }

            // Control de Estado: Paralizado (50% de probabilidad de no atacar)
            if (habilitar && estadoActualTurno == "Paralizado")
            {
                Random rand = new Random();
                if (rand.Next(0, 2) == 0) // 50% chance
                {
                    MostrarNarrador($"¡{pokemonActivo.Nombre} está paralizado y no puede moverse!");
                    ConfigurarTurno(false);
                    Task.Delay(1500).ContinueWith(t => this.Invoke((MethodInvoker)FinalizarTurno));
                    return;
                }
            }

            // Si no está impedido por estados, habilitar botones normalmente
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

            //Definimos un factor de escala
            double escalaMi = 1.5;
            pnlMiVidaFondo.Width = Math.Max(100, (int)(miPokemon.Hp * escalaMi));
            double miPorcentaje = (double)miPokemon.HpCombate / miPokemon.Hp;
            pnlMiVidaBarra.Width = (int)(miPorcentaje * pnlMiVidaFondo.Width);
            lblHpAnfitrion.Text = $"{miPokemon.HpCombate} / {miPokemon.Hp} HP";

            double escalaRival = 1.5;
            pnlRivalVidaFondo.Width = Math.Max(100, (int)(rivalPokemon.Hp * escalaRival));
            double rivalPorcentaje = (double)rivalPokemon.HpCombate / rivalPokemon.Hp;
            pnlRivalVidaBarra.Width = (int)(rivalPorcentaje * pnlRivalVidaFondo.Width);
            lblHpRival.Text = $"{rivalPokemon.HpCombate} / {rivalPokemon.Hp} HP";


            // Forzar actualización visual inmediata en la interfaz
            pnlMiVidaFondo.Refresh();
            pnlMiVidaBarra.Refresh();
            pnlRivalVidaFondo.Refresh();
            pnlRivalVidaBarra.Refresh();
        }

        private void AplicarEfectoAtaque(int idEfecto, Cartas usuario, Cartas objetivo)
        {

            switch (idEfecto)
            {
                case 1: // Ataque +1
                    if (!modificadoresAtaque.ContainsKey(usuario)) modificadoresAtaque[usuario] = 0;
                    modificadoresAtaque[usuario] += 1;
                    MostrarNarrador($"¡El Ataque de {usuario.Nombre} aumentó!");
                    break;

                case 2: // Ataque +2
                    if (!modificadoresAtaque.ContainsKey(usuario)) modificadoresAtaque[usuario] = 0;
                    modificadoresAtaque[usuario] += 2;
                    MostrarNarrador($"¡El Ataque de {usuario.Nombre} aumentó drásticamente!");
                    break;

                case 3: // Velocidad +2
                    if (!modificadoresVelocidad.ContainsKey(usuario)) modificadoresVelocidad[usuario] = 0;
                    modificadoresVelocidad[usuario] += 2;
                    MostrarNarrador($"¡La Velocidad de {usuario.Nombre} aumentó muchísimo!");
                    break;

                case 4: // Especial +1
                    if (!modificadoresEspecial.ContainsKey(usuario)) modificadoresEspecial[usuario] = 0;
                    modificadoresEspecial[usuario] += 1;
                    MostrarNarrador($"¡El Ataque Especial de {usuario.Nombre} aumentó!");
                    break;

                case 5: // Especial +2
                    if (!modificadoresEspecial.ContainsKey(usuario)) modificadoresEspecial[usuario] = 0;
                    modificadoresEspecial[usuario] += 2;
                    MostrarNarrador($"¡El Ataque Especial de {usuario.Nombre} aumentó drásticamente!");
                    break;

                case 6: // Defensa +1
                    if (!modificadoresDefensa.ContainsKey(usuario)) modificadoresDefensa[usuario] = 0;
                    modificadoresDefensa[usuario] += 1;
                    MostrarNarrador($"¡La Defensa de {usuario.Nombre} aumentó!");
                    break;

                case 7: // Defensa +2
                    if (!modificadoresDefensa.ContainsKey(usuario)) modificadoresDefensa[usuario] = 0;
                    modificadoresDefensa[usuario] += 2;
                    MostrarNarrador($"¡La Defensa de {usuario.Nombre} aumentó drásticamente!");
                    break;

                case 32: // Evasion +1
                         // Si necesitas activarlo en el futuro, puedes declarar: private Dictionary<Cartas, int> modificadoresEvasion = new Dictionary<Cartas, int>();
                    MostrarNarrador($"¡La evasión de {usuario.Nombre} subió!");
                    break;

                case 11: // Precision -1
                         // Si necesitas activarlo en el futuro, puedes declarar: private Dictionary<Cartas, int> modificadoresPrecision = new Dictionary<Cartas, int>();
                    MostrarNarrador($"¡La precisión de {objetivo.Nombre} cayó!");
                    break;

                case 12: // DefensaRival -1
                    if (!modificadoresDefensa.ContainsKey(objetivo)) modificadoresDefensa[objetivo] = 0;
                    modificadoresDefensa[objetivo] -= 1;
                    MostrarNarrador($"¡La Defensa de {objetivo.Nombre} bajó!");
                    break;

                case 13: // DefensaRival -2
                    if (!modificadoresDefensa.ContainsKey(objetivo)) modificadoresDefensa[objetivo] = 0;
                    modificadoresDefensa[objetivo] -= 2;
                    MostrarNarrador($"¡La Defensa de {objetivo.Nombre} cayó drásticamente!");
                    break;

                case 14: // AtaqueRival -1
                    if (!modificadoresAtaque.ContainsKey(objetivo)) modificadoresAtaque[objetivo] = 0;
                    modificadoresAtaque[objetivo] -= 1;
                    MostrarNarrador($"¡El Ataque de {objetivo.Nombre} bajó!");
                    break;

                case 15: // VelocidadRival -1
                    if (!modificadoresVelocidad.ContainsKey(objetivo)) modificadoresVelocidad[objetivo] = 0;
                    modificadoresVelocidad[objetivo] -= 1;
                    MostrarNarrador($"¡La Velocidad de {objetivo.Nombre} bajó!");
                    break;

                case 8: // Curar50
                    int saludACurar50 = (int)(usuario.Hp * 0.5M);
                    usuario.HpCombate = Math.Min(usuario.Hp, usuario.HpCombate + saludACurar50);
                    MostrarNarrador($"¡{usuario.Nombre} restauró el 50% de sus PS!");
                    break;

                case 9: // Descanso
                    usuario.HpCombate = usuario.Hp; // Cura la totalidad de los puntos de salud
                    estadoPokemon[usuario] = "Dormido";
                    turnosDormido[usuario] = 2; // Registramos la duración en el diccionario
                    MostrarNarrador($"¡{usuario.Nombre} recuperó todos sus PS y se durmió para descansar!");
                    break;

                case 16: // Dormir
                    estadoPokemon[objetivo] = "Dormido";
                    turnosDormido[objetivo] = 2; // Inicializamos contador de turnos dormido
                    MostrarNarrador($"¡{objetivo.Nombre} se ha quedado dormido!");
                    break;

                case 17: // Paralizar
                    estadoPokemon[objetivo] = "Paralizado";
                    string nombreEstParalizado = objetivo.Nombre;
                    MostrarNarrador($"¡{nombreEstParalizado} ha sido paralizado!");
                    break;

                case 18: // Envenenar
                    estadoPokemon[objetivo] = "Envenenado";
                    MostrarNarrador($"¡{objetivo.Nombre} ha sido envenenado!");
                    break;

                case 19: // EnvenenamientoGrave
                    estadoPokemon[objetivo] = "EnvenenadoGrave";
                    MostrarNarrador($"¡{objetivo.Nombre} fue envenenado gravemente!");
                    break;

                case 20: // Confundir
                    estadoPokemon[objetivo] = "Confundido";
                    string nombreEstConfundido = objetivo.Nombre;
                    MostrarNarrador($"¡{nombreEstConfundido} empezó a sentirse confundido!");
                    break;

                case 37: // DanoFijo40
                    objetivo.HpCombate = Math.Max(0, objetivo.HpCombate - 40);
                    MostrarNarrador($"¡Causó un daño fijo de 40 PS!");
                    break;

                case 38: // DanoNivel
                    int danioNivel = 50; // Ajustable o configurable según el nivel asignado
                    objetivo.HpCombate = Math.Max(0, objetivo.HpCombate - danioNivel);
                    string msgDanioNivel = $"¡Causó {danioNivel} puntos de daño por su nivel!";
                    MostrarNarrador(msgDanioNivel);
                    break;

                case 39: // MitadPS
                    objetivo.HpCombate = Math.Max(1, (int)(objetivo.HpCombate / 2M));
                    MostrarNarrador($"¡Los PS de {objetivo.Nombre} se redujeron a la mitad!");
                    break;

                case 42: // AutoDebilitacion (Autodestrucción / Mismodestino)
                    usuario.HpCombate = 0;
                    MostrarNarrador($"¡{usuario.Nombre} se sacrificó y se ha debilitado!");
                    break;

                case 10: // Inhabilitar
                    MostrarNarrador($"¡El último movimiento de {objetivo.Nombre} ha sido inhabilitado!");
                    break;

                case 21: // Drenadoras
                    tieneDrenadoras[objetivo] = true; // El diccionario activará el efecto en FinalizarTurno()
                    MostrarNarrador($"¡{objetivo.Nombre} fue infestado por drenadoras!");
                    break;

                case 22: // Critico
                    MostrarNarrador($"¡La probabilidad de golpe crítico de {usuario.Nombre} aumentó!");
                    break;

                case 23: // CambiarTipo
                    MostrarNarrador($"¡{usuario.Nombre} cambió su tipo para igualar al rival!");
                    break;

                case 24: // CopiarMovimiento
                    MostrarNarrador($"¡{usuario.Nombre} copió el último movimiento!");
                    break;

                case 25: // MovimientoAleatorio
                    MostrarNarrador($"¡{usuario.Nombre} está invocando un movimiento al azar!");
                    break;

                case 26: // MovimientoEspejo
                    MostrarNarrador($"¡{usuario.Nombre} usó Movimiento Espejo!");
                    break;

                case 27: // ProteccionEstadisticas
                    MostrarNarrador($"¡El bando de {usuario.Nombre} está protegido contra reducción de estadísticas!");
                    break;

                case 28: // ReiniciarEstadisticas
                         // Si deseas reiniciar los diccionarios de estadísticas del combate:
                    modificadoresAtaque[usuario] = 0;
                    modificadoresDefensa[usuario] = 0;
                    modificadoresVelocidad[usuario] = 0;
                    modificadoresEspecial[usuario] = 0;
                    modificadoresAtaque[objetivo] = 0;
                    modificadoresDefensa[objetivo] = 0;
                    modificadoresVelocidad[objetivo] = 0;
                    modificadoresEspecial[objetivo] = 0;
                    MostrarNarrador($"¡Todas las alteraciones de estadísticas volvieron a la normalidad!");
                    break;

                case 29: // PantallaLuz
                    MostrarNarrador($"¡Pantalla de Luz redujo el daño especial entrante!");
                    break;

                case 30: // Reflejo
                    tieneReflejo[usuario] = true;     // Se registra el estado de Reflejo en el diccionario
                    turnosReflejo[usuario] = 5;       // Duración estándar del efecto protector
                    MostrarNarrador($"¡Reflejo redujo el daño físico entrante de {usuario.Nombre}!");
                    break;

                case 31: // HuidaSalvaje
                    MostrarNarrador($"¡Se intentó forzar el final del combate!");
                    break;

                case 33: // SinEfecto
                         // Caso intencionalmente vacío
                    break;

                case 34: // Sustituto
                    int costoSustituto = (int)(usuario.Hp * 0.25M);
                    usuario.HpCombate = Math.Max(1, usuario.HpCombate - costoSustituto);
                    string msgSustituto = $"¡{usuario.Nombre} creó un sustituto sacrificando PS!";
                    MostrarNarrador(msgSustituto);
                    break;

                case 35: // Transformacion
                    MostrarNarrador($"¡{usuario.Nombre} se transformó en el rival!");
                    break;

                case 36: // KOInstantaneo
                    objetivo.HpCombate = 0;
                    MostrarNarrador($"¡Es un golpe fulminante! ¡KO instantáneo!");
                    break;

                case 40: // Contraataque
                    MostrarNarrador($"¡{usuario.Nombre} está preparando un contraataque!");
                    break;

                case 41: // DanoAleatorioNivel
                    Random rnd = new Random();
                    int multiplicador = rnd.Next(1, 11);
                    objetivo.HpCombate = Math.Max(0, objetivo.HpCombate - multiplicador);
                    MostrarNarrador($"¡Causó daño aleatorio basado en el nivel!");
                    break;

                default:
                    break;
            }
        }
    }
}
