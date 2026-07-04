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
            List<Cartas> equipo1 = null;
            List<Cartas> equipo2 = null;

            using (FormSeleccionMiEquipo sel1 = new FormSeleccionMiEquipo(Sesion.IdUsuarioActual))
            {
                sel1.Text = "Selecciona tus cartas (Anfitrión)";
                if (sel1.ShowDialog() == DialogResult.OK)
                    equipo1 = sel1.EquipoSeleccionado;
            }

         
            using (FormSeleccionMiEquipo sel2 = new FormSeleccionMiEquipo(usuario2.IdUsuario))
            {
                sel2.Text = "Selecciona tus cartas (Rival)";
                if (sel2.ShowDialog() == DialogResult.OK)
                    equipo2 = sel2.EquipoSeleccionado;
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
