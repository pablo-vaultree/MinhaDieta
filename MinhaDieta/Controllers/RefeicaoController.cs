using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinhaDieta.Models.ViewModel;
using MinhaDieta.Models.DAL;
using AutoMapper;
using MinhaDieta.Models.Entidades;

namespace MinhaDieta.Controllers
{
    public class RefeicaoController : Controller
    {
        private RefeicaoRepository repRefeicao;
        private AlimentoRepository repAlimento;
        private UsuarioRepository repUsuario;

        public RefeicaoController() 
        {
            MinhaDietaContext db = new MinhaDietaContext();
            repRefeicao = new RefeicaoRepository(db);
            repAlimento = new AlimentoRepository(db);
            repUsuario = new UsuarioRepository(db);
        }

        
        public ActionResult Index()
        {
            RefeicaoViewModel viewmodel = new RefeicaoViewModel();
            viewmodel.Refeicoes = repRefeicao.BuscarTodos();
            var alimentos = repAlimento.BuscarTodos();
            viewmodel.SelectAlimentos = new MultiSelectList(alimentos, "Id", "Nome", "");
            return View(viewmodel);
        }

        public ActionResult Visualizar(int id)
        {
            var refeicao = repRefeicao.BuscarPorId(id);                        
            return View(refeicao);
        }

        [HttpPost]
        public ActionResult Salvar(RefeicaoViewModel model) 
        {            
            if (ModelState.IsValid)
            {
                var refeicao = new Refeicao();
                refeicao.Data = Convert.ToDateTime(model.Data);
                var usuario = repUsuario.BuscarPeloNome(HttpContext.User.Identity.Name);
                refeicao.Usuario = usuario;

                foreach (int id in model.Alimentos)                
                {
                    var alimento = repAlimento.BuscarPorId(id);
                    refeicao.Alimentos.Add(alimento);
                }
                repRefeicao.Inserir(refeicao);
                return RedirectToAction("Index");
            }

            model.Refeicoes = repRefeicao.BuscarTodos();
            var alimentos = repAlimento.BuscarTodos();
            model.SelectAlimentos = new MultiSelectList(alimentos, "Id", "Nome", "");
            return View("Index", model);
        }
        
        
        protected override void Dispose(bool disposing)
        {
            repRefeicao.Dispose();
            base.Dispose(disposing);
        }
    }
}