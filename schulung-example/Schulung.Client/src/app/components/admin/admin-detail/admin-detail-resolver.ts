import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { BooksCrudService } from '../../../generated/books-crud.service';
import { BookEditTM } from '../../../generated/models';

@Injectable()
export class AdminDetailResolver implements Resolve<BookEditTM | null> {

  constructor(private httpService: BooksCrudService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<BookEditTM | null> {
    return this.httpService.getResolveObservable(+route.params.id === 0 ? null : +route.params.id);
  }
}
