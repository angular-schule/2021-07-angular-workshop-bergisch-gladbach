import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';

import { Book } from '../shared/book';
import { BookRatingService } from '../shared/book-rating.service';
import { BookStoreService } from '../shared/book-store.service';

@Component({
  selector: 'br-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  books: Book[] = [];

  constructor(
    // AKTIVIEREN für HTTP
    // private bs: BookStoreService,
    private rs: BookRatingService
    ) { }

    ngOnInit() {
    // AKTIVIEREN für HTTP
    // this.bs.getAll().subscribe(books => this.books = books);
    this.books = [
      {
        isbn: '111',
        title: 'Angular',
        description: 'Grundlagen und Best Practices',
        authors: ['Ferdinand Malcher', 'Johannes Hoppe'],
        rating: 5,
        firstThumbnailUrl: null
      },
      {
        isbn: '222',
        title: 'React',
        description: 'Das andere Framework',
        authors: ['Max Mustermann', 'Erika Musterfrau'],
        rating: 3,
        firstThumbnailUrl: null
      },
      {
        isbn: '333',
        title: 'AngularJS',
        description: '??',
        authors: ['??', '??'],
        rating: 3,
        firstThumbnailUrl: null
      },
    ];
  }

  rateUp(book: Book) {
    const ratedBook = this.rs.rateUp(book);
    this.updateList(ratedBook);
  }

  rateDown(book: Book) {
    const ratedBook = this.rs.rateDown(book);
    this.updateList(ratedBook);
  }

  updateList(ratedBook: Book) {
    this.books = this.books
      .map(b => b.isbn === ratedBook.isbn ? ratedBook : b);
  }

  trackBook(index: number, item: Book) {
    return item.isbn;
  }
}
