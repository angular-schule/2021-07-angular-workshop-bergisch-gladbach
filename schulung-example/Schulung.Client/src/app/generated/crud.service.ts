import { HttpResponse } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { DialogService, markAsTouchedWithChildren, UiMessageService } from '@oevermann/angular';
import { BehaviorSubject, EMPTY, empty, Observable, of, Subject, throwError } from 'rxjs';
import { catchError, share, tap, switchMap, map, first } from 'rxjs/operators';
import { crudToDialog } from './crud-dialog';


export interface CrudHttpService<Model, Id> {

  getForEdit(id: Id): Observable<Model>;

  save(model: Model): Observable<Id>;

  delete?: (id: Id) => Observable<void>;

  defaultModel?: (extraParams?: any) => Observable<Model>;
}

export interface DiscardPrompt<T> {
  data: T;
  save: () => void;
  discard: () => void;
  cancel: () => void;
}

export interface DeletePrompt<T> {
  data: T;
  delete: () => void;
  cancel: () => void;
}

export abstract class CrudService<Model, Id, Form extends FormGroup> {

  constructor(
    protected crudHttpService: CrudHttpService<Model, Id>,
    protected uiMessageService: UiMessageService,
    protected dialogService: DialogService) {
    this._form = this.createForm();
    crudToDialog(dialogService, this);
  }

  private _modelLoadedSubject: Subject<Model> = new Subject();
  public get modelLoaded() {
    return this._modelLoadedSubject.pipe(share());
  }

  private _model: Model;
  public get model(): Model {
    return this._model;
  }

  private _form: Form;
  public get form(): Form {
    return this._form;
  }

  private _selectedId: any;
  public get selectedId() { return this._selectedId; };

  public isOpen: boolean;
  public get isNew() { return this.isOpen && this.model == null; }

  private _isLoading: boolean = false;
  public get isLoading() { return this._isLoading; }
  private _isFailed: boolean = false;
  public get isFailed() { return this._isFailed; }
  private _isSaving: boolean = false;
  public get isSaving() { return this._isSaving; }

  private _errorStatusCode: number = null;
  public get errorStatusCode() { return this._errorStatusCode; }
  private _errorResult: any = null; // TODO: private _errorResult: ErrorResult = null;
  public get errorResult() { return this._errorResult; }

  private loadForEdit() {
    this._isLoading = true;

    const onNext = model => {
      this._model = model;
      //Wir müssen das alte Form wieder aktivieren, da sonst die Controls einfach das neue Form bekommen ohne die Info, dass dieses aktiviert ist.
      if (this._form && this._form.disabled) {
        this._form.enable();
      }
      this._form = this.createForm(model);
      this._isLoading = false;
      this._isFailed = false;
      this._modelLoadedSubject.next(model);
      this._errorResult = null;
      this._errorStatusCode = null;
      this.isOpen = true;
    };

    const onError = error => {

      if (error instanceof HttpResponse) {
        this._errorStatusCode = error.status;
        this._errorResult = error.body;
      }

      this.close();
      this._isLoading = false;
      this._isFailed = true;
      return throwError(error);
    };

    const observable = this.crudHttpService.getForEdit(this.selectedId).pipe(
      tap(onNext),
      catchError(onError),
      share()
    );

    observable.subscribe();

    return observable;
  }

  public load(id: Id): Observable<Model> {
    this._selectedId = id;
    return this.loadForEdit();
  }

  public tryLoad(id: Id): Observable<Model> {
    const observable = this.checkIsDirty().pipe(
      switchMap(result => {
        if (result === 'cancel' || result === 'discard') {
          return of(null);
        } else {
          return this.load(id);
        }
      }),
      share()
    );

    observable.subscribe();

    return observable;
  }

  public reload(): void {
    this.loadForEdit();
  }

  public tryReload() {
    return this.checkIsDirty().pipe(
      tap(result => { if (result !== 'cancel') { this.reload(); } })
    );
  }

  public close() {
    this._model = null;
    this._form = this.createForm();
    this.isOpen = false;
  }

  public tryClose() {
    return this.checkIsDirty().pipe(
      tap(result => { if (result !== 'cancel') { this.close(); } })
    );
  }

