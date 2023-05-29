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
    public partial class ModoServidor : Form
    {
        public ModoServidor()
        {
            InitializeComponent();
        }

        private void buttonServidores_Click(object sender, EventArgs e)
        {
            //Abrir janela para ver jogadores online
            VerLigados dlg = new VerLigados();
            dlg.ShowDialog();
        }

        private void buttonIniciarOn_Click(object sender, EventArgs e)
        {
            //Abrir janela para iniciar jogo online
            ViewMesa dlg = new ViewMesa();
            dlg.ShowDialog();
        }
    }
}
