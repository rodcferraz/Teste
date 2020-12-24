using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteApp.Models.DataModel.Dbo.Queries;
using TesteApp.Extensions;
using TesteApp.Models.DataModel;
using TesteApp.Models.DomainModel.Dbo;
using TesteApp.Models.ViewModel.Dbo.Pedidos;
using TesteApp.Models.ViewModel.Dbo.Item;
using System.Data.Entity;
using System.Threading.Tasks;

namespace TesteApp.Controllers.Dbo
{
    public class PedidosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/Pedidos/ConsultarPedidos.cshtml");
        }

        public ActionResult PedidosCadastrados()
        {
            return View("~/Views/PedidosCadastrados/ConsultarPedidosCadastrados.cshtml");
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarPedidoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }
            using (DbApplication db = new DbApplication())
            {

                Pedido pedido = new Pedido();
                pedido.DataPedido = DateTime.Now;

                //  double total = 0;
                List<Item> itens = new List<Item>();
                //foreach (ItemViewModel item in viewModel.Itens)
                //{
                //    Produto produto = db.Produtos.ComId(item.IdProduto).SingleOrDefault();

                //    if (produto == null)
                //        return this.ErrorMessage("Produto não encontrado.");
                //    Item novoItem = new Item();
                //    novoItem.IdProduto = item.IdProduto;
                //    novoItem.Quantidade = item.Quantidade;
                //    novoItem.Subtotal = item.Quantidade * produto.Preco;

                //    total += novoItem.Subtotal;

                ////////////    itens.Add(novoItem);
                ////////////}
                pedido.Itens = viewModel.Itens;
                pedido.Total = viewModel.Total;

                db.RegistrarNovo(pedido);
                db.Salvar();
            }
            return this.Message("Pedido cadastrado com sucesso.");
        }
        [HttpPost]
        public ActionResult Remover(IdPedidoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                this.ModelErrors();
            using (DbApplication db = new DbApplication())
            {
                Pedido pedido = db
                    .Pedidos
                    .Include(pe => pe.Itens)
                    .ComId(viewModel.IdPedido)
                    .SingleOrDefault();
                if (pedido == null)
                    return this.ErrorMessage("Pedido não encotrado");

                db.Itens.RemoveRange(pedido.Itens);
                db.RegistrarRemovido(pedido);
                db.Salvar();
                return this.Message("Pedido removido com sucesso.");
            }
        }

        [HttpPost]
        public ActionResult Cadastrados(PedidosCadastradosViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return this.ErrorMessage("Data pesquisada está fora do intervalo permitido.");

            using (DbApplication db = new DbApplication())
            {
                IQueryable<Pedido> pedidosQuery = db.Pedidos
                    .DataInicio(viewModel.DataInicio)
                    .DataFinal(viewModel.DataFinal)
                    .Include(pe => pe.Itens)
                    .Include(pe => pe.Itens.Select(p => p.Produto))
                    .OrderBy(pe => pe.DataPedido);


                ICollection<Pedido> pedidos = pedidosQuery
                    .Skip(viewModel.Paginacao.Inicio)
                    .Take(viewModel.Paginacao.Limite)
                    .ToList();
                viewModel.Paginacao.TotalRegistros = pedidosQuery.Count();
                List<dynamic> pedidosJson = new List<dynamic>();
                foreach (Pedido pedido in pedidos)
                {
                    List<dynamic> itensJson = new List<dynamic>();

                    foreach (Item item in pedido.Itens)
                    {
                        itensJson.Add(new
                            {
                                produto = item.Produto.Nome,
                                idItem = item.IdItem,
                                idProduto = item.IdProduto,
                                idPedido = item.IdPedido,
                                quantidade = item.Quantidade,
                                subtotal = item.Subtotal
                            });

                    }

                    pedidosJson.Add(new
                        { 
                            idPedido = pedido.IdPedido,
                            itens = itensJson,
                            dataPedido = pedido.DataPedido.ToString("dd/MM/yyyy"),        
                            total = pedido.Total
                        });
                }
                return Json(new
                    {
                        pedidos = pedidosJson,
                        paginacao = viewModel.Paginacao.Json()
                    });
            }
        }
    }
}