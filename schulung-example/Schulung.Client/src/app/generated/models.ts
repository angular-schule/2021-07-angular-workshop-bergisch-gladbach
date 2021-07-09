import { TMValue, PropertyRights, TypedFormControl, TypedFormGroup, TypedFormArray, TypedFormDictionary, mapValues } from "./helpers";
import { HttpService, OnValidators, SanitizeValidator, OnHttpAsyncValidator } from "@oevermann/angular";
import { ValidatorFn, AsyncValidatorFn, Validators } from "@angular/forms";
import { SortOrder } from "./enums";

export interface BookEditTM {
  id: number;
  title: string | null;
  description: string | null;
  authorId: number;
  changedAt: string;
  changedBy: string | null;
  createdAt: string;
  createdBy: string | null;
  isbn: string | null;
  author: AuthorEditTM | null;
  markAsDeleted: boolean;
}

export namespace BookEditTM {

  export function empty(): BookEditTM {
    return {
      id: 0,
      title: null,
      description: null,
      authorId: 0,
      changedAt: "0001-01-01T00:00:00",
      changedBy: null,
      createdAt: "0001-01-01T00:00:00",
      createdBy: null,
      isbn: null,
      author: AuthorEditTM.empty(),
      markAsDeleted: false,
    };
  }
  
  export interface Value {
    id: number;
    title: string | null;
    description: string | null;
    authorId: number;
    isbn: string | null;
    author: AuthorEditTM.Value | null;
    markAsDeleted: boolean;
  }
  
  interface Controls {
    id: TypedFormControl<number>;
    title: TypedFormControl<string>;
    description: TypedFormControl<string>;
    authorId: TypedFormControl<number>;
    isbn: TypedFormControl<string>;
    author: AuthorEditTM.FormGroup;
    markAsDeleted: TypedFormControl<boolean>;
  }
  
  export class FormGroup extends TypedFormGroup<BookEditTM.Value, Controls> {
    
    private _model: BookEditTM;
    
    constructor(private httpService: HttpService, model: BookEditTM, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super({}, validator, asyncValidator);
      if (!model) {
        model = empty();
      }
      this._model = model;
      
      this.addControl('id', new TypedFormControl<number>(model.id, Validators.compose([Validators.required])));
      
      this.addControl('title', new TypedFormControl<string>(model.title, Validators.compose([Validators.required])));
      
      this.addControl('description', new TypedFormControl<string>(model.description, null, Validators.composeAsync([new SanitizeValidator(this.httpService, null,null,null,null,null).validate])));
      
      this.addControl('authorId', new TypedFormControl<number>(model.authorId, Validators.compose([OnValidators.requiredIntForeignKey])));
      
      this.addControl('isbn', new TypedFormControl<string>(model.isbn, Validators.compose([Validators.minLength(0), Validators.maxLength(20), Validators.required])));
      
      if(model.author != null) { this.addControl('author', new AuthorEditTM.FormGroup(httpService, model.author, null)); }
      
      this.addControl('markAsDeleted', new TypedFormControl<boolean>(model.markAsDeleted, null));
    }
    
    get id() {
      return this.controls.id as any as TypedFormControl<number>;
    }
    
    get title() {
      return this.controls.title as any as TypedFormControl<string>;
    }
    
    get description() {
      return this.controls.description as any as TypedFormControl<string>;
    }
    
    get authorId() {
      return this.controls.authorId as any as TypedFormControl<number>;
    }
    
    get isbn() {
      return this.controls.isbn as any as TypedFormControl<string>;
    }
    
    get author() {
      return this.controls.author as any as AuthorEditTM.FormGroup;
    }
    
    get markAsDeleted() {
      return this.controls.markAsDeleted as any as TypedFormControl<boolean>;
    }
    
