import { Injectable, OnDestroy } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TestService implements OnDestroy {

  constructor() { }

  ngOnDestroy(): void {
    console.log('TODO: cleanup');
  }
}
