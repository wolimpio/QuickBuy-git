import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuariosService } from '../servicos/usuarios/usuarios.service';
import { Usuario } from '../modelo/usuario';
import { CarrinhoCompras } from '../Loja/carrinho-compras/loja-carrinho-compras';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  public carrinhoCompra: CarrinhoCompras;

  constructor(private router: Router, private usuariosService: UsuariosService) {
    this.carrinhoCompra = new CarrinhoCompras();
  }

  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public usuarioLogado(): boolean {
    return this.usuariosService.usuario_autenticado();
  }

  public usuarioAdmin(): boolean {
    return this.usuariosService.usuario_admin();
  }

  public sair() {
    this.usuariosService.limpar_sessao();
    this.router.navigate(['/']);
  }

  public getUsuario(): Usuario {
    return this.usuariosService.usuario;
  }

  public carrinhoVazio(): boolean {
    return this.carrinhoCompra.carrinhoVazio();
  }
}
