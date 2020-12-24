using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;

namespace TesteApp.Models.ViewModel.Dbo.Categoria
{
    public class CategoriasCadastradasViewModel
    {
        public string Descricao { get; set; }

        public PaginacaoViewModel Paginacao { get; private set; }

        public CategoriasCadastradasViewModel()
        {
            Paginacao = new PaginacaoViewModel();
        }
    }
}