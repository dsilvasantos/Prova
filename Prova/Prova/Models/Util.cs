using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Prova.Models
{
    public class ProvaEntities2 : DbContext
    {
        public ProvaEntities2()
            : base("name=ProvaEntities")
        {

        }

        public DbSet<Produto> model_produto { get; set; }

        public DbSet<Pedido> model_pedido { get; set; }

    }
}