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

        public FrmMenu(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
          
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            FormInformacionDeUsuario = new FormInformacionDeUsuario(usuarioActual);
            FormInformacionDeUsuario.ShowDialog();
        }
    }
}
