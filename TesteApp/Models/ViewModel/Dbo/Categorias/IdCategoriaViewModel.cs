using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Categoria
{
    public class IdCategoriaViewModel
    {
        [Required(ErrorMessage = "Campo '{0}' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo '{0}' dever ser maior que '0'")]
        public int Id { get; set; }
    }
}