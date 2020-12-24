using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApp.Models.DomainModel.Dbo
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        //public Nullable<DateTime> DataDeletado { get; set; }
        public double Preco { get; set; }


        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Item> Itens { get; set; }

    }
}