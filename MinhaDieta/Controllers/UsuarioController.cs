using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MinhaDieta.Models.DAL;
using MinhaDieta.Models.Entidades;
using MinhaDieta.Models.ViewModel;

namespace MinhaDieta.Controllers
{

    [Authorize]
    public class UsuarioController : Controller
    {
        UsuarioRepository rep;

        public UsuarioController() 
        {
            rep = new UsuarioRepository();
        }

        [Authorize]
        public ActionResult Dashboard() 
        {
            return View();
        }


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
                if (rep.ValidarLogin(model.Nome, model.Senha))
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
        
        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return RetornaViewNoContexto();
        }
                
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registrar(RegiostroViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Senha = model.Senha;
                usuario.Altura = model.Altura;
                usuario.Peso = model.Peso;
                usuario.DataNascimento = model.DataNascimento;
                rep.Salvar(usuario);

                FormsAuthentication.SetAuthCookie(model.Nome, createPersistentCookie: false);

                return RedirectToAction("Dashboard", "Usuario");
            }
                        
            return View(model);
        }
                                

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
                UsuarioRepository rep = new UsuarioRepository();

                if (rep.ValidarLogin(model.Nome, model.Senha))
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

        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonRegistrar(RegiostroViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Senha = model.Senha;
                usuario.Altura = model.Altura;
                usuario.Peso = model.Peso;
                usuario.DataNascimento = model.DataNascimento;
                rep.Salvar(usuario);

                FormsAuthentication.SetAuthCookie(model.Nome, createPersistentCookie: false);
                return Json(new { success = true });
            }

            // If we got this far, something failed
            return Json(new { errors = "" });
        }
        #endregion        
    }
}
