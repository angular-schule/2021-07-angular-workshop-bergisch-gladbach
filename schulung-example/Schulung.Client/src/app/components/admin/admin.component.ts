import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { BooksCrudService } from '../../generated/books-crud.service';
import { BooksListService } from '../../generated/books-list.service';
import { SortOrder } from '../../generated/enums';

@Component({
  templateUrl: './admin.component.html'
})
export class AdminComponent extends BaseComponent implements OnInit {

  defaultSortOrder = SortOrder.Ascending;

  constructor(public listService: BooksListService,
              public crudService: BooksCrudService) {
    super();
  }

  ngOnInit(): void {
  }

}
