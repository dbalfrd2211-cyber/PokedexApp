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
        public FormSeleccionMiEquipo()
        {
            InitializeComponent();

        }

        private void DGVListMisCartas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seleccionadas = DGVListMisCartas.SelectedRows.Count;
            lblContador.Text = $"Cartas seleccionadas: {seleccionadas}/3";
            btnConfirmar.Enabled = (seleccionadas == 3);

            if (seleccionadas > 0)
            {

                var c = (Cartas)DGVListMisCartas.SelectedRows[0].DataBoundItem;
                string ruta = Path.Combine(Application.StartupPath, "Imagenes", c.IdPokemon.ToString() + ".jpeg");
                if (File.Exists(ruta))
                {
                    picCarta.Image = Image.FromFile(ruta);
                }
                else
                {
                    picCarta.Image = null;
                }


                var detalle = manager.ObtenerDetallesCarta(c.IdPokemon);
                if (detalle != null)
                {
                    txtDetalles.Text = $"Pokémon: {detalle.Nombre}\nTipo: {detalle.Tipo1}\nHP: {detalle.HPCarta}";
                }
            }
        }

        private void FormSeleccionEquipoCartas_Load(object sender, EventArgs e)
        {
            DGVListMisCartas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

     
            foreach (DataGridViewColumn col in DGVListMisCartas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

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
            if (DGVListMisCartas.SelectedRows.Count == 3)
            {
                EquipoSeleccionado = new List<Cartas>();
                foreach (DataGridViewRow fila in DGVListMisCartas.SelectedRows)
                {
                    EquipoSeleccionado.Add((Cartas)fila.DataBoundItem);
                }

                // Indicamos que todo salió bien y cerramos
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            DGVListMisCartas.ClearSelection();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
