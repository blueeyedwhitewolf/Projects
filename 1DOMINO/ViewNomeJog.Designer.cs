namespace _1DOMINO
{
    partial class ViewNomeJog
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
            this.txBNomeJog = new System.Windows.Forms.TextBox();
            this.bRetroceder = new System.Windows.Forms.Button();
            this.bJogar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Insira o seu nome:";
            // 
            // txBNomeJog
            // 
            this.txBNomeJog.Location = new System.Drawing.Point(156, 40);
            this.txBNomeJog.Name = "txBNomeJog";
            this.txBNomeJog.Size = new System.Drawing.Size(110, 20);
            this.txBNomeJog.TabIndex = 3;
            // 
            // bRetroceder
            // 
            this.bRetroceder.Location = new System.Drawing.Point(55, 100);
            this.bRetroceder.Name = "bRetroceder";
            this.bRetroceder.Size = new System.Drawing.Size(75, 23);
            this.bRetroceder.TabIndex = 4;
            this.bRetroceder.Text = "Retroceder";
            this.bRetroceder.UseVisualStyleBackColor = true;
            this.bRetroceder.Click += new System.EventHandler(this.bRetroceder_Click);
            // 
            // bJogar
            // 
            this.bJogar.Location = new System.Drawing.Point(191, 100);
            this.bJogar.Name = "bJogar";
            this.bJogar.Size = new System.Drawing.Size(75, 23);
            this.bJogar.TabIndex = 5;
            this.bJogar.Text = "Jogar";
            this.bJogar.UseVisualStyleBackColor = true;
            this.bJogar.Click += new System.EventHandler(this.bJogar_Click);
            // 
            // ViewNomeJog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.bJogar);
            this.Controls.Add(this.bRetroceder);
            this.Controls.Add(this.txBNomeJog);
            this.Controls.Add(this.label1);
            this.Name = "ViewNomeJog";
            this.Text = "ViewNomeJog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txBNomeJog;
        private System.Windows.Forms.Button bRetroceder;
        private System.Windows.Forms.Button bJogar;
    }
}