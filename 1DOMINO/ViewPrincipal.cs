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
    public partial class ViewPrincipal : Form
    {
        public ViewPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Quantos jogadores são?");
            int num = Convert.ToInt32(Console.ReadLine());

            //Abrir janela de jogo ao clicar em "Iniciar Jogo" para 
            //decidir numero de jogadores
            ViewDecidirJogadores dlg = new ViewDecidirJogadores();
            dlg.ShowDialog();

            
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            //Abrir janela Perfil 
            ViewPerfil dlg = new ViewPerfil();
            dlg.ShowDialog();

        }

        private void buttonRede_Click(object sender, EventArgs e)
        {
            //Abrir opções em rede
            ViewRede dlg = new _1DOMINO.ViewRede();
            dlg.ShowDialog();
        }

        private void ViewPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
