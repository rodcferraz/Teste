using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Produtos
{
    public class ProdutosCadastradosViewModel
    {
        public string Nome { get; set; }
        public PaginacaoViewModel Paginacao { get; private set; }
        public ProdutosCadastradosViewModel()
        {
            Paginacao = new PaginacaoViewModel();
        }
    }
}