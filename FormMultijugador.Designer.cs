namespace PokedexApp
{
    partial class FormMultijugador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCombate = new System.Windows.Forms.Button();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.btnIntercambio = new System.Windows.Forms.Button();
            this.lblUsuarioLogueado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUsuario2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCombate
            // 
            this.btnCombate.Location = new System.Drawing.Point(109, 153);
            this.btnCombate.Name = "btnCombate";
            this.btnCombate.Size = new System.Drawing.Size(225, 153);
            this.btnCombate.TabIndex = 0;
            this.btnCombate.Text = "Batalla 1 vs 1";
            this.btnCombate.UseVisualStyleBackColor = true;
            this.btnCombate.Click += new System.EventHandler(this.btnCombate_Click);
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.Location = new System.Drawing.Point(291, 345);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(227, 76);
            this.btnVolverMenu.TabIndex = 2;
            this.btnVolverMenu.Text = "Volver al menu principal";
            this.btnVolverMenu.UseVisualStyleBackColor = true;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
            // 
            // btnIntercambio
            // 
            this.btnIntercambio.Location = new System.Drawing.Point(457, 153);
            this.btnIntercambio.Name = "btnIntercambio";
            this.btnIntercambio.Size = new System.Drawing.Size(225, 153);
            this.btnIntercambio.TabIndex = 0;
            this.btnIntercambio.Text = "Intercambio de Cartas";
            this.btnIntercambio.UseVisualStyleBackColor = true;
            this.btnIntercambio.Click += new System.EventHandler(this.btnIntercambio_Click);
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.AutoSize = true;
            this.lblUsuarioLogueado.Location = new System.Drawing.Point(149, 39);
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(119, 16);
            this.lblUsuarioLogueado.TabIndex = 1;
            this.lblUsuarioLogueado.Text = "Usuario Logueado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario 2";
            // 
            // cmbUsuario2
            // 
            this.cmbUsuario2.FormattingEnabled = true;
            this.cmbUsuario2.Location = new System.Drawing.Point(534, 36);
            this.cmbUsuario2.Name = "cmbUsuario2";
            this.cmbUsuario2.Size = new System.Drawing.Size(121, 24);
            this.cmbUsuario2.TabIndex = 3;
            this.cmbUsuario2.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario2_SelectedIndexChanged);
            // 
            // FormMultijugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbUsuario2);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsuarioLogueado);
            this.Controls.Add(this.btnIntercambio);
            this.Controls.Add(this.btnCombate);
            this.Name = "FormMultijugador";
            this.Text = "FormMultijugador";
            this.Load += new System.EventHandler(this.FormMultijugador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCombate;
        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.Button btnIntercambio;
        private System.Windows.Forms.Label lblUsuarioLogueado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUsuario2;
    }
}