import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { BookDetailResolver } from './book-detail/book-detail.resolver';
import { HomeComponent } from './home.component';
import { HomeResolver } from './home.resolver';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    resolve: {
      list: HomeResolver
    }
  },
  {
    path: 'detail/:id',
    component: BookDetailComponent,
    resolve: {
      book: BookDetailResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule {
}
