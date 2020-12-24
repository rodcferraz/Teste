using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Item
{
    public class ItemViewModel
    {
        [Required(ErrorMessage="Campo deve ser informado.")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo '{0}' dever ser maior que '0'")]
        public int IdProduto {get; set;}

        [Required(ErrorMessage = "Campo deve ser informado.")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo '{0}' dever ser maior que '0'")]
        public int Quantidade { get; set;}

    }
}