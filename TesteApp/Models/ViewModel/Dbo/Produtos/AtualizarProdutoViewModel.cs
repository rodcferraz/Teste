using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Produtos
{
    public class AtualizarProdutoViewModel
    {
        [Required(ErrorMessage = "Produto precisa ser informado.")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Categoria precisa ser informado.")]
        public int IdCategoria { get; set; }

        [StringLength(50, ErrorMessage = "Campo '{0}' deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço precisa ser informado.")]
        public float Preco { get; set; }
    }
}