    get model(): BookEditTM {
      return {
        id: this.typed.controls.id != undefined ? this.typed.controls.id.model : undefined,
        title: this.typed.controls.title != undefined ? this.typed.controls.title.model : undefined,
        description: this.typed.controls.description != undefined ? this.typed.controls.description.model : undefined,
        authorId: this.typed.controls.authorId != undefined ? this.typed.controls.authorId.model : undefined,
        changedAt: this._model.changedAt,
        changedBy: this._model.changedBy,
        createdAt: this._model.createdAt,
        createdBy: this._model.createdBy,
        isbn: this.typed.controls.isbn != undefined ? this.typed.controls.isbn.model : undefined,
        author: this.typed.controls.author != undefined ? this.typed.controls.author.model : undefined,
        markAsDeleted: this.typed.controls.markAsDeleted != undefined ? this.typed.controls.markAsDeleted.model : undefined,
      };
    }
  }
  
  export class FormArray extends TypedFormArray<BookEditTM.Value, BookEditTM.FormGroup> {
    
    constructor(httpService: HttpService, model?: BookEditTM[], validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super((model || []).map(m => new BookEditTM.FormGroup(httpService, m)), validator, asyncValidator);
    }
    
    get model() {
      return this.typed.controls.map(c => c.model);
    }
    get controlsWithoutDeleted() {
      return this.typed.controls.filter(c => !(c as any).markAsDeleted.value);
    }
  }
  
  export class FormDictionary extends TypedFormDictionary<BookEditTM.Value, BookEditTM.FormGroup> {
    
    constructor(httpService: HttpService, model?: { [key: string]: BookEditTM }, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super(mapValues(model || {}, value => new BookEditTM.FormGroup(httpService, value)), validator, asyncValidator);
    }
    
    get model() {
      return mapValues(this.typed.controls, c =>  c.model);
    }
  }
}

export interface AuthorEditTM {
  id: number;
  firstname: string | null;
  lastname: string | null;
  markAsDeleted: boolean;
}

export namespace AuthorEditTM {

  export function empty(): AuthorEditTM {
    return {
      id: 0,
      firstname: null,
      lastname: null,
      markAsDeleted: false,
    };
  }
  
  export interface Value {
    id: number;
    firstname: string | null;
    lastname: string | null;
    markAsDeleted: boolean;
  }
  
  interface Controls {
    id: TypedFormControl<number>;
    firstname: TypedFormControl<string>;
    lastname: TypedFormControl<string>;
    markAsDeleted: TypedFormControl<boolean>;
  }
  
  export class FormGroup extends TypedFormGroup<AuthorEditTM.Value, Controls> {
    
    private _model: AuthorEditTM;
    
    constructor(private httpService: HttpService, model: AuthorEditTM, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super({}, validator, asyncValidator);
      if (!model) {
        model = empty();
      }
      this._model = model;
      
      this.addControl('id', new TypedFormControl<number>(model.id, Validators.compose([Validators.required])));
      
      this.addControl('firstname', new TypedFormControl<string>(model.firstname, Validators.compose([Validators.required])));
      
      this.addControl('lastname', new TypedFormControl<string>(model.lastname, Validators.compose([Validators.required])));
      
      this.addControl('markAsDeleted', new TypedFormControl<boolean>(model.markAsDeleted, null));
    }
    
    get id() {
      return this.controls.id as any as TypedFormControl<number>;
    }
    
    get firstname() {
      return this.controls.firstname as any as TypedFormControl<string>;
    }
    
    get lastname() {
      return this.controls.lastname as any as TypedFormControl<string>;
    }
    
    get markAsDeleted() {
      return this.controls.markAsDeleted as any as TypedFormControl<boolean>;
    }
    
    get model(): AuthorEditTM {
      return {
        id: this.typed.controls.id != undefined ? this.typed.controls.id.model : undefined,
        firstname: this.typed.controls.firstname != undefined ? this.typed.controls.firstname.model : undefined,
        lastname: this.typed.controls.lastname != undefined ? this.typed.controls.lastname.model : undefined,
        markAsDeleted: this.typed.controls.markAsDeleted != undefined ? this.typed.controls.markAsDeleted.model : undefined,
      };
    }
  }
  
  export class FormArray extends TypedFormArray<AuthorEditTM.Value, AuthorEditTM.FormGroup> {
    
