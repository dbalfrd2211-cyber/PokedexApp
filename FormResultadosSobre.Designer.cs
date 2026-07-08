namespace PokedexApp
{
    partial class FormResultadosSobre
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
            this.picCarta3 = new System.Windows.Forms.PictureBox();
            this.picCarta2 = new System.Windows.Forms.PictureBox();
            this.picCarta1 = new System.Windows.Forms.PictureBox();
            this.btnContinuarReclamar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta1)).BeginInit();
            this.SuspendLayout();
            // 
            // picCarta3
            // 
            this.picCarta3.BackColor = System.Drawing.Color.Transparent;
            this.picCarta3.Location = new System.Drawing.Point(552, 69);
            this.picCarta3.Name = "picCarta3";
            this.picCarta3.Size = new System.Drawing.Size(225, 305);
            this.picCarta3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarta3.TabIndex = 2;
            this.picCarta3.TabStop = false;
            this.picCarta3.Click += new System.EventHandler(this.picCarta3_Click);
            // 
            // picCarta2
            // 
            this.picCarta2.BackColor = System.Drawing.Color.Transparent;
            this.picCarta2.Location = new System.Drawing.Point(289, 69);
            this.picCarta2.Name = "picCarta2";
            this.picCarta2.Size = new System.Drawing.Size(225, 305);
            this.picCarta2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarta2.TabIndex = 1;
            this.picCarta2.TabStop = false;
            this.picCarta2.Click += new System.EventHandler(this.picCarta3_Click);
            // 
            // picCarta1
            // 
            this.picCarta1.BackColor = System.Drawing.Color.Transparent;
            this.picCarta1.Location = new System.Drawing.Point(22, 69);
            this.picCarta1.Name = "picCarta1";
            this.picCarta1.Size = new System.Drawing.Size(225, 305);
            this.picCarta1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarta1.TabIndex = 0;
            this.picCarta1.TabStop = false;
            this.picCarta1.Click += new System.EventHandler(this.picCarta3_Click);
            // 
            // btnContinuarReclamar
            // 
            this.btnContinuarReclamar.Location = new System.Drawing.Point(295, 390);
            this.btnContinuarReclamar.Name = "btnContinuarReclamar";
            this.btnContinuarReclamar.Size = new System.Drawing.Size(214, 48);
            this.btnContinuarReclamar.TabIndex = 3;
            this.btnContinuarReclamar.Text = "Continuar";
            this.btnContinuarReclamar.UseVisualStyleBackColor = true;
            this.btnContinuarReclamar.Click += new System.EventHandler(this.btnContinuarReclamar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enhorabuena, has recibido estas cartas!";
            // 
            // FormResultadosSobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnContinuarReclamar);
            this.Controls.Add(this.picCarta3);
            this.Controls.Add(this.picCarta2);
            this.Controls.Add(this.picCarta1);
            this.MaximizeBox = false;
            this.Name = "FormResultadosSobre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormResultadosSobre";
            this.Load += new System.EventHandler(this.FormResultadosSobre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCarta3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCarta1;
        private System.Windows.Forms.PictureBox picCarta2;
        private System.Windows.Forms.PictureBox picCarta3;
        private System.Windows.Forms.Button btnContinuarReclamar;
        private System.Windows.Forms.Label label1;
    }
}