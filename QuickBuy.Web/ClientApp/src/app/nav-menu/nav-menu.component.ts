import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuariosService } from '../servicos/usuarios/usuarios.service';
import { Usuario } from '../modelo/usuario';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private router: Router, private usuariosService: UsuariosService) {

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

  public sair() {
    this.usuariosService.limpar_sessao();
    this.router.navigate(['/']);
  }

  public getUsuario(): Usuario {
    return this.usuariosService.usuario;
  }
}
