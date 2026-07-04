using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class IntercambioCartas : Form
    {
        private PokedexManager manager = new PokedexManager();
        private Usuario usuarioLogueado;

        private BindingList<Cartas> cartasinteru1 = new BindingList<Cartas>();
        private BindingList<Cartas> cartasinteru2 = new BindingList<Cartas>();
        // lista de cartas temporales para mostrar en el datagridview de cartas por intercambiar

        private Usuario usuario2 = null;
        public IntercambioCartas(Usuario usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
        }

        private void IntercambioCartas_Load(object sender, EventArgs e)
        {
            txtUserInter1.Text = $"Usuario 1: {Sesion.NombreUsuarioActual}";
            DGVAgregarU1.DataSource = manager.ObtenerCartasUsuario(usuarioLogueado.IdUsuario);

            ListaComboUsuario2();

            DGVIntercambiarU1.DataSource = cartasinteru1;
            DGVIntercambiarU2.DataSource = cartasinteru2;
        }

        private void ActualizarDataGridsIntercambio()
        {
            DGVIntercambiarU1.ResetBindings();
            DGVIntercambiarU2.ResetBindings();
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
                        cmbUsuarios2.Items.Clear();
                        while (reader.Read())
                        {
                            cmbUsuarios2.Items.Add(reader["NombreUsuario"].ToString());
                        }
                    }
                }
            }
        }

        private void btnAgregarU1_Click(object sender, EventArgs e)
        {
            if (DGVAgregarU1.CurrentRow != null && DGVAgregarU1.CurrentRow.Index >= 0)
            {
                Cartas cartaSeleccionada = (Cartas)DGVAgregarU1.CurrentRow.DataBoundItem;

                if (cartaSeleccionada != null && !cartasinteru1.Contains(cartaSeleccionada))
                {
                    cartasinteru1.Add(cartaSeleccionada);
                    ActualizarDataGridsIntercambio();

                }
            }
        }
        private void btnAgregarU2_Click(object sender, EventArgs e)
        {
            if (DGVAgregarU2.CurrentRow != null && DGVAgregarU2.CurrentRow.Index >= 0)
            {
                Cartas cartaSeleccionada = (Cartas)DGVAgregarU2.CurrentRow.DataBoundItem;

                if (cartaSeleccionada != null && !cartasinteru2.Contains(cartaSeleccionada))
                {
                    cartasinteru2.Add(cartaSeleccionada);
                    ActualizarDataGridsIntercambio();

                }
            }
        }

        private void btnRetirarU1_Click(object sender, EventArgs e)
        {
            if (DGVIntercambiarU1.CurrentRow != null && DGVIntercambiarU1.CurrentRow.Index >= 0)
            {
                Cartas cartaSeleccionada = (Cartas)DGVIntercambiarU1.CurrentRow.DataBoundItem;

                if (cartaSeleccionada != null)
                {
                    cartasinteru1.Remove(cartaSeleccionada);
                    ActualizarDataGridsIntercambio();
                }
            }
        }
        private void btnRetirarU2_Click(object sender, EventArgs e)
        {
            if (DGVIntercambiarU2.CurrentRow != null && DGVIntercambiarU2.CurrentRow.Index >= 0)
            {
                Cartas cartaSeleccionada = (Cartas)DGVIntercambiarU2.CurrentRow.DataBoundItem;

                if (cartaSeleccionada != null)
                {
                    cartasinteru2.Remove(cartaSeleccionada);
                    ActualizarDataGridsIntercambio();
                }
            }
        }

        private void cmbUsuarios2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuarios2.SelectedItem == null || cmbUsuarios2.SelectedIndex == -1) return;

            string nombreSelected = cmbUsuarios2.SelectedItem.ToString();

            using (AutenticadorUsuario2 frmAuth = new AutenticadorUsuario2(nombreSelected))
            {
                if (frmAuth.ShowDialog() == DialogResult.OK)
                {
                    usuario2 = manager.ObtenerUsuario(nombreSelected);
                    MessageBox.Show($"¡Autenticación exitosa!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DGVAgregarU2.DataSource = manager.ObtenerCartasUsuario(usuario2.IdUsuario);

                    cartasinteru2.Clear();
                    ActualizarDataGridsIntercambio();

                }
                else
                {

                    MessageBox.Show("No se pudo autenticar al usuario.", "Error de Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbUsuarios2.SelectedIndex = -1;
                    DGVAgregarU2.DataSource = null;
                    usuario2 = null;
                    cartasinteru2.Clear();
                    ActualizarDataGridsIntercambio();
                }
            }
        }

        private void btnRealizarIntercambio_Click(object sender, EventArgs e)
        {
            if (usuario2 == null)
            {
                MessageBox.Show("No tienes ningun usuario seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cartasinteru1.Count == 0 && cartasinteru2.Count == 0)
            {
                MessageBox.Show("No hay cartas seleccionadas para el intercambio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("¿Confirmar el intercambio de cartas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    RealizarIntercambioDeCartas();
                    MessageBox.Show("¡Intercambio realizado con éxito!", "¡Enhorabuena!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cartasinteru1.Clear();
                    cartasinteru2.Clear();

                    DGVAgregarU1.DataSource = manager.ObtenerCartasUsuario(usuarioLogueado.IdUsuario);
                    DGVAgregarU2.DataSource = manager.ObtenerCartasUsuario(usuario2.IdUsuario);

                    ActualizarDataGridsIntercambio();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar el intercambio" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void RealizarIntercambioDeCartas()
        {
            using (var conn = new System.Data.SQLite.SQLiteConnection(new Database().cadenaConexion))
            {
                conn.Open();
                using (var transaccion = conn.BeginTransaction())
                {
                    try
                    {
                        // para usuario 1
                        foreach (var carta in cartasinteru1)
                        {

                            string deleteQuery = "DELETE FROM ColeccionUsuario WHERE IdUsuario = @u1 AND IdPokemon = @idp";
                            using (var cmd = new System.Data.SQLite.SQLiteCommand(deleteQuery, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@u1", usuarioLogueado.IdUsuario);
                                cmd.Parameters.AddWithValue("@idp", carta.IdPokemon);
                                cmd.ExecuteNonQuery();
                            }

                            string insertQuery = "INSERT INTO ColeccionUsuario (IdUsuario, IdPokemon) VALUES (@u2, @idp)";
                            using (var cmd = new System.Data.SQLite.SQLiteCommand(insertQuery, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@u2", usuario2.IdUsuario);
                                cmd.Parameters.AddWithValue("@idp", carta.IdPokemon);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // para usuario 2
                        foreach (var carta in cartasinteru2)
                        {

                            string deleteQuery = "DELETE FROM ColeccionUsuario WHERE IdUsuario = @u2 AND IdPokemon = @idp";
                            using (var cmd = new System.Data.SQLite.SQLiteCommand(deleteQuery, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@u2", usuario2.IdUsuario);
                                cmd.Parameters.AddWithValue("@idp", carta.IdPokemon);
                                cmd.ExecuteNonQuery();
                            }

                            string insertQuery = "INSERT INTO ColeccionUsuario (IdUsuario, IdPokemon) VALUES (@u1, @idp)";
                            using (var cmd = new System.Data.SQLite.SQLiteCommand(insertQuery, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@u1", usuarioLogueado.IdUsuario);
                                cmd.Parameters.AddWithValue("@idp", carta.IdPokemon);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                    }

                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        private void btnRegresarVM_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
