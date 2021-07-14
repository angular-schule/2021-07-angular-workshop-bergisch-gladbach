import { TestBed } from '@angular/core/testing';

import { BookFacadeService } from './book-facade.service';

describe('BookFacadeService', () => {
  let service: BookFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
