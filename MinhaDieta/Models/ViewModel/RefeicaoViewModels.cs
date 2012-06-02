using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Models.ViewModel
{
    public class RefeicaoViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data da refeição")]
        [Required(ErrorMessage = "Informe a data da refeição.")]
        public string Data { get; set; }
        
        [Display(Name = "Alimentos")]
        [Required(ErrorMessage = "Informe no minímo um alimento para cadastrar a refeição.")]
        public List<Alimento> Alimentos { get; set; }

        public IEnumerable<SelectListItem> SelectAlimentos { get; set; }      
        
        public List<Refeicao> Refeicoes { get; set; }      
    } 
}