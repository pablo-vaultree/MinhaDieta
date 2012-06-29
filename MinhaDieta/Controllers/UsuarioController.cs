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
    public class UsuarioController : Controller
    {
        UsuarioRepository repUsuario;
        RefeicaoRepository repRefeicao;
        MedidaRepository repMedida;

        public UsuarioController() 
        {
            MinhaDietaContext db = new MinhaDietaContext();
            repUsuario = new UsuarioRepository(db);
            repRefeicao = new RefeicaoRepository(db);
            repMedida = new MedidaRepository(db);
        }

        [Authorize]
        public ActionResult Dashboard() 
        {
            DashboardViewModel model = new DashboardViewModel();
            model.Medidas = repMedida.BuscarTodos();
            model.Refeicoes = repRefeicao.BuscarTodos();
            return View(model);
        }
       
        #region [ Registro ]
        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registrar(RegiostroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var _user = repUsuario.BuscarPeloNome(model.Nome);
                if (_user != null)
                {
                    ModelState.AddModelError("Nome", "Nome de usuário já existente. Favor utilizar outro.");
                    return View(model);
                }

                Usuario usuario = Mapper.Map<RegiostroViewModel, Usuario>(model);
                repUsuario.Adicionar(usuario);

                FormsAuthentication.SetAuthCookie(usuario.Nome, createPersistentCookie: false);
                return RedirectToAction("PrimeirasMedidas", "Medida");
            }

            return View(model);
        }
        #endregion

        #region [ Login ]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return RetornaViewNoContexto();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (repUsuario.ValidarLogin(model.Nome, model.Senha))
                {
                    FormsAuthentication.SetAuthCookie(model.Nome, false);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Usuario");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "O usuário ou a senha informados estão incorretos.");
                }
            }

            return View(model);
        }
        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Inicio");
        }
        #endregion        

        #region Métodos Para Javascript
        /// <summary>
        /// Método utilizado para bindar uma action com o seu metódo que retorna Json
        /// </summary>        
        private ActionResult RetornaViewNoContexto()
        {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null)
            {
                ViewBag.FormAction = "Json" + actionName;
                return PartialView();
            }
            else
            {
                ViewBag.FormAction = actionName;
                return View();
            }
        }       

        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonLogin(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                
                if (repUsuario.ValidarLogin(model.Nome, model.Senha))
                {
                    FormsAuthentication.SetAuthCookie(model.Nome, false);
                    return Json(new { success = true, redirect = returnUrl });
                }
                else
                {
                    ModelState.AddModelError("", "O usuário ou a senha informados estão incorretos.");
                }
            }

            // If we got this far, something failed
            return Json(new { errors = "" });
        }
        #endregion        
        
        protected override void Dispose(bool disposing)
        {
            repUsuario.Dispose();
            base.Dispose(disposing);
        }
    }
}