    constructor(httpService: HttpService, model?: AuthorEditTM[], validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super((model || []).map(m => new AuthorEditTM.FormGroup(httpService, m)), validator, asyncValidator);
    }
    
    get model() {
      return this.typed.controls.map(c => c.model);
    }
    get controlsWithoutDeleted() {
      return this.typed.controls.filter(c => !(c as any).markAsDeleted.value);
    }
  }
  
  export class FormDictionary extends TypedFormDictionary<AuthorEditTM.Value, AuthorEditTM.FormGroup> {
    
    constructor(httpService: HttpService, model?: { [key: string]: AuthorEditTM }, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super(mapValues(model || {}, value => new AuthorEditTM.FormGroup(httpService, value)), validator, asyncValidator);
    }
    
    get model() {
      return mapValues(this.typed.controls, c =>  c.model);
    }
  }
}

export interface BookTM {
  id: number;
  title: string | null;
  description: string | null;
  isbn: string | null;
  authorName: string | null;
  changedAt: string;
  changedBy: string | null;
  createdAt: string;
  createdBy: string | null;
}

export interface BookListRequestTM {
  id: number | null;
  title: string | null;
  isbn: string | null;
  authorName: string | null;
  dateRange: string[] | null;
  page: number;
  pageSize: number;
  sort: string | null;
  sortOrder: SortOrder;
}

export namespace BookListRequestTM {

  export function empty(): BookListRequestTM {
    return {
      id: null,
      title: null,
      isbn: null,
      authorName: null,
      dateRange: [],
      page: 0,
      pageSize: 0,
      sort: null,
      sortOrder: -1,
    };
  }
  
  export interface Value {
    id: number | null;
    title: string | null;
    isbn: string | null;
    authorName: string | null;
    dateRange: string[] | null;
    page: number;
    pageSize: number;
    sort: string | null;
    sortOrder: SortOrder;
  }
  
  interface Controls {
    id: TypedFormControl<number>;
    title: TypedFormControl<string>;
    isbn: TypedFormControl<string>;
    authorName: TypedFormControl<string>;
    dateRange: TypedFormControl<Date[]>;
    page: TypedFormControl<number>;
    pageSize: TypedFormControl<number>;
    sort: TypedFormControl<string>;
    sortOrder: TypedFormControl<SortOrder>;
  }
  
  export class FormGroup extends TypedFormGroup<BookListRequestTM.Value, Controls> {
    
    private _model: BookListRequestTM;
    
    constructor(private httpService: HttpService, model: BookListRequestTM, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super({}, validator, asyncValidator);
      if (!model) {
        model = empty();
      }
      this._model = model;
      
      this.addControl('id', new TypedFormControl<number>(model.id, null));
      
      this.addControl('title', new TypedFormControl<string>(model.title, null));
      
      this.addControl('isbn', new TypedFormControl<string>(model.isbn, null));
      
      this.addControl('authorName', new TypedFormControl<string>(model.authorName, null));
      
      this.addControl('dateRange', new TypedFormControl<Date[]>(model.dateRange ? model.dateRange.map(d => new Date(d)) : null, null));
      
      this.addControl('page', new TypedFormControl<number>(model.page, Validators.compose([Validators.required])));
      
      this.addControl('pageSize', new TypedFormControl<number>(model.pageSize, Validators.compose([Validators.required])));
      
      this.addControl('sort', new TypedFormControl<string>(model.sort, null));
      
      this.addControl('sortOrder', new TypedFormControl<SortOrder>(model.sortOrder, null));
    }
    
    get id() {
      return this.controls.id as any as TypedFormControl<number>;
    }
    
    get title() {
      return this.controls.title as any as TypedFormControl<string>;
    }
    
    get isbn() {
      return this.controls.isbn as any as TypedFormControl<string>;
    }
    
    get authorName() {
      return this.controls.authorName as any as TypedFormControl<string>;
    }
    
    get dateRange() {
      return this.controls.dateRange as any as TypedFormControl<Date[]>;
    }
    
    get page() {
      return this.controls.page as any as TypedFormControl<number>;
    }
    
    get pageSize() {
      return this.controls.pageSize as any as TypedFormControl<number>;
    }
    
