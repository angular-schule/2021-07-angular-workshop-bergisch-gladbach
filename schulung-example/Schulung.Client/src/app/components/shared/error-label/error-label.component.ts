import { Component, HostBinding, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { BaseComponent } from '../../../base.component';

@Component({
  selector: 'app-error-label',
  templateUrl: './error-label.component.html'
})
export class ErrorLabelComponent extends BaseComponent {

  @Input()
  public control: FormControl;

  constructor() {
    super();
  }

}
