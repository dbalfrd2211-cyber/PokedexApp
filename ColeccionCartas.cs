using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class ColeccionCartas : Form
    {
        private PokedexManager manager = new PokedexManager();

        private bool estaBuscando = false;
        private bool mapaAmpliado = false;
        private Size tamañoOriginalMapa;
        private Point ubicacionOriginalMapa;
        private string regionActual = "";

        public ColeccionCartas()
        {
            InitializeComponent();
            DGVListadoCartas.DataSource = manager.AllDatoPokemon();
        }


        private void btnCrearNuevaCarta_Click(object sender, EventArgs e)
        {
            FormNuevaCarta frm = new FormNuevaCarta();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtBuscarPokemon_TextChanged(sender, e);
            }

        }

        private void btnAñadirAColeccion_Click(object sender, EventArgs e)
        {
            if (DGVListadoCartas.CurrentRow?.DataBoundItem is Cartas c)
            {

                if (manager.AgregarCartaColeccion(c.IdPokemon, c.Hp, c.Rareza, c.NumeroDeColeccion))
                {
                    MessageBox.Show("¡Carta añadida a tu coleccion");
                }
            }
        }

        private void txtBuscarPokemon_TextChanged(object sender, EventArgs e)
        {
            estaBuscando = true;

            // Recargamos el origen de datos
            if (string.IsNullOrEmpty(txtBuscarPokemon.Text))
                DGVListadoCartas.DataSource = manager.AllDatoPokemon();
            else
                DGVListadoCartas.DataSource = manager.BuscarCartasPorNombre(txtBuscarPokemon.Text);

            estaBuscando = false;

            // Solo si hay resultados, seleccionamos el primero y cargamos
            if (DGVListadoCartas.Rows.Count > 0)
            {
                DGVListadoCartas.Rows[0].Selected = true;
                CargarDetallesDeFilaSeleccionada();
            }
        }

        private void CargarDetallesDeFilaSeleccionada()
        {
            if (DGVListadoCartas.SelectedRows.Count > 0)
            {
                var fila = DGVListadoCartas.SelectedRows[0];

                // 2. Extraemos el objeto Cartas directamente de esta fila
                if (fila.DataBoundItem is Cartas c)
                {
                    // 3. Usamos 'c.IdPokemon' que es el valor real de ESTA fila
                    int idPokemonSeleccionado = c.IdPokemon;

                    // Carga de imagen
                    string nombreArchivo = idPokemonSeleccionado.ToString() + ".jpeg";
                    string ruta = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo);

                    if (picCarta.Image != null) { picCarta.Image.Dispose(); picCarta.Image = null; }
                    picCarta.Image = File.Exists(ruta) ? Image.FromFile(ruta) : null;

                    // 4. Carga de detalles usando el ID correcto
                    VistaCartasMaestra detalle = manager.ObtenerDetallesCarta(idPokemonSeleccionado);

                    if (detalle != null)
                    {
                        txtDetallesPokemon.Text = $"[ POKÉMON: #{detalle.Pokedex} - {detalle.Nombre.ToUpper()} ]" + Environment.NewLine +
                                                  $"Tipo: {detalle.Tipo1} / {detalle.Tipo2} | Región: {detalle.Region}" + Environment.NewLine +
                                                  $"HP Base: {detalle.HPBase} | Rareza: {detalle.Rareza}";
                    }
                    else
                    {
                        txtDetallesPokemon.Text = "Detalles no disponibles para este Pokémon.";
                    }
                }
            }
        }



        private void ColeccionCartas_Load(object sender, EventArgs e)
        {

            txtDetallesPokemon.ReadOnly = true;

            DGVListadoCartas.DataSource = manager.AllDatoPokemon();
            DGVListadoCartas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVListadoCartas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DGVListadoCartas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            VincularBotonAlMapa(btnKanto);
            VincularBotonAlMapa(btnJohto);
            VincularBotonAlMapa(btnHoenn);
            VincularBotonAlMapa(btnSinnoh);
            VincularBotonAlMapa(btnUnova);
            VincularBotonAlMapa(btnKalos);
            VincularBotonAlMapa(btnAlola);
            VincularBotonAlMapa(btnGalar);
            VincularBotonAlMapa(btnPaldea);

            tamañoOriginalMapa = picMapa.Size;
            ubicacionOriginalMapa = picMapa.Location;
            ResaltarRegion("");

            btnEliminarCarta.Enabled = false;
        }

        private void VincularBotonAlMapa(Button btn)
        {

            int nuevaX = btn.Location.X - picMapa.Location.X;
            int nuevaY = btn.Location.Y - picMapa.Location.Y;

            btn.Location = new Point(nuevaX, nuevaY);
            btn.Parent = picMapa;

        }

        private void btnVolverCC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVListadoCartas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estaBuscando) return;
            if (DGVListadoCartas.SelectedRows.Count == 0) return;

            // 2. Obtenemos la fila seleccionada de forma segura
            var fila = DGVListadoCartas.SelectedRows[0];

            // 3. Verificamos que el DataBoundItem sea del tipo Cartas
            if (fila.DataBoundItem is Cartas c)
            {
                // 4. Liberar imagen anterior de la memoria (CRUCIAL para no alentar el programa)
                if (picCarta.Image != null)
                {
                    picCarta.Image.Dispose();
                    picCarta.Image = null;
                }

                // 5. Cargar nueva imagen
                string nombreArchivo = c.IdPokemon.ToString() + ".jpeg";
                string ruta = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo);

                if (File.Exists(ruta))
                {
                    picCarta.Image = Image.FromFile(ruta);
                }

                // 6. Obtener detalles del Pokémon
                VistaCartasMaestra detalle = manager.ObtenerDetallesCarta(c.IdPokemon);
                if (detalle != null)
                {
                    txtDetallesPokemon.Text =
                        $"[ POKÉMON: #{detalle.Pokedex} - {detalle.Nombre.ToUpper()} ]" + Environment.NewLine +
                        $"Tipo: {detalle.Tipo1} / {detalle.Tipo2} | Región: {detalle.Region}" + Environment.NewLine +
                        $"Altura: {detalle.Altura}m | Peso: {detalle.Peso}kg | HP Base: {detalle.HPBase}" + Environment.NewLine +
                        $"--------------------------------------------------" + Environment.NewLine +
                        $"[ DATOS DE LA CARTA ]" + Environment.NewLine +
                        $"Puntos de Vida (HP Carta): {detalle.HPCarta} | Rareza: {detalle.Rareza}" + Environment.NewLine +
                        $"--------------------------------------------------" + Environment.NewLine +
                        $"[ ATAQUES Y EFECTOS ]" + Environment.NewLine +
                        $" - {detalle.DetallesAtaques.Replace(" | ", Environment.NewLine + " - ")}";

                    regionActual = detalle.Region;
                    if (!mapaAmpliado) ResaltarRegion(regionActual);

                    btnAñadirAColeccion.Enabled = true;
                    btnEliminarCarta.Enabled = (c.IdPokemon > 151);
                }
            }
        }


        private void txtDetallesPokemon_TextChanged(object sender, EventArgs e)
        {
            //elimnar evento

        }

        private void ResaltarRegion(string region)
        {

            btnKanto.Visible = false;
            btnJohto.Visible = false;
            btnHoenn.Visible = false;
            btnSinnoh.Visible = false;
            btnUnova.Visible = false;
            btnKalos.Visible = false;
            btnAlola.Visible = false;
            btnGalar.Visible = false;
            btnPaldea.Visible = false;
            switch (region.Trim().ToLower())
            {
                case "kanto":
                    btnKanto.Visible = true;
                    btnKanto.BackColor = Color.Gold;
                    break;
                case "johto":
                    btnJohto.Visible = true;
                    btnJohto.BackColor = Color.Gold;
                    break;
                case "hoenn":
                    btnHoenn.Visible = true;
                    btnHoenn.BackColor = Color.Gold;
                    break;
                case "sinnoh":
                    btnSinnoh.Visible = true;
                    btnSinnoh.BackColor = Color.Gold;
                    break;
                case "unova":
                    btnUnova.Visible = true;
                    btnUnova.BackColor = Color.Gold;
                    break;
                case "kalos":
                    btnKalos.Visible = true;
                    btnKalos.BackColor = Color.Gold;
                    break;
                case "alola":
                    btnAlola.Visible = true;
                    btnAlola.BackColor = Color.Gold;
                    break;
                case "galar":
                    btnGalar.Visible = true;
                    btnGalar.BackColor = Color.Gold;
                    break;
                case "paldea":
                    btnPaldea.Visible = true;
                    btnPaldea.BackColor = Color.Gold;
                    break;





            }


        }

        private void btnHoenn_Click(object sender, EventArgs e)
        {
            //eliminar evento
        }

        private void picMapa_Click(object sender, EventArgs e)
        {
            if (mapaAmpliado == false)
            {
                ResaltarRegion("");
                picMapa.BringToFront();
                picMapa.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                picMapa.SizeMode = PictureBoxSizeMode.StretchImage;


                picMapa.Size = new Size(3100, 2150);

                switch (regionActual.Trim().ToLower())
                {
                    case "kanto":
                        // Empujamos a -30 para esconder el borde gris izquierdo
                        // Y en -380 para centrarla perfectamente en vertical
                        picMapa.Location = new Point(-30, -370);
                        break;

                    case "johto":
                        picMapa.Location = new Point(-750, -70);
                        break;

                    case "hoenn":
                        picMapa.Location = new Point(-900, -750);
                        break;

                    case "sinnoh":
                        picMapa.Location = new Point(-1550, -70);
                        break;

                    case "unova":
                    case "teselia":
                        picMapa.Location = new Point(-2150, -300);
                        break;

                    case "kalos":
                        picMapa.Location = new Point(-2100, -750);
                        break;

                    case "alola":
                        picMapa.Location = new Point(-80, -1250);
                        break;

                    case "galar":
                        picMapa.Location = new Point(-1000, -1250);
                        break;

                    case "paldea":
                        picMapa.Location = new Point(-2100, -1250);
                        break;

                    default:
                        picMapa.Location = new Point(-1000, -750);
                        break;
                }
                mapaAmpliado = true;


            }
            else
            {
                picMapa.Size = tamañoOriginalMapa;
                picMapa.Location = ubicacionOriginalMapa;

                ResaltarRegion(regionActual);
                mapaAmpliado = false;
            }
        }

        private void btnEliminarCarta_Click(object sender, EventArgs e)
        {
            if (DGVListadoCartas.CurrentRow?.DataBoundItem is Cartas c)
            {
                var confirmResult = MessageBox.Show("¿Seguro que deseas eliminar esta carta?",
                                     "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    if (c.IdPokemon > 151)
                    {
                        if (manager.EliminarCarta(c.IdPokemon))
                        {
                            MessageBox.Show("Carta eliminada de tu colección");
                            txtBuscarPokemon_TextChanged(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Error: No puedes eliminar cartas originales del sistema.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("No puedes eliminar cartas de Pokémon originales del sistema.");


                        //if (manager.EliminarCarta(c.IdCarta))
                        //{
                        //    MessageBox.Show("Carta eliminada de tu colección");
                        //    txtBuscarPokemon_TextChanged(sender, e);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Error: No puedes eliminar cartas originales del sistema.");
                        //}
                    }
                }
            }
        }

        private void picCarta_Click(object sender, EventArgs e)
        {
            if (picCarta.Image != null)
            {
                FormVisorCarta visor = new FormVisorCarta(picCarta.Image);
                visor.ShowDialog();
            }

        }
    }
}
