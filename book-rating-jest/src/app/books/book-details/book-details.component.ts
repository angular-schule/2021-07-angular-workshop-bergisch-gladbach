import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { concatMap, map, mergeMap, share, shareReplay, startWith, switchMap, tap } from 'rxjs/operators';

import { BookStoreService } from '../shared/book-store.service';

@Component({
  selector: 'br-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent {

  showDetails = false;
  isLoading = false;

  book$ = this.route.paramMap.pipe(
    map(paramMap => paramMap.get('isbn') || ''),
    tap(() => this.isLoading = true),
    switchMap(isbn => this.bs.getSingle(isbn)),
    tap(() => this.isLoading = false),
    // share()
    // shareReplay(1)
  );

  constructor(private route: ActivatedRoute, private bs: BookStoreService) { }
}
