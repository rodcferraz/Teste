(function () {
    angular.module("app").controller("PedidosController", [
        "Pedido",
        "Produto",
        PedidosController
    ]);

    function PedidosController(Pedido, Produto) {
        var _self = this;
        _self.pedido = {};
        _self.itens = [];

        _self.adicionarItem = function (produto) {
            produto.quantidade = 1;
            produto.habilitado = true;
            _self.itens.push(produto);
        }

        _self.adicionarHabilitado = function () {
            for (var i = 0; i < _self.produtos.length; i++) {
                _self.produtos[i].habilitado = true;
            }
        }


        _self.limparItens = function () {
            _self.itens = [];
            _self.consultarProdutos(true);
        }

        _self.desabilitarBotao = function (produto) {
            for (var i = 0; i < _self.produtos.length; i++) {
                if (produto.idProduto == _self.produtos[i].idProduto)
                    _self.produtos[i].habilitado = false;
            }
        }

        _self.habilitarBotao = function (itens) {
            for (var i = 0; i < _self.itens.length; i++) {
                if (itens.idProduto == _self.itens[i].idProduto)
                    _self.itens.splice(i,1);
                for (var j = 0; j < _self.produtos.length; j++) {
                    if(itens.idProduto == _self.produtos[j].idProduto)
                    _self.produtos[j].habilitado = true;
                }
            }
        }

        _self.salvar = function () {
            _self.modal.salvando = true;
            _self.modal.erros = {};
            _self.limparMensagens();

            _self.pedido.itens = _self.itens;
            _self.pedido.total = _self.total;

            Pedido
                .salvar(_self.pedido)
                .then(function (response) {
                    _self.info = response.data;
                    _self.modal.dados.visivel = false;
                    _self.consultar(true);
                })
                .catch(function (response) {
                    _self.modal.erros.aoSalvar = response.data;
                })
                ["finally"](function () {
                    _self.modal.salvando = false;
                });
        }

        _self.modal = {
            erros: {},
            remover: function () {
                _self.modal.desativando = true;
                _self.modal.erros = {};
                _self.limparMensagens();

                Pedido
                    .remover(_self.pedido)
                    .then(function (response) {
                        _self.info = response.data;
                        _self.modal.confirmarRemover.visivel = false;
                        _self.consultar(true);
                    })
                    .catch(function (response) {
                        _self.modal.erros.aoRemover = response.data;
                    })
                    ["finally"](function () {
                        _self.modal.desativando = false;
                    });
            },
            limparMensagens: function () {
                _self.modal.info = {};
                _self.modal.erros = {};
            }
        }

        _self.subTotal = 0;

        _self.calcSubtotal = function (produto) {           
            produto.subTotal = (produto.preco * produto.quantidade);
            return produto.subTotal;
        }
        
        _self.calcTotal = function () {
            _self.total = 0;
            for (var i = 0; i < _self.itens.length; i++) {
                _self.total = _self.total + _self.itens[i].subTotal;
            }
            return _self.total;
        }
        _self.consultarProdutos = function (pagina1) {
            if (pagina1) {
                _self.filtro.paginacao.pagina = 1
            }
            Produto
                .cadastrados()
                .ondeNomeContem(_self.filtro.dados.nome)
                .listar(_self.filtro.paginacao)
                .then(function (response) {
                    _self.produtos = response.data.produtos;
                    _self.filtro.paginacao = response.data.paginacao;
                })
                .catch(function (response) {
                    _self.erros = response.data;
                })
                ["finally"](function () {

                })
        };

        _self.limparMensagens = function () {
            _self.erros = null;
            _self.info = null;
        }

        _self.filtro = {
            dados: {},
            limpar: function () {
                _self.filtro.dados = {};
                _self.consultar();
            }
        }

        _self.consultar = function (pagina1) {
            if (pagina1) {
                _self.filtro.paginacao.pagina = 1
            }
            Pedido
                .cadastrados()
                .dataInicio(_self.filtro.dados.dataInicio)
                .dataFinal(_self.filtro.dados.dataFinal)
                .listar(_self.filtro.paginacao)
                .then(function (response) {
                    _self.cadastrados = response.data.pedidos;
                    _self.filtro.paginacao = response.data.paginacao;

                })
                .catch(function (response) {
                    _self.erros = response.data;
                })
                ["finally"](function () {

                })
        };

        _self.novo = function () {
           _self.pedido = {

           };
           _self.modal.info = {};
            _self.modal.erros = {};
        }

        _self.selecionar = function (pedido) {
            _self.limparMensagens();
            _self.pedido = angular.copy(pedido);
        }
    }
})();