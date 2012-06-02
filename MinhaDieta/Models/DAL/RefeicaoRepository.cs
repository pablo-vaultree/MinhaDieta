using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Models.DAL
{
    public class RefeicaoRepository : IDisposable
    {
        MinhaDietaContext db;

        public RefeicaoRepository() 
        {
            db = new MinhaDietaContext();
        }

        public void Salvar()
        {
            db.SaveChanges();
        }

        public void Inserir(Refeicao Refeicao) 
        {
            db.Refeicoes.Add(Refeicao);
            this.Salvar();
        }
        
        public void Alterar(Refeicao Refeicao)
        {
            db.Entry(Refeicao).State = EntityState.Modified;
            this.Salvar();
        }

        public void Excluir(Refeicao Refeicao)
        {
            db.Refeicoes.Remove(Refeicao);
            this.Salvar();
        }

        public List<Refeicao> BuscarTodos()
        {
            return db.Refeicoes.ToList();
        }     

        public Refeicao BuscarPorId(int id)
        {
            return db.Refeicoes.Where(u => u.Id == id).SingleOrDefault();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}