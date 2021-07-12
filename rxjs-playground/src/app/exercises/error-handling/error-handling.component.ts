import { Component } from '@angular/core';
import { ReplaySubject, throwError, of, onErrorResumeNext, EMPTY } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { ExerciseService } from '../exercise.service';

@Component({
  selector: 'rxw-error-handling',
  templateUrl: './error-handling.component.html',
})
export class ErrorHandlingComponent {

  logStream$ = new ReplaySubject<string>();

  constructor(private es: ExerciseService) { }

  /**
   * Das Observable aus `this.es.randomError()` liefert mit hoher Wahrscheinlichkeit einen Fehler.
   * Probiere verschiedene Strategien aus, um den Fehler zu behandeln:
   * - wiederholen
   * - Fehler weiterwerfen
   * - Fehler umwandeln (in ein normales Element)
   * - Fehler verschlucken/ignorieren
   */

  start() {
    this.es.randomError().pipe(

      /******************************/

      // retry(3),
      // catchError((e: Error) => { console.log('Hilfe!'); return throwError(':-('); })
      // catchError((e: Error) => { console.log('Hilfe!'); return of(':-)'); })
      catchError((e: Error) => { console.log('Hilfe!'); return EMPTY; })


      /******************************/

    ).subscribe({
      next: e => this.logStream$.next(e),
      error: err => this.logStream$.next('❌ ERROR: ' + err)
    });
  }
}
