import { Component, OnInit } from '@angular/core';
import { Observable, of, from, timer, interval, ReplaySubject } from 'rxjs';
import { map, filter } from 'rxjs/operators';

@Component({
  selector: 'rxw-creating',
  templateUrl: './creating.component.html',
})
export class CreatingComponent implements OnInit {

  logStream$ = new ReplaySubject<string | number>();

  ngOnInit() {
    /**
     * 1. Erstelle ein Observable und abonniere den Datenstrom.
     *    Probiere dazu die verschiedenen Creation Functions aus: of(), from(), timer(), interval()
     * 2. Implementiere außerdem ein Observable manuell, indem du den Konstruktor "new Observable()" nutzt.
     *
     * Tipps:
     * Zum Abonnieren kannst du einen (partiellen) Observer oder ein einzelnes next-Callback verwenden.
     * Du kannst die Methode this.log() verwenden, um eine Ausgabe in der schwarzen Box im Browser zu erzeugen.
     */

    /******************************/

    // 1. Observer
    const observer = {
      next: e => this.log(e),
      error: err => this.log('>ERROR>: ' + err),
      complete: () => this.log('COMPLETE!')
    }

    // (ABC|)
    //const observable$ = of('😎', '😆', '🤪');

    // 2. Observable
    // 4. Subscriber
    const observable$ = new Observable<string>(subscriber => {
      subscriber.next('😎');
      subscriber.next('🤪');
      const x = setTimeout(() => subscriber.next('😆'), 1000);
      const y = setTimeout(() => { subscriber.error('NOPE!'), this.log('ZOMBIE CODE!') }, 2000);
      const z = setTimeout(() => subscriber.next('Weiter machen!'), 3000);

      return () => {
        this.log('Wir sollten den Zombie killen!');
        clearTimeout(x);
        clearTimeout(y);
      }
    });

    // 3. Subscription
    const subscription = observable$.subscribe(observer);
    setTimeout(() => subscription.unsubscribe(), 4000);

    const subscription2 = observable$.subscribe(observer);


    /******************************/
  }

  private log(msg: string | number) {
    this.logStream$.next(msg);
  }

}
