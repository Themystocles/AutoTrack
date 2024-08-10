import { TestBed } from '@angular/core/testing';

import { ClientePostService } from './Services/CRUD - Cliente/cliente-post.service';

describe('ClientePostService', () => {
  let service: ClientePostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientePostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
