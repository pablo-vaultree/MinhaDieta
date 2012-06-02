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
            repRefeicao = new RefeicaoRepository();
            repAlimento = new AlimentoRepository();
            repUsuario = new UsuarioRepository();
        }

        
        public ActionResult Index()
        {
            RefeicaoViewModel viewmodel = new RefeicaoViewModel();
            viewmodel.Refeicoes = repRefeicao.BuscarTodos();
            viewmodel.SelectAlimentos = this.BuscarSelectAlimentos();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Salvar(RefeicaoViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var refeicao = Mapper.Map<RefeicaoViewModel, Refeicao>(model);
                repRefeicao.Inserir(refeicao);
                return RedirectToAction("Index");
            }

            model.Refeicoes = repRefeicao.BuscarTodos();
            model.SelectAlimentos = this.BuscarSelectAlimentos();
            return View("Index", model);
        }

        private IEnumerable<SelectListItem> BuscarSelectAlimentos()
        {
            var alimentos = repAlimento.BuscarTodos();
            List<SelectListItem> select = new List<SelectListItem>();
            foreach (var alimento in alimentos)
            {
                SelectListItem item = new SelectListItem();
                item.Text = alimento.Nome;
                item.Value = alimento.Id.ToString();
                select.Add(item);
            }
            return select.AsEnumerable();
        }
        
        protected override void Dispose(bool disposing)
        {
            repRefeicao.Dispose();
            base.Dispose(disposing);
        }
    }
}