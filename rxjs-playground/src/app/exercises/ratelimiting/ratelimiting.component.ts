import { Component, OnInit } from '@angular/core';
import { ExerciseService } from '../exercise.service';
import { Subject, Observable } from 'rxjs';
import { debounceTime, throttleTime, auditTime, sampleTime } from 'rxjs/operators';

@Component({
  selector: 'rxw-ratelimiting',
  templateUrl: './ratelimiting.component.html',
  styleUrls: ['./ratelimiting.component.scss']
})
export class RatelimitingComponent implements OnInit {

  scrollContent = new Array(100);
  result$: Observable<string>;
  events$ = new Subject<string>();

  constructor(private es: ExerciseService) {}

  ngOnInit() {

    /**
     * Durch Scrollen und Buttonklicks werden Events erzeugt.
     *
     * Begrenze die Zahl der ausgegebenen Events mit einem Rate Limiting Operator.
     * - debounceTime: nach Ablauf einer PAUSE den letzten Wert entnehmen
     * - throttleTime: Wert sofort entnehmen, Quelle dann für eine bestimmte Zeit ignorieren
     * - auditTime: bei Event die Quelle überwachen, nach bestimmter Zeit Wert entnehmen
     * - sampleTime: periodisch Werte entnehmen (sofern vorhanden)
     */

    /**************!!**************/

    this.result$ = this.events$.pipe(
    );

    /**************!!**************/
  }

  emitRandomString() {
    const newRandom = this.es.generateRandomString(7);
    this.events$.next(newRandom);
  }

  emitScrollEvent(e: Event) {
    const timestamp = Math.floor(e.timeStamp);
    this.events$.next('SCROLL ' + timestamp);
  }


}
