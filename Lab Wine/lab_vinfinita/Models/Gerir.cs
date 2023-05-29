using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Gerir
    {
        public int IdUtilizador { get; set; }
        public int IdAdministrador { get; set; }
        public string Motivo { get; set; }
        public DateTime DataRegisto { get; set; }
        public DateTime? DataSuspensao { get; set; }

        public Administrador IdAdministradorNavigation { get; set; }
        public Utilizador IdUtilizadorNavigation { get; set; }
    }
}
