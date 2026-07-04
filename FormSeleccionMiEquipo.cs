using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PokedexApp
{

    public partial class FormSeleccionMiEquipo : Form

    {
        private PokedexManager manager = new PokedexManager();
        public List<Cartas> EquipoSeleccionado { get; private set; }
        private List<Cartas> _equipoTemporal = new List<Cartas>();
        private int idUsuarioAMostrar;
        public FormSeleccionMiEquipo(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioAMostrar = idUsuario;
        }

        private void DGVListMisCartas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void FormSeleccionEquipoCartas_Load(object sender, EventArgs e)
        {
            DGVListMisCartas.DataSource = manager.ObtenerCartasUsuario(this.idUsuarioAMostrar);
            DGVListMisCartas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVListMisCartas.MultiSelect = true;

            DGVListMisCartas.DataSource = manager.ObtenerCartasUsuario(Sesion.IdUsuarioActual);
            DGVListMisCartas.DataSource = manager.ObtenerCartasUsuario(Sesion.IdUsuarioActual);

            DGVListMisCartas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVListMisCartas.MultiSelect = true;
            DGVListMisCartas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MostrarImagenesEnGrid();
        }

        private void MostrarImagenesEnGrid()
        {
            if (DGVListMisCartas.Columns["Imagen"] != null)
                DGVListMisCartas.Columns["Imagen"].Visible = false;

            // 2. Si no existe, agregamos la columna de imagen
            if (!DGVListMisCartas.Columns.Contains("ColumnaFoto"))
            {
                DataGridViewImageColumn colFoto = new DataGridViewImageColumn();
                colFoto.Name = "ColumnaFoto";
                colFoto.HeaderText = "Foto";
                colFoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DGVListMisCartas.Columns.Add(colFoto);
            }


            foreach (DataGridViewRow fila in DGVListMisCartas.Rows)
            {
                if (fila.IsNewRow) continue;


                var idPokemon = fila.Cells["IdPokemon"].Value;

                if (idPokemon != null)
                {

                    string nombreArchivo = idPokemon.ToString() + ".jpeg";
                    string ruta = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo);

                    if (File.Exists(ruta))
                    {
                        fila.Cells["ColumnaFoto"].Value = Image.FromFile(ruta);
                    }
                }
            }
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_equipoTemporal.Count == 3)
            {
                EquipoSeleccionado = _equipoTemporal; // Pasamos nuestra lista validada
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            _equipoTemporal.Clear();
            txtDetalles.Text = "";
            lblContador.Text = "Cartas seleccionadas: 0/3";
            btnConfirmar.Enabled = false;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void DGVListMisCartas_SelectionChanged(object sender, EventArgs e)
        {


            if (DGVListMisCartas.SelectedRows.Count > 0)
            {
                var c = (Cartas)DGVListMisCartas.SelectedRows[0].DataBoundItem;

                // Carga de imagen (manteniendo tu lógica)
                string ruta = Path.Combine(Application.StartupPath, "Imagenes", c.IdPokemon.ToString() + ".jpeg");
                picCarta.Image = File.Exists(ruta) ? Image.FromFile(ruta) : null;

                // Mostrar detalles (solo de la carta seleccionada)
                var detalle = manager.ObtenerDetallesCarta(c.IdPokemon);
                if (detalle != null)
                {
                    // Mantenemos tu formato de detalles
                    txtDetalles.Text = $"Pokémon: {detalle.Nombre}\nTipo: {detalle.Tipo1}\nHP: {detalle.HPCarta}";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (DGVListMisCartas.SelectedRows.Count > 0)
            {
                var carta = (Cartas)DGVListMisCartas.SelectedRows[0].DataBoundItem;

                if (_equipoTemporal.Count < 3 && !_equipoTemporal.Contains(carta))
                {
                    _equipoTemporal.Add(carta);


                    lblContador.Text = $"Cartas seleccionadas: {_equipoTemporal.Count}/3";
                    btnConfirmar.Enabled = (_equipoTemporal.Count == 3);


                    txtDetalles.Text = "Equipo actual:\r\n" + string.Join("\r\n", _equipoTemporal.ConvertAll(c => c.Nombre));
                }

            }

        }
    }
}
 

