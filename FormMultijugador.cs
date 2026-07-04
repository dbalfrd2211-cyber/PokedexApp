using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class FormMultijugador : Form
    {
        private PokedexManager manager = new PokedexManager();
        public Usuario usuarioLogueado;
        private Usuario usuario2 = null;

        public FormMultijugador(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;
        }

        private void btnCombate_Click(object sender, EventArgs e)
        {
            PokedexManager manager = new PokedexManager();

            // 1. Obtenemos los detalles
            VistaCartasMaestra miPokemonInfo = manager.ObtenerDetallesCarta(1);
            VistaCartasMaestra rivalPokemonInfo = manager.ObtenerDetallesCarta(25);

            if (miPokemonInfo != null && rivalPokemonInfo != null)
            {
                // 2. Convertimos los objetos 'VistaCartasMaestra' a 'Cartas'
                // Esto es necesario porque FormBatalla requiere List<Cartas>
                Cartas miCarta = new Cartas(0, miPokemonInfo.IdPokemon, miPokemonInfo.HPCarta, miPokemonInfo.Rareza,
                                            miPokemonInfo.NumeroColeccion, miPokemonInfo.Nombre, "", "");

                Cartas rivalCarta = new Cartas(0, rivalPokemonInfo.IdPokemon, rivalPokemonInfo.HPCarta, rivalPokemonInfo.Rareza,
                                               rivalPokemonInfo.NumeroColeccion, rivalPokemonInfo.Nombre, "", "");

                // 3. Creamos las listas que espera el constructor de FormBatalla
                List<Cartas> miEquipo = new List<Cartas> { miCarta };
                List<Cartas> equipoRival = new List<Cartas> { rivalCarta };

                // 4. Abrimos la batalla enviando las LISTAS
                FormBatalla arena = new FormBatalla(miEquipo, equipoRival);
                this.Hide();
                arena.ShowDialog();
                this.Show();
            }
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIntercambio_Click(object sender, EventArgs e)
        {
            if (usuario2 == null)
            {
                MessageBox.Show("Por favor, selecciona y autentica al Segundo Usuario antes de proceder al intercambio.", "Usuario Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IntercambioCartas ventanaIntercambio = new IntercambioCartas(usuarioLogueado, usuario2);
            this.Hide();

            ventanaIntercambio.ShowDialog();
            this.Show();
        }

        private void cmbUsuario2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuario2.SelectedItem == null || cmbUsuario2.SelectedIndex == -1) return;

            string nombreSelected = cmbUsuario2.SelectedItem.ToString();

            using (AutenticadorUsuario2 frmAuth = new AutenticadorUsuario2(nombreSelected))
            {
                if (frmAuth.ShowDialog() == DialogResult.OK)
                {
                    usuario2 = manager.ObtenerUsuario(nombreSelected);
                    MessageBox.Show($"¡Autenticación exitosa!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("No se pudo autenticar al usuario.", "Error de Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbUsuario2.SelectedIndex = -1;
                    usuario2 = null;
                }
            }
        }

        private void FormMultijugador_Load(object sender, EventArgs e)
        {
            lblUsuarioLogueado.Text = $"Anfitrión: {Sesion.NombreUsuarioActual}";

            ListaComboUsuario2();

        }

        private void ListaComboUsuario2()
        {
            using (var conn = new System.Data.SQLite.SQLiteConnection(new Database().cadenaConexion))
            {
                conn.Open();
                string query = "SELECT NombreUsuario FROM Usuarios WHERE IdUsuario != @idActual";
                using (var cmd = new System.Data.SQLite.SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idActual", Sesion.IdUsuarioActual);
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbUsuario2.Items.Clear();
                        while (reader.Read())
                        {
                            cmbUsuario2.Items.Add(reader["NombreUsuario"].ToString());
                        }
                    }
                }
            }
        }
    }
}
