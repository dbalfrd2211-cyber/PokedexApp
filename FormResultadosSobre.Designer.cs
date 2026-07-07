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
            ((System.ComponentModel.ISupportInitialize)(this.picCarta3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta1)).BeginInit();
            this.SuspendLayout();
            // 
            // picCarta3
            // 
            this.picCarta3.BackColor = System.Drawing.Color.Transparent;
            this.picCarta3.Location = new System.Drawing.Point(563, 52);
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
            this.picCarta2.Location = new System.Drawing.Point(289, 52);
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
            this.picCarta1.Location = new System.Drawing.Point(22, 52);
            this.picCarta1.Name = "picCarta1";
            this.picCarta1.Size = new System.Drawing.Size(225, 305);
            this.picCarta1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarta1.TabIndex = 0;
            this.picCarta1.TabStop = false;
            this.picCarta1.Click += new System.EventHandler(this.picCarta3_Click);
            // 
            // FormResultadosSobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picCarta3);
            this.Controls.Add(this.picCarta2);
            this.Controls.Add(this.picCarta1);
            this.Name = "FormResultadosSobre";
            this.Text = "FormResultadosSobre";
            this.Load += new System.EventHandler(this.FormResultadosSobre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCarta3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarta1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCarta1;
        private System.Windows.Forms.PictureBox picCarta2;
        private System.Windows.Forms.PictureBox picCarta3;
    }
}