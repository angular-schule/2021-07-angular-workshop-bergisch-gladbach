import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';

import { Book } from '../shared/book';
import { BookRatingService } from '../shared/book-rating.service';
import { BookStoreService } from '../shared/book-store.service';
import { TestService } from '../shared/test.service';

@Component({
  selector: 'br-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [TestService]
})
export class DashboardComponent implements OnInit {

  books: Book[] = [];

  constructor(
    private bs: BookStoreService,
    private rs: BookRatingService,
    private test: TestService
    ) { }

  ngOnInit() {
    // this.bs.getAll().subscribe(books => this.books = books);
  }

  rateUp(book: Book) {
    // const ratedBook = this.rs.rateUp(book);
    // this.updateList(ratedBook);
  }

  rateDown(book: Book) {
    // const ratedBook = this.rs.rateDown(book);
    // this.updateList(ratedBook);
  }

  updateList(ratedBook: Book) {
    // this.books = this.books
    //   .map(b => b.isbn === ratedBook.isbn ? ratedBook : b);
  }

  trackBook(index: number, item: Book) {
    return item.isbn;
  }
}
