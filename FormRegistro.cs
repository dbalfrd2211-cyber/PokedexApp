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
    public partial class FormRegistro : Form
    {
        private PokedexManager manager = new PokedexManager();

        public FormRegistro()
        {
            InitializeComponent();
            btnRegistrar.Enabled = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (manager.ExisteUsuario(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario ya existe, porfavor elige otro");
                return;
            }
            else
            {
                if (txtContraseña.Text == txtConfirmar.Text)
                {


                    if (manager.RegistrarUsuario(txtUsuario.Text, txtContraseña.Text, txtConfirmar.Text))
                    {
                        MessageBox.Show("Usuario registrado correctamnete");

                        this.Hide();
                        using (FrmInicio inicio = new FrmInicio())
                        {
                            inicio.ShowDialog();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar usuario. El nombre puede estar en uso");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = !string.IsNullOrWhiteSpace(txtUsuario.Text) &&
                                   !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                                   !string.IsNullOrWhiteSpace(txtConfirmar.Text);

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {btnRegistrar.Enabled = !string.IsNullOrWhiteSpace(txtUsuario.Text) &&
                                  !string.IsNullOrWhiteSpace(txtContraseña.Text)&&
                                   !string.IsNullOrWhiteSpace(txtConfirmar.Text);
        }

        private void txtConfirmar_TextChanged(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = !string.IsNullOrWhiteSpace(txtUsuario.Text) &&
                                  !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                                   !string.IsNullOrWhiteSpace(txtConfirmar.Text);
        }
    }
}
