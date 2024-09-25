import { TestBed } from '@angular/core/testing';

import { FuncionarioPostService } from './funcionario-post.service';

describe('FuncionarioPostService', () => {
  let service: FuncionarioPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FuncionarioPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
