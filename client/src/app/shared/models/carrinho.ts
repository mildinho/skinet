import { nanoid } from 'nanoid';

export interface CarrinhoType {
    id: string;
    items: CarrinhoItem[];
}

export interface CarrinhoItem {
    productId: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string[];
 
}


export class Carrinho implements CarrinhoType {
    id = nanoid();
    items: CarrinhoItem[] = [];

   
}