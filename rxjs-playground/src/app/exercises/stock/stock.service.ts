import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { merge, Observable, of, timer } from 'rxjs';
import { catchError, concatMap, filter, map, scan, shareReplay, startWith, timeout } from 'rxjs/operators';
import { ExerciseService } from '../exercise.service';

@Injectable({
  providedIn: 'root'
})
export class StockService {
  
  goldRate$ = this.getRealCurrentRate().pipe(
    concatMap(rate => this.variation$.pipe(startWith(rate))),
    scan((acc, item) => acc + item),
    shareReplay(1)
  );


  private variation$ = merge(
    timer(this.es.generateRandomInt(1000, 5000), this.es.generateRandomInt(3800, 5000)).pipe(map(() => this.es.generateRandomInt(-500, 500) / 100)),
    timer(this.es.generateRandomInt(800, 2000), this.es.generateRandomInt(3800, 4500)).pipe(map(() => this.es.generateRandomInt(1, 100) / 100))
  )

  constructor(private es: ExerciseService, private http: HttpClient) { }

  private getRealCurrentRate(): Observable<number> {
    return this.http.get('https://api.coingecko.com/api/v3/simple/price?ids=pax-gold&vs_currencies=eur').pipe(
      map(res => res['pax-gold']?.eur),
      filter(e => !!e),
      timeout(1000),
      catchError(() => of(1400.50))
    );
  }

}
