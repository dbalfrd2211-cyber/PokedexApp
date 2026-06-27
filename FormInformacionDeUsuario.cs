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
            lblCartas.Text = $"Cartas Obtenidas: {info.NumeroCartas}";

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
