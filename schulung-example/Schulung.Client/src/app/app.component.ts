import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BaseComponent } from './base.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent extends BaseComponent {

  constructor(private translate: TranslateService) {
    super();
    translate.use(translate.getBrowserLang());
  }
}
