using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteApp.Extensions;
using TesteApp.Models.DataModel;
using System.Threading.Tasks;
using TesteApp.Models.DomainModel.Dbo;
using TesteApp.Models.DataModel.Dbo.Queries;
using System.Data.Entity;
using TesteApp.Models.ViewModel.Dbo.Produtos;

namespace TesteApp.Controllers.Dbo
{
    public class ProdutosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/Produtos/ConsultarProdutos.cshtml");
        }
        [HttpPost]
        public ActionResult Atualizar(AtualizarProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return this.ModelErrors();

            using (DbApplication db = new DbApplication())
            {
                Produto produtoBanco = db.
                    Produtos
                    .ComNome(viewModel.Nome)
                    .SingleOrDefault();

                if (produtoBanco != null && produtoBanco.IdProduto != viewModel.IdProduto)
                    return this.ErrorMessage("Já existe um produto  cadastrado com esta descrição.");
                Produto produto = db.Produtos
                    .ComId(viewModel.IdProduto)
                    .SingleOrDefault();

                produto.IdCategoria = viewModel.IdCategoria;
                produto.Nome = viewModel.Nome;
                produto.Preco = viewModel.Preco;

                db.RegistrarAlterado(produto);
                db.Salvar();
            }

            return this.Message("Produto atualizado com sucesso.");
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return this.ModelErrors();
            using (DbApplication db = new DbApplication())
            {
                Produto produtoBanco = db.Produtos
                    .ComNome(viewModel.Nome).SingleOrDefault();

                if (produtoBanco != null)
                    return this.ErrorMessage("Já existe um produto cadastrado com esse nome.");

                Produto produto = new Produto();

                produto.IdCategoria = viewModel.IdCategoria;
                produto.Nome = viewModel.Nome;
                produto.Preco = viewModel.Preco;
                db.RegistrarNovo(produto);
                db.Salvar();

                return this.Message("Produto cadastrado com sucesso.");
            }
        }

        [HttpPost]
        public ActionResult Cadastrados(ProdutosCadastradosViewModel viewModel)
        {
            using (DbApplication db = new DbApplication())
            {
                IQueryable<Produto> produtosQuery = db.Produtos
                    .OndeNomeContem(viewModel.Nome)
                    //.Ativo()
                    .OrderBy(n => n.Nome);

                ICollection<Produto> produtos = produtosQuery
                    .Skip(viewModel.Paginacao.Inicio)
                    .Take(viewModel.Paginacao.Limite)
                    .ToList();

                viewModel.Paginacao.TotalRegistros = produtosQuery.Count();

                List<dynamic> produtosJson = new List<dynamic>();

                foreach (Produto produto in produtos)
                {
                    produtosJson.Add(new
                        {
                            idProduto = produto.IdProduto,
                            idCategoria = produto.IdCategoria,
                            nome = produto.Nome,
                            preco = produto.Preco
                        });
                }

                return Json(new
                {
                    produtos = produtosJson,
                    paginacao = viewModel.Paginacao.Json()
                });
            }
        }
        [HttpPost]
        public ActionResult Remover(IdProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                this.ModelErrors();

            using (DbApplication db = new DbApplication())
            {
                Produto produto = db
                    .Produtos
                    .ComId(viewModel.IdProduto)
                    .SingleOrDefault();
                if (produto == null)
                    return this.ErrorMessage("Produto não encontrado.");

                //produto.DataDeletado = DateTime.Now;

                db.RegistrarAlterado(produto);
                db.Salvar();

                return this.Message("Produto removido com sucesso");
            }
        }

        [HttpPost]
        public ActionResult Todas()
        {
            using (DbApplication db = new DbApplication())
            {
                ICollection<Produto> produtos = db.Produtos
                    .OrderBy(n => n.Nome)
                    .ToList();

                List<dynamic> produtosJson = new List<dynamic>();
                foreach (Produto produto in produtos)
                {
                    produtosJson.Add(new
                        {
                            idProduto = produto.IdProduto,
                            nome = produto.Nome,
                        });
                }
                return Json(new
                    {
                        produtos = produtosJson
                    });
            }
        }

    }
}