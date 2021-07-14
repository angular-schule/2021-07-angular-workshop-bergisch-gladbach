import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Book } from '../shared/book';
import { BookStoreService } from '../shared/book-store.service';
import { loadBooks, loadBooksFailure, loadBooksSuccess } from './book.actions';
import { selectBookByIsbn, selectBookByIsbnFactory, selectBooks, selectLoading } from './book.selectors';

@Injectable({
  providedIn: 'root'
})
export class BookFacadeService {

  books$ = this.store.select(selectBooks);
  loading$ = this.store.select(selectLoading);

  constructor(private store: Store, private bs: BookStoreService) { }

  loadBooks(): void {
    this.store.dispatch(loadBooks());
  }

  loadBooks2(): Observable<Book[]> {
    this.store.dispatch(loadBooks());
    return this.store.select(selectBooks);
  }

  // without Effects (using caution)
  loadBooks3(): void {

    this.store.dispatch(loadBooks());

    this.bs.getAll().subscribe({
      next: books => this.store.dispatch(loadBooksSuccess({ books })),
      error: (error: HttpErrorResponse) =>  this.store.dispatch(loadBooksFailure({ error })),
    });
  }

  // depcrecated
  getBookByIsbn(isbn: string): Observable<Book | undefined> {
    return this.store.select(selectBookByIsbn, { isbn });
  }

  getBookByIsbn2(isbn: string): Observable<Book | undefined> {
    return this.store.select(selectBookByIsbnFactory(isbn));
  }
}
