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

        public MedidaController() 
        {
            repMedida = new MedidaRepository();
        }

        [Authorize]
        public ActionResult PrimeirasMedidas() 
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult SalvarMedidas(MedidaViewModel model)
        {
            if (ModelState.IsValid)
            {                                
                var medida = Mapper.Map<MedidaViewModel, Medida>(model);
                
                UsuarioRepository repUsuario = new UsuarioRepository();
                var usuario = repUsuario.BuscarPeloNome(HttpContext.User.Identity.Name);
                medida.Usuario = usuario;
                repMedida.Adicionar(medida);

                return RedirectToAction("Dashboard", "Usuario");
            }
            return View("PrimeirasMedidas", model);
        }
    }
}
