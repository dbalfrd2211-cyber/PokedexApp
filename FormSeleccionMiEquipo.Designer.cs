namespace PokedexApp
{
    partial class FormSeleccionMiEquipo
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.DGVListMisCartas = new System.Windows.Forms.DataGridView();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.picCarta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListMisCartas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(479, 431);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // DGVListMisCartas
            // 
            this.DGVListMisCartas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVListMisCartas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVListMisCartas.Location = new System.Drawing.Point(35, 67);
            this.DGVListMisCartas.Name = "DGVListMisCartas";
            this.DGVListMisCartas.ReadOnly = true;
            this.DGVListMisCartas.RowHeadersWidth = 51;
            this.DGVListMisCartas.RowTemplate.Height = 24;
            this.DGVListMisCartas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVListMisCartas.Size = new System.Drawing.Size(549, 215);
            this.DGVListMisCartas.TabIndex = 1;
            this.DGVListMisCartas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVListMisCartas_CellContentClick);
            this.DGVListMisCartas.SelectionChanged += new System.EventHandler(this.DGVListMisCartas_SelectionChanged);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(32, 468);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(143, 16);
            this.lblContador.TabIndex = 2;
            this.lblContador.Text = "Cartas Seleccionadas:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(479, 389);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selecciona tus 3 cartas pokemon para la batalla";
            // 
            // txtDetalles
            // 
            this.txtDetalles.Location = new System.Drawing.Point(35, 335);
            this.txtDetalles.Multiline = true;
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.ReadOnly = true;
            this.txtDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalles.Size = new System.Drawing.Size(413, 119);
            this.txtDetalles.TabIndex = 6;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(156, 297);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 32);
            this.btnRemover.TabIndex = 7;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(35, 297);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(94, 32);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar\r\n";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // picCarta
            // 
            this.picCarta.Location = new System.Drawing.Point(613, 94);
            this.picCarta.Name = "picCarta";
            this.picCarta.Size = new System.Drawing.Size(146, 173);
            this.picCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarta.TabIndex = 9;
            this.picCarta.TabStop = false;
            // 
            // FormSeleccionMiEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.picCarta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.txtDetalles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.DGVListMisCartas);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "FormSeleccionMiEquipo";
            this.Text = "FormSeleccionMiEquipo";
            this.Load += new System.EventHandler(this.FormSeleccionEquipoCartas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVListMisCartas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridView DGVListMisCartas;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetalles;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.PictureBox picCarta;
    }
}