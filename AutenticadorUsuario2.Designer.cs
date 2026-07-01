namespace PokedexApp
{
    partial class AutenticadorUsuario2
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
            this.lblUsuarioAutenticador = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptarAuntenticar = new System.Windows.Forms.Button();
            this.btnCancelarAuntenticar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsuarioAutenticador
            // 
            this.lblUsuarioAutenticador.AutoSize = true;
            this.lblUsuarioAutenticador.Location = new System.Drawing.Point(193, 33);
            this.lblUsuarioAutenticador.Name = "lblUsuarioAutenticador";
            this.lblUsuarioAutenticador.Size = new System.Drawing.Size(54, 16);
            this.lblUsuarioAutenticador.TabIndex = 0;
            this.lblUsuarioAutenticador.Text = "Usuario";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(138, 114);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(175, 22);
            this.txtContrasena.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Introduzca su contraseña para continuar:";
            // 
            // btnAceptarAuntenticar
            // 
            this.btnAceptarAuntenticar.Location = new System.Drawing.Point(100, 185);
            this.btnAceptarAuntenticar.Name = "btnAceptarAuntenticar";
            this.btnAceptarAuntenticar.Size = new System.Drawing.Size(111, 42);
            this.btnAceptarAuntenticar.TabIndex = 3;
            this.btnAceptarAuntenticar.Text = "Aceptar";
            this.btnAceptarAuntenticar.UseVisualStyleBackColor = true;
            this.btnAceptarAuntenticar.Click += new System.EventHandler(this.btnAceptarAuntenticar_Click);
            // 
            // btnCancelarAuntenticar
            // 
            this.btnCancelarAuntenticar.Location = new System.Drawing.Point(261, 185);
            this.btnCancelarAuntenticar.Name = "btnCancelarAuntenticar";
            this.btnCancelarAuntenticar.Size = new System.Drawing.Size(111, 42);
            this.btnCancelarAuntenticar.TabIndex = 3;
            this.btnCancelarAuntenticar.Text = "Cancelar";
            this.btnCancelarAuntenticar.UseVisualStyleBackColor = true;
            this.btnCancelarAuntenticar.Click += new System.EventHandler(this.btnCancelarAuntenticar_Click);
            // 
            // AutenticadorUsuario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 262);
            this.Controls.Add(this.btnCancelarAuntenticar);
            this.Controls.Add(this.btnAceptarAuntenticar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblUsuarioAutenticador);
            this.Name = "AutenticadorUsuario2";
            this.Text = "AutenticadorUsuario2";
            this.Load += new System.EventHandler(this.AutenticadorUsuario2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioAutenticador;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptarAuntenticar;
        private System.Windows.Forms.Button btnCancelarAuntenticar;
    }
}