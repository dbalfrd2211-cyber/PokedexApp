namespace PokedexApp
{
    partial class FormFondo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFondo));
            this.picMiCarta = new System.Windows.Forms.PictureBox();
            this.picCartaRival = new System.Windows.Forms.PictureBox();
            this.pbHpRival = new System.Windows.Forms.ProgressBar();
            this.pbMiHp = new System.Windows.Forms.ProgressBar();
            this.btnAtacar = new System.Windows.Forms.Button();
            this.timerAnimacion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartaRival)).BeginInit();
            this.SuspendLayout();
            // 
            // picMiCarta
            // 
            this.picMiCarta.BackColor = System.Drawing.Color.Transparent;
            this.picMiCarta.Location = new System.Drawing.Point(96, 38);
            this.picMiCarta.Name = "picMiCarta";
            this.picMiCarta.Size = new System.Drawing.Size(140, 200);
            this.picMiCarta.TabIndex = 0;
            this.picMiCarta.TabStop = false;
            // 
            // picCartaRival
            // 
            this.picCartaRival.BackColor = System.Drawing.Color.Transparent;
            this.picCartaRival.Location = new System.Drawing.Point(552, 38);
            this.picCartaRival.Name = "picCartaRival";
            this.picCartaRival.Size = new System.Drawing.Size(140, 200);
            this.picCartaRival.TabIndex = 1;
            this.picCartaRival.TabStop = false;
            // 
            // pbHpRival
            // 
            this.pbHpRival.Location = new System.Drawing.Point(575, 244);
            this.pbHpRival.Name = "pbHpRival";
            this.pbHpRival.Size = new System.Drawing.Size(100, 23);
            this.pbHpRival.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbHpRival.TabIndex = 2;
            // 
            // pbMiHp
            // 
            this.pbMiHp.Location = new System.Drawing.Point(122, 244);
            this.pbMiHp.Name = "pbMiHp";
            this.pbMiHp.Size = new System.Drawing.Size(100, 23);
            this.pbMiHp.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbMiHp.TabIndex = 3;
            this.pbMiHp.Click += new System.EventHandler(this.obMiHp_Click);
            // 
            // btnAtacar
            // 
            this.btnAtacar.Location = new System.Drawing.Point(134, 292);
            this.btnAtacar.Name = "btnAtacar";
            this.btnAtacar.Size = new System.Drawing.Size(75, 23);
            this.btnAtacar.TabIndex = 4;
            this.btnAtacar.Text = "Atacar";
            this.btnAtacar.UseVisualStyleBackColor = true;
            this.btnAtacar.Click += new System.EventHandler(this.btnAtacar_Click);
            // 
            // timerAnimacion
            // 
            this.timerAnimacion.Interval = 15;
            this.timerAnimacion.Tick += new System.EventHandler(this.timerAnimacion_Tick);
            // 
            // FormFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAtacar);
            this.Controls.Add(this.pbMiHp);
            this.Controls.Add(this.pbHpRival);
            this.Controls.Add(this.picCartaRival);
            this.Controls.Add(this.picMiCarta);
            this.Name = "FormFondo";
            this.Text = "Batalla";
            this.Load += new System.EventHandler(this.FormBatalla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartaRival)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMiCarta;
        private System.Windows.Forms.PictureBox picCartaRival;
        private System.Windows.Forms.ProgressBar pbHpRival;
        private System.Windows.Forms.ProgressBar pbMiHp;
        private System.Windows.Forms.Button btnAtacar;
        private System.Windows.Forms.Timer timerAnimacion;
    }
}