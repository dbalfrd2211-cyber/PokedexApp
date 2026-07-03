namespace PokedexApp
{
    partial class FormVisorCarta
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
            this.picZoomCarta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomCarta)).BeginInit();
            this.SuspendLayout();
            // 
            // picZoomCarta
            // 
            this.picZoomCarta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picZoomCarta.Location = new System.Drawing.Point(0, 0);
            this.picZoomCarta.Name = "picZoomCarta";
            this.picZoomCarta.Size = new System.Drawing.Size(800, 450);
            this.picZoomCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picZoomCarta.TabIndex = 0;
            this.picZoomCarta.TabStop = false;
            this.picZoomCarta.Click += new System.EventHandler(this.picZoomCarta_Click);
            // 
            // FormVisorCarta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picZoomCarta);
            this.Name = "FormVisorCarta";
            this.Text = "FormVisorCarta";
            this.Load += new System.EventHandler(this.FormVisorCarta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picZoomCarta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picZoomCarta;
    }
}