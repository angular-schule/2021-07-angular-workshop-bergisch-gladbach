import { Injectable } from "@angular/core";
import { ListService } from "./list.service";
import { BookListRequestTM, BookListTM } from "./models";
import { HttpService } from "@oevermann/angular";
import { BooksHttpService } from "./books-http.service";

const defaults = { ...BookListRequestTM.empty(), page: 1, pageSize: 10, sort: null, sortOrder: -1 };

@Injectable()
export class BooksListService extends ListService<BookListRequestTM, BookListRequestTM.FormGroup, BookListTM> {

  constructor(private httpService: HttpService, private modelHttpService: BooksHttpService) {
    super(defaults, modelHttpService.changes);
  }

  protected createForm(request: BookListRequestTM) {
    return new BookListRequestTM.FormGroup(this.httpService, request);
  }

  protected load(request: BookListRequestTM) {
    return this.modelHttpService.list(request);
  }

  public reset() {
    this.form.reset(defaults);
  }
}