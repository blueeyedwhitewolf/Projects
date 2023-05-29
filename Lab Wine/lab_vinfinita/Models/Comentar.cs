using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Comentar
    {
        public int IdCliente { get; set; }
        public int IdVinho { get; set; }
        public int Rating { get; set; }
        public string TextoOpiniao { get; set; }
        public DateTime DataComentario { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Vinho IdVinhoNavigation { get; set; }
    }
}
