import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, filter, switchMap, tap } from 'rxjs/operators';
import { Book } from '../shared/book';
import { BookStoreService } from '../shared/book-store.service';

@Component({
  selector: 'br-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  control = new FormControl();
  term$: Observable<string> = this.control.valueChanges;
  results$: Observable<Book[]> = of([]);
  loading = false;

  constructor(private bs: BookStoreService) { }

  ngOnInit(): void {
    this.results$ = this.term$.pipe(
      debounceTime(500),
      filter(term => term.length >= 3 || term.length === 0),
      tap(() => this.loading = true),
      switchMap(term => this.bs.search(term)),
      tap(() => this.loading = false),
    );
  }

}
