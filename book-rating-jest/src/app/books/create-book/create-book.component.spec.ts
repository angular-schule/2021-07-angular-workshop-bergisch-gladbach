import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { BookStoreService } from '../shared/book-store.service';

import { CreateBookComponent } from './create-book.component';

describe('CreateBookComponent', () => {
  let component: CreateBookComponent;
  let fixture: ComponentFixture<CreateBookComponent>;
  let bsMock: Partial<BookStoreService>;

  beforeEach(async () => {
    bsMock = { create: jest.fn(book => of(book)) };

    await TestBed.configureTestingModule({
      declarations: [CreateBookComponent],
      providers: [{ provide: BookStoreService, useValue: bsMock }],
      schemas: [NO_ERRORS_SCHEMA],
      imports: [],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should dummy test', () => {
    expect(true).toBeTruthy();
  });
});
