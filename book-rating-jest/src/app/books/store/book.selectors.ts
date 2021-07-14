import { createFeatureSelector, createSelector } from '@ngrx/store';
import { createChildSelectors } from 'ngrx-child-selectors';
import { Book } from '../shared/book';
import * as fromBook from './book.reducer';

export const selectBookState = createFeatureSelector<fromBook.State>(
  fromBook.bookFeatureKey
);

// export const selectLoading = createSelector(
//   selectBookState,
//   state => state.loading
// );

// export const selectBooks = createSelector(
//   selectBookState,
//   state => state.books
// );

// ODER

export const {
  selectBooks,
  selectLoading
} = createChildSelectors(selectBookState, fromBook.initialState);


// weitere Beispiele

export const selectFirstBookTitle = createSelector(
  selectBooks,
  state => state.length ? state[0].title : 'no title'
);

export const selectBookByIsbn = createSelector(
  selectBooks,
  (state: Book[], props: { isbn: string }) => state.find(b => b.isbn === props.isbn)
);
