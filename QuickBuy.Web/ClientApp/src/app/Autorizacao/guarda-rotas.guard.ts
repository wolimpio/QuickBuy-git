import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { UsuariosService } from '../servicos/usuarios/usuarios.service';

@Injectable({
  providedIn: 'root'
})
export class GuardaRotasGuard implements CanActivate {

  constructor(private router: Router, private usuariosService: UsuariosService) {

  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    const usutarioAutenticado = this.usuariosService.usuario_autenticado();

    if (usutarioAutenticado) {
      return true;
    } else {
      this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
      return false;
    }

  }

}
