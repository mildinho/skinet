import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Product } from '../../shared/models/product';
import { Pagination } from '../../shared/models/pagination';
import { ShopParams } from '../../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private http = inject(HttpClient);

  baseURL = 'https://localhost:7245/api/';
  types: string[] = [];
  brands: string[] = [];
  
  


  getProducts(shopParams: ShopParams){

    let params = new HttpParams();

    if(shopParams.brands && shopParams.brands?.length > 0) params = params.append('brands', shopParams.brands.join(','));
    if(shopParams.types && shopParams.types?.length > 0) params = params.append('types', shopParams.types.join(','));

    if(shopParams.sort) params = params.append('sort', shopParams.sort);

    if(shopParams.pageSize) params = params.append('PageSize', shopParams.pageSize);
    if(shopParams.pageNumber) params = params.append('PageIndex', shopParams.pageNumber);


    if(shopParams.search) params = params.append('search', shopParams.search);


    return this.http.get<Pagination<Product>>(this.baseURL + 'Products', {params});
  }



  getBrandes(){
    if(this.brands.length > 0) return;

    return this.http.get<string[]>(this.baseURL + 'Products/brands').subscribe({
      next: (response) => {
        this.brands = response;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }


  getTypes(){
    if(this.types.length > 0) return;

    return this.http.get<string[]>(this.baseURL + 'Products/types').subscribe({
      next: (response) => {
        this.types = response;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
  
  
}
