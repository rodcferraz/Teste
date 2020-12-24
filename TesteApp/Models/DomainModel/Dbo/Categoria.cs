using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApp.Models.DomainModel.Dbo
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        //public Nullable<DateTime> DataDeletado { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}