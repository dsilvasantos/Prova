using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prova.Models;
using System.Text;

namespace Prova.Controllers
{
    public class AutorController : Controller
    {
        //
        // GET: /Autor/

        public ActionResult Index()
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
            var model = new Author();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Author author)
        {
            int id;
            try
            {
                using (ProvaEntities db = new ProvaEntities())
                {

                    Pedido ped = new Pedido();
                    ped.cep = author.cep;
                    ped.cidade = author.cidade;
                    ped.complemento = author.complemento;
                    ped.cpf = author.cpf;
                    ped.data = author.data;
                    ped.endereco = author.endereco;
                    ped.uf = author.uf;
                    db.Pedido.Add(ped);
                    db.SaveChanges();
                    Pedido p = db.Pedido.FirstOrDefault(u => u.cpf == author.cpf);
                    id = p.id_pedido;
                }
                foreach (var itens in author.Books)
                {
                    using (ProvaEntities db = new ProvaEntities())
                    {
                        ItemPedido ped = new ItemPedido();
                        ped.id_pedido = id;
                        ped.id_produto = itens.id_prod;
                        ped.qtde = itens.qtde;
                        ped.subtotal = itens.subtotal;
                        db.ItemPedido.Add(ped);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
