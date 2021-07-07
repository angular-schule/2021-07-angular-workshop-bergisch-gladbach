import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { BaseComponent } from '../../../base.component';
import { BookTM } from '../../../generated/models';

@Component({
  templateUrl: './book-detail.component.html'
})
export class BookDetailComponent extends BaseComponent implements OnInit {

  routeBook = this.route.data.pipe(map(d => d.book as BookTM));

  constructor(private route: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {
  }

}
