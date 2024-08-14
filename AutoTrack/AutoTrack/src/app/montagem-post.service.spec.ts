import { TestBed } from '@angular/core/testing';

import { MontagemPostService } from './Services/CRUD - Cliente/montagem-post.service';

describe('MontagemPostService', () => {
  let service: MontagemPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MontagemPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
