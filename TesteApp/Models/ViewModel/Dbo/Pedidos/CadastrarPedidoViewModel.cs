using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TesteApp.Models.DomainModel.Dbo;
using TesteApp.Models.ViewModel.Dbo.Item;

namespace TesteApp.Models.ViewModel.Dbo.Pedidos
{
    public class CadastrarPedidoViewModel
    {
        public CadastrarPedidoViewModel()
        {
            Itens = new List<TesteApp.Models.DomainModel.Dbo.Item>();
        }
        [Required (ErrorMessage="Campo deve ser informado.")]
        public int Total {get; set;}

        public List<TesteApp.Models.DomainModel.Dbo.Item> Itens { get; set; }
       
    }
}