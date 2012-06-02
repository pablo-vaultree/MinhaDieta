using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using MinhaDieta.Models.DAL;
using MinhaDieta.Models.Entidades;
using MinhaDieta.Models.ViewModel;

namespace MinhaDieta.Controllers
{

    [Authorize]
    public class AlimentoController : Controller
    {

        AlimentoRepository repAlimento;

        public AlimentoController() 
        {
            repAlimento = new AlimentoRepository();
        }

        public ActionResult Index() 
        {
            var alimentos = repAlimento.BuscarTodos();
            return View(alimentos);
        }

        public ActionResult Criar() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(CadastroAlimentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var alimento = Mapper.Map<CadastroAlimentoViewModel, Alimento>(model);
                repAlimento.Inserir(alimento);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Editar(int Id)
        {
            var alimento = repAlimento.BuscarPorId(Id);
            CadastroAlimentoViewModel viewmodel = Mapper.Map<Alimento, CadastroAlimentoViewModel>(alimento);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Editar(CadastroAlimentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var alimento = Mapper.Map<CadastroAlimentoViewModel, Alimento>(model);
                repAlimento.Alterar(alimento);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Excluir(int Id)
        {
            var alimento = repAlimento.BuscarPorId(Id);
            repAlimento.Excluir(alimento);
            return RedirectToAction("Index");
        }
    }
}
