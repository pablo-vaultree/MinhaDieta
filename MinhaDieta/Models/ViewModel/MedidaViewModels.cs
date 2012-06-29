using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Models.ViewModel
{
    public class MedidaViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Informe o peso.")]
        public decimal Peso { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Altura")]
        public decimal? Altura { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Braço")]        
        public decimal? Braco { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Quadril")]        
        public decimal? Quadril { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Abdomen")]
        public decimal? Abdomen { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Pescoço")]                
        public decimal? Pescoco { get; set; }

        public List<Medida> Medidas { get; set; }
    }    
}