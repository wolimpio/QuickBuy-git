import { Component, OnInit } from '@angular/core';
import { ProdutosService } from '../servicos/produtos/produtos.service';
import { Produto } from '../modelo/produto';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {
  public produto: Produto;

  constructor(private produtosService: ProdutosService) {
    this.produto = new Produto();
  }

  ngOnInit() {
  }

  public ObterNome(): string {
    return 'Samsung ';
  }

  public cadastrar() {
    this.produtosService.cadastrar(this.produto).subscribe(
      retornoCadastro => {
        console.log(retornoCadastro);
      },
      erro => {
        console.log(erro.error);
      }
    );
  }
}
