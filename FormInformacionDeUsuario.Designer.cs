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
            this.lblGanadas = new System.Windows.Forms.Label();
            this.lblPerdidas = new System.Windows.Forms.Label();
            this.lblCartas = new System.Windows.Forms.Label();
            this.DGVCartasUsuario = new System.Windows.Forms.DataGridView();
            this.btnEliminarCartaUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHistorialIntercambio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartasUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRegresar.Location = new System.Drawing.Point(250, 398);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(252, 40);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Volver al menu";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(171, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(114, 36);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "usuario";
            // 
            // lblNivel
            // 
            this.lblNivel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.Location = new System.Drawing.Point(117, 45);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(55, 25);
            this.lblNivel.TabIndex = 3;
            this.lblNivel.Text = "Nivel";
            // 
            // lblGanadas
            // 
            this.lblGanadas.AutoSize = true;
            this.lblGanadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanadas.Location = new System.Drawing.Point(268, 98);
            this.lblGanadas.Name = "lblGanadas";
            this.lblGanadas.Size = new System.Drawing.Size(101, 29);
            this.lblGanadas.TabIndex = 5;
            this.lblGanadas.Text = "victorias";
            // 
            // lblPerdidas
            // 
            this.lblPerdidas.AutoSize = true;
            this.lblPerdidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerdidas.Location = new System.Drawing.Point(268, 127);
            this.lblPerdidas.Name = "lblPerdidas";
            this.lblPerdidas.Size = new System.Drawing.Size(102, 29);
            this.lblPerdidas.TabIndex = 6;
            this.lblPerdidas.Text = "derrotas";
            // 
            // lblCartas
            // 
            this.lblCartas.AutoSize = true;
            this.lblCartas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartas.Location = new System.Drawing.Point(12, 179);
            this.lblCartas.Name = "lblCartas";
            this.lblCartas.Size = new System.Drawing.Size(171, 25);
            this.lblCartas.TabIndex = 7;
            this.lblCartas.Text = "Cartas Obtenidas:";
            // 
            // DGVCartasUsuario
            // 
            this.DGVCartasUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCartasUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVCartasUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCartasUsuario.Location = new System.Drawing.Point(12, 207);
            this.DGVCartasUsuario.Name = "DGVCartasUsuario";
            this.DGVCartasUsuario.ReadOnly = true;
            this.DGVCartasUsuario.RowHeadersWidth = 51;
            this.DGVCartasUsuario.RowTemplate.Height = 24;
            this.DGVCartasUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCartasUsuario.Size = new System.Drawing.Size(763, 152);
            this.DGVCartasUsuario.TabIndex = 8;
            // 
            // btnEliminarCartaUsuario
            // 
            this.btnEliminarCartaUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminarCartaUsuario.Location = new System.Drawing.Point(12, 365);
            this.btnEliminarCartaUsuario.Name = "btnEliminarCartaUsuario";
            this.btnEliminarCartaUsuario.Size = new System.Drawing.Size(158, 34);
            this.btnEliminarCartaUsuario.TabIndex = 9;
            this.btnEliminarCartaUsuario.Text = "Eliminar carta";
            this.btnEliminarCartaUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarCartaUsuario.Click += new System.EventHandler(this.btnEliminarCartaUsuario_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 36);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nivel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Partidas ganadas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Partidas perdidas:";
            // 
            // btnHistorialIntercambio
            // 
            this.btnHistorialIntercambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorialIntercambio.Location = new System.Drawing.Point(508, 365);
            this.btnHistorialIntercambio.Name = "btnHistorialIntercambio";
            this.btnHistorialIntercambio.Size = new System.Drawing.Size(267, 34);
            this.btnHistorialIntercambio.TabIndex = 9;
            this.btnHistorialIntercambio.Text = "Historial De Intercambios";
            this.btnHistorialIntercambio.UseVisualStyleBackColor = true;
            this.btnHistorialIntercambio.Click += new System.EventHandler(this.btnHistorialIntercambio_Click);
            // 
            // FormInformacionDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHistorialIntercambio);
            this.Controls.Add(this.btnEliminarCartaUsuario);
            this.Controls.Add(this.DGVCartasUsuario);
            this.Controls.Add(this.lblCartas);
            this.Controls.Add(this.lblPerdidas);
            this.Controls.Add(this.lblGanadas);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnRegresar);
            this.Name = "FormInformacionDeUsuario";
            this.Text = "FormInformacionDeUsuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInformacionDeUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartasUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblGanadas;
        private System.Windows.Forms.Label lblPerdidas;
        private System.Windows.Forms.Label lblCartas;
        private System.Windows.Forms.DataGridView DGVCartasUsuario;
        private System.Windows.Forms.Button btnEliminarCartaUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHistorialIntercambio;
    }
}