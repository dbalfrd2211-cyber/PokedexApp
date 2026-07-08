using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using static System.Net.WebRequestMethods;

namespace PokedexApp
{
    public partial class FormInformacionDeUsuario : Form
    {
        private PokedexManager pokedexManager = new PokedexManager();
        private Usuario usuario;
        private InfoUsuario info;

        public FormInformacionDeUsuario(Usuario usuario, InfoUsuario info)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.info = info;
            this.Load += FormInformacionDeUsuario_Load;
        }

        public void FormInformacionDeUsuario_Load(object sender, EventArgs e)
        {
            ActualizarDatoPartidas();
            
        }

        private void ActualizarDatoPartidas()
        {
            if (usuario == null) return;

            InfoUsuario infoActualizada = pokedexManager.ObtenerInfoUsuario(usuario.IdUsuario);

            if (infoActualizada == null)
            {
                infoActualizada = this.info;
            }

            if (infoActualizada != null)
            {
                lblNombre.Text = usuario.NombreUsuario;
                lblNivel.Text = $"{infoActualizada.Nivel}";
                lblGanadas.Text = $"{infoActualizada.BatallasGanadas}";
                lblPerdidas.Text = $"{infoActualizada.BatallasPerdidas}";
            }

            var cartasUsuario = pokedexManager.ObtenerCartasUsuario(usuario.IdUsuario);
            DGVCartasUsuario.DataSource = cartasUsuario;
            lblCartas.Text = $"Cartas Obtenidas: {cartasUsuario.Count}";

            DGVCartasUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVCartasUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            MostrarImagenesEnGrid();
        }

        private void MostrarImagenesEnGrid()
        {
            if (DGVCartasUsuario.Columns["Imagen"] != null)
            {
                DGVCartasUsuario.Columns["Imagen"].Visible = false;
            }

            if (DGVCartasUsuario.Columns["ColumnaFoto"] == null)
            {
                DataGridViewImageColumn colFoto = new DataGridViewImageColumn();
                colFoto.Name = "ColumnaFoto";
                colFoto.HeaderText = "Carta";
                colFoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DGVCartasUsuario.Columns.Add(colFoto);
            }

            foreach (DataGridViewRow fila in DGVCartasUsuario.Rows)
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

        /*//foreach (DataGridViewRow fila in DGVCartasUsuario.Rows)
        //{
        //    if (fila.IsNewRow) continue;
        //
        //    var valor = fila.Cells["Imagen"].Value;
        //    if (valor != null)
        //    {
        //        string nombreArchivo = valor.ToString();
        //        string ruta = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo);
        //
        //
        //        if (!File.Exists(ruta)) ruta += ".jpeg";
        //
        //        if (File.Exists(ruta))
        //        {
        //            fila.Cells["ColumnaFoto"].Value = Image.FromFile(ruta);
        //        }
        //    }
        //}
        */
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInformacionDeUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (DataGridViewRow fila in DGVCartasUsuario.Rows)
            {
                if (fila.Cells["ColumnaFoto"].Value is Image img)
                {
                    img.Dispose();
                }
            } 
        }

        private void btnEliminarCartaUsuario_Click(object sender, EventArgs e)
        {
            if (DGVCartasUsuario.CurrentRow?.DataBoundItem is Cartas c)
            {
                var confirmResult = MessageBox.Show($"¿Está seguro de que desea eliminar la carta {c.IdCarta} del usuario {usuario.NombreUsuario}?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    PokedexManager manager = new PokedexManager();
                    if (manager.EliminarCartaUsuario(usuario.IdUsuario, c.IdPokemon))
                    {
                        MessageBox.Show("Carta eliminada correctamente.");

                        // Refrescamos todo automáticamente usando nuestra función centralizada
                        ActualizarDatoPartidas();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la carta.");
                    }
                }
            }
        }
    }
}
