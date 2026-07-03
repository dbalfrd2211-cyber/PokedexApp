using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PokedexApp
{
    public partial class FormInformacionDeUsuario : Form
    {
        private Usuario usuario;

        private InfoUsuario info;
        public FormInformacionDeUsuario()
        {
            InitializeComponent();
        }

        public FormInformacionDeUsuario(Usuario usuario, InfoUsuario info)
        {
            this.usuario = usuario;
            this.info = info;
            this.Load += FormInformacionDeUsuario_Load;
        }

        public void  FormInformacionDeUsuario_Load(object sender, EventArgs e)
        {

            InitializeComponent();
            lblNombre.Text = usuario.NombreUsuario;
            lblNivel.Text = $"Nivel: {info.Nivel}";
                lblGanadas.Text = $"Partidas Ganadas: {info.BatallasGanadas}";
            lblPerdidas.Text = $"Partidas Perdidas: {info.BatallasPerdidas}";
            


            PokedexManager manager = new PokedexManager();
            DGVCartasUsuario.DataSource = manager.ObtenerCartasUsuario(usuario.IdUsuario);
            var cartasUsuario = manager.ObtenerCartasUsuario(usuario.IdUsuario);
            lblCartas.Text = $"Cartas Obtenidas: {cartasUsuario.Count}";


            DGVCartasUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVCartasUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            MostrarImagenesEnGrid();
        }

        private void MostrarImagenesEnGrid()
        {
            if (DGVCartasUsuario.Columns["imagen"] != null)
            {
                DGVCartasUsuario.Columns["imagen"].Visible = false;
            }

            DataGridViewImageColumn colFoto = new DataGridViewImageColumn();
            colFoto.Name = "ColumnaFoto";
            colFoto.HeaderText = "Foto";
            colFoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DGVCartasUsuario.Columns.Add(colFoto);

            foreach (DataGridViewRow fila in DGVCartasUsuario.Rows)
            {
                if (fila.IsNewRow)continue;
                
                string nombreArchivo = fila.Cells["imagen"].Value?.ToString();

                if(!string.IsNullOrEmpty(nombreArchivo))
                {
                    string ruta = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo + ".jpeg");
                    if (File.Exists(ruta))
                    {
                       
                        fila.Cells["ColumnaFoto"].Value = Image.FromFile(ruta);
                    }
                }
            }


        }





        
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
