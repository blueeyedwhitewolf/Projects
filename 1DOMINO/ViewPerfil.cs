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
    public partial class ViewPerfil : Form
    {
        public ViewPerfil()
        {
            InitializeComponent();
        }

        private void btnEditarPessoal_Click(object sender, EventArgs e)
        {
            //Abrir janela para editar perfil pessoal
            ViewEditarPerfilPessoal dlg = new ViewEditarPerfilPessoal();
            dlg.ShowDialog();

        }

        private void btnConsultarqq_Click(object sender, EventArgs e)
        {

        }

        private void ViewPerfil_Load(object sender, EventArgs e)
        {

        }
    }
}
