using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Regiao
    {
        public Regiao()
        {
            Possuir = new HashSet<Possuir>();
        }

        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }

        public ICollection<Possuir> Possuir { get; set; }
    }
}
