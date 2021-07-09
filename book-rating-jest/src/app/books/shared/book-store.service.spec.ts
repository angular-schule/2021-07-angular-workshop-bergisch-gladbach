import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { BookStoreService } from './book-store.service';
import { Book } from './book';

describe('BookStoreService', () => {
  let service: BookStoreService;
  let httpCtrl: HttpTestingController;
  const dummyBook = {
    isbn: '000',
    title: 'Angular'
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });

    service = TestBed.inject(BookStoreService);
    httpCtrl = TestBed.inject(HttpTestingController);
  });

  it('should make the expected HTTP call for getSingle', () => {

    let result: Book | null = null;
    service.getSingle('123').subscribe(book => result = book);


    const req = httpCtrl.expectOne('https://api.angular.schule/books/123');
    req.flush(dummyBook);

    expect(req.request.method).toBe('GET');

    // const req2 = httpCtrl.expectOne('https://api.angular.schule/xxxxxx');
    // req2.flush(dummyBook);

    // es dürfen keine Requests mehr offen sein
    httpCtrl.verify();
  });
});

