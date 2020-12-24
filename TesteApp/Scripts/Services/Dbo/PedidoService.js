(function () {
    angular.module("app").service("Pedido", [
        "ApiRequest",
        PedidoService
    ]);

    function PedidoService(ApiRequest) {
        var url;
        var filtro;

        this.cadastrados = function () {
            url = "/Pedidos/Cadastrados";
            filtro = {};
            return this;
        }

        this.listar = function (paginacao) {
            filtro.paginacao = paginacao;
            return ApiRequest.json(url, filtro);
        }

        this.ondeNomeContem = function (Nome) {
            filtro.Nome = Nome;
            return this;
        }

        this.dataInicio = function (DataInicio) {
            filtro.DataInicio = DataInicio;
            return this;
        }

        this.dataFinal = function (DataFinal) {
            filtro.DataFinal = DataFinal;
            return this;
        }

        this.remover = function (pedido) {
            return ApiRequest.json("/Pedidos/Remover", { idPedido: pedido.idPedido });

        }

        this.salvar = function (pedido) {
            console.info(pedido);
            return ApiRequest.json("/Pedidos/Cadastrar", pedido);
        }

    }
})();