using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinhaDieta.Models.ViewModel
{
    public class CadastroAlimentoViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do alimento.")]
        [StringLength(128)]
        public string Nome { get; set; }

        [Display(Name = "Quantidade unitária")]
        [Required(ErrorMessage = "Informe a quantidade unitária do alimento.")]
        public decimal Quantidade { get; set; }

        [Display(Name = "Valor calórico")]
        [Required(ErrorMessage = "Informe o valor calórico do alimento.")]
        public decimal ValorCalorico { get; set; }      
    }    
}