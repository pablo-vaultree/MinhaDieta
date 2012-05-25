using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinhaDieta.Models.ViewModel
{
    public class LoginViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }      
    }

    public class RegiostroViewModel
    {        
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]        
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Informe uma data de nascimento válida.")]
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Informe a data de nascimento.")]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Genero")]
        [Required(ErrorMessage = "Informe o genero.")]
        public string Genero { get; set; }

        [Display(Name = "Altura")]
        [Required(ErrorMessage = "Informe a altura.")]
        public decimal Altura { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Informe o peso.")]
        public decimal Peso { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um email válido.")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }
    }
}