import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';
import { Carrinho, CarrinhoItem } from '../../shared/models/carrinho';
import { Produto } from '../../shared/models/produto';
import { Produto_Detalhe } from '../../shared/models/produto_detalhe';
import { Produto_Imagem } from '../../shared/models/produto_imagem';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {
  baseUrl = environment.apiUrl

  private http = inject(HttpClient);

  cart = signal<Carrinho |null>(null);
  itemCount = computed(() => {
    return this.cart()?.items.reduce( (sum, item) => sum + item.quantity, 0);
  });

  totals = computed(() => {
    const cart = this.cart();

    if(!cart) return null;

    const subtotal = cart.items.reduce ( ( sum, item) => sum + item.price * item.quantity, 0);
    const shipping = 0;
    const discount = 0 ;

    return  {
      subtotal, 
      shipping, 
      discount,
      total : subtotal + shipping - discount
    }

});

  getCart(id : string) {
    return this.http.get<Carrinho>(this.baseUrl + 'Cart?id=' + id).pipe(
      map( cart => {
        this.cart.set(cart);
        return cart;
      })
    )
  }

  setCart(cart : Carrinho ) {
    return this.http.post<Carrinho>(this.baseUrl + 'Cart', cart).subscribe({
      next : cart => this.cart.set(cart)
    })
  }


  public addItemToCart(item : CarrinhoItem | Produto, imagem : Produto_Imagem[] | undefined , quantity = 1, ) {

    const cart = this.cart() ?? this.createCart();
    if (this.isProduct(item)) {
      item = this.mapProductToCartItem(item, imagem);
    }

    cart.items = this.addOrUpdateItem(cart.items, item, quantity);

  
    this.setCart( cart );
  }

  removeItemFromCart(productId : number, quantity = 1) {
    const cart = this.cart();

    if(!cart) return null;

    const index = cart.items.findIndex( x => x.productId === productId);
    if (index !== -1) {
      if ( cart.items[index].quantity > quantity ) {
        cart.items[index].quantity -= quantity;
      } else {
        cart.items.splice(index,1);
      }

      if( cart.items.length === 0 ) {
        this.deleteCart();
      } else {
        this.setCart( cart);
      }
    }

    return true;
  }


  deleteCart() {
    this.http.delete(this.baseUrl + 'cart?id=' + this.cart()?.id).subscribe({
      next : () =>  {
        localStorage.removeItem('cart_id');
        this.cart.set(null);
      }
    })
  }



  private addOrUpdateItem(items: CarrinhoItem[], item: CarrinhoItem, quantity: number): CarrinhoItem[] {
    const index = items.findIndex( x=> x.productId === item.productId);
    if ( index === -1) {
      item.quantity = quantity;
      items.push(item);

    } else {
      items[index].quantity += quantity;
    
    }

    return items;
  }


  private mapProductToCartItem(item: Produto, imagem : Produto_Imagem[] | undefined): CarrinhoItem {
    return {
      productId : item.id,
      productName : item.referencia,
      price : 0,
      quantity : 0 ,
      pictureUrl : imagem ? imagem.map(img => img.url) : []     
    }
  }

  private isProduct(item : CarrinhoItem | Produto) : item is Produto {
    return (item as Produto).id !== undefined;
  }



  private createCart(): Carrinho {
    const cart = new Carrinho();
    localStorage.setItem('cart_id', cart.id);

    return cart;
  }

  

}
