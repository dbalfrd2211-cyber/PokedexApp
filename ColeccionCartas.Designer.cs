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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColeccionCartas));
            this.DGVListadoCartas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetallesPokemon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarPokemon = new System.Windows.Forms.TextBox();
            this.btnAñadirAColeccion = new System.Windows.Forms.Button();
            this.btnCrearNuevaCarta = new System.Windows.Forms.Button();
            this.btnVolverCC = new System.Windows.Forms.Button();
            this.btnKanto = new System.Windows.Forms.Button();
            this.btnSinnoh = new System.Windows.Forms.Button();
            this.btnJohto = new System.Windows.Forms.Button();
            this.btnHoenn = new System.Windows.Forms.Button();
            this.btnKalos = new System.Windows.Forms.Button();
            this.btnAlola = new System.Windows.Forms.Button();
            this.btnGalar = new System.Windows.Forms.Button();
            this.btnPaldea = new System.Windows.Forms.Button();
            this.btnUnova = new System.Windows.Forms.Button();
            this.btnEliminarCarta = new System.Windows.Forms.Button();
            this.picCarta = new System.Windows.Forms.PictureBox();
            this.picMapa = new System.Windows.Forms.PictureBox();
            this.picSobre = new System.Windows.Forms.PictureBox();
            this.btnSobre = new System.Windows.Forms.Button();
            this.timerSobre = new System.Windows.Forms.Timer(this.components);
            this.coleccionCartasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVListadoCartas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSobre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coleccionCartasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVListadoCartas
            // 
            this.DGVListadoCartas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVListadoCartas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVListadoCartas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVListadoCartas.Location = new System.Drawing.Point(31, 119);
            this.DGVListadoCartas.Name = "DGVListadoCartas";
            this.DGVListadoCartas.ReadOnly = true;
            this.DGVListadoCartas.RowHeadersWidth = 51;
            this.DGVListadoCartas.RowTemplate.Height = 24;
            this.DGVListadoCartas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVListadoCartas.Size = new System.Drawing.Size(527, 273);
            this.DGVListadoCartas.TabIndex = 0;
            this.DGVListadoCartas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVListadoCartas_CellContentClick);
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
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detalles del Pokemon\r\n";
            // 
            // txtDetallesPokemon
            // 
            this.txtDetallesPokemon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetallesPokemon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetallesPokemon.Location = new System.Drawing.Point(31, 442);
            this.txtDetallesPokemon.Multiline = true;
            this.txtDetallesPokemon.Name = "txtDetallesPokemon";
            this.txtDetallesPokemon.ReadOnly = true;
            this.txtDetallesPokemon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetallesPokemon.Size = new System.Drawing.Size(454, 160);
            this.txtDetallesPokemon.TabIndex = 3;
            this.txtDetallesPokemon.TextChanged += new System.EventHandler(this.txtDetallesPokemon_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 687);
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
            this.txtBuscarPokemon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarPokemon.Location = new System.Drawing.Point(144, 43);
            this.txtBuscarPokemon.Name = "txtBuscarPokemon";
            this.txtBuscarPokemon.Size = new System.Drawing.Size(549, 22);
            this.txtBuscarPokemon.TabIndex = 9;
            this.txtBuscarPokemon.TextChanged += new System.EventHandler(this.txtBuscarPokemon_TextChanged);
            // 
            // btnAñadirAColeccion
            // 
            this.btnAñadirAColeccion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAñadirAColeccion.Location = new System.Drawing.Point(31, 617);
            this.btnAñadirAColeccion.Name = "btnAñadirAColeccion";
            this.btnAñadirAColeccion.Size = new System.Drawing.Size(126, 56);
            this.btnAñadirAColeccion.TabIndex = 10;
            this.btnAñadirAColeccion.Text = "Añadir a mi colección";
            this.btnAñadirAColeccion.UseVisualStyleBackColor = true;
            this.btnAñadirAColeccion.Click += new System.EventHandler(this.btnAñadirAColeccion_Click);
            // 
            // btnCrearNuevaCarta
            // 
            this.btnCrearNuevaCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCrearNuevaCarta.Location = new System.Drawing.Point(175, 624);
            this.btnCrearNuevaCarta.Name = "btnCrearNuevaCarta";
            this.btnCrearNuevaCarta.Size = new System.Drawing.Size(170, 43);
            this.btnCrearNuevaCarta.TabIndex = 11;
            this.btnCrearNuevaCarta.Text = "Crear Nueva Carta";
            this.btnCrearNuevaCarta.UseVisualStyleBackColor = true;
            this.btnCrearNuevaCarta.Click += new System.EventHandler(this.btnCrearNuevaCarta_Click);
            // 
            // btnVolverCC
            // 
            this.btnVolverCC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnVolverCC.Location = new System.Drawing.Point(1253, 738);
            this.btnVolverCC.Name = "btnVolverCC";
            this.btnVolverCC.Size = new System.Drawing.Size(206, 55);
            this.btnVolverCC.TabIndex = 13;
            this.btnVolverCC.Text = "Volver al menu principal";
            this.btnVolverCC.UseVisualStyleBackColor = true;
            this.btnVolverCC.Click += new System.EventHandler(this.btnVolverCC_Click);
            // 
            // btnKanto
            // 
            this.btnKanto.Location = new System.Drawing.Point(865, 208);
            this.btnKanto.Name = "btnKanto";
            this.btnKanto.Size = new System.Drawing.Size(72, 23);
            this.btnKanto.TabIndex = 16;
            this.btnKanto.Text = "Kanto";
            this.btnKanto.UseVisualStyleBackColor = false;
            // 
            // btnSinnoh
            // 
            this.btnSinnoh.Location = new System.Drawing.Point(1169, 128);
            this.btnSinnoh.Name = "btnSinnoh";
            this.btnSinnoh.Size = new System.Drawing.Size(60, 23);
            this.btnSinnoh.TabIndex = 17;
            this.btnSinnoh.Text = "Sinnoh";
            this.btnSinnoh.UseVisualStyleBackColor = false;
            // 
            // btnJohto
            // 
            this.btnJohto.Location = new System.Drawing.Point(1021, 128);
            this.btnJohto.Name = "btnJohto";
            this.btnJohto.Size = new System.Drawing.Size(53, 23);
            this.btnJohto.TabIndex = 18;
            this.btnJohto.Text = "Johto";
            this.btnJohto.UseVisualStyleBackColor = false;
            // 
            // btnHoenn
            // 
            this.btnHoenn.Location = new System.Drawing.Point(1064, 313);
            this.btnHoenn.Name = "btnHoenn";
            this.btnHoenn.Size = new System.Drawing.Size(56, 23);
            this.btnHoenn.TabIndex = 19;
            this.btnHoenn.Text = "Hoenn";
            this.btnHoenn.UseVisualStyleBackColor = false;
            this.btnHoenn.Click += new System.EventHandler(this.btnHoenn_Click);
            // 
            // btnKalos
            // 
            this.btnKalos.Location = new System.Drawing.Point(1275, 332);
            this.btnKalos.Name = "btnKalos";
            this.btnKalos.Size = new System.Drawing.Size(61, 23);
            this.btnKalos.TabIndex = 20;
            this.btnKalos.Text = "Kalos";
            this.btnKalos.UseVisualStyleBackColor = false;
            // 
            // btnAlola
            // 
            this.btnAlola.Location = new System.Drawing.Point(932, 495);
            this.btnAlola.Name = "btnAlola";
            this.btnAlola.Size = new System.Drawing.Size(57, 23);
            this.btnAlola.TabIndex = 21;
            this.btnAlola.Text = "Alola";
            this.btnAlola.UseVisualStyleBackColor = false;
            // 
            // btnGalar
            // 
            this.btnGalar.Location = new System.Drawing.Point(1118, 505);
            this.btnGalar.Name = "btnGalar";
            this.btnGalar.Size = new System.Drawing.Size(56, 23);
            this.btnGalar.TabIndex = 22;
            this.btnGalar.Text = "Galar";
            this.btnGalar.UseVisualStyleBackColor = false;
            // 
            // btnPaldea
            // 
            this.btnPaldea.Location = new System.Drawing.Point(1297, 526);
            this.btnPaldea.Name = "btnPaldea";
            this.btnPaldea.Size = new System.Drawing.Size(61, 23);
            this.btnPaldea.TabIndex = 23;
            this.btnPaldea.Text = "Paldea";
            this.btnPaldea.UseVisualStyleBackColor = false;
            // 
            // btnUnova
            // 
            this.btnUnova.Location = new System.Drawing.Point(1323, 172);
            this.btnUnova.Name = "btnUnova";
            this.btnUnova.Size = new System.Drawing.Size(56, 23);
            this.btnUnova.TabIndex = 24;
            this.btnUnova.Text = "Unova";
            this.btnUnova.UseVisualStyleBackColor = false;
            // 
            // btnEliminarCarta
            // 
            this.btnEliminarCarta.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminarCarta.Location = new System.Drawing.Point(362, 624);
            this.btnEliminarCarta.Name = "btnEliminarCarta";
            this.btnEliminarCarta.Size = new System.Drawing.Size(145, 43);
            this.btnEliminarCarta.TabIndex = 25;
            this.btnEliminarCarta.Text = "Eliminar Carta";
            this.btnEliminarCarta.UseVisualStyleBackColor = true;
            this.btnEliminarCarta.Click += new System.EventHandler(this.btnEliminarCarta_Click);
            // 
            // picCarta
            // 
            this.picCarta.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picCarta.Location = new System.Drawing.Point(564, 119);
            this.picCarta.Name = "picCarta";
            this.picCarta.Size = new System.Drawing.Size(204, 273);
            this.picCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarta.TabIndex = 26;
            this.picCarta.TabStop = false;
            this.picCarta.Click += new System.EventHandler(this.picCarta_Click);
            // 
            // picMapa
            // 
            this.picMapa.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picMapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMapa.Image = ((System.Drawing.Image)(resources.GetObject("picMapa.Image")));
            this.picMapa.Location = new System.Drawing.Point(789, 58);
            this.picMapa.Name = "picMapa";
            this.picMapa.Size = new System.Drawing.Size(650, 593);
            this.picMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapa.TabIndex = 15;
            this.picMapa.TabStop = false;
            this.picMapa.Click += new System.EventHandler(this.picMapa_Click);
            // 
            // picSobre
            // 
            this.picSobre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picSobre.Location = new System.Drawing.Point(564, 416);
            this.picSobre.Name = "picSobre";
            this.picSobre.Size = new System.Drawing.Size(204, 287);
            this.picSobre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSobre.TabIndex = 27;
            this.picSobre.TabStop = false;
            // 
            // btnSobre
            // 
            this.btnSobre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSobre.BackColor = System.Drawing.Color.Transparent;
            this.btnSobre.BackgroundImage = global::PokedexApp.Properties.Resources.Boton3;
            this.btnSobre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSobre.FlatAppearance.BorderSize = 0;
            this.btnSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSobre.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSobre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSobre.Location = new System.Drawing.Point(578, 517);
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(190, 209);
            this.btnSobre.TabIndex = 28;
            this.btnSobre.Text = "Abrir Mi Sobre Diario";
            this.btnSobre.UseVisualStyleBackColor = false;
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // timerSobre
            // 
            this.timerSobre.Interval = 900;
            this.timerSobre.Tick += new System.EventHandler(this.timersobre_Tick);
            // 
            // coleccionCartasBindingSource
            // 
            this.coleccionCartasBindingSource.DataSource = typeof(PokedexApp.ColeccionCartas);
            // 
            // ColeccionCartas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 815);
            this.Controls.Add(this.btnSobre);
            this.Controls.Add(this.picSobre);
            this.Controls.Add(this.picCarta);
            this.Controls.Add(this.btnEliminarCarta);
            this.Controls.Add(this.btnUnova);
            this.Controls.Add(this.btnPaldea);
            this.Controls.Add(this.btnGalar);
            this.Controls.Add(this.btnAlola);
            this.Controls.Add(this.btnKalos);
            this.Controls.Add(this.btnHoenn);
            this.Controls.Add(this.btnJohto);
            this.Controls.Add(this.btnSinnoh);
            this.Controls.Add(this.btnKanto);
            this.Controls.Add(this.picMapa);
            this.Controls.Add(this.btnVolverCC);
            this.Controls.Add(this.btnCrearNuevaCarta);
            this.Controls.Add(this.btnAñadirAColeccion);
            this.Controls.Add(this.txtBuscarPokemon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDetallesPokemon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVListadoCartas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ColeccionCartas";
            this.Text = "ColeccionCartas";
            this.Load += new System.EventHandler(this.ColeccionCartas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVListadoCartas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSobre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coleccionCartasBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnVolverCC;
        private System.Windows.Forms.PictureBox picMapa;
        private System.Windows.Forms.Button btnKanto;
        private System.Windows.Forms.Button btnSinnoh;
        private System.Windows.Forms.Button btnJohto;
        private System.Windows.Forms.Button btnHoenn;
        private System.Windows.Forms.Button btnKalos;
        private System.Windows.Forms.Button btnAlola;
        private System.Windows.Forms.Button btnGalar;
        private System.Windows.Forms.Button btnPaldea;
        private System.Windows.Forms.Button btnUnova;
        private System.Windows.Forms.Button btnEliminarCarta;
        private System.Windows.Forms.PictureBox picCarta;
        private System.Windows.Forms.BindingSource coleccionCartasBindingSource;
        private System.Windows.Forms.PictureBox picSobre;
        private System.Windows.Forms.Button btnSobre;
        private System.Windows.Forms.Timer timerSobre;
    }
}