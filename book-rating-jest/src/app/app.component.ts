import { Component, Inject, LOCALE_ID } from '@angular/core';

@Component({
  selector: 'br-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = $localize`:@@HelloWorld:Hello World! :-(`;

  constructor(@Inject(LOCALE_ID) locale: string) {
    console.log('LOCALE_ID', locale);
  }
}
