import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { ErrorLabelComponent } from './error-label.component';


@NgModule({
  declarations: [
    ErrorLabelComponent
  ],
  exports: [
    ErrorLabelComponent
  ],
  imports: [
    CommonModule,
    TranslateModule
  ]
})
export class ErrorLabelModule {
}
