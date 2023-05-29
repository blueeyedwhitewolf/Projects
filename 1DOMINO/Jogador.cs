using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DOMINO
{
    public class Jogador
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        int Vitorias { get; set; } // = pontuação
        int Derrotas { get; set; }
        int Iniciados { get; set; }
        int Abandonados { get; set; }
        bool Turno { get; set; } //flag (0=não pode jogar; 1 = é a sua vez de jogar)
        public List<Peca> Mao { get; set; } //peças que o jogador possui  

        public Jogador()
        {

        }

        public Jogador(string nome,string email,string pais)
        {
            Nome = nome;
            Email = email;
            Pais = pais;
        }


    }
}
