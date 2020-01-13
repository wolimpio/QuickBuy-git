import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalPerguntaComponent } from './ModalPergunta.component';

describe('ModalPerguntaComponent', () => {
  let component: ModalPerguntaComponent;
  let fixture: ComponentFixture<ModalPerguntaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ModalPerguntaComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalPerguntaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
