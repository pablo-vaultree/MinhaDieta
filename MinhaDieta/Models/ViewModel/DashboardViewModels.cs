using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Models.ViewModel
{
    public class DashboardViewModel
    {
        public List<Medida> Medidas { get; set; }
        
        public List<Refeicao> Refeicoes { get; set; }    
    }    
}