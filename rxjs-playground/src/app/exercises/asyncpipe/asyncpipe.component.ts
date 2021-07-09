import { Component, OnInit } from '@angular/core';
import { timer, Observable } from 'rxjs';
import { tap, scan } from 'rxjs/operators';

@Component({
  selector: 'rxw-fromevent',
  templateUrl: './asyncpipe.component.html',
  styles: ['.big-num {font-size: 120pt}']
})
export class AsyncpipeComponent implements OnInit {

  result: number;
  result$: Observable<number>;

  ngOnInit() {

    /**
     * Verwende die AsyncPipe und verzichte auf den Einsatz von subscribe()!
     */

    /**************!!**************/

     timer(0, 700).pipe(                        
      scan((acc, item) => acc + item, 0),
      tap({
        next: e => console.log(e),
        complete: () => console.log('✅ COMPLETE')
      }),
     ).subscribe(e => this.result = e);         

    /**************!!**************/
  }

}
