using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Produtos
{
    public class CadastrarProdutoViewModel
    {
        [Required(ErrorMessage = "Campo {0} deve ser informado.")]
        public int IdCategoria { get; set; }

        [StringLength(50, ErrorMessage = "Campo {0} deve conter no máximo {1} caracteres.")]
        public string Nome {get; set;}

        [Range(1, double.MaxValue, ErrorMessage = "Campo '{0}' dever ser maior que '0'")]
        [Required(ErrorMessage = "Valor de ser atribuido.")]
        public double Preco { get; set; }
    }
}