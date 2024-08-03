import { TestBed } from '@angular/core/testing';

import { FiltroServicesService } from './filtro-services.service';

describe('FiltroServicesService', () => {
  let service: FiltroServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FiltroServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
