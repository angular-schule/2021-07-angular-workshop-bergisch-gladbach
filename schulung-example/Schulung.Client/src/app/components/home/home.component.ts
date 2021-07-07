import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { BooksListService } from '../../generated/books-list.service';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent extends BaseComponent implements OnInit {

  constructor(public listService: BooksListService) {
    super();
  }

  ngOnInit(): void {
  }

}
