import { TestBed } from '@angular/core/testing';

import { AviocompanyService } from './aviocompany.service';

describe('AviocompanyService', () => {
  let service: AviocompanyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AviocompanyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
