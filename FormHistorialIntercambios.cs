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
    public partial class FormHistorialIntercambios : Form
    {
        private Usuario usuarioLogueado;

        public FormHistorialIntercambios(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;
            this.Load += new System.EventHandler(this.FormHistorialIntercambios_Load);
        }

        private void FormHistorialIntercambios_Load(object sender, EventArgs e)
        {
            CargarHistorial(DTPHistorial.Value);
        }

        private void CargarHistorial(DateTime fechaFiltro)
        {
            DataTable dtHistorial = new DataTable();

            using (var conn = new System.Data.SQLite.SQLiteConnection(new Database().cadenaConexion))
            {
                conn.Open();

                string query = @"
            SELECT 
                T.Fecha,
                U1.NombreUsuario AS Emisor,
                U2.NombreUsuario AS Receptor,
                T.IdPokemonEntregado1,
                T.IdPokemonEntregado2
            FROM Transacciones T
            JOIN Usuarios U1 ON T.IdUsuarioEmisor = U1.IdUsuario
            JOIN Usuarios U2 ON T.IdUsuarioReceptor = U2.IdUsuario
            WHERE (T.IdUsuarioEmisor = @id OR T.IdUsuarioReceptor = @id)
              AND DATE(T.Fecha) = DATE(@fecha)
            ORDER BY T.Fecha DESC";

                using (var cmd = new System.Data.SQLite.SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioLogueado.IdUsuario);
                    cmd.Parameters.AddWithValue("@fecha", fechaFiltro.ToString("yyyy-MM-dd"));

                    using (var da = new System.Data.SQLite.SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dtHistorial);
                    }
                }
            }

            DGVHistorial.DataSource = dtHistorial;
            ConfigurarYMostrarImagenesDosColumnas();
        }

        private void ConfigurarYMostrarImagenesDosColumnas()
        {
            DGVHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (DGVHistorial.Columns["IdPokemonEntregado1"] != null) DGVHistorial.Columns["IdPokemonEntregado1"].Visible = false;
            if (DGVHistorial.Columns["IdPokemonEntregado2"] != null) DGVHistorial.Columns["IdPokemonEntregado2"].Visible = false;

            if (DGVHistorial.Columns["ColumnaFoto1"] == null)
            {
                DataGridViewImageColumn col1 = new DataGridViewImageColumn();
                col1.Name = "ColumnaFoto1";
                col1.HeaderText = "Carta Emisor";
                col1.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DGVHistorial.Columns.Add(col1);
            }

            if (DGVHistorial.Columns["ColumnaFoto2"] == null)
            {
                DataGridViewImageColumn col2 = new DataGridViewImageColumn();
                col2.Name = "ColumnaFoto2";
                col2.HeaderText = "Carta Receptor";
                col2.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DGVHistorial.Columns.Add(col2);
            }

            foreach (DataGridViewRow fila in DGVHistorial.Rows)
            {
                if (fila.IsNewRow) continue;

                AsignarCeldaImagen(fila, "IdPokemonEntregado1", "ColumnaFoto1");
                AsignarCeldaImagen(fila, "IdPokemonEntregado2", "ColumnaFoto2");
            }
        }

        private void AsignarCeldaImagen(DataGridViewRow fila, string colIdNombre, string colFotoNombre)
        {
            if (fila.Cells[colIdNombre].Value != DBNull.Value && fila.Cells[colIdNombre].Value != null)
            {
                string id = fila.Cells[colIdNombre].Value.ToString();
                string ruta = Path.Combine(Application.StartupPath, "Imagenes", id + ".jpeg");

                if (!File.Exists(ruta))
                {
                    ruta = Path.Combine(Application.StartupPath, "Imagenes", "default.jpeg");
                }

                if (File.Exists(ruta))
                {
                    using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                    {
                        fila.Cells[colFotoNombre].Value = Image.FromStream(fs);
                    }
                }
            }
        }

        private void DTPHistorial_ValueChanged(object sender, EventArgs e)
        {
            CargarHistorial(DTPHistorial.Value);
        }
    }
}
