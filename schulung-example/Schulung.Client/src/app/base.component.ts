import { Component, Inject, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService, UiMessageService, UiMessageServiceToken } from '@oevermann/angular';
import { de } from '@oevermann/angular-primeng';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { LocatorService } from './services/locator.service';

@Component({
  template: ''
})
export class BaseComponent implements OnDestroy {

  private ngUnsubscribe = new Subject();

  public localeDe = de;

  public router: Router;
  public httpService: HttpService;
  public messageService: UiMessageService;

  constructor() {
    this.messageService = LocatorService.Injector.get(UiMessageServiceToken) as UiMessageService;
    this.router = LocatorService.Injector.get(Router) as Router;
    this.httpService = LocatorService.Injector.get(HttpService) as HttpService;

  }

  public uiSucces() {

  }

  public untilDestroy = <T>() => takeUntil<T>(this.ngUnsubscribe);

  ngOnDestroy() {
    this.ngUnsubscribe.next();
  }
}
