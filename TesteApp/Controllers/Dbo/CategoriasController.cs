using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteApp.Extensions;
using TesteApp.Models.DataModel;
using TesteApp.Models.DomainModel.Dbo;
using System.Threading.Tasks;
using TesteApp.Models.DataModel.Dbo.Queries;
using TesteApp.Models.ViewModel.Dbo.Categoria;
using System.Data.Entity;

namespace TesteApp.Controllers.Dbo
{
    public class CategoriasController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/Categorias/ConsultarCategorias.cshtml");
        }

        [HttpPost]
        public ActionResult Atualizar(AtualizarCategoriaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return this.ModelErrors();

            using (DbApplication db = new DbApplication())
            {
                Categoria categoriaBanco = db.Categorias
                    .ComDescricao(viewModel.Descricao)
                    .SingleOrDefault();

                if (categoriaBanco != null && categoriaBanco.IdCategoria != viewModel.Id)
                    return this.ErrorMessage("Já existe uma Categoria cadastrada com esta descrição.");

                Categoria categoria = db.Categorias
                    .ComId(viewModel.Id)
                    .SingleOrDefault();

                categoria.Descricao = viewModel.Descricao;

                db.RegistrarAlterado(categoria);
                db.Salvar();
            }
            return this.Message("Categoria atualizada com sucesso.");
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarCategoriaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return this.ModelErrors();

            using (DbApplication db = new DbApplication())
            {
                Categoria categoriaBanco = db.Categorias
                    .ComDescricao(viewModel.Descricao).SingleOrDefault();

                if (categoriaBanco != null)
                    return this.ErrorMessage("Já existe uma Categoria cadastrada com esta descrição.");

                Categoria categoria = new Categoria();
                categoria.Descricao = viewModel.Descricao;

                db.RegistrarNovo(categoria);
                db.Salvar();
            }

            return this.Message("Categoria cadastrada com sucesso.");
        }

        [HttpPost]
        public ActionResult Cadastradas(CategoriasCadastradasViewModel viewModel)
        {
            using (DbApplication db = new DbApplication())
            {
                IQueryable<Categoria> categoriasQuery = db.Categorias
                    .OndeDescricaoContem(viewModel.Descricao)
                    .OrderBy(d => d.Descricao);

                ICollection<Categoria> categorias = categoriasQuery
                    .Skip(viewModel.Paginacao.Inicio)
                    .Take(viewModel.Paginacao.Limite)
                    .ToList();

                viewModel.Paginacao.TotalRegistros = categoriasQuery.Count();

                List<dynamic> categoriasJson = new List<dynamic>();

                foreach (Categoria categoria in categorias)
                {
                    categoriasJson.Add(new
                    {
                        id = categoria.IdCategoria,
                        descricao = categoria.Descricao,
                    });
                }
                return Json(new
                {
                    categorias = categoriasJson,
                    paginacao = viewModel.Paginacao.Json()
                });
            }
        }

        [HttpPost]
        public ActionResult Remover(IdCategoriaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                this.ModelErrors();

            using (DbApplication db = new DbApplication())
            {
                Categoria categoria = db
                    .Categorias
                    .Include(c => c.Produtos)
                    .ComId(viewModel.Id)
                    .SingleOrDefault();

                if (categoria == null)
                    return this.ErrorMessage("Categoria não encontrada.");
                if (categoria.Produtos.Count > 0)
                    return this.ErrorMessage("A Categoria está associada a um produto.");
                db.RegistrarRemovido(categoria);
                db.Salvar();

                return this.Message("Categoria removida com sucesso.");
            }
        }

        [HttpPost]
        public ActionResult Todas()
        {
            using (DbApplication db = new DbApplication())
            {
                ICollection<Categoria> categorias = db.Categorias
                        .OrderBy(d => d.Descricao)
                        .ToList();

                List<dynamic> categoriasJson = new List<dynamic>();

                foreach (Categoria categoria in categorias)
                {
                    categoriasJson.Add(new
                    {
                        id = categoria.IdCategoria,
                        descricao = categoria.Descricao,
                    });
                }
                return Json(new
                {
                    categorias = categoriasJson
                });
            }
        }

    }
}