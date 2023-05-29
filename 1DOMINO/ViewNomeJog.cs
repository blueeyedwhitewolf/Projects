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
    public partial class ViewNomeJog : Form
    {
        public ViewNomeJog()
        {
            InitializeComponent();
        }

        private void bJogar_Click(object sender, EventArgs e)
        {
            //Abrir janela de jogo ao clicar em "Iniciar" depois de decidir os jogadores
            ViewMesa dlg = new ViewMesa();
            dlg.ShowDialog();
        }

        private void bRetroceder_Click(object sender, EventArgs e)
        {
            //Voltar à View Principal
            ViewPrincipal dlg = new ViewPrincipal();
            dlg.ShowDialog();
        }
    }
}
