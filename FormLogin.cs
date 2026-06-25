using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokedexApp
{
    public partial class FormLogin : Form
    {
       
        private PokedexManager manager= new PokedexManager();
        public FormLogin()
        {
            InitializeComponent();
           
            txtContraseña.PasswordChar = '*'; // Oculta la contraseña c
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            
            if (manager.ValidarCredenciales(txtUsuario.Text, txtContraseña.Text))
            {
                MessageBox.Show("Inicio de sesión exitoso, BIENVENIDO A LA POKEDEX");
                this.Hide();
                FrmMenu menu = new FrmMenu();
                  //aqui ocultamos el loging y la de inicio para que no se superponga al menu
                menu.ShowDialog();
                this.Close();            

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.");
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
