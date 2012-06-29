using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Models.DAL
{
    public class AlimentoRepository : IDisposable
    {
        private MinhaDietaContext db;
        public AlimentoRepository(MinhaDietaContext _db) 
        {
            db = _db;
        }

        public void Salvar()
        {
            db.SaveChanges();
        } 
      
        public void Inserir(Alimento alimento) 
        {
            db.Alimentos.Add(alimento);
            this.Salvar();
        }
        
        public void Alterar(Alimento alimento)
        {
            db.Entry(alimento).State = EntityState.Modified;
            this.Salvar();
        }

        public void Excluir(Alimento alimento)
        {
            db.Alimentos.Remove(alimento);
            this.Salvar();
        }

        public List<Alimento> BuscarTodos()
        {
            return db.Alimentos.ToList();
        }     

        public Alimento BuscarPorId(int id)
        {
            return db.Alimentos.Where(u => u.Id == id).SingleOrDefault();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}