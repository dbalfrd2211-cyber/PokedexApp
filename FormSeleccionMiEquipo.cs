using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DGVListMisCartas.SelectionChanged += DGVListMisCartas_SelectionChanged;
        }

        private void DGVListMisCartas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //borrar


        }

        private void FormSeleccionEquipoCartas_Load(object sender, EventArgs e)
        {
            DGVListMisCartas.DataSource = manager.ObtenerCartasUsuario(Sesion.IdUsuarioActual);
            DGVListMisCartas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVListMisCartas.MultiSelect = true; // Permite elegir varias
            DGVListMisCartas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MostrarImagenesEnGrid();
        }

        private void MostrarImagenesEnGrid()
        {
            // Aseguramos que la columna de imagen exista y la configuramos
            if (DGVListMisCartas.Columns["Imagen"] != null)
            {
                DGVListMisCartas.Columns["Imagen"].Visible = false;
            }

            // Agregar columna de imagen si no existe
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
                string nombreArchivo = fila.Cells["Imagen"].Value?.ToString();
                if (!string.IsNullOrEmpty(nombreArchivo))
                {
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

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
