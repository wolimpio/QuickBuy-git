import { Component, OnInit } from '@angular/core';
import { Produto } from '../modelo/produto';
import { ProdutosService } from '../servicos/produtos/produtos.service';

@Component({
  selector: 'app-produto-pesquisa',
  templateUrl: './produto-pesquisa.component.html',
  styleUrls: ['./produto-pesquisa.component.css']
})
export class ProdutoPesquisaComponent implements OnInit {

  public produtos: Produto[];

  constructor(private produtoServico: ProdutosService) {
    this.produtoServico.obterTodos().subscribe(
      produtos => {
        this.produtos = produtos;
      },
      erro => {
        console.log(erro.error);
      }
    );
  }

  ngOnInit() {
  }

}
