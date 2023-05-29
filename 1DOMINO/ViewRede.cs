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
    public partial class ViewRede : Form
    {
        public ViewRede()
        {
            InitializeComponent();
        }

        private void buttonServidores_Click(object sender, EventArgs e)
        {
            //Abrir janela para ver servidores online
            ServidoresDisponiveis dlg  = new ServidoresDisponiveis();
            dlg.ShowDialog();
        }

        private void buttonLigar_Click(object sender, EventArgs e)
        {
            //Abrir janela para ligar a um servidor existente na rede
            LigarServidor dlg = new LigarServidor();
            dlg.ShowDialog();
        }

        private void buttonComutar_Click(object sender, EventArgs e)
        {
            //Abrir janela para comutar a aplicação para o modo Servidor
            ModoServidor dlg = new ModoServidor();
            dlg.ShowDialog();
        }
    }
}
