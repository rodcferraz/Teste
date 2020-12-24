using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.DataModel.Dbo.Queries
{
    public static class PedidoQuery
    {

        public static IQueryable<Pedido> ComId(this IQueryable<Pedido> pedidos, int idPedido)
        {
            return pedidos.Where(pe => pe.IdPedido == idPedido);
        }

        public static IQueryable<Pedido> ContemId(this IQueryable<Pedido> pedidos, int idPedido)
        {
            if (idPedido == 0)
                return pedidos;
            return pedidos.Where(pe => pe.IdPedido == idPedido);
        }
        
        public static IQueryable<Pedido> ComDataPedido(this IQueryable<Pedido> pedidos, DateTime dataPedido)
        {
            if (!dataPedido.Equals(""))
            {
                return pedidos.Where(pe => pe.DataPedido == dataPedido);
            }

            return pedidos;
        }

        public static IQueryable<Pedido> DataInicio(this IQueryable<Pedido> pedidos, DateTime? dataInicio)
        {
            if (dataInicio == null)
            {
                return pedidos;

            }
            return pedidos.Where(pe => pe.DataPedido >= dataInicio);
        }
           

        public static IQueryable<Pedido> DataFinal(this IQueryable<Pedido> pedidos, DateTime? dataFinal)
        {
            if (dataFinal == null)
            {
                return pedidos;
            }

            dataFinal = dataFinal.Value.AddDays(1);
            return pedidos.Where(pe => pe.DataPedido <= dataFinal);
        }

    }
}