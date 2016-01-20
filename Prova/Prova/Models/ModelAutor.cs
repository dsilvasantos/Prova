using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        [Key]
        public int id_pedido { get; set; }

        public string data { get; set; }

        [Required(ErrorMessage = "Informe o cpf do cliente")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Informe o cpe do pedido")]
        public string cep
        { get; set; }

        [Required(ErrorMessage = "Informe o endereço do pedido")]
        public string endereco { get; set; }

        public string complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro do pedido")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade do pedido")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado do pedido")]
        public string uf { get; set; }

        public string total { get; set; }

        public Produto prod { get; set; }

        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public int id_prod { get; set; }
        public string nome_prod { get; set; }
        public string valor { get; set; }
        public int qtde { get; set; }
        public string subtotal { get; set; }
    }
}
