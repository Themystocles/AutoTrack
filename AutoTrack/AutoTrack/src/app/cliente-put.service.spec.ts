import { TestBed } from '@angular/core/testing';

import { ClientePutService } from './Services/CRUD - Cliente/cliente-put.service';

describe('ClientePutService', () => {
  let service: ClientePutService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientePutService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
