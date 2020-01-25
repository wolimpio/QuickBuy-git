import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompraSucessoComponent } from './compra-sucesso.component';

describe('CompraSucessoComponent', () => {
  let component: CompraSucessoComponent;
  let fixture: ComponentFixture<CompraSucessoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompraSucessoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompraSucessoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
