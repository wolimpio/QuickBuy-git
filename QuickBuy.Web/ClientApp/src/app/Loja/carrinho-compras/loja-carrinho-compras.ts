import { Produto } from "src/app/modelo/produto";

export class CarrinhoCompras {
    public _produtos: Produto[] = [];

    constructor() {
    }

    public adicionar(produto: Produto) {

        var produtoLocalStorage = localStorage.getItem("produtoLocalstorage");

        if (!produtoLocalStorage) {
            this._produtos.push(produto);
        } else {
            this._produtos = JSON.parse(produtoLocalStorage);
            this._produtos.push(produto);
        }

        localStorage.setItem("produtoLocalstorage", JSON.stringify(this._produtos));
    }

    public remover(produto: Produto) {
        var produtoLocalStorage = localStorage.getItem("produtoLocalstorage");

        if (produtoLocalStorage) {
            this._produtos = JSON.parse(produtoLocalStorage);
            this._produtos = this._produtos.filter(p => p.id !== produto.id);

            localStorage.setItem("produtoLocalstorage", JSON.stringify(this._produtos));
        }
    }

    public obterProdutos(): Produto[] {
        var produtoLocalStorage = localStorage.getItem("produtoLocalstorage");

        if (produtoLocalStorage) {
            this._produtos = JSON.parse(produtoLocalStorage);
        }

        return this._produtos;
    }

    public atualizar(produtos: Produto[]) {
        localStorage.setItem("produtoLocalstorage", JSON.stringify(produtos));
    }

    public carrinhoVazio(): boolean {
        var itens = this.obterProdutos();

        return (itens.length === 0);
    }
}