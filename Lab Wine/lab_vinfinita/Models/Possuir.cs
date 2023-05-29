using System;
using System.Collections.Generic;

namespace lab_vinfinita.Models
{
    public partial class Possuir
    {
        public int IdVinho { get; set; }
        public int IdTipo { get; set; }
        public int IdProdutor { get; set; }
        public int IdRegiao { get; set; }

        public Produtor IdProdutorNavigation { get; set; }
        public Regiao IdRegiaoNavigation { get; set; }
        public Tipo IdTipoNavigation { get; set; }
        public Vinho IdVinhoNavigation { get; set; }
    }
}
