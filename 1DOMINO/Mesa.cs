using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace _1DOMINO
{
    public class Mesa
    {
        List<Peca> Banco_Pecas = new List<Peca>();//lista peças do banco

        Jogador Jogador = new Jogador();
        Random rand = new Random(DateTime.Now.Millisecond);

        public List<Peca> Criar_Banco()
        {
            Peca zero_zero = new Peca(0,0);
            Peca zero_um = new Peca(0, 1);
            Peca zero_dois = new Peca(0, 2);
            Peca zero_tres = new Peca(0, 3);
            Peca zero_quatro = new Peca(0, 4);
            Peca zero_cinco = new Peca(0, 5);
            Peca zero_seis = new Peca(0, 6);
            Peca um_um = new Peca(1, 1);
            Peca um_dois = new Peca(1, 2);
            Peca um_tres = new Peca(1, 3);
            Peca um_quatro = new Peca(1, 4);
            Peca um_cinco = new Peca(1, 5);
            Peca um_seis = new Peca(1, 6);
            Peca dois_dois = new Peca(2, 2);
            Peca dois_tres = new Peca(2, 3);
            Peca dois_quatro = new Peca(2, 4);
            Peca dois_cinco = new Peca(2, 5);
            Peca dois_seis = new Peca(2, 6);
            Peca tres_tres = new Peca(3, 3);
            Peca tres_quatro = new Peca(3, 4);
            Peca tres_cinco = new Peca(3, 5);
            Peca tres_seis = new Peca(3, 6);
            Peca quatro_quatro = new Peca(4, 4);
            Peca quatro_cinco = new Peca(4, 5);
            Peca quatro_seis = new Peca(4, 6);
            Peca cinco_cinco = new Peca(5, 5);
            Peca cinco_seis = new Peca(5, 6);
            Peca seis_seis = new Peca(6, 6);
       
       
            Banco_Pecas.Add(zero_zero);
            Banco_Pecas.Add(zero_um);
            Banco_Pecas.Add(zero_dois);
            Banco_Pecas.Add(zero_tres);
            Banco_Pecas.Add(zero_quatro);
            Banco_Pecas.Add(zero_cinco);
            Banco_Pecas.Add(zero_seis);
            Banco_Pecas.Add(um_um);
            Banco_Pecas.Add(um_dois);
            Banco_Pecas.Add(um_tres);
            Banco_Pecas.Add(um_quatro);
            Banco_Pecas.Add(um_cinco);
            Banco_Pecas.Add(um_seis);
            Banco_Pecas.Add(dois_dois);
            Banco_Pecas.Add(dois_tres);
            Banco_Pecas.Add(dois_quatro);
            Banco_Pecas.Add(dois_cinco);
            Banco_Pecas.Add(dois_seis);
            Banco_Pecas.Add(tres_tres);
            Banco_Pecas.Add(tres_quatro);
            Banco_Pecas.Add(tres_cinco);
            Banco_Pecas.Add(tres_seis);
            Banco_Pecas.Add(quatro_quatro);
            Banco_Pecas.Add(quatro_cinco);
            Banco_Pecas.Add(quatro_seis);
            Banco_Pecas.Add(cinco_cinco);
            Banco_Pecas.Add(cinco_seis);
            Banco_Pecas.Add(seis_seis);

            return (Banco_Pecas);
        }

          

    List<Peca> jogadas { get; set; } //peças na mesa que ja foram jogadas

        public void atribuir_pecas()
        {
            //Atribuir peças ao jogador, deixar as restantes no banco
            Peca aux; 
            for (int i = 1; i < 7; i++)
            {
                aux = Banco_Pecas[rand.Next(Banco_Pecas.Count)];
                Jogador.Mao.Add(aux); //adiciona peça aleatória à lista Mao do Jogador
            }
        }

        public bool validar_peca()
        {
            return true;
        }

        List<Jogador> a_jogar { get; set; } // lista dos jogadores em jogo

        int gestor_mesa; //criar indice para um gestor de mesa, para decidir quem joga
         
        //Jogador this [Jogador indice]
        //{

        //}

    }
}
