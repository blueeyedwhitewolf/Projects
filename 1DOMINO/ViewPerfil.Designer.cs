namespace _1DOMINO
{
    partial class ViewPerfil
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
            this.btnEditarPessoal = new System.Windows.Forms.Button();
            this.btnConsultarqq = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditarPessoal
            // 
            this.btnEditarPessoal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnEditarPessoal.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPessoal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditarPessoal.Location = new System.Drawing.Point(50, 51);
            this.btnEditarPessoal.Name = "btnEditarPessoal";
            this.btnEditarPessoal.Size = new System.Drawing.Size(192, 39);
            this.btnEditarPessoal.TabIndex = 0;
            this.btnEditarPessoal.Text = "Editar perfil pessoal";
            this.btnEditarPessoal.UseVisualStyleBackColor = false;
            this.btnEditarPessoal.Click += new System.EventHandler(this.btnEditarPessoal_Click);
            // 
            // btnConsultarqq
            // 
            this.btnConsultarqq.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnConsultarqq.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarqq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConsultarqq.Location = new System.Drawing.Point(50, 114);
            this.btnConsultarqq.Name = "btnConsultarqq";
            this.btnConsultarqq.Size = new System.Drawing.Size(192, 54);
            this.btnConsultarqq.TabIndex = 1;
            this.btnConsultarqq.Text = "Consultar perfil dos jogadores";
            this.btnConsultarqq.UseVisualStyleBackColor = false;
            this.btnConsultarqq.Click += new System.EventHandler(this.btnConsultarqq_Click);
            // 
            // ViewPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 209);
            this.Controls.Add(this.btnConsultarqq);
            this.Controls.Add(this.btnEditarPessoal);
            this.Name = "ViewPerfil";
            this.Text = "ViewPerfil";
            this.Load += new System.EventHandler(this.ViewPerfil_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditarPessoal;
        private System.Windows.Forms.Button btnConsultarqq;
    }
}