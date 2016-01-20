using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prova.Models
{
    public class ModelProduto
    {

        [Key]
        public string id_produto { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string nome_produto { get; set; }

        [Required(ErrorMessage = "Informe o valor do produto")]
        public double valor { get; set; }

        public IList<Produto> GetCategory()
        {
            using (ProvaEntities2 db = new ProvaEntities2())
            {
                return (from c in db.model_produto
                        select c).ToList();
            }

        }
    }
}