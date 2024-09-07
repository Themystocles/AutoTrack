import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelecionarprintComponent } from './selecionarprint.component';

describe('SelecionarprintComponent', () => {
  let component: SelecionarprintComponent;
  let fixture: ComponentFixture<SelecionarprintComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelecionarprintComponent]
    });
    fixture = TestBed.createComponent(SelecionarprintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
