using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Queries
{
    public static class ProdutoQuery
    {
        public static IQueryable<Produto> ComId(this IQueryable<Produto> produtos, int idProduto)
        {
             return produtos.Where(p => p.IdProduto == idProduto);    
        }

        public static IQueryable<Produto> ComIdC(this IQueryable<Produto> produtos, int idCategoria)
        {        
                return produtos.Where(p => p.IdCategoria == idCategoria);
        }

        public static IQueryable<Produto> ComNome(this IQueryable<Produto> produtos, string nome)
        {
          
                return produtos.Where(p => p.Nome == nome);
               
        }

        public static IQueryable<Produto> OndeNomeContem(this IQueryable<Produto> produtos, string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return produtos;
            return produtos.Where(p => p.Nome.Contains(nome));
        }

        public static IQueryable<Produto> ComPreco(this IQueryable<Produto> produtos, double preco)
        {
            return produtos.Where(p => p.Preco == preco);
        }

        public static IQueryable<Produto> OrdenadosPorNome(this IQueryable<Produto> produtos)
        {
            return produtos.OrderBy(p => p.Nome);
        }

        //public static IQueryable<Produto> Ativo(this IQueryable<Produto> produtos)
        //{
        //   return produtos.Where(p => p.DataDeletado == null);         
        //}
    }
}