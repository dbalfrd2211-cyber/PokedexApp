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
    public partial class FormVisorCarta : Form
    {
        public FormVisorCarta(Image imagen)
        {
            InitializeComponent();

            picZoomCarta.Image = imagen;

            this.StartPosition= FormStartPosition.CenterScreen;
            this.Text = "Vista Ampliada -Presiona ESC para cerrar";
            this.BackColor = Color.Black;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys KeyData)
        {
            if (KeyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, KeyData);
        }

        private void FormVisorCarta_Load(object sender, EventArgs e)
        {
            //borrar

        }

        private void picZoomCarta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
