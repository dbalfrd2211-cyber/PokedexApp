using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class FormLogin : Form
    {
        private PokedexManager manager = new PokedexManager();

        public FormLogin()
        {
            InitializeComponent();
            txtContraseña.PasswordChar = '*';
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

            Func<bool> sonCamposInvalidos = () =>
                string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text);

            if (sonCamposInvalidos())
            {
                MessageBox.Show("Por favor, ingresa usuario y tu contraseña.");
                return;
            }

            try
            {
                if (manager.ValidarCredenciales(txtUsuario.Text, txtContraseña.Text))
                {
                    Usuario usuarioActual = manager.ObtenerUsuario(txtUsuario.Text);


                    if (usuarioActual != null)
                    {
                        InfoUsuario infoActual = manager.ObtenerInfoUsuario(usuarioActual.IdUsuario);


                        Sesion.Iniciar(usuarioActual.IdUsuario, usuarioActual.NombreUsuario);

                        MessageBox.Show("Inicio de sesión exitoso, BIENVENIDO A LA POKEDEX");

                        this.Hide();

                        using (FrmMenu menu = new FrmMenu(usuarioActual, infoActual))
                        {
                            menu.ShowDialog();
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo cargar la información del usuario.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al conectar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}