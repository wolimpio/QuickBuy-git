import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GuardaRotasGuard implements CanActivate {

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    const usutarioAutenticado = sessionStorage.getItem("usuario-autenticado");
    if (usutarioAutenticado === "1") {
      return true;
    } else {
      this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
      return false;
    }

  }

  constructor(private router: Router) {

  }
}
