import { TestBed } from '@angular/core/testing';

import { CrudEstoqueService } from './Services/CRUD - Cliente/crud-estoque.service';

describe('CrudEstoqueService', () => {
  let service: CrudEstoqueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CrudEstoqueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
