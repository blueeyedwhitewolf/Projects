using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Produtor
    {
        public Produtor()
        {
            Possuir = new HashSet<Possuir>();
        }

        public int IdProdutor { get; set; }
        public string NomeProdutor { get; set; }

        public ICollection<Possuir> Possuir { get; set; }
    }
}
