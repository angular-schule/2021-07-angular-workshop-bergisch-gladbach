import { Injectable, Inject, Optional } from "@angular/core";
import { CrudService } from "./crud.service";
import { HttpService, UiMessageService, UiMessageServiceToken, DialogServiceToken, DialogService } from "@oevermann/angular";
import { BookEditTM } from "./models";
import { BooksHttpService } from "./books-http.service";

@Injectable()
export class BooksCrudService extends CrudService<BookEditTM, number, BookEditTM.FormGroup> {

  constructor(private httpService: HttpService, crudHttpService: BooksHttpService, @Inject(UiMessageServiceToken) messageService: UiMessageService, @Optional() @Inject(DialogServiceToken) dialogService: DialogService) {
    super(crudHttpService, messageService, dialogService);
  }

  protected createForm(model: BookEditTM): BookEditTM.FormGroup {
    return new BookEditTM.FormGroup(this.httpService, model);
  }
}