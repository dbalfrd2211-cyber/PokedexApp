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
            this.lblUsuarioAutenticador.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioAutenticador.Location = new System.Drawing.Point(139, 46);
            this.lblUsuarioAutenticador.Name = "lblUsuarioAutenticador";
            this.lblUsuarioAutenticador.Size = new System.Drawing.Size(142, 39);
            this.lblUsuarioAutenticador.TabIndex = 0;
            this.lblUsuarioAutenticador.Text = "Usuario";
            this.lblUsuarioAutenticador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(196, 144);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(175, 34);
            this.txtContrasena.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(528, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Introduzca su contraseña para continuar:";
            // 
            // btnAceptarAuntenticar
            // 
            this.btnAceptarAuntenticar.Location = new System.Drawing.Point(90, 236);
            this.btnAceptarAuntenticar.Name = "btnAceptarAuntenticar";
            this.btnAceptarAuntenticar.Size = new System.Drawing.Size(175, 61);
            this.btnAceptarAuntenticar.TabIndex = 3;
            this.btnAceptarAuntenticar.Text = "Aceptar";
            this.btnAceptarAuntenticar.UseVisualStyleBackColor = true;
            this.btnAceptarAuntenticar.Click += new System.EventHandler(this.btnAceptarAuntenticar_Click);
            // 
            // btnCancelarAuntenticar
            // 
            this.btnCancelarAuntenticar.Location = new System.Drawing.Point(314, 236);
            this.btnCancelarAuntenticar.Name = "btnCancelarAuntenticar";
            this.btnCancelarAuntenticar.Size = new System.Drawing.Size(175, 61);
            this.btnCancelarAuntenticar.TabIndex = 3;
            this.btnCancelarAuntenticar.Text = "Cancelar";
            this.btnCancelarAuntenticar.UseVisualStyleBackColor = true;
            this.btnCancelarAuntenticar.Click += new System.EventHandler(this.btnCancelarAuntenticar_Click);
            // 
            // AutenticadorUsuario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 333);
            this.Controls.Add(this.btnCancelarAuntenticar);
            this.Controls.Add(this.btnAceptarAuntenticar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblUsuarioAutenticador);
            this.Name = "AutenticadorUsuario2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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