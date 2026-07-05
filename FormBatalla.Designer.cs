namespace PokedexApp
{
    partial class FormBatalla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBatalla));
            this.picMiCarta = new System.Windows.Forms.PictureBox();
            this.picCartaRival = new System.Windows.Forms.PictureBox();
            this.pbHpRival = new System.Windows.Forms.ProgressBar();
            this.pbMiHp = new System.Windows.Forms.ProgressBar();
            this.btnAtacar = new System.Windows.Forms.Button();
            this.timerAnimacion = new System.Windows.Forms.Timer(this.components);
            this.picMiCarta1 = new System.Windows.Forms.PictureBox();
            this.picMiCarta3 = new System.Windows.Forms.PictureBox();
            this.picMiCarta2 = new System.Windows.Forms.PictureBox();
            this.picRCarta1 = new System.Windows.Forms.PictureBox();
            this.picRCarta2 = new System.Windows.Forms.PictureBox();
            this.picRCarta3 = new System.Windows.Forms.PictureBox();
            this.btnAtaque1 = new System.Windows.Forms.Button();
            this.btnAtaque2 = new System.Windows.Forms.Button();
            this.btnAtaque3 = new System.Windows.Forms.Button();
            this.btnAtaque4 = new System.Windows.Forms.Button();
            this.btnRAtaque1 = new System.Windows.Forms.Button();
            this.btnRAtaque2 = new System.Windows.Forms.Button();
            this.btnRAtaque3 = new System.Windows.Forms.Button();
            this.btnRAtaque4 = new System.Windows.Forms.Button();
            this.lblNarrador = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartaRival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRCarta1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRCarta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRCarta3)).BeginInit();
            this.SuspendLayout();
            // 
            // picMiCarta
            // 
            this.picMiCarta.BackColor = System.Drawing.Color.Transparent;
            this.picMiCarta.Location = new System.Drawing.Point(96, 38);
            this.picMiCarta.Name = "picMiCarta";
            this.picMiCarta.Size = new System.Drawing.Size(140, 200);
            this.picMiCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMiCarta.TabIndex = 0;
            this.picMiCarta.TabStop = false;
            // 
            // picCartaRival
            // 
            this.picCartaRival.BackColor = System.Drawing.Color.Transparent;
            this.picCartaRival.Location = new System.Drawing.Point(552, 38);
            this.picCartaRival.Name = "picCartaRival";
            this.picCartaRival.Size = new System.Drawing.Size(140, 200);
            this.picCartaRival.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            this.btnAtacar.Location = new System.Drawing.Point(340, 187);
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
            // picMiCarta1
            // 
            this.picMiCarta1.Location = new System.Drawing.Point(69, 329);
            this.picMiCarta1.Name = "picMiCarta1";
            this.picMiCarta1.Size = new System.Drawing.Size(62, 87);
            this.picMiCarta1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMiCarta1.TabIndex = 5;
            this.picMiCarta1.TabStop = false;
            // 
            // picMiCarta3
            // 
            this.picMiCarta3.Location = new System.Drawing.Point(227, 329);
            this.picMiCarta3.Name = "picMiCarta3";
            this.picMiCarta3.Size = new System.Drawing.Size(62, 87);
            this.picMiCarta3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMiCarta3.TabIndex = 6;
            this.picMiCarta3.TabStop = false;
            // 
            // picMiCarta2
            // 
            this.picMiCarta2.Location = new System.Drawing.Point(147, 329);
            this.picMiCarta2.Name = "picMiCarta2";
            this.picMiCarta2.Size = new System.Drawing.Size(62, 87);
            this.picMiCarta2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMiCarta2.TabIndex = 7;
            this.picMiCarta2.TabStop = false;
            // 
            // picRCarta1
            // 
            this.picRCarta1.Location = new System.Drawing.Point(533, 310);
            this.picRCarta1.Name = "picRCarta1";
            this.picRCarta1.Size = new System.Drawing.Size(62, 87);
            this.picRCarta1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRCarta1.TabIndex = 8;
            this.picRCarta1.TabStop = false;
            // 
            // picRCarta2
            // 
            this.picRCarta2.Location = new System.Drawing.Point(613, 310);
            this.picRCarta2.Name = "picRCarta2";
            this.picRCarta2.Size = new System.Drawing.Size(62, 87);
            this.picRCarta2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRCarta2.TabIndex = 9;
            this.picRCarta2.TabStop = false;
            // 
            // picRCarta3
            // 
            this.picRCarta3.Location = new System.Drawing.Point(699, 310);
            this.picRCarta3.Name = "picRCarta3";
            this.picRCarta3.Size = new System.Drawing.Size(62, 87);
            this.picRCarta3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRCarta3.TabIndex = 10;
            this.picRCarta3.TabStop = false;
            // 
            // btnAtaque1
            // 
            this.btnAtaque1.Location = new System.Drawing.Point(12, 284);
            this.btnAtaque1.Name = "btnAtaque1";
            this.btnAtaque1.Size = new System.Drawing.Size(75, 23);
            this.btnAtaque1.TabIndex = 11;
            this.btnAtaque1.Text = "btnAtaque1";
            this.btnAtaque1.UseVisualStyleBackColor = true;
            // 
            // btnAtaque2
            // 
            this.btnAtaque2.Location = new System.Drawing.Point(96, 284);
            this.btnAtaque2.Name = "btnAtaque2";
            this.btnAtaque2.Size = new System.Drawing.Size(75, 23);
            this.btnAtaque2.TabIndex = 12;
            this.btnAtaque2.Text = "button2";
            this.btnAtaque2.UseVisualStyleBackColor = true;
            // 
            // btnAtaque3
            // 
            this.btnAtaque3.Location = new System.Drawing.Point(186, 284);
            this.btnAtaque3.Name = "btnAtaque3";
            this.btnAtaque3.Size = new System.Drawing.Size(75, 23);
            this.btnAtaque3.TabIndex = 13;
            this.btnAtaque3.Text = "button3";
            this.btnAtaque3.UseVisualStyleBackColor = true;
            // 
            // btnAtaque4
            // 
            this.btnAtaque4.Location = new System.Drawing.Point(282, 284);
            this.btnAtaque4.Name = "btnAtaque4";
            this.btnAtaque4.Size = new System.Drawing.Size(75, 23);
            this.btnAtaque4.TabIndex = 14;
            this.btnAtaque4.Text = "button4";
            this.btnAtaque4.UseVisualStyleBackColor = true;
            // 
            // btnRAtaque1
            // 
            this.btnRAtaque1.Location = new System.Drawing.Point(453, 284);
            this.btnRAtaque1.Name = "btnRAtaque1";
            this.btnRAtaque1.Size = new System.Drawing.Size(75, 23);
            this.btnRAtaque1.TabIndex = 15;
            this.btnRAtaque1.Text = "button1";
            this.btnRAtaque1.UseVisualStyleBackColor = true;
            // 
            // btnRAtaque2
            // 
            this.btnRAtaque2.Location = new System.Drawing.Point(534, 284);
            this.btnRAtaque2.Name = "btnRAtaque2";
            this.btnRAtaque2.Size = new System.Drawing.Size(75, 23);
            this.btnRAtaque2.TabIndex = 16;
            this.btnRAtaque2.Text = "button2";
            this.btnRAtaque2.UseVisualStyleBackColor = true;
            // 
            // btnRAtaque3
            // 
            this.btnRAtaque3.Location = new System.Drawing.Point(633, 284);
            this.btnRAtaque3.Name = "btnRAtaque3";
            this.btnRAtaque3.Size = new System.Drawing.Size(75, 23);
            this.btnRAtaque3.TabIndex = 17;
            this.btnRAtaque3.Text = "button3";
            this.btnRAtaque3.UseVisualStyleBackColor = true;
            // 
            // btnRAtaque4
            // 
            this.btnRAtaque4.Location = new System.Drawing.Point(714, 281);
            this.btnRAtaque4.Name = "btnRAtaque4";
            this.btnRAtaque4.Size = new System.Drawing.Size(75, 23);
            this.btnRAtaque4.TabIndex = 18;
            this.btnRAtaque4.Text = "button4";
            this.btnRAtaque4.UseVisualStyleBackColor = true;
            // 
            // lblNarrador
            // 
            this.lblNarrador.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.lblNarrador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNarrador.ForeColor = System.Drawing.Color.White;
            this.lblNarrador.Location = new System.Drawing.Point(337, 357);
            this.lblNarrador.Name = "lblNarrador";
            this.lblNarrador.Size = new System.Drawing.Size(137, 84);
            this.lblNarrador.TabIndex = 19;
            this.lblNarrador.Text = "label1";
            // 
            // FormBatalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNarrador);
            this.Controls.Add(this.btnRAtaque4);
            this.Controls.Add(this.btnRAtaque3);
            this.Controls.Add(this.btnRAtaque2);
            this.Controls.Add(this.btnRAtaque1);
            this.Controls.Add(this.btnAtaque4);
            this.Controls.Add(this.btnAtaque3);
            this.Controls.Add(this.btnAtaque2);
            this.Controls.Add(this.btnAtaque1);
            this.Controls.Add(this.picRCarta3);
            this.Controls.Add(this.picRCarta2);
            this.Controls.Add(this.picRCarta1);
            this.Controls.Add(this.picMiCarta2);
            this.Controls.Add(this.picMiCarta3);
            this.Controls.Add(this.picMiCarta1);
            this.Controls.Add(this.btnAtacar);
            this.Controls.Add(this.pbMiHp);
            this.Controls.Add(this.pbHpRival);
            this.Controls.Add(this.picCartaRival);
            this.Controls.Add(this.picMiCarta);
            this.Name = "FormBatalla";
            this.Text = "Batalla";
            this.Load += new System.EventHandler(this.FormBatalla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartaRival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiCarta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRCarta1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRCarta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRCarta3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMiCarta;
        private System.Windows.Forms.PictureBox picCartaRival;
        private System.Windows.Forms.ProgressBar pbHpRival;
        private System.Windows.Forms.ProgressBar pbMiHp;
        private System.Windows.Forms.Button btnAtacar;
        private System.Windows.Forms.Timer timerAnimacion;
        private System.Windows.Forms.PictureBox picMiCarta1;
        private System.Windows.Forms.PictureBox picMiCarta3;
        private System.Windows.Forms.PictureBox picMiCarta2;
        private System.Windows.Forms.PictureBox picRCarta1;
        private System.Windows.Forms.PictureBox picRCarta2;
        private System.Windows.Forms.PictureBox picRCarta3;
        private System.Windows.Forms.Button btnAtaque1;
        private System.Windows.Forms.Button btnAtaque2;
        private System.Windows.Forms.Button btnAtaque3;
        private System.Windows.Forms.Button btnAtaque4;
        private System.Windows.Forms.Button btnRAtaque1;
        private System.Windows.Forms.Button btnRAtaque2;
        private System.Windows.Forms.Button btnRAtaque3;
        private System.Windows.Forms.Button btnRAtaque4;
        private System.Windows.Forms.Label lblNarrador;
    }
}