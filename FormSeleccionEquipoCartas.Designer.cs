namespace PokedexApp
{
    partial class FormSeleccionEquipoCartas
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
            this.picCarta = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVListMisCartas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(61, 288);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // DGVListMisCartas
            // 
            this.DGVListMisCartas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVListMisCartas.Location = new System.Drawing.Point(35, 67);
            this.DGVListMisCartas.Name = "DGVListMisCartas";
            this.DGVListMisCartas.ReadOnly = true;
            this.DGVListMisCartas.RowHeadersWidth = 51;
            this.DGVListMisCartas.RowTemplate.Height = 24;
            this.DGVListMisCartas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.DGVListMisCartas.Size = new System.Drawing.Size(395, 191);
            this.DGVListMisCartas.TabIndex = 1;
            this.DGVListMisCartas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVListMisCartas_CellContentClick);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(58, 425);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(143, 16);
            this.lblContador.TabIndex = 2;
            this.lblContador.Text = "Cartas Seleccionadas:";
            // 
            // picCarta
            // 
            this.picCarta.Location = new System.Drawing.Point(470, 44);
            this.picCarta.Name = "picCarta";
            this.picCarta.Size = new System.Drawing.Size(318, 254);
            this.picCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarta.TabIndex = 3;
            this.picCarta.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(172, 288);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
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
            this.txtDetalles.Location = new System.Drawing.Point(35, 364);
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.Size = new System.Drawing.Size(413, 22);
            this.txtDetalles.TabIndex = 6;
            // 
            // FormSeleccionEquipoCartas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDetalles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.picCarta);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.DGVListMisCartas);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "FormSeleccionEquipoCartas";
            this.Text = "FormSeleccionEquipoCartas";
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
        private System.Windows.Forms.PictureBox picCarta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetalles;
    }
}