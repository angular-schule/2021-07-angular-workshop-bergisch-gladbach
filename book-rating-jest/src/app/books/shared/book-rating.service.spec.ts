import { TestBed } from '@angular/core/testing';
import { Book } from './book';

import { BookRatingService } from './book-rating.service';

describe('BookRatingService', () => {
  let service: BookRatingService;
  let book: Book;

  beforeEach(() => {
    service = new BookRatingService();

    book = {
      isbn: '',
      title: '',
      rating: 3,
      description: '',
      authors: [],
      firstThumbnailUrl: null
    };
  });

  it('should rate up a book by one [JIRA-1231]', () => {
    const ratedBook = service.rateUp(book);
    expect(ratedBook.rating).toBe(4);
  });

  it('should rate down a book by one', () => {
    const ratedBook = service.rateDown(book);
    expect(ratedBook.rating).toBe(2);
  });

  it('it should not rate higher than 5', () => {
    book.rating = 5;
    const ratedBook = service.rateUp(book);
    expect(ratedBook.rating).toBe(5);
  });

  it('it should not rate lower than 1', () => {
    book.rating = 1;
    const ratedBook = service.rateDown(book);
    expect(ratedBook.rating).toBe(1);
  });

  it('it should respect immutability and return a new book', () => {
    const ratedBook = service.rateUp(book);
    expect(ratedBook).not.toBe(book);
  });
});
