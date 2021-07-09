import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { marker } from '@biesbjerg/ngx-translate-extract-marker';
import { logInvalidFormFields } from '@oevermann/angular';
import { filter } from 'rxjs/operators';
import { BaseComponent } from '../../../base.component';
import { BooksCrudService } from '../../../generated/books-crud.service';

marker('book.saveDialog.text');
marker('book.saveDialog.title');

@Component({
  templateUrl: './admin-detail.component.html'
})
export class AdminDetailComponent extends BaseComponent implements OnInit {

  constructor(public crudService: BooksCrudService,
              private route: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {
    this.crudService.form.title.valueChanges.subscribe()
  }

  save() {
    logInvalidFormFields(this.crudService.form);

    this.crudService.save((id => {
      this.crudService.form.markAsPristine();
      this.crudService.form.markAsUntouched();
      this.router.navigate(['..', id], { relativeTo: this.route });
      this.messageService.pushSuccess('book.saveDialog.text', 'book.saveDialog.title');
    }), true);
  }

  delete() {
    this.crudService.tryDelete().pipe(this.untilDestroy(), filter(b => b === 'delete')).subscribe(() => {
      this.router.navigate(['..'], { relativeTo: this.route });
    });
  }
}
