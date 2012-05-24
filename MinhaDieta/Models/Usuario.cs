using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MinhaDieta.Models
{
    public class Usuario
    {
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Genero")]
        public string Genre { get; set; }
        
        [Display(Name = "Altura")]
        public decimal Altura { get; set; }
        
        [Display(Name = "Peso")]
        public decimal Peso { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
      
    public class UsuarioDBContext : DbContext
    {
        private DbSet<Usuario> Usuarios { get; set; }

        public Usuario BuscarUsuarioPeloId(int id)
        {
            return Usuarios.Where(u => u.ID == id).SingleOrDefault();
        }

        public Usuario BuscarUsuarioPeloNome(string nome)
        {
            return Usuarios.Where(u => u.Nome.Equals(nome)).SingleOrDefault();
        }
    }
}