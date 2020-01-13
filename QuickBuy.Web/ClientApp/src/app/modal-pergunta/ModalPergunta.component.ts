import { Component, OnInit, OnDestroy } from '@angular/core';
import { ModalPerguntaService } from '../servicos/Componentes/modal-pergunta.service';

@Component({
  selector: 'app-modal-pergunta',
  templateUrl: './modal-pergunta.component.html',
  styleUrls: ['./modal-pergunta.component.css']
})
export class ModalPerguntaComponent implements OnInit, OnDestroy {
  constructor(private modalPerguntaservico: ModalPerguntaService) { }

  ngOnInit() {
  }

  ngOnDestroy(): void {
    // this.modalPerguntaservico.getResposta().subscribe().unsubscribe();
  }

  public responder(resposta: boolean) {
    this.modalPerguntaservico.responder(resposta);
  }

}
