using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Comentar = new HashSet<Comentar>();
            SugerirIdClienteEnviaNavigation = new HashSet<Sugerir>();
            SugerirIdClienteRecebeNavigation = new HashSet<Sugerir>();
        }

        public int IdCliente { get; set; }

        public Utilizador IdClienteNavigation { get; set; }
        public ICollection<Comentar> Comentar { get; set; }
        public ICollection<Sugerir> SugerirIdClienteEnviaNavigation { get; set; }
        public ICollection<Sugerir> SugerirIdClienteRecebeNavigation { get; set; }
    }
}
