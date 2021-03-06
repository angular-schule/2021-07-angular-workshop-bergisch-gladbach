import { Component, OnInit } from '@angular/core';
import { Subject, BehaviorSubject, ReplaySubject, Observable } from 'rxjs';
import { share, shareReplay } from 'rxjs/operators';

import { MeasureValuesService } from './measure-values.service';
import { ExerciseService } from '../exercise.service';

@Component({
  selector: 'rxw-multicast',
  templateUrl: './multicast.component.html',
})
export class MulticastComponent implements OnInit {

  listeners = [];
  logStream$ = new ReplaySubject<string>();

  measureValues$: Observable<number>; // später: Subject<number>;

  constructor(private mvs: MeasureValuesService, private es: ExerciseService) { }

  ngOnInit() {
    /******************************/

    // 1. unchanged stream
    // this.measureValues$ = this.mvs.getValues();

    // 2. unchanged stream
    // this.measureValues$ = this.mvs.getValues().pipe(share())
    // ODER SO
    // this.measureValues$ = new Subject();
    // this.mvs.getValues().subscribe(this.measureValues$)

    // 3. ReplaySubject
    this.measureValues$ = this.mvs.getValues().pipe(shareReplay(1))

    /******************************/
  }

  addListener() {
    this.listeners.push(this.es.generateRandomString(5));
  }

  addConsoleListener() {
    const randomString = this.es.generateRandomString(5);
    this.measureValues$.subscribe(e => this.logStream$.next(`${randomString} ${e}`));
  }

}
