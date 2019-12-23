import { Component, OnInit } from '@angular/core';
import { ProdutosService } from '../servicos/produtos/produtos.service';
import { Produto } from '../modelo/produto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {
  public produto: Produto;
  public arquivoSelecionado: File;
  public ativar_spinner: boolean;
  public mensagem: string;

  constructor(private produtosService: ProdutosService, private router: Router) {

  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.produtosService.enviarArquivo(this.arquivoSelecionado).subscribe(
      nomeArquivo => {
        this.produto.nomeArquivo = nomeArquivo;
        console.log(nomeArquivo);
      },
      erro => {
        console.log(erro.error);
      }
    );
  }

  ngOnInit() {
    var produtoSession = sessionStorage.getItem('produtoSessao');

    if (produtoSession) {
      this.produto = JSON.parse(produtoSession);
    } else {
      this.produto = new Produto();
    }

    sessionStorage.setItem('produtoSessao', '');
  }

  public ObterNome(): string {
    return 'Samsung ';
  }

  public cadastrar() {
    this.ativar_spinner = true;
    this.mensagem = '';

    this.produtosService.cadastrar(this.produto).subscribe(
      retornoCadastro => {
        this.router.navigate(['/produto']);
      },
      erro => {
        console.log(erro.error);
        this.mensagem = erro.error;
      }
    );
    this.ativar_spinner = false;
  }
}
