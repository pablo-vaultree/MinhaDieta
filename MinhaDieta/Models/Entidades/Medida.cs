using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MinhaDieta.Models.Entidades
{
    public class Medida
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Peso { get; set; }

        public decimal? Altura { get; set; }

        public decimal? Braco { get; set; }

        public decimal? Quadril { get; set; }

        public decimal? Abdomen { get; set; }

        public decimal? Pescoco { get; set; }

        [Required]
        public virtual Usuario Usuario { get; set; }
    }   
}