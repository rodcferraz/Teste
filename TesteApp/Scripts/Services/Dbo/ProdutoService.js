(function () {
    angular.module("app").service("Produto", [
        "ApiRequest",
        ProdutoService
    ]);

    function ProdutoService(ApiRequest) {
        var url;
        var filtro;

        this.cadastrados = function () {
            url = "/Produtos/Cadastrados";
            filtro = {};
            return this;
        }

        this.listar = function (paginacao) {
            filtro.paginacao = paginacao;
            return ApiRequest.json(url, filtro);
        }

        this.ondeNomeContem = function (nome) {
            filtro.nome = nome;
            return this;
        }

        this.comPreco = function (preco) {
            filtro.preco = preco;
            return this;
        }

        this.remover = function (produto) {
            console.log(produto);
            return ApiRequest.json("/Produtos/Remover", {idProduto: produto.idProduto});
        }

        this.salvar = function (produto) {
            if (produto.idProduto) {
                return ApiRequest.json("/Produtos/Atualizar", produto);
            } else {
                return ApiRequest.json("/Produtos/Cadastrar", produto);
            }
        }

        this.todas = function () {
            return ApiRequest.json("/Produtos/Todas");
        }
    }

})();