using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Possuir = new HashSet<Possuir>();
        }

        public int IdTipo { get; set; }
        public string NomeTipo { get; set; }

        public ICollection<Possuir> Possuir { get; set; }
    }
}
