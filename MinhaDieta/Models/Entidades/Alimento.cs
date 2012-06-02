using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinhaDieta.Models.Entidades
{
    public class Alimento
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string Nome { get; set; }

        [Required]
        public decimal Quantidade { get; set; }

        [Required]
        public decimal ValorCalorico { get; set; }

        public virtual ICollection<Refeicao> Refeicoes { get; set; }
    }
}