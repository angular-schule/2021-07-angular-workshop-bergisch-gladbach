import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { PipesModule } from '@oevermann/angular';
import { CalendarModule } from 'primeng/calendar';
import { EditorModule } from 'primeng/editor';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { BooksCrudService } from '../../generated/books-crud.service';
import { BooksListService } from '../../generated/books-list.service';
import { ErrorLabelModule } from '../shared/error-label/error-label.module';
import { AdminDetailResolver } from './admin-detail/admin-detail-resolver';
import { AdminDetailComponent } from './admin-detail/admin-detail.component';
import { AdminDetailGuard } from './admin-detail/admin-detail.guard';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AdminResolver } from './admin.resolver';


@NgModule({
  declarations: [
    AdminComponent,
    AdminDetailComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    TableModule,
    TranslateModule,
    InputTextModule,
    ReactiveFormsModule,
    CalendarModule,
    PipesModule,
    EditorModule,
    ErrorLabelModule
  ],
  providers: [
    BooksListService,
    BooksCrudService,
    AdminResolver,
    AdminDetailResolver,
    AdminDetailGuard
  ]
})
export class AdminModule {
}
