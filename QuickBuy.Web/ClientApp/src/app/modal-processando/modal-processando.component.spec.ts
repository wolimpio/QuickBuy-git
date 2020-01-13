import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalProcessandoComponent } from './modal-processando.component';

describe('ModalProcessandoComponent', () => {
  let component: ModalProcessandoComponent;
  let fixture: ComponentFixture<ModalProcessandoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalProcessandoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalProcessandoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
