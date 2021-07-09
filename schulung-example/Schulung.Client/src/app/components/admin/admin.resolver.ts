import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { BooksListService } from '../../generated/books-list.service';
import { BookListTM, PagedResult } from '../../generated/models';

@Injectable()
export class AdminResolver implements Resolve<PagedResult<BookListTM>> {
  constructor(private listService: BooksListService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<PagedResult<BookListTM>> {
    if (this.listService.form.dateRange.model?.length === 0) {
      this.listService.form.dateRange.setValue(null, { emitEvent: false });
    }
    return this.listService.getResolveObservable(true);
  }
}
