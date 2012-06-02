using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinhaDieta.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Dashboard", "Usuario");

            return View();
        }

        public ActionResult Sobre()
        {         
            return View();
        }
    }
}
