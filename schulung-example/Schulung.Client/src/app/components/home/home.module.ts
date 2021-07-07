import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { PipesModule } from '@oevermann/angular';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { PaginatorModule } from 'primeng/paginator';
import { BooksListService } from '../../generated/books-list.service';
import { BookDetailResolver } from './book-detail/book-detail.resolver';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { HomeResolver } from './home.resolver';


@NgModule({
  declarations: [
    HomeComponent,
    BookDetailComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    InputTextModule,
    TranslateModule,
    ReactiveFormsModule,
    CalendarModule,
    PipesModule,
    PaginatorModule
  ],
  providers: [
    BooksListService,
    HomeResolver,
    BookDetailResolver
  ]
})
export class HomeModule {
}
