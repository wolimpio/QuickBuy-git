import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Produto } from 'src/app/modelo/produto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService implements OnInit {

  private _baseUrl: string;
  public _produtos: Produto[];
  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this._produtos = [];
  }

  public cadastrar(produto: Produto): Observable<Produto> {

    return this.http.post<Produto>(this._baseUrl + 'api/produto/cadastrar', JSON.stringify(produto), { headers: this.headers });
  }

  public salvar(produto: Produto): Observable<Produto> {

    return this.http.post<Produto>(this._baseUrl + 'api/produto/salvar', JSON.stringify(produto), { headers: this.headers });
  }

  public deletar(produto: Produto): Observable<Produto> {

    return this.http.post<Produto>(this._baseUrl + 'api/produto/deletar', JSON.stringify(produto), { headers: this.headers });
  }

  public obterTodos(): Observable<Produto[]> {

    return this.http.get<Produto[]>(this._baseUrl + 'api/produto');
  }

  public obterPorId(produtoId: number): Observable<Produto> {

    return this.http.get<Produto>(this._baseUrl + 'api/produto');
  }
}
