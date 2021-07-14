/* eslint-disable arrow-body-style */
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

import { BookStoreService } from '../shared/book-store.service';
import * as BookActions from './book.actions';


@Injectable()
export class BookEffects {

  loadBooks$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(BookActions.loadBooks),
      switchMap(() =>
        this.bs.getAll().pipe(
          map(books => BookActions.loadBooksSuccess({ books })),
          catchError(error => of(BookActions.loadBooksFailure({ error }))))
      )
    );
  });



  constructor(private actions$: Actions, private bs: BookStoreService) {}

}
