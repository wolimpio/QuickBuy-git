import { TestBed, inject } from '@angular/core/testing';

import { PedidoService } from './pedido.service';

describe('PedidoServicoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PedidoService]
    });
  });

  it('should be created', inject([PedidoService], (service: PedidoService) => {
    expect(service).toBeTruthy();
  }));
});
