using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Garrafeira
    {
        public Garrafeira()
        {
            Inserir = new HashSet<Inserir>();
        }

        public int IdGarrafeira { get; set; }
        public string EnderecoCodigo { get; set; }
        public string EnderecoMorada { get; set; }
        public string EnderecoLocalidade { get; set; }

        public Utilizador IdGarrafeiraNavigation { get; set; }
        public ICollection<Inserir> Inserir { get; set; }
    }
}
