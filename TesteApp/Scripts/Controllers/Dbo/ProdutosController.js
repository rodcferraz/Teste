(function () {
    angular.module("app").controller("ProdutosController", [
        "Produto",
        "Categoria",
        ProdutosController   
    ]);

    function ProdutosController(Produto, Categoria) {
        var _self = this;
        
        _self.filtro = {
            dados: {},
            limpar: function () {
                _self.filtro.dados = {};
                _self.consultar();
            }
        }

        _self.consultar = function (pagina1) {
            if (pagina1) {
                _self.filtro.paginacao.pagina = 1;
            }
            Produto
                .cadastrados()
                .ondeNomeContem(_self.filtro.dados.nome)
                .listar(_self.filtro.paginacao)
                .then(function (response) {
                    _self.cadastrados = response.data.produtos;
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

        _self.modal = {
            erros: {},
            remover: function () {
                _self.modal.desativando = true;
                _self.modal.erros = {};
                _self.limparMensagens();
               
                Produto
                    .remover(_self.produto)
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
            },
            salvar: function () {
                _self.modal.salvando = true;
                _self.modal.erros = {};
                _self.limparMensagens();

                Produto
                    .salvar(_self.produto)
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
        }

        _self.consultarCategorias = function () {

            Categoria
                .todas()
                .then(function (response) {
                    _self.categorias = response.data.categorias;

                })
                .catch(function (response) {
                    _self.erros = response.data;
                })
                ["finally"](function () {

                })
        }

        _self.novo = function () {
            _self.produto = {

            };
            _self.modal.info = {};
            _self.modal.erros = {};
        }

        _self.selecionar = function (produto) {
            _self.modal.limparMensagens();
            _self.produto = angular.copy(produto);
        }
    }

})();