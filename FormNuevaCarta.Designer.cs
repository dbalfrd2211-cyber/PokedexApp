namespace PokedexApp
{
    partial class FormNuevaCarta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdPokemon = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.txtNumeroColeccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbRareza = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipo1 = new System.Windows.Forms.ComboBox();
            this.txtPokedex = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtHPbase = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbUnidadPeso = new System.Windows.Forms.ComboBox();
            this.cmbUnidadAltura = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IdPokemon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "HP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rareza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Numero de coleccion";
            // 
            // txtIdPokemon
            // 
            this.txtIdPokemon.Location = new System.Drawing.Point(145, 36);
            this.txtIdPokemon.Name = "txtIdPokemon";
            this.txtIdPokemon.Size = new System.Drawing.Size(174, 22);
            this.txtIdPokemon.TabIndex = 4;
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(145, 162);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(174, 22);
            this.txtHP.TabIndex = 5;
            // 
            // txtNumeroColeccion
            // 
            this.txtNumeroColeccion.Location = new System.Drawing.Point(549, 44);
            this.txtNumeroColeccion.Name = "txtNumeroColeccion";
            this.txtNumeroColeccion.Size = new System.Drawing.Size(174, 22);
            this.txtNumeroColeccion.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(268, 404);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(145, 111);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(174, 22);
            this.txtNombre.TabIndex = 10;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(425, 404);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(94, 34);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbRareza
            // 
            this.cmbRareza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRareza.FormattingEnabled = true;
            this.cmbRareza.Items.AddRange(new object[] {
            "Comun",
            "Rara",
            "Legendaria"});
            this.cmbRareza.Location = new System.Drawing.Point(145, 315);
            this.cmbRareza.Name = "cmbRareza";
            this.cmbRareza.Size = new System.Drawing.Size(174, 24);
            this.cmbRareza.TabIndex = 14;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(409, 102);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(142, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "IdPokemon debe ser a partir de 152";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(142, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = " HP solo admite numeros";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(546, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Coleccio solo admite numeros";
            // 
            // cmbTipo1
            // 
            this.cmbTipo1.FormattingEnabled = true;
            this.cmbTipo1.Items.AddRange(new object[] {
            "Acero",
            "Agua",
            "Bicho",
            "Dragón",
            "Eléctrico",
            "Fantasma",
            "Fuego",
            "Hada",
            "Hielo",
            "Lucha",
            "Normal",
            "Planta",
            "Psíquico",
            "Roca",
            "Tierra",
            "Veneno",
            "Volador"});
            this.cmbTipo1.Location = new System.Drawing.Point(145, 273);
            this.cmbTipo1.Name = "cmbTipo1";
            this.cmbTipo1.Size = new System.Drawing.Size(174, 24);
            this.cmbTipo1.TabIndex = 19;
            // 
            // txtPokedex
            // 
            this.txtPokedex.Location = new System.Drawing.Point(145, 223);
            this.txtPokedex.Name = "txtPokedex";
            this.txtPokedex.Size = new System.Drawing.Size(174, 22);
            this.txtPokedex.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Pokedex";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Tipo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 371);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Region";
            // 
            // cmbRegion
            // 
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Items.AddRange(new object[] {
            "Kanto",
            "Johto",
            "Hoenn",
            "Sinnoh",
            "Teselia",
            "Kalos",
            "Alola",
            "Galar",
            "Paldea"});
            this.cmbRegion.Location = new System.Drawing.Point(145, 368);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(174, 24);
            this.cmbRegion.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Altura";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(409, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Peso";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(408, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 16);
            this.label14.TabIndex = 27;
            this.label14.Text = "HP base";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(549, 118);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(174, 22);
            this.txtAltura.TabIndex = 28;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(549, 168);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(174, 22);
            this.txtPeso.TabIndex = 29;
            // 
            // txtHPbase
            // 
            this.txtHPbase.Location = new System.Drawing.Point(549, 217);
            this.txtHPbase.Name = "txtHPbase";
            this.txtHPbase.Size = new System.Drawing.Size(174, 22);
            this.txtHPbase.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(142, 248);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(189, 16);
            this.label15.TabIndex = 31;
            this.label15.Text = "Pokedex solo admite numeros";
            // 
            // cmbUnidadPeso
            // 
            this.cmbUnidadPeso.FormattingEnabled = true;
            this.cmbUnidadPeso.Items.AddRange(new object[] {
            "Kg",
            "g"});
            this.cmbUnidadPeso.Location = new System.Drawing.Point(730, 165);
            this.cmbUnidadPeso.Name = "cmbUnidadPeso";
            this.cmbUnidadPeso.Size = new System.Drawing.Size(42, 24);
            this.cmbUnidadPeso.TabIndex = 32;
            // 
            // cmbUnidadAltura
            // 
            this.cmbUnidadAltura.FormattingEnabled = true;
            this.cmbUnidadAltura.Items.AddRange(new object[] {
            "cm",
            "m"});
            this.cmbUnidadAltura.Location = new System.Drawing.Point(730, 118);
            this.cmbUnidadAltura.Name = "cmbUnidadAltura";
            this.cmbUnidadAltura.Size = new System.Drawing.Size(42, 24);
            this.cmbUnidadAltura.TabIndex = 33;
            // 
            // FormNuevaCarta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbUnidadAltura);
            this.Controls.Add(this.cmbUnidadPeso);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtHPbase);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPokedex);
            this.Controls.Add(this.cmbTipo1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cmbRareza);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNumeroColeccion);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.txtIdPokemon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormNuevaCarta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNuevaCarta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdPokemon;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.TextBox txtNumeroColeccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbRareza;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTipo1;
        private System.Windows.Forms.TextBox txtPokedex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtHPbase;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbUnidadPeso;
        private System.Windows.Forms.ComboBox cmbUnidadAltura;
    }
}