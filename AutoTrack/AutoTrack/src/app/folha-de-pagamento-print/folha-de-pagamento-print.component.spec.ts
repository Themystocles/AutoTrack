import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FolhaDePagamentoPrintComponent } from './folha-de-pagamento-print.component';

describe('FolhaDePagamentoPrintComponent', () => {
  let component: FolhaDePagamentoPrintComponent;
  let fixture: ComponentFixture<FolhaDePagamentoPrintComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FolhaDePagamentoPrintComponent]
    });
    fixture = TestBed.createComponent(FolhaDePagamentoPrintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
