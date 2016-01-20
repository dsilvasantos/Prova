using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prova.Models;

namespace Prova.Controllers
{
    public class ProdutoController : Controller
    {
        //
        // GET: /Produto/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                using (ProvaEntities db = new ProvaEntities())
                {
                    db.Produto.Add(produto);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = produto.nome_produto + " Cadastrado com sucesso";
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            using (ProvaEntities db = new ProvaEntities())
            {
                List<Produto> produtos = db.Produto.ToList<Produto>();
                return this.Json(new { Result = produtos }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
