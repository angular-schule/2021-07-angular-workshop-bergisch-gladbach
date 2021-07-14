import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { BooksRoutingModule } from './books-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BookComponent } from './book/book.component';
import { RepeatDirective } from './shared/repeat.directive';
import { CreateBookComponent } from './create-book/create-book.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { BookFormComponent } from './book-form/book-form.component';
import { SearchComponent } from './search/search.component';
import { Store, StoreModule } from '@ngrx/store';
import * as fromBook from './store/book.reducer';
import { EffectsModule } from '@ngrx/effects';
import { BookEffects } from './store/book.effects';
import { loadBooks } from './store/book.actions';
import { BookFacadeService } from './store/book-facade.service';


@NgModule({
  declarations: [
    DashboardComponent,
    BookComponent,
    RepeatDirective,
    BookFormComponent,
    CreateBookComponent,
    BookDetailsComponent,
    SearchComponent,
  ],
  imports: [
    CommonModule,
    BooksRoutingModule,
    ReactiveFormsModule,
    StoreModule.forFeature(fromBook.bookFeatureKey, fromBook.reducer),
    EffectsModule.forFeature([BookEffects])
  ],
  exports: [
    DashboardComponent
  ]
})
export class BooksModule {
  constructor(facade: BookFacadeService) {
    facade.loadBooks();
  }
}
