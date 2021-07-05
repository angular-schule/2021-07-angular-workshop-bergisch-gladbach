import { Component, EventEmitter, Output } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

import { Book } from '../shared/book';

@Component({
  selector: 'br-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.scss']
})
export class BookFormComponent {

  @Output() bookSubmit = new EventEmitter<Book>();
  bookForm = new FormGroup({
    isbn: new FormControl('', [
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(13)
    ]),
    title: new FormControl('', Validators.required),
    description: new FormControl(''),
    authors: new FormArray([
      new FormControl('')
    ])
  });

  isInvalid(name: string) {
    const control = this.bookForm.get(name);
    return !!control && control.invalid && control.touched;
  }

  hasError(name: string, errorCode: string) {
    const control = this.bookForm.get(name);
    return !!control && control.hasError(errorCode) && control.touched;
  }

  get authors() {
    return this.bookForm.get('authors') as FormArray;
  }

  addAuthorControl() {
    this.authors.push(new FormControl(''));
  }

  submitForm() {
    const newBook = {
      ...this.bookForm.value,
      authors: this.bookForm.value.authors.filter((e: string) => !!e),
      rating: 1
    };

    this.bookSubmit.emit(newBook);
  }
}
