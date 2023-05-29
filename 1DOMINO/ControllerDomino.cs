using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DOMINO
{
    public class ControllerDomino
    {
        public ControllerDomino()
        {
            Program.V_EditarPerfilPessoal.EnviarDados += V_EditarPerfilPessoal_EnviarDados;
        }

        private void V_EditarPerfilPessoal_EnviarDados(string caminho, string nome, string email, string pais)
        {
            Program.M_Domino.GuardarDadosJog(caminho, nome, email, pais);
        }
    }
}
