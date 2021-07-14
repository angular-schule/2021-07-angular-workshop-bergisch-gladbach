import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { catchError, concatMap, map, mergeMap, retry, share, shareReplay, startWith, switchMap, tap } from 'rxjs/operators';

import { BookStoreService } from '../shared/book-store.service';
import { BookFacadeService } from '../store/book-facade.service';

@Component({
  selector: 'br-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent {

  showDetails = false;

  book$ = this.facade.selectedBook$;

  constructor(private facade: BookFacadeService) { }
}
