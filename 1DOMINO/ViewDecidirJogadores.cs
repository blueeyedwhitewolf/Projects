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
    public partial class ViewDecidirJogadores : Form
    {
        //Método get para aceder ao nº de jogadores da combobox
        public string NumJog
        {
            get
            {
                return cbNumJog.Text;
            }
        }

        public ViewDecidirJogadores()
        {
            InitializeComponent();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbNumJog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            //Avança para view para pedir nome do jogador
            ViewNomeJog dlg = new ViewNomeJog();
            dlg.ShowDialog();
        }


        private void ViewDecidirJogadores_Load(object sender, EventArgs e)
        {

        }
    }
}