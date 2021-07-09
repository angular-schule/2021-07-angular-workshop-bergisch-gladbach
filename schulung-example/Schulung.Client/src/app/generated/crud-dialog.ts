import { DialogService } from '@oevermann/angular';
import { CrudService } from './crud.service';
import { filter } from 'rxjs/operators';

export function crudToDialog(dialogService: DialogService, crudService: CrudService<any, any, any>) {
  if (dialogService) {
    crudService.discardPromptChanges.pipe(filter(p => p != null)).subscribe((p) => {
      if (crudService.form.valid) {
        dialogService.openDialog({
          header: 'Ungespeicherte Änderungen',
          content: 'Sie haben noch ungespeicherte Änderungen, sollen diese gespeichert werden?',
          buttons: [
            {
              text: 'Speichern',
              action: (val) => p.save(),
              id: 'save',
              buttonClass: 'success'
            },
            {
              text: 'Änderungen verwerfen',
              action: p.discard,
              id: 'discard',
              buttonClass: 'secondary'
            },
            {
              text: 'Abbrechen',
              id: 'cancel',
              action: p.cancel,
              buttonClass: 'secondary'
            }
          ]
        });
      } else {
        dialogService.openDialog({
          header: 'Ungespeicherte Änderungen',
          content: 'Sie haben noch ungespeicherte Änderungen, diese können in ihrem aktuellen Zustand nicht gespeichert werden.',
          buttons: [
            {
              text: 'Änderungen verwerfen',
              action: p.discard,
              id: 'discard',
              buttonClass: 'primary'
            },
            {
              text: 'Abbrechen',
              id: 'cancel',
              action: p.cancel,
              buttonClass: 'secondary'
            }
          ]
        });
      }
    });

    crudService.deletePromptChanges.pipe(filter(p => p != null)).subscribe((p) => {
      dialogService.openDialog({
        header: 'Eintrag löschen?',
        content: 'Soll der Eintrag wirklich gelöscht werden?',
        buttons: [
          {
            text: 'Ja',
            action: p.delete,
            id: 'yes',
            buttonClass: 'danger'
          },
          {
            text: 'Nein',
            action: p.cancel,
            id: 'no',
            buttonClass: 'secondary'
          }
        ],
        useHtml: false
      });
    })
  }
}
