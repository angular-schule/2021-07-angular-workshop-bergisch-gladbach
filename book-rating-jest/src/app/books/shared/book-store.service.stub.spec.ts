import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { Book } from './book';

import { BookStoreService } from './book-store.service';

describe('BookStoreService with HTTP stub', () => {
  let service: BookStoreService;
  let httpMock: Partial<HttpClient>;
  const dummyBook = {
    isbn: '000',
    title: 'Angular'
  };

  beforeEach(() => {
    httpMock = {
      get: jest.fn().mockReturnValue(of(dummyBook))
    };

    TestBed.configureTestingModule({
      providers: [{
        provide: HttpClient,
        useValue: httpMock
      }]
    });
    service = TestBed.inject(BookStoreService);
  });

  it('should call the correct URL for getSingle', () => {
    service.getSingle('123');
    expect(httpMock.get).toHaveBeenCalledWith('https://api.angular.schule/books/123');
  });

  it('should provide the requested book', () => {
    let result: Book | null = null;
    service.getSingle('123').subscribe(book => result = book);

    expect(result).toEqual(dummyBook);
  });

});