  public save(afterSave?: (id: Id) => void, touchBeforeSave?: boolean, onInvalid?: () => void, onError?: (err: any) => void) {

    if (touchBeforeSave) {
      this.form.statusChanges.pipe(first(x => x !== 'PENDING'))
        .subscribe(() => this.internalSave(afterSave, onInvalid, onError));
      markAsTouchedWithChildren(this.form);
    } else {
      this.internalSave(afterSave, onInvalid, onError);
    }

  }

  private internalSave(afterSave?: (id: Id) => void, onInvalid?: () => void, onError?: (err: any) => void) {
    if (this.form.valid) {
      this._isSaving = true;
      this.crudHttpService.save((this._form as any).model).subscribe(
        {
          next: (newId) => {
            this._isSaving = false;
            this._selectedId = newId;
            if (afterSave != null) {
              afterSave(newId);
              //this.form.saveCleanup(); TODO
            } else {
              this.loadForEdit();
            }
          }, error: (err) => {
            if (onError) {
              onError(err);
            }
            this._isSaving = false;
          }
        });
    } else {
      if (onInvalid) {
        onInvalid();
      } else {
        this.uiMessageService.pushError('Bitte prüfen Sie ihre Eingaben.', 'Formular ungültig.');
      }
    }
  }

  private deletePromptSubject = new BehaviorSubject<DeletePrompt<Model> | null>(null);

  get deletePromptChanges() {
    return this.deletePromptSubject;
  }

  public delete() {
    this.crudHttpService.delete(this._selectedId).subscribe(() => {
      this._selectedId = null;
      this.close();
    });
  }

  public triggerDeletePrompt(skipAction = false) {

    if (this.deletePromptSubject.observers.length === 0) {
      return of('none' as 'none');
    }

    const subject = new Subject<'none' | 'delete' | 'cancel'>();

    this.deletePromptSubject.next({
      data: this.form.value,
      delete: () => {
        this.deletePromptSubject.next(null);
        if (!skipAction) {
          this.delete();
        }
        subject.next('delete');
        subject.complete();
      },
      cancel: () => {
        this.deletePromptSubject.next(null);
        subject.next('cancel');
        subject.complete();
      }
    });

    return subject.asObservable();
  }

  /**
   * Liefert ein Observable zur�ck, mit dem geklickten Button (yes,no)
   */
  public tryDelete(): Observable<'none' | 'delete' | 'cancel'> {

    if (this.crudHttpService.delete == null) {
      throw new Error('Delete wird nicht unterstützt.');
    }

    return this.triggerDeletePrompt();
  }

  public create(model?: Model) {
    this._selectedId = null;
    this._model = null;
    this._form = this.createForm(model);
    this.isOpen = true;
  }

  public tryCreate(model?: Model): Observable<Model> {
    return this.checkIsDirty().pipe(
      map(result => {
        if (result === 'discard' || result === 'cancel') {
          return null;
        }
        this.create(model);
        return model;
      })
    );
  }

  protected abstract createForm(model?: Model): Form;

  private discardPromptSubject = new BehaviorSubject<DiscardPrompt<Model> | null>(null);

  get discardPromptChanges() {
    return this.discardPromptSubject.asObservable();
  }

  public triggerDiscardPrompt() {
    if (this.discardPromptSubject.observers.length === 0) {
      return of('none' as 'none');
    }

    const subject = new Subject<'save' | 'discard' | 'cancel'>();

    this.discardPromptSubject.next({
      data: this.form.value,
      save: () => {
        this.discardPromptSubject.next(null);
        this.save();
        subject.next('save');
        subject.complete();
      },
      discard: () => {
        this.discardPromptSubject.next(null);
        subject.next('discard');
        subject.complete();
      },
      cancel: () => {
        this.discardPromptSubject.next(null);
        subject.next('cancel');
        subject.complete();
      }
    });

    return subject.asObservable();
  }

  /**
   * Liefert ein Observable zurück, mit dem geklickten Button (save, discard, cancel, none (wenn nicht dirty))
   */
  private checkIsDirty(): Observable<'none' | 'save' | 'discard' | 'cancel'> {

    if (this.form == null || !this.form.dirty) {
      return of('none' as 'none');
    }

    return this.triggerDiscardPrompt();
  }

  public getResolveObservable(id: Id, extraParams?: any): Observable<Model> {
    if (id === null) {
      if (this.crudHttpService.defaultModel) {
        return this.crudHttpService.defaultModel(extraParams).pipe(switchMap((m: Model) => this.tryCreate(m)));
      }
      return this.tryCreate();
    } else {
      return this.tryLoad(id);
    }
  }
}
