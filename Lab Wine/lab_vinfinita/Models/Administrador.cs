using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            Gerir = new HashSet<Gerir>();
        }

        public int IdAdministrador { get; set; }

        public Utilizador IdAdministradorNavigation { get; set; }
        public ICollection<Gerir> Gerir { get; set; }
    }
}
