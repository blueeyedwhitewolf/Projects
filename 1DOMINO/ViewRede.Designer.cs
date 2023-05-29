namespace _1DOMINO
{
    partial class ViewRede
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
            this.buttonServidores = new System.Windows.Forms.Button();
            this.buttonLigar = new System.Windows.Forms.Button();
            this.buttonComutar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonServidores
            // 
            this.buttonServidores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServidores.Location = new System.Drawing.Point(60, 56);
            this.buttonServidores.Name = "buttonServidores";
            this.buttonServidores.Size = new System.Drawing.Size(171, 39);
            this.buttonServidores.TabIndex = 0;
            this.buttonServidores.Text = "Servidores Disponíveis";
            this.buttonServidores.UseVisualStyleBackColor = true;
            this.buttonServidores.Click += new System.EventHandler(this.buttonServidores_Click);
            // 
            // buttonLigar
            // 
            this.buttonLigar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLigar.Location = new System.Drawing.Point(60, 112);
            this.buttonLigar.Name = "buttonLigar";
            this.buttonLigar.Size = new System.Drawing.Size(171, 39);
            this.buttonLigar.TabIndex = 1;
            this.buttonLigar.Text = "Ligar a um Servidor";
            this.buttonLigar.UseVisualStyleBackColor = true;
            this.buttonLigar.Click += new System.EventHandler(this.buttonLigar_Click);
            // 
            // buttonComutar
            // 
            this.buttonComutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComutar.Location = new System.Drawing.Point(60, 169);
            this.buttonComutar.Name = "buttonComutar";
            this.buttonComutar.Size = new System.Drawing.Size(171, 45);
            this.buttonComutar.TabIndex = 2;
            this.buttonComutar.Text = "Comutar para Modo Servidor";
            this.buttonComutar.UseVisualStyleBackColor = true;
            this.buttonComutar.Click += new System.EventHandler(this.buttonComutar_Click);
            // 
            // ViewRede
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 249);
            this.Controls.Add(this.buttonComutar);
            this.Controls.Add(this.buttonLigar);
            this.Controls.Add(this.buttonServidores);
            this.Name = "ViewRede";
            this.Text = "ViewRede";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonServidores;
        private System.Windows.Forms.Button buttonLigar;
        private System.Windows.Forms.Button buttonComutar;
    }
}