using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Inserir
    {
        public int IdGarrafeira { get; set; }
        public int IdVinho { get; set; }
        public double Preco { get; set; }
        public int Stock { get; set; }
        public DateTime DataInsercao { get; set; }

        public Garrafeira IdGarrafeiraNavigation { get; set; }
        public Vinho IdVinhoNavigation { get; set; }
    }
}
