using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Categoria
{
    public class AtualizarCategoriaViewModel
    {
        [Required(ErrorMessage = "Categoria precisa ser informada.")]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Campo '{0}' deve conter no máximo {1} caracteres.")]
        public string Descricao { get; set; }
    }
}