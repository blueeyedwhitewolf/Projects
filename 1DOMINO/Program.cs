using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1DOMINO
{
    static class Program
    {
        public static ViewDecidirJogadores V_DecidirJogadores { get; private set; }
        public static ViewEditarPerfilPessoal V_EditarPerfilPessoal { get; private set; }
        public static ViewMesa V_Mesa { get; private set; }
        public static ViewPerfil V_Perfil { get; private set; }
        public static ViewPrincipal V_Principal { get; private set; }
        public static LigarServidor V_LigarServidor { get; private set; }
        public static ModoServidor V_ModoServidor { get; private set; }
        public static ServidoresDisponiveis V_ServidoresDisponiveis { get; private set; }
        public static VerLigados V_VerLigados { get; private set; }
        public static ViewRede V_Rede { get; private set; }
        public static ModelDomino M_Domino { get; private set; }
        public static ControllerDomino C_Domino { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            M_Domino = new ModelDomino();
            V_DecidirJogadores = new ViewDecidirJogadores();
            V_EditarPerfilPessoal = new ViewEditarPerfilPessoal();
            V_Mesa = new ViewMesa();
            V_Perfil = new ViewPerfil();
            V_Principal = new ViewPrincipal();
            V_LigarServidor = new LigarServidor();
            V_ModoServidor = new ModoServidor();
            V_ServidoresDisponiveis = new ServidoresDisponiveis();
            V_VerLigados = new VerLigados();
            V_Rede = new ViewRede();
            C_Domino = new ControllerDomino();

            Application.Run(V_Principal);
        }
    }
}
