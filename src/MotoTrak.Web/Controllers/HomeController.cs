using System;
using System.Web.Mvc;

namespace MotoTrak.Web.Controllers
{
    public class HomeController : ApplicationController
    {
        [Authorize]
        [Host("Dashboard")]
        public ActionResult Index()
        {
            return View();
        }
    }
}