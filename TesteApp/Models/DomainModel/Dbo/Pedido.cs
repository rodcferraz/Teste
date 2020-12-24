using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApp.Models.DomainModel.Dbo
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime DataPedido { get; set; }

        public double Total { get; set; }

        public virtual ICollection<Item> Itens { get; set; }

    }
}