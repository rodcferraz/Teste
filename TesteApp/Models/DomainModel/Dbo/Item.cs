using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApp.Models.DomainModel.Dbo
{
    public class Item
    {
        public int IdItem { get; set; }
        public int IdProduto { get; set; }
        public int IdPedido { get; set; }
        public double? Quantidade { get; set; }
        public double Subtotal { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}