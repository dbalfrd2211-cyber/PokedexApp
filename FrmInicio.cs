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
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            FormLogin login=new FormLogin();
            login.ShowDialog();    
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FormRegistro registro = new FormRegistro();
            registro.ShowDialog();
        }
    }
}
