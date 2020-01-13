import { Component, OnInit } from '@angular/core';
import { CarrinhoCompras } from '../carrinho-compras/loja-carrinho-compras';
import { Produto } from 'src/app/modelo/produto';

@Component({
  selector: 'app-loja-efetivar',
  templateUrl: './loja-efetivar.component.html',
  styleUrls: ['./loja-efetivar.component.css']
})
export class LojaEfetivarComponent implements OnInit {
  public carrinhoCompras: CarrinhoCompras;
  public produtos: Produto[] = [];
  public total: number;

  constructor() { }

  ngOnInit() {
    this.carrinhoCompras = new CarrinhoCompras();

    this.produtos = this.carrinhoCompras.obterProdutos();

    this.atualizarTotal();
  }

  public atualizarPreco(produto: Produto, qtd: number) {
    var quantidade: number = qtd;

    if (qtd <= 0) {
      quantidade = 1;
    }
    if (!produto.precoOriginal) {
      produto.precoOriginal = produto.preco;
    }

    produto.preco = produto.precoOriginal * quantidade;
    produto.quantidade = quantidade;

    this.carrinhoCompras.atualizar(this.produtos);

    this.atualizarTotal();
  }

  public remover(produto: Produto) {
    this.carrinhoCompras.remover(produto);
    this.produtos = this.carrinhoCompras.obterProdutos();

    this.atualizarTotal();
  }

  atualizarTotal() {
    this.total = this.produtos.reduce((acumulador, produto) => acumulador + produto.preco, 0);
  }

}
