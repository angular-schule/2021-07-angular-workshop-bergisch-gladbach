import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BooksCrudService } from '../../../generated/books-crud.service';
import { AdminDetailComponent } from './admin-detail.component';

@Injectable()
export class AdminDetailGuard implements CanDeactivate<AdminDetailComponent> {

  constructor(private crudService: BooksCrudService) {
  }

  canDeactivate(
    component: AdminDetailComponent,
    currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot,
    nextState?: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.crudService.tryClose().pipe(map(s => s !== 'cancel'));
  }
  
}
