namespace _1DOMINO
{
    partial class ViewDecidirJogadores
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbNumJog = new System.Windows.Forms.ComboBox();
            this.buttonContinuar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantos jogadores são ?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbNumJog
            // 
            this.cbNumJog.FormattingEnabled = true;
            this.cbNumJog.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.cbNumJog.Location = new System.Drawing.Point(85, 59);
            this.cbNumJog.Name = "cbNumJog";
            this.cbNumJog.Size = new System.Drawing.Size(121, 21);
            this.cbNumJog.TabIndex = 1;
            this.cbNumJog.UseWaitCursor = true;
            this.cbNumJog.SelectedIndexChanged += new System.EventHandler(this.cbNumJog_SelectedIndexChanged);
            // 
            // buttonContinuar
            // 
            this.buttonContinuar.Location = new System.Drawing.Point(213, 105);
            this.buttonContinuar.Name = "buttonContinuar";
            this.buttonContinuar.Size = new System.Drawing.Size(75, 23);
            this.buttonContinuar.TabIndex = 2;
            this.buttonContinuar.Text = "Continuar";
            this.buttonContinuar.UseVisualStyleBackColor = true;
            this.buttonContinuar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // ViewDecidirJogadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 140);
            this.Controls.Add(this.buttonContinuar);
            this.Controls.Add(this.cbNumJog);
            this.Controls.Add(this.label1);
            this.Name = "ViewDecidirJogadores";
            this.Text = "DecidirJogadores";
            this.Load += new System.EventHandler(this.ViewDecidirJogadores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNumJog;
        private System.Windows.Forms.Button buttonContinuar;
    }
}