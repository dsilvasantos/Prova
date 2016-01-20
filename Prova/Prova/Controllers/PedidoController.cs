using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prova.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Prova.Controllers
{
    public class PedidoController : Controller
    {
        //
        // GET: /Pedido/

        public ActionResult Cadastrar()
        {
            using (ProvaEntities db = new ProvaEntities())
            {
                ViewBag.ProdList = (from c in db.Produto
                                    select new SelectListItem()
                                    {
                                        Text = c.nome_produto,
                                        Value = c.nome_produto
                                    }).ToList();
            }
            var model = new Prova.Models.ModelPedido();
            return View(model);
        }



        [HttpPost]
        public JsonResult Cadastrar(Pedido pedido)
        {
            var Result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    using (ProvaEntities db = new ProvaEntities())
                    {

                        Pedido ped = new Pedido();
                        ped.cep = pedido.cep;
                        ped.cidade = pedido.cidade;
                        ped.complemento = pedido.complemento;
                        ped.cpf = pedido.cpf;
                        ped.data = pedido.data;
                        ped.endereco = pedido.endereco;
                        ped.uf = pedido.uf;
                        db.Pedido.Add(ped);
                        db.SaveChanges();
                        Pedido p = db.Pedido.FirstOrDefault(u => u.cpf == pedido.cpf);
                        Result = p.id_pedido;
                    }
                }
                return Json(new { Result }, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return Json(new { Result = "Erro" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Index(string nome_prod)
        {
            return RedirectToAction("Details", new { nome_prod = nome_prod });
        }

        [HttpPost]
        public JsonResult PreencheEndereco(string nome_produto)
        {
            using (ProvaEntities db = new ProvaEntities())
                try
                {
                    var Result = (from a in db.Produto
                                  where a.nome_produto == nome_produto
                                  select new
                                  {
                                      a.nome_produto,
                                      a.valor,
                                      a.id_produto,
                                  }).ToList();

                    return Json(new { Result }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
                }
        }
    }
}
