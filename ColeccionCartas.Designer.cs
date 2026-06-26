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
            this.btnAñadirAColeccion = new System.Windows.Forms.Button();
            this.btnCrearNuevaCarta = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListadoCartas)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVListadoCartas
            // 
            this.DGVListadoCartas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVListadoCartas.Location = new System.Drawing.Point(31, 119);
            this.DGVListadoCartas.Name = "DGVListadoCartas";
            this.DGVListadoCartas.ReadOnly = true;
            this.DGVListadoCartas.RowHeadersWidth = 51;
            this.DGVListadoCartas.RowTemplate.Height = 24;
            this.DGVListadoCartas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVListadoCartas.Size = new System.Drawing.Size(464, 192);
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
            this.label2.Location = new System.Drawing.Point(28, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detalles del Pokemon\r\n";
            // 
            // txtDetallesPokemon
            // 
            this.txtDetallesPokemon.Location = new System.Drawing.Point(31, 356);
            this.txtDetallesPokemon.Name = "txtDetallesPokemon";
            this.txtDetallesPokemon.Size = new System.Drawing.Size(464, 22);
            this.txtDetallesPokemon.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Listado de cartas Pokemon disponibles  en el servidor:\r\n";
            // 
            // txtBuscarPokemon
            // 
            this.txtBuscarPokemon.Location = new System.Drawing.Point(144, 43);
            this.txtBuscarPokemon.Name = "txtBuscarPokemon";
            this.txtBuscarPokemon.Size = new System.Drawing.Size(351, 22);
            this.txtBuscarPokemon.TabIndex = 9;
            this.txtBuscarPokemon.TextChanged += new System.EventHandler(this.txtBuscarPokemon_TextChanged);
            // 
            // btnAñadirAColeccion
            // 
            this.btnAñadirAColeccion.Location = new System.Drawing.Point(31, 398);
            this.btnAñadirAColeccion.Name = "btnAñadirAColeccion";
            this.btnAñadirAColeccion.Size = new System.Drawing.Size(159, 23);
            this.btnAñadirAColeccion.TabIndex = 10;
            this.btnAñadirAColeccion.Text = "Añadir a mi colección";
            this.btnAñadirAColeccion.UseVisualStyleBackColor = true;
            this.btnAñadirAColeccion.Click += new System.EventHandler(this.btnAñadirAColeccion_Click);
            // 
            // btnCrearNuevaCarta
            // 
            this.btnCrearNuevaCarta.Location = new System.Drawing.Point(596, 367);
            this.btnCrearNuevaCarta.Name = "btnCrearNuevaCarta";
            this.btnCrearNuevaCarta.Size = new System.Drawing.Size(170, 43);
            this.btnCrearNuevaCarta.TabIndex = 11;
            this.btnCrearNuevaCarta.Text = "Crear Nueva Carta";
            this.btnCrearNuevaCarta.UseVisualStyleBackColor = true;
            this.btnCrearNuevaCarta.Click += new System.EventHandler(this.btnCrearNuevaCarta_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(549, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(243, 180);
            this.listBox1.TabIndex = 12;
            // 
            // ColeccionCartas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 685);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnCrearNuevaCarta);
            this.Controls.Add(this.btnAñadirAColeccion);
            this.Controls.Add(this.txtBuscarPokemon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDetallesPokemon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVListadoCartas);
            this.Name = "ColeccionCartas";
            this.Text = "ColeccionCartas";
            this.Load += new System.EventHandler(this.ColeccionCartas_Load);
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
        private System.Windows.Forms.Button btnAñadirAColeccion;
        private System.Windows.Forms.Button btnCrearNuevaCarta;
        private System.Windows.Forms.ListBox listBox1;
    }
}