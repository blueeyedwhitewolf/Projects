using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DOMINO
{
    public class Peca
    {
        int ext_dir;
        int ext_esq;
        bool orientacao; // 1 = vertical
                         // 0 = horizontal
        bool desenha; 
       

        //Construtor da peça
        public Peca(int _ext_dir, int _ext_esq)
        {
            ext_dir= _ext_dir;
            ext_esq = _ext_esq; ;

            if (ext_dir == ext_esq) orientacao = true; 
            //se a peça tiver nrs iguais desenha na vertical
        }

        public int Ext_dir { get; set; }
        public int Ext_esq { get; set; }
        public int Orientacao{ get; set; }

        //Gerar nrs aleatórios 
        public int aleatorio(int min, int max)
        {

            Random randNum = new Random();
            return randNum.Next();

        }
    }
}
