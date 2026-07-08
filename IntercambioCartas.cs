using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace PokedexApp
{
    public partial class IntercambioCartas : Form
    {
        private PokedexManager manager = new PokedexManager();
        public Usuario usuarioLogueado;

        private BindingList<Cartas> cartasinteru1 = new BindingList<Cartas>();
        private BindingList<Cartas> cartasinteru2 = new BindingList<Cartas>();
        // lista de cartas temporales para mostrar en el datagridview de cartas por intercambiar

        private Usuario usuario2 = null;
        public IntercambioCartas(Usuario usuarioLogueado, Usuario usuario2)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            this.usuario2 = usuario2;
            this.FormClosing += IntercambioCartas_FormClosing;
        }

        private void IntercambioCartas_Load(object sender, EventArgs e)
        {
            txtUserInter1.Text = $"Anfitrión: {Sesion.NombreUsuarioActual}";
            ActualizarTodoElContenido();
        }

        private void ActualizarTodoElContenido()
        {
            DGVAgregarU1.DataSource = manager.ObtenerCartasUsuario(usuarioLogueado.IdUsuario);
            if (usuario2 != null)
            {
                lblUsuario2.Text = $"Usuario 2: {usuario2.NombreUsuario}";
                DGVAgregarU2.DataSource = manager.ObtenerCartasUsuario(usuario2.IdUsuario);
            }

            DGVIntercambiarU1.DataSource = cartasinteru1;
            DGVIntercambiarU2.DataSource = cartasinteru2;

            ConfigurarYMostrarImagenes(DGVAgregarU1);
            ConfigurarYMostrarImagenes(DGVIntercambiarU1);
            if (usuario2 != null)
            {
                ConfigurarYMostrarImagenes(DGVAgregarU2);
                ConfigurarYMostrarImagenes(DGVIntercambiarU2);
            }
        }

        private void ConfigurarYMostrarImagenes(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dgv.Columns["Imagen"] != null)
            {
                dgv.Columns["Imagen"].Visible = false;
            }

            if (dgv.Columns["ColumnaFoto"] == null)
            {
                DataGridViewImageColumn colFoto = new DataGridViewImageColumn();
                colFoto.Name = "ColumnaFoto";
                colFoto.HeaderText = "Carta";
                colFoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgv.Columns.Add(colFoto);
            }

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (fila.IsNewRow) continue;
                if (fila.DataBoundItem is Cartas c)
                {
                    string nombreArchivo = c.IdPokemon.ToString() + ".jpeg";
                    string ruta = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo);

                    if (File.Exists(ruta))
                    {
                        fila.Cells["ColumnaFoto"].Value = Image.FromFile(ruta);
                    }
                    else
                    {
                        string rutaDefault = Path.Combine(Application.StartupPath, "Imagenes", "default.jpeg");
                        if (File.Exists(rutaDefault))
                            fila.Cells["ColumnaFoto"].Value = Image.FromFile(rutaDefault);
                    }
                }
            }
        }

        private void ActualizarDataGridsIntercambio()
        {
            cartasinteru1.ResetBindings();
            cartasinteru2.ResetBindings();

            ConfigurarYMostrarImagenes(DGVIntercambiarU1);
            ConfigurarYMostrarImagenes(DGVIntercambiarU2);
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

                    ActualizarTodoElContenido();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar el intercambio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void IntercambioCartas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Action<DataGridView> liberarGrid = (dgv) => {
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (dgv.Columns["ColumnaFoto"] != null && fila.Cells["ColumnaFoto"].Value is Image img)
                    {
                        img.Dispose();
                    }
                }
            };

            liberarGrid(DGVAgregarU1);
            liberarGrid(DGVIntercambiarU1);
            liberarGrid(DGVAgregarU2);
            liberarGrid(DGVIntercambiarU2);
        }
    }
}
