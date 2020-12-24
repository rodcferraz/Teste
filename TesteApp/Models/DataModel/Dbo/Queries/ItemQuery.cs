using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Queries
{
    public static class ItemQuery
    {
        public static IQueryable<Item> ComId(this IQueryable<Item> itens, int idItem)
        {
            return itens.Where(i => i.IdItem == idItem);
        }

        public static IQueryable<Item> ComIdPr(this IQueryable<Item> itens, int idProduto)
        {
            return itens.Where(i => i.IdProduto == idProduto);
        }

        public static IQueryable<Item> ComIdPe(this IQueryable<Item> itens, int idPedido)
        {
            return itens.Where(i => i.IdPedido == idPedido);
        }
        public static IQueryable<Item> ComQuantidade(this IQueryable<Item> itens, int quantidade)
        {
            return itens.Where(i => i.Quantidade == quantidade);
        }
        public static IQueryable<Item> ComSubTotal(this IQueryable<Item> itens, double subtotal)
        {
            return itens.Where(i => i.Subtotal == subtotal);
        }

    }
}