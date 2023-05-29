using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1DOMINO
{
    public class ModelDomino
    {
        public event MetodosSemStrings DadosValidos;
        public event MetodosSemStrings DadosInvalidos;
        public string _Nome { get; private set; }
        public string _Email { get; private set; }
        public string _Pais { get; private set; }
        public void GuardarDadosJog(string caminho,string nome,string email,string pais)
        {
            _Nome = nome;
            _Email = email;
            _Pais = pais;

            StreamWriter sw = new StreamWriter(caminho);
            sw.WriteLine("Dados dos perfis dos jogadores:");
            sw.WriteLine("Nome: {0};Email: {1};Pais: {2}", nome, email, pais); ;

            if (DadosValidos != null)
                DadosValidos();
        }
    }
}
