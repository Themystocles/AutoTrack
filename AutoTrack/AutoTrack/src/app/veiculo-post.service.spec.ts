import { TestBed } from '@angular/core/testing';

import { VeiculoPostService } from './Services/CRUD - Cliente/veiculo-post.service';

describe('VeiculoPostService', () => {
  let service: VeiculoPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VeiculoPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
