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
    public partial class AutenticadorUsuario2 : Form
    {
        private string nombreUsuario;
        private PokedexManager manager = new PokedexManager();
        public AutenticadorUsuario2(string nombreSelected)
        {
            InitializeComponent();
            this.nombreUsuario = nombreSelected;
        }

        private void AutenticadorUsuario2_Load(object sender, EventArgs e)
        {
            lblUsuarioAutenticador.Text = $"Usuario: {nombreUsuario}";
        }

        private void btnAceptarAuntenticar_Click(object sender, EventArgs e)
        {
            string passwordInput = txtContrasena.Text.Trim();
            if (string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Por favor, introduce la contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return;
            }

            if (manager.ValidarCredenciales(nombreUsuario, passwordInput))
            {
                // Si la contraseña coincide, devolvemos OK y cerramos de inmediato
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Inténtelo de nuevo.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }

        private void btnCancelarAuntenticar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
