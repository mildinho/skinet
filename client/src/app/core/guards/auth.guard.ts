import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { inject } from '@angular/core';
import { map, of } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);


  console.log('aqui oh')
  if (accountService.currentUser()){
    console.log('estou logado')
    return of(true);
  } else {
   
    return accountService.getAuthState().pipe(
      map( auth => {
        if( auth.isAuthenticated) {
          console.log('estou logado')
          return true;
        } else {
          console.log('NAO  logado')
          router.navigate(['/account/login'], {queryParams : {returnUrl : state.url }})
          return false;
        }} )
    )
  
  }
 
};
