import { MissingTranslationHandler, MissingTranslationHandlerParams } from '@ngx-translate/core';
import { environment } from '../../environments/environment';
import { Injectable } from "@angular/core";

@Injectable()
export class CustomMissingTranslationHandler implements MissingTranslationHandler {
  public handle(params: MissingTranslationHandlerParams) {
    if (!environment.production)
      console.warn('[Translation] Missing key => "' + params.key + '"');
    return `${params.key}`;
  }
}
