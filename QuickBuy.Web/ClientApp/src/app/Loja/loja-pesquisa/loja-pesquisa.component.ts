import { Component, OnInit } from '@angular/core';
import { ProdutosService } from 'src/app/servicos/produtos/produtos.service';
import { Produto } from 'src/app/modelo/produto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-loja-pesquisa',
  templateUrl: './loja-pesquisa.component.html',
  styleUrls: ['./loja-pesquisa.component.css']
})
export class LojaPesquisaComponent implements OnInit {
  public produtos: Produto[];

  constructor(private produtoService: ProdutosService, private router: Router) {
    produtoService.obterTodos().subscribe(
      produto => {
        this.produtos = produto;
      },
      erro => {
        console.log(erro.error());
      }
    );
  }

  ngOnInit() {
  }

  public abrirProduto(produto: Produto) {
    sessionStorage.setItem('produtoDetalhe', JSON.stringify(produto));
    this.router.navigate(['/loja-produto']);
  }

}
