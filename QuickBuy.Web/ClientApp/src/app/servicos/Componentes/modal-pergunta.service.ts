import { Injectable, EventEmitter } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalPerguntaService {
  _resposta: BehaviorSubject<boolean>;

  constructor() {
    this._resposta = new BehaviorSubject<boolean>(null);
  }

  public responder(resposta: boolean) {
    this._resposta.next(resposta);
  }

  public getResposta(): Observable<boolean> {
    while (this._resposta.value == null) {
      return this._resposta.asObservable();
    }
  }
}
