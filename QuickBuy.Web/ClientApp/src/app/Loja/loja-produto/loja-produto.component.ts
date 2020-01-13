import { Component, OnInit } from '@angular/core';
import { ProdutosService } from 'src/app/servicos/produtos/produtos.service';
import { Produto } from 'src/app/modelo/produto';
import { Router } from '@angular/router';
import { CarrinhoCompras } from '../carrinho-compras/loja-carrinho-compras';

@Component({
  selector: 'app-loja-produto',
  templateUrl: './loja-produto.component.html',
  styleUrls: ['./loja-produto.component.css']
})
export class LojaProdutoComponent implements OnInit {
  public produto: Produto;
  public carrinhoCompras: CarrinhoCompras;

  constructor(private produtoServico: ProdutosService, private router: Router) { }

  ngOnInit() {
    this.carrinhoCompras = new CarrinhoCompras();

    var produtoDetalhe = sessionStorage.getItem('produtoDetalhe');

    if (produtoDetalhe) {
      this.produto = JSON.parse(produtoDetalhe);
    }
    else {
      this.produto = new Produto();
    }
  }

  public comprar() {
    this.carrinhoCompras.adicionar(this.produto);
    this.router.navigate(['/loja-efetivar']);
  }

}
