import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {

  const router = inject(Router);
  const snackbar = inject(SnackbarService);

  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      if (err.status === 400) {
        if (err.error.errors) {

          const modelStateErrors = [];
          for (const key in err.error.errors) {
            if (err.error.errors[key]) {
              modelStateErrors.push(err.error.errors[key]);
            }
          }

          throw modelStateErrors.flat();
        } else {
          snackbar.error(err.error.title || err.error.message);
        }
        
      }

      if (err.status === 401) {
       
        snackbar.error(err.error.title || err.message);
      }
      if (err.status === 404) {
        router.navigate(['/not-found']);
      }
      if (err.status === 500) {
        const navigationExtras: NavigationExtras = {
          state: { error: err.error }
        };
        router.navigate(['/server-error'], navigationExtras);
      }

      return throwError(() => err);
    })
  );
};
