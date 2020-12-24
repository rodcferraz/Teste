using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteApp.Models.ViewModel.Dbo.Pedidos
{
    public class PedidosCadastradosViewModel
    {
        public int Id { get; set; }

        [Range(typeof(DateTime), "1/1/2001", "1/1/2019", ErrorMessage = "Date is out of Range ")]
        public DateTime? DataInicio { get; set; }

        [Range(typeof(DateTime), "1/1/2001", "1/1/2019", ErrorMessage = "Date is out of Range")]

        public DateTime? DataFinal { get; set; }

        public DateTime DataPedido { get; set; }

        public float Total { get; set; }

        public PaginacaoViewModel Paginacao { get; private set; }
        public PedidosCadastradosViewModel()
        {
            Paginacao = new PaginacaoViewModel();
        }
    }
}