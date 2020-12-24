(function () {
    angular.module("app").controller("CategoriasController", [
        "Categoria",
        CategoriasController
    ]);

    function CategoriasController(Categoria) {

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

            Categoria
                .cadastradas()
                .ondeDescricaoContem(_self.filtro.dados.descricao)
                .listar(_self.filtro.paginacao)
                .then(function (response) {
                    _self.cadastradas = response.data.categorias;
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

                Categoria
                    .remover(_self.categoria)
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

                Categoria
                    .salvar(_self.categoria)
                    .success(function (mensagem) {
                        _self.info = mensagem;
                        _self.modal.dados.visivel = false;
                        _self.consultar(true);
                    })
                    .error(function (erros) {
                        _self.modal.erros.aoSalvar = erros;
                    })
                    ["finally"](function () {
                        _self.modal.salvando = false;
                    });
            }
        }

        _self.nova = function () {
            _self.categoria = {
                
            };
            _self.modal.info = {};
            _self.modal.erros = {};
        }

        _self.selecionar = function (categoria) {
            _self.modal.limparMensagens();
            _self.categoria = angular.copy(categoria);
        }
    }
})();