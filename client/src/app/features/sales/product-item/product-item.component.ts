import { Component, inject, Input } from '@angular/core';
import { MatCard, MatCardActions, MatCardContent } from '@angular/material/card';
import { CurrencyPipe } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { CartService } from '../../../core/services/cart.service';
import { Produto } from '../../../shared/models/produto';
import { Produto_Imagem } from '../../../shared/models/produto_imagem';
import { Produto_Similar } from '../../../shared/models/produto_similar';
import { Produto_Detalhe } from '../../../shared/models/produto_detalhe';

@Component({
  selector: 'app-product-item',
  standalone: true,
  imports: [MatCard, MatCardContent, CurrencyPipe, MatCardActions, MatIcon, MatButton, RouterLink],
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss'
})
export class ProductItemComponent {

  @Input() produto? : Produto;
  @Input() produto_detalhe? : Produto_Detalhe[];
  @Input() produto_imagem? : Produto_Imagem[];
  @Input() produto_similar? : Produto_Similar[];

  cartSevice = inject(CartService);


}
