using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Sugerir
    {
        public int IdClienteEnvia { get; set; }
        public int IdClienteRecebe { get; set; }
        public int IdVinho { get; set; }
        public bool? EstadoNotificacao { get; set; }
        public DateTime DataSugestao { get; set; }
        public string TextoSugestao { get; set; }

        public Cliente IdClienteEnviaNavigation { get; set; }
        public Cliente IdClienteRecebeNavigation { get; set; }
        public Vinho IdVinhoNavigation { get; set; }
    }
}
