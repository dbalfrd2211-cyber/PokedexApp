namespace PokedexApp
{
    partial class FormHistorialIntercambios
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
            this.DGVHistorial = new System.Windows.Forms.DataGridView();
            this.DTPHistorial = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVHistorial
            // 
            this.DGVHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistorial.Location = new System.Drawing.Point(28, 73);
            this.DGVHistorial.Name = "DGVHistorial";
            this.DGVHistorial.RowHeadersWidth = 51;
            this.DGVHistorial.RowTemplate.Height = 24;
            this.DGVHistorial.Size = new System.Drawing.Size(970, 450);
            this.DGVHistorial.TabIndex = 0;
            // 
            // DTPHistorial
            // 
            this.DTPHistorial.Location = new System.Drawing.Point(408, 25);
            this.DTPHistorial.Name = "DTPHistorial";
            this.DTPHistorial.Size = new System.Drawing.Size(200, 22);
            this.DTPHistorial.TabIndex = 1;
            this.DTPHistorial.ValueChanged += new System.EventHandler(this.DTPHistorial_ValueChanged);
            // 
            // FormHistorialIntercambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 544);
            this.Controls.Add(this.DTPHistorial);
            this.Controls.Add(this.DGVHistorial);
            this.MaximizeBox = false;
            this.Name = "FormHistorialIntercambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HistorialIntercambios";
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVHistorial;
        private System.Windows.Forms.DateTimePicker DTPHistorial;
    }
}