import { TestBed, inject } from '@angular/core/testing';

import { ModalPerguntaService } from './modal-pergunta.service';

describe('ModalPerguntaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ModalPerguntaService]
    });
  });

  it('should be created', inject([ModalPerguntaService], (service: ModalPerguntaService) => {
    expect(service).toBeTruthy();
  }));
});
