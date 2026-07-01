using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Usuario usuario2= null;
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
    }
}
