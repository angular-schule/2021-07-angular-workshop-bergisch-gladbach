import { Directive, Input, TemplateRef, ViewContainerRef, OnChanges } from '@angular/core';

@Directive({
  selector: '[brRepeat]'
})
export class RepeatDirective {

  constructor(
    private template: TemplateRef<any>,
    private vcr: ViewContainerRef
  ) { }

  @Input() set brRepeat(times: number) {
    this.vcr.clear();
    for (let i = 0; i < times; i++) {
      this.vcr.createEmbeddedView(this.template);
    }
  }
}