    get sort() {
      return this.controls.sort as any as TypedFormControl<string>;
    }
    
    get sortOrder() {
      return this.controls.sortOrder as any as TypedFormControl<SortOrder>;
    }
    
    get model(): BookListRequestTM {
      return {
        id: this.typed.controls.id != undefined ? this.typed.controls.id.model : undefined,
        title: this.typed.controls.title != undefined ? this.typed.controls.title.model : undefined,
        isbn: this.typed.controls.isbn != undefined ? this.typed.controls.isbn.model : undefined,
        authorName: this.typed.controls.authorName != undefined ? this.typed.controls.authorName.model : undefined,
        dateRange: (this.typed.controls.dateRange != undefined && this.typed.controls.dateRange.model != undefined) ? this.typed.controls.dateRange.model.map(d => d.toJSON()) : undefined,
        page: this.typed.controls.page != undefined ? this.typed.controls.page.model : undefined,
        pageSize: this.typed.controls.pageSize != undefined ? this.typed.controls.pageSize.model : undefined,
        sort: this.typed.controls.sort != undefined ? this.typed.controls.sort.model : undefined,
        sortOrder: this.typed.controls.sortOrder != undefined ? this.typed.controls.sortOrder.model : undefined,
      };
    }
  }
  
  export class FormArray extends TypedFormArray<BookListRequestTM.Value, BookListRequestTM.FormGroup> {
    
    constructor(httpService: HttpService, model?: BookListRequestTM[], validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super((model || []).map(m => new BookListRequestTM.FormGroup(httpService, m)), validator, asyncValidator);
    }
    
    get model() {
      return this.typed.controls.map(c => c.model);
    }
    get controlsWithoutDeleted() {
      return this.typed.controls.filter(c => !(c as any).markAsDeleted.value);
    }
  }
  
  export class FormDictionary extends TypedFormDictionary<BookListRequestTM.Value, BookListRequestTM.FormGroup> {
    
    constructor(httpService: HttpService, model?: { [key: string]: BookListRequestTM }, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super(mapValues(model || {}, value => new BookListRequestTM.FormGroup(httpService, value)), validator, asyncValidator);
    }
    
    get model() {
      return mapValues(this.typed.controls, c =>  c.model);
    }
  }
}

export interface PagedResult<T> {
  page: number;
  pageSize: number;
  totalCount: number;
  startIndex: number;
  endIndex: number;
  count: number;
  totalPages: number;
  canPageForward: boolean;
  canPageBackward: boolean;
  items: T[] | null;
}

export namespace PagedResult {

  export function empty<T>(): PagedResult<T> {
    return {
      page: 0,
      pageSize: 0,
      totalCount: 0,
      startIndex: 0,
      endIndex: 0,
      count: 0,
      totalPages: 0,
      canPageForward: false,
      canPageBackward: false,
      items: [],
    };
  }
  
  export interface Value<T> {
    page: number;
    pageSize: number;
    totalCount: number;
    startIndex: number;
    endIndex: number;
    count: number;
    totalPages: number;
    canPageForward: boolean;
    canPageBackward: boolean;
    items: T[] | null;
  }
  
  interface Controls<T> {
    page: TypedFormControl<number>;
    pageSize: TypedFormControl<number>;
    totalCount: TypedFormControl<number>;
    startIndex: TypedFormControl<number>;
    endIndex: TypedFormControl<number>;
    count: TypedFormControl<number>;
    totalPages: TypedFormControl<number>;
    canPageForward: TypedFormControl<boolean>;
    canPageBackward: TypedFormControl<boolean>;
    items: TypedFormControl<T[]>;
  }
  
  export class FormGroup<T> extends TypedFormGroup<PagedResult<T>, Controls<T>> {
    
    private _model: PagedResult<T>;
    
