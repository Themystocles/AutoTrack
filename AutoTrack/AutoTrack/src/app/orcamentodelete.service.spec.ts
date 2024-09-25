import { TestBed } from '@angular/core/testing';

import { OrcamentodeleteService } from './Services/CRUD - Cliente/orcamentodelete.service';

describe('OrcamentodeleteService', () => {
  let service: OrcamentodeleteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrcamentodeleteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
