using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MinhaDieta.Models.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public string Nome { get; set; }
        
        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Genero { get; set; }

        public decimal Altura { get; set; }

        public decimal Peso { get; set; }

        public string Email { get; set; }
    }   
}