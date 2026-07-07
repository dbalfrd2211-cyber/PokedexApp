using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PokedexApp
{

    public partial class FormSeleccionMiEquipo : Form

    {
        private PokedexManager manager = new PokedexManager();
        public List<CartaBatalla> EquipoSeleccionado { get; private set; }
        private List<CartaBatalla> _equipoTemporal = new List<CartaBatalla>();
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

            //DGVListMisCartas.DataSource = manager.ObtenerCartasUsuario(Sesion.IdUsuarioActual);
            //DGVListMisCartas.DataSource = manager.ObtenerCartasUsuario(Sesion.IdUsuarioActual);

            DGVListMisCartas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVListMisCartas.MultiSelect = true;
            DGVListMisCartas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MostrarImagenesEnGrid();
        }

        private void MostrarImagenesEnGrid()
        {
            if (DGVListMisCartas.Columns["Imagen"] != null)
                DGVListMisCartas.Columns["Imagen"].Visible = false;

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

                EquipoSeleccionado = _equipoTemporal;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes seleccionar exactamente 3 cartas para poder iniciar la batalla.", "Equipo Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                string ruta = Path.Combine(Application.StartupPath, "Imagenes", c.IdPokemon.ToString() + ".jpeg");
                picCarta.Image = File.Exists(ruta) ? Image.FromFile(ruta) : null;

                var detalle = manager.ObtenerDetallesCarta(c.IdPokemon);
                if (detalle != null)
                {

                    string textoAmostrar = $"Pokémon: {detalle.Nombre}\r\nTipo: {detalle.Tipo1}\r\nHP: {detalle.HPCarta}";

                    var listaAtaques = manager.ObtenerAtaquesDePokemon(c.IdPokemon);

                    if (listaAtaques != null && listaAtaques.Count > 0)
                    {
                        textoAmostrar += "\r\n\r\nAtaques:";
                        foreach (var atq in listaAtaques)
                        {
                            textoAmostrar += $"\r\n- {atq.Nombre}";
                        }
                    }
                    else
                    {
                        textoAmostrar += "\r\n\r\nAtaques: (No se encontraron ataques en la base de datos)";
                    }

                    txtDetalles.Text = textoAmostrar;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (DGVListMisCartas.SelectedRows.Count > 0)
            {
                var cartaBase = (Cartas)DGVListMisCartas.SelectedRows[0].DataBoundItem;

                cartaBase.Ataques = manager.ObtenerAtaquesDePokemon(cartaBase.IdPokemon);

                CartaBatalla cartaBatalla = new CartaBatalla(cartaBase);

                bool yaExiste = _equipoTemporal.Any(c => c.IdPokemon == cartaBatalla.IdPokemon);

                if (_equipoTemporal.Count < 3 && !yaExiste)
                {
                    _equipoTemporal.Add(cartaBatalla);

                    lblContador.Text = $"Cartas seleccionadas: {_equipoTemporal.Count}/3";
                    btnConfirmar.Enabled = (_equipoTemporal.Count == 3);

                }
            }
        }
    }
}
 

