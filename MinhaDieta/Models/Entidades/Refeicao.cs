using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinhaDieta.Models.Entidades
{
    public class Refeicao
    {
        public Refeicao() 
        {
            Alimentos = new List<Alimento>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public virtual ICollection<Alimento> Alimentos { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}