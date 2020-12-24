using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Pedidos
{
    public class IdPedidoViewModel
    {
        [Required(ErrorMessage="Campo deve ser informado")]
        [Range(1, int.MaxValue, ErrorMessage="Campo deve ser maior que '0'")]

        public int IdPedido { get; set; }
    }
}