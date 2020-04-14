import { TestBed } from '@angular/core/testing';

import { AvioadminGuard } from './avioadmin.guard';

describe('AvioadminGuard', () => {
  let guard: AvioadminGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AvioadminGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
