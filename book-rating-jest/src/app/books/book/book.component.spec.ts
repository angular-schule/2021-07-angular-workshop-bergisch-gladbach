import { Directive, Input, NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { RepeatDirective } from '../shared/repeat.directive';

import { BookComponent } from './book.component';

// Stub
@Directive({
  selector: '[brRepeat]'
})
export class DummyRepeatDirective {
  @Input() set brRepeat(times: number) {}
}


describe('BookComponent', () => {
  let component: BookComponent;
  let fixture: ComponentFixture<BookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        BookComponent,
        // RepeatDirective // Integration Test!
        DummyRepeatDirective
      ],
      imports: [RouterTestingModule]
      // schemas: [NO_ERRORS_SCHEMA] // Shallow Unit Test
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookComponent);
    component = fixture.componentInstance;

    fixture.detectChanges();
  });


  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
