namespace _1DOMINO
{
    partial class ModoServidor
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
            this.buttonJogOn = new System.Windows.Forms.Button();
            this.buttonIniciarOn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonJogOn
            // 
            this.buttonJogOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJogOn.Location = new System.Drawing.Point(43, 59);
            this.buttonJogOn.Name = "buttonJogOn";
            this.buttonJogOn.Size = new System.Drawing.Size(171, 39);
            this.buttonJogOn.TabIndex = 1;
            this.buttonJogOn.Text = "Jogadores Online";
            this.buttonJogOn.UseVisualStyleBackColor = true;
            this.buttonJogOn.Click += new System.EventHandler(this.buttonServidores_Click);
            // 
            // buttonIniciarOn
            // 
            this.buttonIniciarOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIniciarOn.Location = new System.Drawing.Point(43, 123);
            this.buttonIniciarOn.Name = "buttonIniciarOn";
            this.buttonIniciarOn.Size = new System.Drawing.Size(171, 39);
            this.buttonIniciarOn.TabIndex = 2;
            this.buttonIniciarOn.Text = "Iniciar Jogo Online";
            this.buttonIniciarOn.UseVisualStyleBackColor = true;
            this.buttonIniciarOn.Click += new System.EventHandler(this.buttonIniciarOn_Click);
            // 
            // ModoServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 215);
            this.Controls.Add(this.buttonIniciarOn);
            this.Controls.Add(this.buttonJogOn);
            this.Name = "ModoServidor";
            this.Text = "MudarParaServidor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonJogOn;
        private System.Windows.Forms.Button buttonIniciarOn;
    }
}