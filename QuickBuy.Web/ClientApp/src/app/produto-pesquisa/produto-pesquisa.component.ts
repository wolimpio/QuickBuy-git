import { Component, OnInit } from '@angular/core';
import { Produto } from '../modelo/produto';
import { ProdutosService } from '../servicos/produtos/produtos.service';
import { Router } from '@angular/router';
import { ModalPerguntaService } from '../servicos/Componentes/modal-pergunta.service';

@Component({
  selector: 'app-produto-pesquisa',
  templateUrl: './produto-pesquisa.component.html',
  styleUrls: ['./produto-pesquisa.component.css']
})
export class ProdutoPesquisaComponent implements OnInit {

  public produtos: Produto[];
  private nomeProdutoSelecionado: string;

  constructor(private produtoServico: ProdutosService,
    private modalPerguntaServico: ModalPerguntaService,
    private router: Router) {
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

  public deletarProduto(produto: Produto) {
    var retorno = confirm("Você deseja realmente deletar o produto " + produto.descricao + "?");

    if (retorno) {
      this.produtoServico.deletar(produto).subscribe(
        produtos => {
          this.produtos = produtos;
        },
        erro => {
          console.log(erro.error);
        }
      );
    }

    // this.nomeProdutoSelecionado = produto.nome;
    // // tslint:disable-next-line: prefer-const
    // this.modalPerguntaServico.getResposta().subscribe(
    //   retorno => {
    //     if (retorno) {
    //       console.log('chamou o deletar');
    //       // this.produtoServico.deletar(produto).subscribe(
    //       //   produtos => {
    //       //     this.produtos = produtos;
    //       //   },
    //       //   erro => {
    //       //     console.log(erro.error);
    //       //   }
    //       // );
    //     }
    //   }
    // );

  }

  public editarProduto(produto: Produto) {
    console.log('Editar Produto');
    sessionStorage.setItem('produtoSessao', JSON.stringify(produto));
    this.router.navigate(['/novo-produto']);
  }

}
