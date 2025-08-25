import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Product } from '../../shared/models/product';
import { Pagination } from '../../shared/models/pagination';
import { Fabricante } from '../../shared/models/fabricante';
import { SalesParams } from '../../shared/models/salesParams';
import { BuscaProduto } from '../../shared/models/buscaproduto';
import { FabricanteParams } from '../../shared/models/fabricanteParams';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  private http = inject(HttpClient);

  baseURL = 'https://localhost:7245/api/';


  getProducts(shopParams: SalesParams) {

    let params = new HttpParams();

    if (shopParams.id && shopParams.id?.length > 0) params = params.append('Id', shopParams.id.join(','));

    if (shopParams.idempresaparceira && shopParams.idempresaparceira?.length > 0) params = params.append('IdEmpresaParceira', shopParams.idempresaparceira.join(','));

    if (shopParams.idfabricantes && shopParams.idfabricantes?.length > 0) params = params.append('IdFabricante', shopParams.idfabricantes.join(','));

    if (shopParams.sort) params = params.append('sort', shopParams.sort);

    if (shopParams.pageSize) params = params.append('PageSize', shopParams.pageSize);
    if (shopParams.pageNumber) params = params.append('PageIndex', shopParams.pageNumber);


    if (shopParams.buscar) params = params.append('Buscar', shopParams.buscar);


    return this.http.get<Pagination<BuscaProduto>>(this.baseURL + 'BuscaProduto', { params });
  }


  getProduct(id: number) {
    return this.http.get<Product>(this.baseURL + 'Products/' + id);
  }


  getFabricantes(fabricanteParams: FabricanteParams) {
    let params = new HttpParams();

    if (fabricanteParams.id && fabricanteParams.id?.length > 0) params = params.append('Id', fabricanteParams.id.join(','));

    if (fabricanteParams.sort) params = params.append('sort', fabricanteParams.sort);

    if (fabricanteParams.pageSize) params = params.append('PageSize', fabricanteParams.pageSize);
    if (fabricanteParams.pageNumber) params = params.append('PageIndex', fabricanteParams.pageNumber);


    if (fabricanteParams.buscar) params = params.append('Buscar', fabricanteParams.buscar);

    return this.http.get<Pagination<Fabricante>>(this.baseURL + 'BuscaProduto/Fabricante', { params });
    
    
  }


}
