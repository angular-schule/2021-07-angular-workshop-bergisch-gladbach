import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { BooksHttpService } from '../../../generated/books-http.service';
import { BookTM } from '../../../generated/models';

@Injectable()
export class BookDetailResolver implements Resolve<BookTM | null> {

  constructor(private httpService: BooksHttpService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<BookTM | null> {
    return this.httpService.detail(+route.params.id);
  }
}
