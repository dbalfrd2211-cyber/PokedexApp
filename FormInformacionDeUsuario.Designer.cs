namespace PokedexApp
{
    partial class FormInformacionDeUsuario
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
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.lblGanadas = new System.Windows.Forms.Label();
            this.lblPerdidas = new System.Windows.Forms.Label();
            this.lblCartas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(289, 369);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(201, 40);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Volver al menu principal";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(182, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(37, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "label";
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(182, 137);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(44, 16);
            this.lblNivel.TabIndex = 3;
            this.lblNivel.Text = "label2";
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(538, 369);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(141, 23);
            this.btnGuardarCambios.TabIndex = 4;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // lblGanadas
            // 
            this.lblGanadas.AutoSize = true;
            this.lblGanadas.Location = new System.Drawing.Point(182, 201);
            this.lblGanadas.Name = "lblGanadas";
            this.lblGanadas.Size = new System.Drawing.Size(44, 16);
            this.lblGanadas.TabIndex = 5;
            this.lblGanadas.Text = "label1";
            // 
            // lblPerdidas
            // 
            this.lblPerdidas.AutoSize = true;
            this.lblPerdidas.Location = new System.Drawing.Point(182, 316);
            this.lblPerdidas.Name = "lblPerdidas";
            this.lblPerdidas.Size = new System.Drawing.Size(44, 16);
            this.lblPerdidas.TabIndex = 6;
            this.lblPerdidas.Text = "label2";
            // 
            // lblCartas
            // 
            this.lblCartas.AutoSize = true;
            this.lblCartas.Location = new System.Drawing.Point(182, 264);
            this.lblCartas.Name = "lblCartas";
            this.lblCartas.Size = new System.Drawing.Size(44, 16);
            this.lblCartas.TabIndex = 7;
            this.lblCartas.Text = "label1";
            // 
            // FormInformacionDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCartas);
            this.Controls.Add(this.lblPerdidas);
            this.Controls.Add(this.lblGanadas);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnRegresar);
            this.Name = "FormInformacionDeUsuario";
            this.Text = "FormInformacionDeUsuario";
            this.Load += new System.EventHandler(this.FormInformacionDeUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Label lblGanadas;
        private System.Windows.Forms.Label lblPerdidas;
        private System.Windows.Forms.Label lblCartas;
    }
}