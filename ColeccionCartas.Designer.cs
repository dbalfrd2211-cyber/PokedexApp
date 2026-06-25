namespace PokedexApp
{
    partial class ColeccionCartas
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
            this.DGVListadoCartas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetallesPokemon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarPokemon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListadoCartas)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVListadoCartas
            // 
            this.DGVListadoCartas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVListadoCartas.Location = new System.Drawing.Point(31, 185);
            this.DGVListadoCartas.Name = "DGVListadoCartas";
            this.DGVListadoCartas.RowHeadersWidth = 51;
            this.DGVListadoCartas.RowTemplate.Height = 24;
            this.DGVListadoCartas.Size = new System.Drawing.Size(561, 429);
            this.DGVListadoCartas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar Pokemon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detalles del Pokemon\r\n";
            // 
            // txtDetallesPokemon
            // 
            this.txtDetallesPokemon.Location = new System.Drawing.Point(653, 89);
            this.txtDetallesPokemon.Name = "txtDetallesPokemon";
            this.txtDetallesPokemon.Size = new System.Drawing.Size(727, 22);
            this.txtDetallesPokemon.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 651);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Listado de cartas Pokemon disponibles  en el servidor:\r\n";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtBuscarPokemon
            // 
            this.txtBuscarPokemon.Location = new System.Drawing.Point(144, 43);
            this.txtBuscarPokemon.Name = "txtBuscarPokemon";
            this.txtBuscarPokemon.Size = new System.Drawing.Size(351, 22);
            this.txtBuscarPokemon.TabIndex = 9;
            // 
            // ColeccionCartas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 685);
            this.Controls.Add(this.txtBuscarPokemon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDetallesPokemon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVListadoCartas);
            this.Name = "ColeccionCartas";
            this.Text = "ColeccionCartas";
            ((System.ComponentModel.ISupportInitialize)(this.DGVListadoCartas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVListadoCartas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetallesPokemon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscarPokemon;
    }
}