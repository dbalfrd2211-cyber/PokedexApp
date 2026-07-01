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
            this.lblBatallaPokemon = new System.Windows.Forms.Label();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIntercambio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCombate
            // 
            this.btnCombate.Location = new System.Drawing.Point(320, 125);
            this.btnCombate.Name = "btnCombate";
            this.btnCombate.Size = new System.Drawing.Size(133, 23);
            this.btnCombate.TabIndex = 0;
            this.btnCombate.Text = "1 vs 1";
            this.btnCombate.UseVisualStyleBackColor = true;
            this.btnCombate.Click += new System.EventHandler(this.btnCombate_Click);
            // 
            // lblBatallaPokemon
            // 
            this.lblBatallaPokemon.AutoSize = true;
            this.lblBatallaPokemon.Location = new System.Drawing.Point(317, 71);
            this.lblBatallaPokemon.Name = "lblBatallaPokemon";
            this.lblBatallaPokemon.Size = new System.Drawing.Size(136, 16);
            this.lblBatallaPokemon.TabIndex = 1;
            this.lblBatallaPokemon.Text = "BATALLA POKEMON";
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.Location = new System.Drawing.Point(303, 299);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(176, 35);
            this.btnVolverMenu.TabIndex = 2;
            this.btnVolverMenu.Text = "Volver al menu principal";
            this.btnVolverMenu.UseVisualStyleBackColor = true;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Batalla";
            // 
            // btnIntercambio
            // 
            this.btnIntercambio.Location = new System.Drawing.Point(320, 164);
            this.btnIntercambio.Name = "btnIntercambio";
            this.btnIntercambio.Size = new System.Drawing.Size(133, 52);
            this.btnIntercambio.TabIndex = 0;
            this.btnIntercambio.Text = "Intercambio de Cartas";
            this.btnIntercambio.UseVisualStyleBackColor = true;
            this.btnIntercambio.Click += new System.EventHandler(this.btnIntercambio_Click);
            // 
            // FormMultijugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.lblBatallaPokemon);
            this.Controls.Add(this.btnIntercambio);
            this.Controls.Add(this.btnCombate);
            this.Name = "FormMultijugador";
            this.Text = "FormMultijugador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCombate;
        private System.Windows.Forms.Label lblBatallaPokemon;
        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIntercambio;
    }
}