import { registerLocaleData } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import localeDe from '@angular/common/locales/de';
import { Injector, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MissingTranslationHandler, TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { HttpModule, UiMessageServiceToken } from '@oevermann/angular';
import { OnPrimeNavigationLoaderModule, PrimeDialogModule, PrimeUIMessageService } from '@oevermann/angular-primeng';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BaseComponent } from './base.component';
import { BooksHttpService } from './generated/books-http.service';
import { CustomMissingTranslationHandler } from './services/custom-missing-translation.handler';
import { LocatorService } from './services/locator.service';
import { TranslateHttpLoader } from './services/translate-http.loader';

registerLocaleData(localeDe);

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    AppComponent,
    BaseComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HttpModule.forRoot(environment.httpConfig),
    OnPrimeNavigationLoaderModule.withService(),
    PrimeDialogModule,
    ToastModule,
    AppRoutingModule,
    TranslateModule.forRoot({
      defaultLanguage: 'de',
      useDefaultLang: true,
      missingTranslationHandler: {
        provide: MissingTranslationHandler,
        useExisting: CustomMissingTranslationHandler
      },
      loader: {
        provide: TranslateLoader,
        useExisting: TranslateHttpLoader
      }
    }),
    AppRoutingModule
  ],
  providers: [
    MessageService,
    { provide: UiMessageServiceToken, useClass: PrimeUIMessageService, deps: [MessageService] },
    { provide: LOCALE_ID, useValue: 'de' },
    CustomMissingTranslationHandler,
    {
      provide: TranslateHttpLoader,
      useFactory: (createTranslateLoader),
      deps: [HttpClient]
    },
    BooksHttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(injector: Injector) {
    LocatorService.Injector = injector;
  }
}
