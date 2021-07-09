import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import { Book } from './book';

@Injectable({
  providedIn: 'root'
})
export class TypeaheadService {

  private apiUrl = 'https://api.angular.schule/books/search/';

  constructor(private http: HttpClient) { }

  search(term: string): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl + term).pipe(
      catchError(() => of([]))
    );
  }
}
