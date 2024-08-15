import { TestBed } from '@angular/core/testing';

import { VeiculoPutService } from './Services/CRUD - Cliente/veiculo-put.service';

describe('VeiculoPutService', () => {
  let service: VeiculoPutService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VeiculoPutService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
