//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prova
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {

        public Pedido()
        {
            item_pedidos = new List<ItemPedido>();
        }
        public int id_pedido { get; set; }
        public string data { get; set; }
        public string cpf { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string total { get; set; }

        public List<ItemPedido> item_pedidos { get; set; }
    }
}
