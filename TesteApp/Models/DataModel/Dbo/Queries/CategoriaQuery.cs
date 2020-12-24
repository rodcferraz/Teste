using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Queries
{
    public static class CategoriaQuery
    {
        public static IQueryable<Categoria> ComId(this IQueryable<Categoria> categorias, int idCategoria)
        {  
                return categorias.Where(c => c.IdCategoria == idCategoria);

        }

        public static IQueryable<Categoria> ComDescricao(this IQueryable<Categoria> categorias, string descricao)
        {
            return categorias.Where(c => c.Descricao == descricao);
        }

        public static IQueryable<Categoria> OndeDescricaoContem(this IQueryable<Categoria> categorias, string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                return categorias;

            return categorias.Where(c => c.Descricao.Contains(descricao));
        }

        public static IQueryable<Categoria> OrdenadosPorDescricao(this IQueryable<Categoria> categorias)
        {
            return categorias.OrderBy(c => c.Descricao);
        }
    }
}