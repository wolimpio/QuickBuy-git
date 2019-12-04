import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/modelo/usuario';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private urlbase: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlbase = baseUrl;
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      email: usuario.email,
      senha: usuario.senha
    }

    return this.http.post<Usuario>(this.urlbase + 'api/usuario', body, { headers });
  }
}
