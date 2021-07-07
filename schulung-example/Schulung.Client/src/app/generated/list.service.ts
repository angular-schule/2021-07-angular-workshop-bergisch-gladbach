import { Observable, BehaviorSubject, Subscription, Subject, merge } from 'rxjs';
import { tap, skip, filter, take, startWith, pairwise, debounceTime } from 'rxjs/operators';
import { FormGroup } from '@angular/forms';
import { PagedResult } from './models';
import { PagedRequestForm } from './helpers';

export abstract class ListService<RequestType, RequestFormType extends PagedRequestForm & FormGroup, ResultType> {

  private subscription: Subscription;
  private loadingSubject: BehaviorSubject<boolean>;
  private resultSubject: BehaviorSubject<PagedResult<ResultType>>;
  private _ignoreNextChange = false;

  public primeNgFirst = 0;
  public primeNgSortOrder = 1;

  readonly form: RequestFormType;
    
  protected constructor(initialRequest: RequestType, ...reloads: Observable<any>[]) {

    this.loadingSubject = new BehaviorSubject<boolean>(false);
    this.resultSubject = new BehaviorSubject<PagedResult<ResultType>>(null);

    this.form = this.createForm(initialRequest);
    this.primeNgSortOrder = this.form.sortOrder.value == 1 ? -1 : 1;

    if (reloads) {
      merge(...reloads).subscribe(() => this.loadInternal());
    }
    this.form.valueChanges
      .pipe(
        startWith(null),
        pairwise(),
        tap(() => this.loadingSubject.next(true)),
        debounceTime(300) // TODO: Debounce wirklich immer machen?
      )
      .subscribe(([prev, next]) => {
        if (this._ignoreNextChange) {
          this._ignoreNextChange = false;
          return;
        }
        if (prev != null && next.page === prev.page) {
          this.form.page.setValue(1, { emitEvent: false });
          //this.primeNgFirst = 0;
        }
        this.loadInternal();
      });

    this.form.page.valueChanges.subscribe((p) => {
      this.primeNgFirst = this.form.pageSize.value * (this.form.page.value - 1);
    })
  }

  ignoreNextChange() {
    this._ignoreNextChange = true;
  }

  private loadInternal() {
    if (this.subscription) {
      this.subscription.unsubscribe();
      this.subscription = null;
    }
    this.loadingSubject.next(true);
    this.subscription = this.load(this.form.value)
      .pipe(
        tap(() => this.loadingSubject.next(false))
      )
      .subscribe((s) => {
        this.primeNgFirst = s.pageSize * (s.page - 1);
        this.resultSubject.next(s)
      });
  }

  protected abstract createForm(request: RequestType): RequestFormType;

  protected abstract load(request: RequestType): Observable<PagedResult<ResultType>>;

  get requestChanges() {
    return this.form.valueChanges as Observable<RequestType>;
  }

  setRequest(request: RequestType) {
    this.form.setValue(request);
  }

  get loadingChanges() {
    return this.loadingSubject.asObservable();
  }

  get loading() {
    return this.loadingSubject.value;
  }

  get resultChanges() {
    return this.resultSubject.asObservable();
  }

  get resultFullPageChanges() {
    return this.resultSubject.pipe(tap((result: any) => { // todo: any durch korrekten Typ ersetzen
      if (result) {
        let items = new Array(result.pageSize);
        for (let i = 0; i < result.items.length; i++) {
          items[i] = this.result.items[i];
        }
        result.items = items;
      }
    }));
  }

  get result() {
    return this.resultSubject.value;
  }

  reload() {
    this.loadInternal();
  }

  getResolveObservable(reload: boolean) {
    if (reload) {
      this.reload();
      return this.resultChanges.pipe(skip(1), take(1));
    } else if (this.result) {
      return this.resultChanges.pipe(skip(1), filter(r => r != null), take(1));
    }
    return this.resultChanges.pipe(filter(r => r != null), take(1));
  }

  primeNgLazyLoad(event: any) {
    const newSortOrder = event.sortOrder == -1 ? 1 : 0;
    const newPage = (event.first / event.rows) + 1;
    if (this.form.sort.value != event.sortField) {
      this.form.sort.setValue(event.sortField);
    }
    if (this.form.sortOrder.value != newSortOrder) {
      this.form.sortOrder.setValue(newSortOrder);
    }
    if (this.form.pageSize.value != event.rows) {
      this.form.pageSize.setValue(event.rows);
    }
    if (this.form.page.value != newPage) {
      this.form.page.setValue(newPage);
    }
  }

  pageForward() {
    this.form.page.setValue(this.form.page.value + 1);
  }

  pageBackward() {
    this.form.page.setValue(this.form.page.value - 1);
  }
}
