import { Component, inject, Input } from '@angular/core';
import { MatCard, MatCardActions, MatCardContent } from '@angular/material/card';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { Produto } from '../../../shared/models/produto';
import { Produto_Imagem } from '../../../shared/models/produto_imagem';
import { Produto_Similar } from '../../../shared/models/produto_similar';
import { Produto_Detalhe } from '../../../shared/models/produto_detalhe';
import { CarrinhoService } from '../../../core/services/carinho.service';
import { RealCurrencyPipe } from '../../../core/helpers/RealCurrency/real-currency.pipe';

@Component({
  selector: 'app-product-item',
  standalone: true,
  imports: [MatCard, MatCardContent, MatCardActions, MatIcon, MatButton, RouterLink, RealCurrencyPipe],
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss'
})
export class ProductItemComponent {

  @Input() produto? : Produto;
  @Input() produto_detalhe? : Produto_Detalhe[];
  @Input() produto_imagem? : Produto_Imagem[];
  @Input() produto_similar? : Produto_Similar[];

  cartSevice = inject(CarrinhoService);

   ngOnInit(): void {
//     console.log('Detalhes do produto:', this.produto_detalhe);
//     console.log('Imagens', this.produto_imagem);
  }

}
