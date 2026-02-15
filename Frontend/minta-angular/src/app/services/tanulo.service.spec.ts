import { TestBed } from '@angular/core/testing';

import { TanuloService } from './tanulo.service';

describe('TanuloService', () => {
  let service: TanuloService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TanuloService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
