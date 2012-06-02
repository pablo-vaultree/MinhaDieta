using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MinhaDieta.Models.Entidades;
using MinhaDieta.Models.ViewModel;

namespace MinhaDieta.Models.DAL
{
    public class MinhaDietaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Refeicao> Refeicoes { get; set; }
        public DbSet<Medida> Medidas { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }    
    }
}