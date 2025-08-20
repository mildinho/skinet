import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../core/services/shop.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../shared/models/product';
import { CurrencyPipe } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatDivider } from '@angular/material/divider';
import { CartService } from '../../core/services/cart.service';
import { FormsModule } from '@angular/forms';
import { Produto } from '../../shared/models/produto';
import { SalesService } from '../../core/services/sales.service';
import { CarrinhoService } from '../../core/services/carinho.service';
import { BuscaProduto } from '../../shared/models/buscaproduto';
import { Pagination } from '../../shared/models/pagination';
import { SnackbarService } from '../../core/services/snackbar.service';
import { SalesParams } from '../../shared/models/salesParams';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CurrencyPipe, MatButton, MatIcon, MatFormField, MatInput, MatLabel, MatDivider,
    FormsModule
  ],
  templateUrl: './produto-detalhes.component.html',
  styleUrl: './produto-detalhes.component.scss'
})
export class ProdutoDetalhesComponent implements OnInit {

  private salesService = inject(SalesService);
  private activatedRoute = inject(ActivatedRoute);
  private cartService = inject(CarrinhoService);
  private snackBarService = inject(SnackbarService);
  

  //product?: Produto;
  shopParams = new SalesParams();
  product?      : Pagination<BuscaProduto>;
  quantityInCart = 0;
  quantity = 1;

  ngOnInit(): void {
    this.loadProduct();
  }


  // loadProduct() {
  //   const id = this.activatedRoute.snapshot.paramMap.get('id');
  //   if (!id) return;

  //   this.salesService.getProduct(+id).subscribe({
  //     next: (response) => {
  //       this.product = response,
  //       this.updateQuantityInCart();
  //     },
  //     error: (error) => console.log(error),
  //   });
  // }

    loadProduct(){
      const id = this.activatedRoute.snapshot.paramMap.get('id');
      if (!id) return;

      this.shopParams.id.push(id);
    this.salesService.getProducts(this.shopParams).subscribe({
      next: (response) => {
//        console.log(response);
        this.product = response
//       console.log(this.products.data);
        
      },
      error: (error) => {
        this.snackBarService.error(error.error);
      } 
      
    })
  }


  updateCart() {
    if (!this.product) return;

    if( this.quantity > this.quantityInCart) 
    {
      const itemsToAdd = this.quantity - this.quantityInCart;
      this.quantityInCart += itemsToAdd;
      
      this.cartService.addItemToCart(this.product.data[0],this.product.data[0].imagens ,itemsToAdd);

    } else {
      const itemsToRemove = this.quantityInCart - this.quantity;
      this.quantityInCart -= itemsToRemove;

      this.cartService.removeItemFromCart(this.product.data[0].id, itemsToRemove);
    }

  }


  updateQuantityInCart() {
    this.quantityInCart = this.cartService.cart()?.items
      .find(x => x.productId === this.product?.data[0].id)?.quantity || 0;

    this.quantity = this.quantityInCart || 1;

  }

  getButtonText() {
    return this.quantityInCart > 0 ? 'Atualizar': 'Adicionar'
  }


}
