import { Component, OnInit } from '@angular/core';
import { CarrinhoCompras } from '../carrinho-compras/loja-carrinho-compras';
import { Produto } from 'src/app/modelo/produto';
import { Pedido } from 'src/app/modelo/pedido';
import { UsuariosService } from 'src/app/servicos/usuarios/usuarios.service';
import { ItemPedido } from 'src/app/modelo/itemPedido';

@Component({
  selector: 'app-loja-efetivar',
  templateUrl: './loja-efetivar.component.html',
  styleUrls: ['./loja-efetivar.component.css']
})
export class LojaEfetivarComponent implements OnInit {
  public carrinhoCompras: CarrinhoCompras;
  public produtos: Produto[] = [];
  public total: number;

  constructor(private usuarioServico: UsuariosService) { }

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

  efetivarCompra() {
    let pedido = this.criarPedido();
  }

  criarPedido(): Pedido {
    let pedido = new Pedido();

    pedido.usuarioId = this.usuarioServico.usuario.id;
    pedido.cep = '50870-470';
    pedido.cidade = 'Recife';
    pedido.estado = 'PE';
    pedido.numeroEndereco = '108';
    pedido.enderecoCompleto = 'Rua São Barnabé, Areias';
    pedido.dataPrevisaoEntrega = new Date();
    pedido.formaPagamentoId = 1;

    this.produtos = this.carrinhoCompras.obterProdutos();
    // tslint:disable-next-line: prefer-const
    for (let produtoSelecionado of this.produtos) {
      // tslint:disable-next-line: prefer-const
      let itemPedido = new ItemPedido();
      itemPedido.produtoId = produtoSelecionado.id;
      itemPedido.quantidade = produtoSelecionado.quantidade ? produtoSelecionado.quantidade : 1;

      pedido.itemPedido.push(itemPedido);
    }

    return pedido;
  }
}
