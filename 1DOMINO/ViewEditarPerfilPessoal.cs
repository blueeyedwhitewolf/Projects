using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1DOMINO
{
    public partial class ViewEditarPerfilPessoal : Form
    {
        public event MetodosComStrings EnviarDados;
        public string nome
        {
            get
            {
                return this.textBoxNome.Text;
            }
            set
            {
                this.textBoxNome.Text = value;
            }
        }

        public string email
        {
            get
            {
                return this.textBoxEmail.Text;
            }
            set
            {
                this.textBoxEmail.Text = value;
            }
        }
        public string pais
        {
            get
            {
                return this.textBoxPais.Text;
            }
            set
            {
                this.textBoxPais.Text = value;
            }
        }



        public ViewEditarPerfilPessoal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ViewEditarPerfilPessoal_Load(object sender, EventArgs e)
        {
          
        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            Jogador jog = new Jogador(textBoxNome.Text,textBoxEmail.Text,textBoxPais.Text);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros .XML | *.XML";

            if(dlg.ShowDialog()==DialogResult.OK)
            {
                if (EnviarDados != null)
                    EnviarDados(dlg.FileName, textBoxNome.Text, textBoxEmail.Text, textBoxPais.Text);
            }
        }
    }
}
