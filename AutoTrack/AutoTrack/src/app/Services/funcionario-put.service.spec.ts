import { TestBed } from '@angular/core/testing';

import { FuncionarioPutService } from './funcionario-put.service';

describe('FuncionarioPutService', () => {
  let service: FuncionarioPutService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FuncionarioPutService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
