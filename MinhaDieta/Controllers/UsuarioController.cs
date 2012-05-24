using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MinhaDieta.Models;

namespace MinhaDieta.Controllers
{

    [Authorize]
    public class UsuarioController : Controller
    {
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            return RetornaViewNoContexto();
        }
               
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Usuario model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                //TODO: método para validar o login do usuario
                // model.Nome, model.Senha
                if (true)
                {
                    FormsAuthentication.SetAuthCookie(model.Nome, false);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Inicio");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
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
        public ActionResult Registrar(Usuario model)
        {
            if (ModelState.IsValid)
            {

                //TODO: Método para criar o usuario no banco


                //FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);

                return RedirectToAction("Index", "Inicio");

                //ModelState.AddModelError("", ErrorCodeToString(createStatus));

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
        public JsonResult JsonLogin(Usuario model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Nome, model.Senha))
                {
                    FormsAuthentication.SetAuthCookie(model.Nome, false);
                    return Json(new { success = true, redirect = returnUrl });
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed
            return Json(new { errors = "" });
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonRegister(Usuario model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                //MembershipCreateStatus createStatus;
                //Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);

                if (true)
                {
                    FormsAuthentication.SetAuthCookie(model.Nome, createPersistentCookie: false);
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("", "");
                }
            }

            // If we got this far, something failed
            return Json(new { errors = "" });
        }
        #endregion        
    }
}
