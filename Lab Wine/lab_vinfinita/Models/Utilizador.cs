using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab_vinfinita.Models
{
    public partial class Utilizador
    {
        public int IdUtilizador { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Display(Name ="Estado de Conta")]
        public int EstadoConta { get; set; }

        public Administrador Administrador { get; set; }
        public Cliente Cliente { get; set; }
        public Garrafeira Garrafeira { get; set; }
        public Gerir Gerir { get; set; }
    }
}
