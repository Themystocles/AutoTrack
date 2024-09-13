import { TestBed } from '@angular/core/testing';

import { FiltroEstoqueService } from './Services/filtro-estoque.service';

describe('FiltroEstoqueService', () => {
  let service: FiltroEstoqueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FiltroEstoqueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
