import { Injectable, Inject } from "@angular/core";
import { Subject, Observable } from "rxjs";
import { UiMessageService, UiMessageServiceToken, HttpService, URI } from "@oevermann/angular";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map, tap, share } from "rxjs/operators";
import { BookEditTM, BookTM, BookListRequestTM, PagedResult, BookListTM } from "./models";

@Injectable()
export class BooksHttpService {
  
  private changesSubject = new Subject<void>();
  
  get changes() { return this.changesSubject.asObservable(); }

  constructor(private httpService: HttpService, @Inject(UiMessageServiceToken) private messageService: UiMessageService) { }
  
  public delete(id: number, customHeaders?: HttpHeaders) {
    return this.httpService.delete<void>(URI`/api/books/delete`, 'json', { id }, customHeaders).pipe(
      map((response: HttpResponse <void>) => response.body),
      tap(() => this.changesSubject.next()),
      share()
    );
  }
  
  public default(customHeaders?: HttpHeaders) {
    return this.httpService.get<BookEditTM>(URI`/api/books/default`, 'json', customHeaders).pipe(
      map((response: HttpResponse <BookEditTM>) => response.body),
      share()
    );
  }
  
  public defaultModel(extraParams?: any, customHeaders?: HttpHeaders): Observable<BookEditTM> {
    return this.default(customHeaders);
  }
  
  public detail(id: number, customHeaders?: HttpHeaders) {
    return this.httpService.get<BookTM>(URI`/api/books/detail`, 'json', { id }, customHeaders).pipe(
      map((response: HttpResponse <BookTM>) => response.body),
      share()
    );
  }
  
  public edit(id: number, customHeaders?: HttpHeaders) {
    return this.httpService.get<BookEditTM>(URI`/api/books/edit`, 'json', { id }, customHeaders).pipe(
      map((response: HttpResponse <BookEditTM>) => response.body),
      share()
    );
  }
  
  public getForEdit(id: number, customHeaders?: HttpHeaders): Observable<BookEditTM> {
    return this.edit(id, customHeaders);
  }
  
  public list(request: BookListRequestTM, customHeaders?: HttpHeaders) {
    return this.httpService.post<PagedResult<BookListTM>>(URI`/api/books/list`, 'json', request, customHeaders).pipe(
      map((response: HttpResponse <PagedResult<BookListTM>>) => response.body),
      share()
    );
  }
  
  public save(model: BookEditTM, customHeaders?: HttpHeaders) {
    return this.httpService.post<number>(URI`/api/books/save`, 'json', model, customHeaders).pipe(
      map((response: HttpResponse <number>) => response.body),
      tap(() => this.changesSubject.next()),
      share()
    );
  }
}
