import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/modelo/usuario';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private urlbase: string;
  private _usuario: Usuario;

  set usuario(usuario: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
    this._usuario = usuario;

    console.log(this.usuario);
  }

  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem("usuario-autenticado");
    this._usuario = JSON.parse(usuario_json);

    return this._usuario;
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public usuario_autenticado(): boolean {
    return this._usuario != null && this._usuario.email != null && this._usuario.senha != null;
  }

  public usuario_admin(): boolean {
    return this.usuario_autenticado() && this._usuario.admin;
  }

  public limpar_sessao() {
    sessionStorage.setItem("usuario-autenticado", "");
    this._usuario = null;
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlbase = baseUrl;
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      email: usuario.email,
      senha: usuario.senha
    }


    return this.http.post<Usuario>(this.urlbase + 'api/usuario/VerificarUsuario', body, { headers });
  }

  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.urlbase + 'api/usuario/', JSON.stringify(usuario), { headers: this.headers });
  }
}