    constructor(private httpService: HttpService, model: PagedResult<T>, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super({}, validator, asyncValidator);
      if (!model) {
        model = empty();
      }
      this._model = model;
      
      this.addControl('page', new TypedFormControl<number>(model.page, null));
      
      this.addControl('pageSize', new TypedFormControl<number>(model.pageSize, null));
      
      this.addControl('totalCount', new TypedFormControl<number>(model.totalCount, null));
      
      this.addControl('startIndex', new TypedFormControl<number>(model.startIndex, null));
      
      this.addControl('endIndex', new TypedFormControl<number>(model.endIndex, null));
      
      this.addControl('count', new TypedFormControl<number>(model.count, null));
      
      this.addControl('totalPages', new TypedFormControl<number>(model.totalPages, null));
      
      this.addControl('canPageForward', new TypedFormControl<boolean>(model.canPageForward, null));
      
      this.addControl('canPageBackward', new TypedFormControl<boolean>(model.canPageBackward, null));
      
      this.addControl('items', new TypedFormControl<T[]>(model.items || [], null));
    }
    
    get page() {
      return this.controls.page as any as TypedFormControl<number>;
    }
    
    get pageSize() {
      return this.controls.pageSize as any as TypedFormControl<number>;
    }
    
    get totalCount() {
      return this.controls.totalCount as any as TypedFormControl<number>;
    }
    
    get startIndex() {
      return this.controls.startIndex as any as TypedFormControl<number>;
    }
    
    get endIndex() {
      return this.controls.endIndex as any as TypedFormControl<number>;
    }
    
    get count() {
      return this.controls.count as any as TypedFormControl<number>;
    }
    
    get totalPages() {
      return this.controls.totalPages as any as TypedFormControl<number>;
    }
    
    get canPageForward() {
      return this.controls.canPageForward as any as TypedFormControl<boolean>;
    }
    
    get canPageBackward() {
      return this.controls.canPageBackward as any as TypedFormControl<boolean>;
    }
    
    get items() {
      return this.controls.items as any as TypedFormControl<T[]>;
    }
    
    get model(): PagedResult<T> {
      return {
        page: this.typed.controls.page != undefined ? this.typed.controls.page.model : undefined,
        pageSize: this.typed.controls.pageSize != undefined ? this.typed.controls.pageSize.model : undefined,
        totalCount: this.typed.controls.totalCount != undefined ? this.typed.controls.totalCount.model : undefined,
        startIndex: this.typed.controls.startIndex != undefined ? this.typed.controls.startIndex.model : undefined,
        endIndex: this.typed.controls.endIndex != undefined ? this.typed.controls.endIndex.model : undefined,
        count: this.typed.controls.count != undefined ? this.typed.controls.count.model : undefined,
        totalPages: this.typed.controls.totalPages != undefined ? this.typed.controls.totalPages.model : undefined,
        canPageForward: this.typed.controls.canPageForward != undefined ? this.typed.controls.canPageForward.model : undefined,
        canPageBackward: this.typed.controls.canPageBackward != undefined ? this.typed.controls.canPageBackward.model : undefined,
        items: this.typed.controls.items != undefined ? this.typed.controls.items.model : undefined,
      };
    }
  }
  
  export class FormArray<T> extends TypedFormArray<PagedResult.Value<T>, PagedResult.FormGroup<T>> {
    
    constructor(httpService: HttpService, model?: PagedResult<T>[], validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super((model || []).map(m => new PagedResult.FormGroup<T>(httpService, m)), validator, asyncValidator);
    }
    
    get model() {
      return this.typed.controls.map(c => c.model);
    }
    get controlsWithoutDeleted() {
      return this.typed.controls.filter(c => !(c as any).markAsDeleted.value);
    }
  }
  
  export class FormDictionary<T> extends TypedFormDictionary<PagedResult.Value<T>, PagedResult.FormGroup<T>> {
    
    constructor(httpService: HttpService, model?: { [key: string]: PagedResult<T> }, validator?: ValidatorFn | ValidatorFn[] | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
      super(mapValues(model || {}, value => new PagedResult.FormGroup<T>(httpService, value)), validator, asyncValidator);
    }
    
    get model() {
      return mapValues(this.typed.controls, c =>  c.model);
    }
  }
}

export interface BookListTM {
  id: number;
  title: string | null;
  isbn: string | null;
  createdAt: string;
  authorName: string | null;
}