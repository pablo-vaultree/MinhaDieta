using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Models.DAL
{
    public class BaseRepository
    {
        protected MinhaDietaContext db;

        public BaseRepository() 
        {
            db = new MinhaDietaContext();
        }

        public void Salvar()
        {
            db.SaveChanges();
        }        
    }
}