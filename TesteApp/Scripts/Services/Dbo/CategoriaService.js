(function () {
    angular.module("app").service("Categoria", [
        "ApiRequest",
        CategoriaService
    ]);

    function CategoriaService(ApiRequest) {
        var url;
        var filtro;

        this.cadastradas = function () {
            url = "/Categorias/Cadastradas";
            filtro = {};
            return this;
        }

        this.listar = function (paginacao) {
            filtro.paginacao = paginacao;
            return ApiRequest.json(url, filtro);
        }

        this.ondeDescricaoContem = function (descricao) {
            filtro.descricao = descricao;
            return this;
        }

        this.remover = function (categoria) {
            console.log(categoria);
            return ApiRequest.json("/Categorias/Remover", { id: categoria.id });
        }

        this.salvar = function (categoria) {
            if (categoria.id)
                return ApiRequest.json("/Categorias/Atualizar", categoria);
            else
                return ApiRequest.json("/Categorias/Cadastrar", categoria);
        }

        this.todas = function () {
            return ApiRequest.json("/Categorias/Todas");
        }

    }
})();