import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ShopComponent } from './features/shop/shop.component';
import { ProductDetailsComponent } from './features/product-details/product-details.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ServerErrorComponent } from './shared/components/server-error/server-error.component';
import { CartComponent } from './features/cart/cart.component';
import { CheckoutComponent } from './features/checkout/checkout.component';

export const routes: Routes = [

    { path: '', component: HomeComponent },
    { path: 'shop', component: ShopComponent },    
    { path: 'shop/:id', component: ProductDetailsComponent },   
    { path: 'cart', component: CartComponent },  
    { path: 'checkout', component: CheckoutComponent },   
    { path: 'server-error', component: ServerErrorComponent },
    { path: 'not-found', component: NotFoundComponent },
    { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];
