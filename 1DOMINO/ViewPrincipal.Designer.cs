namespace _1DOMINO
{
    partial class ViewPrincipal
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
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.buttonRede = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(195, 278);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(187, 35);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar Jogo";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnPerfil
            // 
            this.btnPerfil.Location = new System.Drawing.Point(195, 319);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(187, 35);
            this.btnPerfil.TabIndex = 1;
            this.btnPerfil.Text = "Perfil";
            this.btnPerfil.UseVisualStyleBackColor = true;
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // buttonRede
            // 
            this.buttonRede.Location = new System.Drawing.Point(195, 360);
            this.buttonRede.Name = "buttonRede";
            this.buttonRede.Size = new System.Drawing.Size(187, 35);
            this.buttonRede.TabIndex = 3;
            this.buttonRede.Text = "Em rede";
            this.buttonRede.UseVisualStyleBackColor = true;
            this.buttonRede.Click += new System.EventHandler(this.buttonRede_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_1DOMINO.Properties.Resources.apr;
            this.pictureBox1.Location = new System.Drawing.Point(37, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(492, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ViewPrincipal
            // 
            this.AcceptButton = this.btnIniciar;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(580, 407);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonRede);
            this.Controls.Add(this.btnPerfil);
            this.Controls.Add(this.btnIniciar);
            this.Name = "ViewPrincipal";
            this.Text = "Vamos ao jogoooo";
            this.Load += new System.EventHandler(this.ViewPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Button buttonRede;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

