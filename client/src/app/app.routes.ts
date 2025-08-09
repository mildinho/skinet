import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ShopComponent } from './features/shop/shop.component';
import { ProductDetailsComponent } from './features/product-details/product-details.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ServerErrorComponent } from './shared/components/server-error/server-error.component';
import { CartComponent } from './features/cart/cart.component';
import { CheckoutComponent } from './features/checkout/checkout.component';
import { AccountService } from './core/services/account.service';
import { LoginComponent } from './features/account/login/login.component';
import { RegisterComponent } from './features/account/register/register.component';
import { authGuard } from './core/guards/auth.guard';
import { emptyCartGuard } from './core/guards/empty-cart.guard';
import { SalesComponent } from './features/sales/sales.component';
import { ProdutoDetalhesComponent } from './features/produto-detalhes/produto-detalhescomponent';

export const routes: Routes = [

    { path: '', component: HomeComponent },
    { path: 'shop', component: ShopComponent },    
    { path: 'shop/:id', component: ProductDetailsComponent },   
    { path: 'sales', component: SalesComponent },    
    { path: 'sales/:id', component: ProdutoDetalhesComponent },   
    { path: 'cart', component: CartComponent },  
    { path: 'checkout', component: CheckoutComponent, canActivate : 
        [authGuard, emptyCartGuard]
     },   
    { path: 'account/login', component: LoginComponent },   
    { path: 'account/register', component: RegisterComponent },   
    { path: 'server-error', component: ServerErrorComponent },
    { path: 'not-found', component: NotFoundComponent },
    { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];
