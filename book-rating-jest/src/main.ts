import { enableProdMode, LOCALE_ID } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { getTranslations } from '@locl/core';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

// VORHER
// platformBrowserDynamic().bootstrapModule(AppModule)
//   .catch(err => console.error(err));


// NACHHER
// ruft für uns import { loadTranslations } from '@angular/localize'; auf
getTranslations('/assets/messages.de.json').then(() => {

  platformBrowserDynamic().bootstrapModule(AppModule)
    .catch(err => console.error(err));
});
