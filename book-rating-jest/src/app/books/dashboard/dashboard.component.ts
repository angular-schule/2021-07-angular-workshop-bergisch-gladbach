import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

import { Book } from '../shared/book';
import { BookFacadeService } from '../store/book-facade.service';

@Component({
  selector: 'br-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardComponent implements OnInit {

  booksTheOtherWay$ = this.facade.loadBooks2();
  angularBook$ = this.facade.getBookByIsbn('9783864907791');

  constructor(public facade: BookFacadeService) { }

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
