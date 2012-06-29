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
    public class MedidaController : Controller
    {
        MedidaRepository repMedida;
        UsuarioRepository repUsuario; 

        public MedidaController() 
        {
            MinhaDietaContext db = new MinhaDietaContext();
            repUsuario  = new UsuarioRepository(db);
            repMedida = new MedidaRepository(db);
        }

        [Authorize]
        public ActionResult PrimeirasMedidas() 
        {
            return View("InformarMedidas");
        }

        [Authorize]
        public ActionResult Visualizar(int id)
        {
            Medida medida = repMedida.BuscarPeloId(id);
            var model = Mapper.Map<Medida, MedidaViewModel>(medida);
            model.Medidas = repMedida.BuscarTodos();
            return View("InformarMedidas", model);
        }

        [Authorize]
        public ActionResult InformarMedidas()
        {
            MedidaViewModel model = new MedidaViewModel();
            model.Medidas = repMedida.BuscarTodos();
            return View("InformarMedidas", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SalvarMedidas(MedidaViewModel model)
        {
            if (ModelState.IsValid)
            {                                
                var medida = Mapper.Map<MedidaViewModel, Medida>(model);

                TryUpdateModel(medida);
                
                var usuario = repUsuario.BuscarPeloNome(HttpContext.User.Identity.Name);
                medida.Usuario = usuario;
                if (medida.Id != null && medida.Id != 0)
                {
                    repMedida.Alterar(medida);
                }
                else
                {
                    repMedida.Adicionar(medida);
                }
                

                return RedirectToAction("Dashboard", "Usuario");
            }
            return View("InformarMedidas", model);
        }

        protected override void Dispose(bool disposing)
        {
            repMedida.Dispose();
            base.Dispose(disposing);
        }
    }
}
