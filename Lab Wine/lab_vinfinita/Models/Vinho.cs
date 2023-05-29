using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab_vinfinita.Models
{
    public partial class Vinho
    {
        public Vinho()
        {
            Comentar = new HashSet<Comentar>();
            Inserir = new HashSet<Inserir>();
            Sugerir = new HashSet<Sugerir>();
        }

        public int IdVinho { get; set; }

        [Display(Name ="Nome do Vinho")]
        public string NomeVinho { get; set; }

        [Display(Name = "Capacidade(cl)")]
        public double Capacidade { get; set; }


        [DataType(DataType.Upload)]
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Só Jpg's")]
        [Display(Name = "Foto frente")]
        public string FotoFrente { get; set; }

        [DataType(DataType.Upload)]
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Só Jpg's")]
        [Display(Name = "Foto trás")]
        public string FotoTras { get; set; }

        [DataType(DataType.Upload)]
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Só Jpg's")]
        [Display(Name = "Foto rotulo")]
        public string FotoRotulo { get; set; }

        [Display(Name = "Teor Alcóolico (º)")]
        public double TeorAlcoolico { get; set; }
        public string Castas { get; set; }

        [Display(Name = "Ano de produção")]
        public int AnoProducao { get; set; }

        public int Stock { get; set; }

        [Display(Name = "Preço €")]
        public int Preco { get; set; }

        [Display(Name = "Data inserção")]
        public DateTime DataInsercao { get; set; }

        public int IdProdutor { get; set; }

        public int IdRegiao { get; set; }

        public int IdTipo { get; set; }

        public Possuir Possuir { get; set; }
        public ICollection<Comentar> Comentar { get; set; }
        public ICollection<Inserir> Inserir { get; set; }
        public ICollection<Sugerir> Sugerir { get; set; }
    }
}
