import { inject, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

   private snackbar = inject(MatSnackBar);

   error(message: string) {
    this.snackbar.open(message, 'Close', {
      duration: 4000,
      panelClass: ['snackbar-error']
    });
   }

   success(message: string) {
    this.snackbar.open(message, 'Close', {
      duration: 4000,
      panelClass: ['snackbar-success']
    });
   }


}
