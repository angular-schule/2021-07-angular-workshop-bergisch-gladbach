import { FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { AbstractControlOptions } from '@angular/forms';
import { ValidatorFn } from '@angular/forms';
import { AsyncValidatorFn } from '@angular/forms';

export enum PropertyRights {
  None = 0,
  Read = 1,
  Write = 2,
  All = 3
}

export interface TMValue<T> {
  value: T;
  right: PropertyRights;
}

export enum SortOrder {
  Ascending = 0,
  Descending = 1,
  Unspecified = -1
}


/** Stellt Funktionen einer FormGroup typisiert bereit. */
class TypedFormGroupHelper<V, C> {

  constructor(private formGroup: FormGroup) { }

  get controls() {
    return this.formGroup.controls as any as C;
  }

  addControl<N extends keyof C>(name: N, control: C[N]) {
    this.formGroup.addControl(name as any, control as any);
  }

  setControl<N extends keyof C>(name: N, control: C[N]) {
    this.formGroup.setControl(name as any, control as any);
  }

  removeControl(name: keyof C) {
    this.formGroup.removeControl(name as any);
  }

  get value() {
    return this.formGroup.value as V;
  }

  get valueChanges() {
    return this.formGroup.valueChanges as Observable<V>;
  }

  setValue(value: V, options?: { onlySelf?: boolean; emitEvent?: boolean; }) {
    this.formGroup.setValue(value, options);
  }

  patchValue(value: Partial<V>, options?: { onlySelf?: boolean; emitEvent?: boolean; }) {
    this.formGroup.patchValue(value, options);
  }
}

/** Stellt eine typisierte Version der FormGroup bereit. */
export class TypedFormGroup<V, C> extends FormGroup {

  /** Stellt die FormGroup in typisierter Form dar. */
  readonly typed = new TypedFormGroupHelper<V, C>(this);

  private _right = PropertyRights.All;

  get right() {
    return this._right;
  }

  set right(right: PropertyRights) {
    this._right = right;
    //if (right & PropertyRights.Write) {
    //  this.enable();
    //} else {
    //  this.disable();
    //}
  }
}

/** Stellt Funktionen eines FormControl typisiert bereit. */
class TypedFormControlHelper<V> {

  constructor(private formControl: FormControl) { }

  get value() {
    return this.formControl.value as V;
  }

  get valueChanges() {
    return this.formControl.valueChanges as Observable<V>;
  }

  setValue(value: V, options?: { onlySelf?: boolean; emitEvent?: boolean; }) {
    this.formControl.setValue(value, options);
  }

  patchValue(value: Partial<V>, options?: { onlySelf?: boolean; emitEvent?: boolean; }) {
    this.formControl.patchValue(value, options);
  }
}

/** Stellt eine typisierte Version eines FormControl bereit. */
export class TypedFormControl<V> extends FormControl {

  constructor(formState?: V, validatorOrOpts?: ValidatorFn | ValidatorFn[] | AbstractControlOptions | null, asyncValidator?: AsyncValidatorFn | AsyncValidatorFn[] | null) {
    super(formState, validatorOrOpts, asyncValidator);
  }

  /** Stellt das FormControl in typisierter Form dar. */
  readonly typed = new TypedFormControlHelper<V>(this);

  get model(): V {
    return this.value;
  }

  private _right = PropertyRights.All;

  get right() {
    return this._right;
  }

  set right(right: PropertyRights) {
    this._right = right;
    if (right & PropertyRights.Write) {
      this.enable();
    } else {
      this.disable();
    }
  }
}

/** Stellt eine typisierte Version eines FormArray bereit. */
class TypedFormArrayHelper<V, C> {

  constructor(private formArray: FormArray) { }

  get controls() {
    return this.formArray.controls as any as C[];
  }

  at(index: number) {
    return this.formArray.at(index) as any as C;
  }

  push(control: C) {
    this.formArray.push(control as any);
  }

  removeAt(index: number) {
    this.formArray.removeAt(index);
  }

  get value() {
    return this.formArray.value as V[];
  }

  get valueChanges() {
    return this.formArray.valueChanges as Observable<V[]>;
  }

  setValue(value: V[], options?: { onlySelf?: boolean; emitEvent?: boolean; }) {
    this.formArray.setValue(value, options);
  }
}

export class TypedFormArray<V, C> extends FormArray {

  /** Stellt eine typisierte Version eines FormArray bereit. */
  readonly typed = new TypedFormArrayHelper<V, C>(this);

  private _right = PropertyRights.All;

  get right() {
    return this._right;
  }

  set right(right: PropertyRights) {
    this._right = right;
    //if (right & PropertyRights.Write) {
    //  this.enable();
    //} else {
    //  this.disable();
    //}
  }
}

/** Stellt Funktionen einer FormGroup typisiert bereit. */
class TypedFormDictionaryHelper<V, C> {

  constructor(private formGroup: FormGroup) { }

  get controls() {
    return this.formGroup.controls as any as { [name: string]: C };
  }

  addControl(name: string, control: C) {
    this.formGroup.addControl(name, control as any);
  }

  setControl(name: string, control: C) {
    this.formGroup.setControl(name, control as any);
  }

  removeControl(name: string) {
    this.formGroup.removeControl(name);
  }

  get value() {
    return this.formGroup.value as { [key: string]: V };
  }

  get valueChanges() {
    return this.formGroup.valueChanges as Observable<{ [key: string]: V }>;
  }

  setValue(value: { [key: string]: V }, options?: { onlySelf?: boolean; emitEvent?: boolean; }) {
    this.formGroup.setValue(value, options);
  }

  patchValue(value: { [key: string]: V }, options?: { onlySelf?: boolean; emitEvent?: boolean; }) {
    this.formGroup.patchValue(value, options);
  }
}

/** Stellt eine typisierte Version der FormGroup bereit. */
export class TypedFormDictionary<V, C> extends FormGroup {

  /** Stellt die FormGroup in typisierter Form dar. */
  readonly typed = new TypedFormDictionaryHelper<V, C>(this);

  private _right = PropertyRights.All;

  get right() {
    return this._right;
  }

  set right(right: PropertyRights) {
    this._right = right;
  }

  get model() {
    return this.typed.value;
  }
}

export function mapValues(source: any, callbackFn: (value: any) => any) {
  const result = {};
  for (let key in source) {
    result[key] = callbackFn(source[key]);
  }
  return result;
}

export interface PagedRequestForm {
  page: TypedFormControl<number>;
  pageSize: TypedFormControl<number>;
  sort: TypedFormControl<string>;
  sortOrder: TypedFormControl<SortOrder>;
}