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
    public partial class FrmMenu : Form
    {
        private Usuario usuarioActual;

        private InfoUsuario infoActual;

        public FrmMenu()
        {
            InitializeComponent();
          
        }

        public FrmMenu(Usuario usuarioActual, InfoUsuario infoActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
            this.infoActual = infoActual;
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            FormInformacionDeUsuario frmInfo = new FormInformacionDeUsuario(usuarioActual,infoActual);
            frmInfo.ShowDialog();
        }

        private void btnMultijugador_Click(object sender, EventArgs e)
        {

        }

        private void btnColeccionCartas_Click(object sender, EventArgs e)
        {
            ColeccionCartas frmColeccion = new ColeccionCartas();
            frmColeccion.ShowDialog();

        }
    }
}
