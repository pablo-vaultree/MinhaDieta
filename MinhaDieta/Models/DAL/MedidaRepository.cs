using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Models.DAL
{
    public class MedidaRepository :  IDisposable
    {        
        
        private MinhaDietaContext db;
        public MedidaRepository(MinhaDietaContext _db) 
        {
            db = _db;
        }

        public void Salvar()
        {
            db.SaveChanges();
        }

        public void Adicionar(Medida medida) 
        {            
            db.Medidas.Add(medida);
            db.Entry(medida.Usuario).State = EntityState.Modified;
            this.Salvar();
        }

        public void Alterar(Medida medida)
        {
            db.Entry(medida).State = EntityState.Modified;
            this.Salvar();
        }

        public List<Medida> BuscarTodos() 
        {
            return db.Medidas.ToList();
        }
        public Medida BuscarPeloId(int id)
        {
            return db.Medidas.Where(u => u.Id == id).SingleOrDefault();
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}