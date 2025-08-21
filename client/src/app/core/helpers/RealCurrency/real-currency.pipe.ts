import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'realCurrency',
  standalone: true
})
export class RealCurrencyPipe implements PipeTransform {
  transform(value: number | string): string {
    if (value === null || value === undefined) {
      return '';
    }

    const numericValue = typeof value === 'string' ? parseFloat(value) : value;

    if (isNaN(numericValue)) {
      return 'R$ 0,00';
    }

    const formattedValue = numericValue.toLocaleString('pt-BR', {
      style: 'currency',
      currency: 'BRL',
    });

    return formattedValue;
  }
}