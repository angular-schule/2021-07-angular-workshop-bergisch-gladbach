import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { of } from 'rxjs';
import { TestScheduler } from 'rxjs/testing';
import { Book } from '../shared/book';
import { BookStoreService } from '../shared/book-store.service';

import { SearchComponent } from './search.component';

describe('SearchComponent', () => {
  let component: SearchComponent;
  let fixture: ComponentFixture<SearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SearchComponent],
      providers: [
        {
          provide: BookStoreService,
          useValue: {
            search: jest.fn(term => of([{ title: 'Book ' + term }])),
          },
        },
      ],
      imports: [RouterModule, ReactiveFormsModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });



  describe('with marbles', () => {
    let scheduler: TestScheduler;

    beforeEach(() => {
      scheduler = new TestScheduler((actual, expected) => {
        expect(actual).toEqual(expected);
      });
    });


    it('should debounce terms', () => {
      scheduler.run(({ cold, hot, expectObservable }) => {
        component.term$ = cold('a--b--c--d', {
          a: 'AAAA',
          b: 'BBBB',
          c: 'CCCC',
          d: 'DDDD',
        });

        component.ngOnInit();

        const expectedBooks = [{ title: 'Book DDDD' }];
        expectObservable(component.results$).toBe('--- --- --- 500ms x', { x: expectedBooks });
      });
    });

  });
});
