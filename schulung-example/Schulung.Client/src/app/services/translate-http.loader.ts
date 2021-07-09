import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TranslateLoader } from '@ngx-translate/core';
import { Observable } from 'rxjs';



@Injectable()
export class TranslateHttpLoader extends TranslateLoader {

  constructor(private httpClient: HttpClient) {
    super();
  }

  public getTranslation(lang: string): Observable<any> {
    return this.httpClient.get(`assets/i18n/${lang}.json`, { responseType: 'json' }).pipe();
  }
}
