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
    public partial class ColeccionCartas : Form
    {
        private PokedexManager manager = new PokedexManager();

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
            if (string.IsNullOrEmpty(txtBuscarPokemon.Text))
            {
                DGVListadoCartas.DataSource = manager.AllDatoPokemon();

            }
            else
            {
                DGVListadoCartas.DataSource = manager.BuscarCartasPorNombre(txtBuscarPokemon.Text);

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

        }

        private void VincularBotonAlMapa(Button btn)
        {

            int nuevaX = btn.Location.X - picMapa.Location.X;
            int nuevaY = btn.Location.Y - picMapa.Location.Y;

            btn.Location= new Point (nuevaX, nuevaY);
            btn.Parent = picMapa;

        }

        private void btnVolverCC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVListadoCartas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            { if (DGVListadoCartas.Rows[e.RowIndex].DataBoundItem is Cartas c)
                {
                    VistaCartasMaestra detalle = manager.ObtenerDetallesCarta(c.IdPokemon);
                    if (detalle != null)
                    {
                        txtDetallesPokemon.Text =
                         $"[ POKÉMON: #{detalle.Pokedex} - {detalle.Nombre.ToUpper()} ]" + Environment.NewLine +
                        $"Tipo: {detalle.Tipo1} / {detalle.Tipo2} | Región: {detalle.Region}" + Environment.NewLine +
                         $"Altura: {detalle.Altura}m | Peso: {detalle.Peso}kg | HP Base Biológico: {detalle.HPBase}" + Environment.NewLine +
                         $"--------------------------------------------------" + Environment.NewLine +
                        $"[ DATOS DE LA CARTA ]" + Environment.NewLine +
                         $"Puntos de Vida (HP Carta): {detalle.HPCarta} | Rareza: {detalle.Rareza}" + Environment.NewLine +
                          $"--------------------------------------------------" + Environment.NewLine +
                        $"[ ATAQUES Y EFECTOS ]" + Environment.NewLine +
                      $" - {detalle.DetallesAtaques.Replace(" | ", Environment.NewLine + " - ")}";

                        regionActual = detalle.Region;
                        if (mapaAmpliado == false)
                        {
                            ResaltarRegion(regionActual);
                        
                        }

                        btnAñadirAColeccion.Enabled = true;
                    }
                    else
                    {
                        txtDetallesPokemon.Text = "No se encontraron detalles completos";
                    }
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
    }
}
