import { TestBed } from '@angular/core/testing';

import { ServicoPostService } from './Services/CRUD - Cliente/servico-post.service';

describe('ServicoPostService', () => {
  let service: ServicoPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicoPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
