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
    public partial class FormSeleccionEquipoCartas : Form
    {
        private PokedexManager manager = new PokedexManager();
        public FormSeleccionEquipoCartas()
        {
            InitializeComponent();
        }

        private void DGVListMisCartas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //borrar


        }

        private void FormSeleccionEquipoCartas_Load(object sender, EventArgs e)
        {
            DGVListMisCartas.DataSource = manager.ObtenerCartasUsuario(Sesion.IdUsuarioActual);

            // 2. Configuración estética igual a ColeccionCartas
            DGVListMisCartas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVListMisCartas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 3. Selección múltiple obligatoria para elegir 3 cartas
            DGVListMisCartas.MultiSelect = true;
            DGVListMisCartas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 4. Mostrar imágenes (Reutilizando la lógica de tu otro formulario)
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
    }
}
