import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { catchError, concatMap, map, mergeMap, share, shareReplay, startWith, switchMap, tap } from 'rxjs/operators';

import { BookStoreService } from '../shared/book-store.service';

@Component({
  selector: 'br-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent {

  showDetails = false;

  book$ = this.route.paramMap.pipe(
    map(paramMap => paramMap.get('isbn') || ''),
    switchMap(isbn => this.bs.getSingle(isbn)),
    // share()
    // shareReplay(1)
    catchError((err: HttpErrorResponse) => of({
      title: 'ERROR',
      description: err.message
    }))
  );

  constructor(private route: ActivatedRoute, private bs: BookStoreService) { }
}
