using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prova.Models;

namespace Prova.Controllers

{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult CadProduto()
        {
            return View();
        }
    }
}
